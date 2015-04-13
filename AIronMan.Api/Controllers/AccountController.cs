using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

using AIronMan.Api.Infrastructure;
using AIronMan.Api.Models;

using AIronMan.Api.Models;
using AIronMan.Logging;
using AIronMan.Services;
using AIronMan.Domain;

namespace AIronMan.Api.Controllers
{
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

        public IHttpActionResult Authenticate(LogOnModel viewModel)
        {

            if (ModelState.IsValid)
            {
                ErrorCode.AccountServiceStatus loginStaus = ErrorCode.AccountServiceStatus.Success;

                User user = userServices.ValidateUser(viewModel.UserName, viewModel.Password, true, ref loginStaus);

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
                    return Ok(new { success = true });
                }
                ModelState.AddModelError("", ErrorCodeString.AccountServiceStatusString(loginStaus));
                return Ok(new { success = false, message = "User code or password is incorrect" });
            }

            /* REPLACE THIS WITH REAL AUTHENTICATION
            ----------------------------------------------*/
            if (!(viewModel.UserName == "test" && viewModel.Password == "test"))
            {
                return Ok(new { success = false, message = "User code or password is incorrect" });
            }

            return Ok(new { success = true });
        }

        public IHttpActionResult GetStart()
        {
            return this.Ok(new { sucess = true });
        }
    }
}
