using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.DataSource;
using AIronMan.Domain;
using AIronMan.Logging;
using AIronMan.Services.Providers;
using AIronMan.Utility;
using System.Linq.Expressions;
//using System.Data.Entity;
using System.Security.Cryptography;

namespace AIronMan.Services
{
    public class UserService : ServiceBase, IUserService
    {

        private readonly int _minRequiredPasswordLength;
        private readonly int _minRequiredNonalphanumericCharacters;

        public int MinRequiredPasswordLength
        {
            get
            {
                return _minRequiredPasswordLength;
            }
        }
        public int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                return _minRequiredNonalphanumericCharacters;
            }
        }

        public UserService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        {
            _minRequiredPasswordLength = 6;
            _minRequiredNonalphanumericCharacters = 0;
        }

        public IQueryable<User> GetUser()
        {
            return Context.UserRepository.All();
        }

        public User CreateUser(string userName, string email, string password, bool isApproved, ref ErrorCode.UserServiceStatus status)
        {
            #region Model Validation

            if (!AppUtil.ValidateParameter(ref password, true, true, false, 128))
            {
                status = ErrorCode.UserServiceStatus.InvalidPassword;
                return null;
            }

            if (!AppUtil.ValidateParameter(ref userName, true, true, true, 16))
            {
                status = ErrorCode.UserServiceStatus.InvalidUserName;
                return null;
            }

            if (!AppUtil.ValidateParameter(ref email, true, true, true, 128))
            {
                status = ErrorCode.UserServiceStatus.InvalidEmail;
                return null;
            }

            int count = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password, i))
                {
                    count++;
                }
            }

            if (count < MinRequiredNonAlphanumericCharacters)
            {
                status = ErrorCode.UserServiceStatus.InvalidPassword;
                return null;
            }

            #endregion

            if (Context.UserRepository.Contains(m => m.UserName == userName))
            {
                status = ErrorCode.UserServiceStatus.DuplicateUserName;
                return null;
            }

            if (Context.UserRepository.Contains(m => m.Email == email))
            {
                status = ErrorCode.UserServiceStatus.DuplicateEmail;
                return null;
            }

            string salt = GenerateSalt();
            string encodePassword = EncodePassword(password, salt);

            User user = new User
            {
                UserName = userName,
                Email = email,
                PasswordSalt = salt,
                Password = encodePassword,
                IsApproved = isApproved,
                CrDate = DateTime.Now,
                LmDate = DateTime.Now,
                LastLoginDate = new DateTime(1870, 1, 1),
                LastPasswordChangeDate = new DateTime(1870, 1, 1)
            };

            Context.UserRepository.Create(user);
            Context.Save();

            return user;
        }

        private string GenerateSalt()
        {
            byte[] buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        private string EncodePassword(string pass, string salt)
        {
            byte[] bIn = Encoding.Unicode.GetBytes(pass);
            byte[] bSalt = Convert.FromBase64String(salt);
            byte[] bAll = new byte[bSalt.Length + bIn.Length];
            byte[] bRet = null;

            Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length);
            Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length);

            HashAlgorithm s = HashAlgorithm.Create("SHA256");
            bRet = s.ComputeHash(bAll);


            return Convert.ToBase64String(bRet);
        }

        public User ValidateUser(string userNameOrEmail, string password, bool isSystemLogin, ref ErrorCode.AccountServiceStatus status)
        {
            string encodedPassword = "";
            #region Model Validation

            if (string.IsNullOrEmpty(userNameOrEmail) || string.IsNullOrEmpty(password))
            {
                status = ErrorCode.AccountServiceStatus.InputNameAndPassPlease;
                return null;
            }

            #endregion

            User userDb = Context.UserRepository.Find(m =>
                String.Equals(m.UserName, userNameOrEmail) ||
                m.Email == userNameOrEmail.ToLower());

            if (userDb == null)
            {
                status = ErrorCode.AccountServiceStatus.InvalidUserNameOrEmail;
                return null;
            }

            encodedPassword = EncodePassword(password, userDb.PasswordSalt);

            bool isPasswordCorrect = encodedPassword.Equals(userDb.Password);

            if (isPasswordCorrect)
            {
                status = ErrorCode.AccountServiceStatus.Success;
                return userDb;
            }
            status = ErrorCode.AccountServiceStatus.InvalidPassword;
            return null;
        }

        public IEnumerable<User> GetAllActiveCacheUsers()
        {
            var users = Cache.Get("ActiveUser") as IEnumerable<User>;

            // If it's not in the cache, we need to read it from the repository
            if (users == null)
            {
                // Get the repository data
                users = Context.UserRepository.Filter(m=>m.IsApproved && m.IsLockedOut == false).ToList();

                if (users.Any())
                {
                    // Put this data into the cache for 30 minutes
                    Cache.Set("ActiveUser", users, 1440);
                }
            }

            return users;
        }
    }
}
