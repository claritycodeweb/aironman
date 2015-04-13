using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Collections.Specialized;
using System.Web.Routing;

using AIronMan.Domain;

namespace AIronMan.Api.Infrastructure
{
    public class TicketHandler
    {

        private string userId = "";
        private string userName = "";
        private string userEmail = "";

        private User user;

        public User User
        {
            get { return user; }
        }

        public TicketHandler()
        {
            try
            {
                if (!String.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                {
                    NameValueCollection ticketData = ((System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity)
                                                        .Ticket.GetStructuredUserData();
                    userId = ticketData["UserId"];
                    userName = ticketData["UserName"];
                    userEmail = ticketData["UserEmail"];

                    user = new User()
                    {
                        Id = int.Parse(userId),
                        Email = userName
                    };
                }
                else
                {
                    userId = "";
                    userName = "";
                    userEmail = "";
                    user = null;
                }

                if (String.IsNullOrEmpty(userId))
                {
                    //FormsAuthentication.SignOut();
                }
            }
            catch
            {
                //FormsAuthentication.SignOut();
            }
        }

        public void SetTicket(string userCode, NameValueCollection ticketData)
        {
            new FormsAuthentication().SetAuthCookie(userCode, false, ticketData);
        }

        public string UserName
        {
            get
            {
                return userName;
            }
        }

        public string UserId
        {
            get
            {
                return userId;
            }
        }

        public string UserEmail
        {
            get
            {
                return userEmail;
            }
        }
    }
}