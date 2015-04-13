using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Web.Security;

namespace AIronMan.Api.Infrastructure
{
    public static class FormsAuthenticationTicketExtensions
    {
        public static NameValueCollection GetStructuredUserData(this FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            return string.IsNullOrEmpty(ticket.UserData)
                ? null
                : HttpUtility.ParseQueryString(ticket.UserData);
        }
    }
}