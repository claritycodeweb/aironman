using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace AIronMan.Api.Infrastructure
{
    public class Token
    {
        public static string CreateToken(Domain.User user)
        {
            FormsAuthenticationTicket formsTicket = new FormsAuthenticationTicket(
                1,
                user.UserName,
                DateTime.Now,
                DateTime.Now.AddMinutes(360),
                true,
                string.Join(",", user.UserName + "," + user.Id)
                );

            string encryptedTicket = FormsAuthentication.Encrypt(formsTicket);

            return encryptedTicket;
        }

        public static FormsAuthenticationTicket DecryptToken(string token)
        {
            return FormsAuthentication.Decrypt(token);
        }
    }
}