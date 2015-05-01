using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Threading.Tasks;

using AIronMan.Api.Common.Result;
using AIronMan.Api.Filters;
using AIronMan.Api.Infrastructure;
using AIronMan.Api.Models;

using AIronMan.Api.Models;
using AIronMan.Logging;
using AIronMan.Services;
using AIronMan.Domain;

namespace AIronMan.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly IUserService userServices;
        private readonly ISettingService settingService;
        private readonly ILogger logger;
        private readonly IPageService pageService;

        public AccountController(ISettingService settingSrv, IUserService userSrv, ILogger logger, IPageService pageService)
        {
            this.settingService = settingSrv;
            this.userServices = userSrv;
            this.logger = logger;
            this.pageService = pageService;
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LogOnModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ErrorCode.AccountServiceStatus loginStaus = ErrorCode.AccountServiceStatus.Success;

                User user = userServices.ValidateUser(viewModel.UserName, viewModel.Password, true, ref loginStaus);

                var isAuth = new Authenticate().IsAuthenticate();

                if (loginStaus == ErrorCode.AccountServiceStatus.Success)
                {
                    new Authenticate().SignIn(user);
                    //FormsAuthentication.SetAuthCookie(user.Email, true);
                    var ticket = new TicketHandler();
                    ticket.SetTicket(user.UserName, new NameValueCollection {
                        { "UserId", user.Id.ToString() },
                        { "UserName", user.UserName },
                        { "UserEmail", user.Email }
                    });
                    return Ok(new { Success = true, Content = "Udalo sie", Token = Guid.NewGuid().ToString() });
                }
                ModelState.AddModelError("", ErrorCodeString.AccountServiceStatusString(loginStaus));

                //var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                //{
                //    Content = new StringContent("Not found not found"),
                //    ReasonPhrase = "Product ID Not Found"
                //};

                return new HttpActionResult(HttpStatusCode.BadRequest, "User Name or Password is incorrect", Request);

                //throw new HttpResponseException(resp);
                //return Json(new { success = false, message = "User code or password is incorrect" });
                //return Ok(new { success = false, message = "User code or password is incorrect" });
            }

            return Ok(new { success = true, message = "ok" });
        }

        [AuthToken]
        public IHttpActionResult GetStart()
        {
            return this.Ok(new { sucess = true });
        }
    }
}
