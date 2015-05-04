using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using AIronMan.Api.Common.Result;
using AIronMan.Services;

using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;

namespace AIronMan.Api.Filters
{
    public class AuthToken : ActionFilterAttribute
    {
        [Dependency]
        public IUserService userService { get; set; }

        public AuthToken()
        {
            this.userService = (IUserService)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IUserService));
        }

        public bool ValidateToken(string token)
        {
            var formAuthentication = Utility.Token.DecryptToken(token);

            if (formAuthentication != null)
            {
                var users = userService.GetAllActiveCacheUsers();

                if (users.FirstOrDefault(m => m.UserName.ToLower() == formAuthentication.Name.ToLower()) != null)
                {
                    return true;
                }
            }

            return false;
        }

        public override void OnActionExecuting(HttpActionContext context)
        {
            var header = context.Request.Headers.SingleOrDefault(x => x.Key == "Authorization");

            var valid = header.Value != null;
            if (!valid)
            {
                context.Response = new HttpResponseMessage
                {
                    Content = new StringContent("Invalid Authorization Key, you need to login first."),
                    StatusCode = HttpStatusCode.Unauthorized,
                    RequestMessage = context.Request,
                };
            }
            else
            {
                if (!this.ValidateToken(header.Value.SingleOrDefault()))
                {
                    context.Response = new HttpResponseMessage
                    {
                        Content = new StringContent("UserName provided is not authorized"),
                        StatusCode = HttpStatusCode.Unauthorized,
                        RequestMessage = context.Request,
                    };
                }
            }
        }
    }
}