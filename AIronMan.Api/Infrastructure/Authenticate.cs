using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

using AIronMan.Domain;

namespace AIronMan.Api.Infrastructure
{
    public class Authenticate
    {
        public void SignIn(User user)
        {
            SetAuthenticationCookie(user);
        }

        public void SignOut()
        {
            InvalidateAuthenticationCookie();
        }

        public void SetAuthenticationCookie(User user)
        {
            var newCookie = new HttpCookie[4];

            newCookie[0] = new HttpCookie("username1", user.UserName)
            {
                Expires = DateTime.Today.AddDays(2)
            };
            newCookie[1] = new HttpCookie("userid1", user.Id.ToString(CultureInfo.InvariantCulture))
            {
                Expires = DateTime.Today.AddDays(2)
            };
            newCookie[2] = new HttpCookie("email1", user.Email)
            {
                Expires = DateTime.Today.AddDays(2)
            };
            newCookie[3] = new HttpCookie("usersessionobject1", new JavaScriptSerializer().Serialize(user))
            {
                Expires = DateTime.Today.AddDays(2)
            };

            foreach (HttpCookie t in newCookie)
            {
                HttpContext.Current.Response.Cookies.Add(t);
            }
        }

        public bool IsAuthenticate()
        {
            HttpCookie existingCookieId = HttpContext.Current.Request.Cookies.Get("userid1");
            HttpCookie existingUserObject = HttpContext.Current.Request.Cookies.Get("usersessionobject1");
            HttpCookie existingCookieUserName = HttpContext.Current.Request.Cookies.Get("username1");
            HttpCookie existingCookieEmail = HttpContext.Current.Request.Cookies.Get("email1");

            if (existingCookieId == null || existingUserObject == null || existingCookieUserName == null || existingCookieEmail == null)
            {
                return false;
            }

            existingCookieId.Expires = DateTime.Today.AddDays(2);
            HttpContext.Current.Response.Cookies.Add(existingCookieId);

            existingCookieUserName.Expires = DateTime.Today.AddDays(2);
            HttpContext.Current.Response.Cookies.Add(existingCookieUserName);

            existingCookieEmail.Expires = DateTime.Today.AddDays(2);
            HttpContext.Current.Response.Cookies.Add(existingCookieEmail);

            existingUserObject.Expires = DateTime.Today.AddDays(2);
            HttpContext.Current.Response.Cookies.Add(existingUserObject);

            return true;
        }


        public void InvalidateAuthenticationCookie()
        {
            var cookie = HttpContext.Current.Request.Cookies.Get("username1");
            if (cookie != null)
            {
                cookie = new HttpCookie("username1") { Expires = DateTime.Now.AddDays(-1) };
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            cookie = HttpContext.Current.Request.Cookies.Get("userid1");
            if (cookie != null)
            {
                cookie = new HttpCookie("userid1") { Expires = DateTime.Now.AddDays(-1) };
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            cookie = HttpContext.Current.Request.Cookies.Get("email1");
            if (cookie != null)
            {
                cookie = new HttpCookie("email1") { Expires = DateTime.Now.AddDays(-1) };
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

            cookie = HttpContext.Current.Request.Cookies.Get("usersessionobject1");
            if (cookie != null)
            {
                cookie = new HttpCookie("usersessionobject1") { Expires = DateTime.Now.AddDays(-1) };
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public string UserName
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies.Get("username1");
                return cookie != null ? cookie.Value : "";
            }
        }
        public string UserId
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies.Get("userid1");
                return cookie != null ? cookie.Value : "";
            }
        }
        public string Email
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies.Get("email1");
                return cookie != null ? cookie.Value : "";
            }
        }

        public User User
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies.Get("usersessionobject1");
                return cookie != null ? (User)new JavaScriptSerializer().Deserialize(cookie.Value, typeof(User)) : null;
            }
        }
    }
}