using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.Domain;

namespace AIronMan.Services {
    public interface IUserService {
        IQueryable<User> GetUser();
        User CreateUser(string userName, string email, string password, bool isApproved, ref ErrorCode.UserServiceStatus status);
        User ValidateUser(string userNameOrEmail, string password,  bool isSystemLogin, ref ErrorCode.AccountServiceStatus status);
    }
}
