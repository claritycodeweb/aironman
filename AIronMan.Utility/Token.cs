﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace AIronMan.Utility 
{
    public class Token
    {
        public static string CreateToken(string userName, int userId)
        {
            FormsAuthenticationTicket formsTicket = new FormsAuthenticationTicket(
                1,
                userName,
                DateTime.Now,
                DateTime.Now.AddMinutes(12*60),
                true,
                string.Join(",", userName + "," + userId)
                );

            string encryptedTicket = FormsAuthentication.Encrypt(formsTicket);

            return encryptedTicket;
        }

        public static FormsAuthenticationTicket DecryptToken(string token)
        {
            try
            {
                if (token != null)
                {
                    return FormsAuthentication.Decrypt(token);
                }
            }
            catch (ArgumentException e)
            {
                return null;
            }

            return null;
        }
    }
}