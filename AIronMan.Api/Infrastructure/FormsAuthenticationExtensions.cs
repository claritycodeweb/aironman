using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Collections.Specialized;

namespace AIronMan.Api.Infrastructure
{
    public static class FormsAuthenticationExtensions
    {

        public static void SetAuthCookie(this FormsAuthentication formsAuthentication, string userName, bool createPersistentCookie, NameValueCollection userData, DateTime? expiresOn = null)
        {
            var response = new HttpResponseWrapper(HttpContext.Current.Response);
            SetAuthCookie(formsAuthentication, response, userName, createPersistentCookie, userData, expiresOn);
        }

        public static void SetAuthCookie(this FormsAuthentication formsAuthentication, HttpResponseBase response, string userName, bool createPersistentCookie, NameValueCollection userData, DateTime? expiresOn = null)
        {
            var encodedUserData = EncodeAsQueryString(userData);
            SetAuthCookie(formsAuthentication, response, userName, createPersistentCookie, encodedUserData, expiresOn);
        }

        public static void SetAuthCookie(this FormsAuthentication formsAuthentication, string userName, bool createPersistentCookie, string userData, DateTime? expiresOn = null)
        {
            var response = new HttpResponseWrapper(HttpContext.Current.Response);
            SetAuthCookie(formsAuthentication, response, userName, createPersistentCookie, userData, expiresOn);
        }

        public static void SetAuthCookie(this FormsAuthentication formsAuthentication, HttpResponseBase response, string userName, bool createPersistentCookie, string userData, DateTime? expiresOn = null)
        {
            var cookie = FormsAuthentication.GetAuthCookie(userName, createPersistentCookie);
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(
                ticket.Version,
                ticket.Name,
                ticket.IssueDate,
                expiresOn ?? ticket.Expiration,
                createPersistentCookie,
                userData,
                ticket.CookiePath);
            cookie.Value = FormsAuthentication.Encrypt(newTicket);
            if (newTicket.IsPersistent)
                cookie.Expires = newTicket.Expiration;
            response.Cookies.Set(cookie);
        }

        static string EncodeAsQueryString(NameValueCollection userData)
        {
            var targetCollection = HttpUtility.ParseQueryString(string.Empty);
            targetCollection.Add(userData);
            return targetCollection.ToString();
        }
    }
}