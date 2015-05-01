using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using AIronMan.Api.Common.Result;

namespace AIronMan.Api.Filters
{
    public class AuthToken : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            var header = context.Request.Headers.SingleOrDefault(x => x.Key == "Authorization");

            var valid = header.Value != null;
            if (!valid)
            {
                context.Response = new HttpResponseMessage
                {
                    Content = new StringContent("Invalid Authorization Key, you need to login first."),
                    StatusCode = HttpStatusCode.Forbidden,
                    RequestMessage = context.Request,
                };
            }
        }
    }
}