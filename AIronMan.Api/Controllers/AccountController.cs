using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI.WebControls;

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

                if (loginStaus == ErrorCode.AccountServiceStatus.Success)
                {
                    return Ok(new { Success = true, Content = "Udalo sie", Token = Utility.Token.CreateToken(user.UserName, user.Id) });
                }
                ModelState.AddModelError("", ErrorCodeString.AccountServiceStatusString(loginStaus));

                //var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                //{
                //    Content = new StringContent("Not found not found"),
                //    ReasonPhrase = "Product ID Not Found"
                //};

                //return new HttpActionResult(HttpStatusCode.BadRequest, "User Name or Password is incorrect", Request);

                //throw new HttpResponseException(resp);
                //return Json(new { success = false, message = "User code or password is incorrect" });
                //return Ok(new { success = false, message = "User code or password is incorrect" });
            }

            return new HttpActionResult(HttpStatusCode.BadRequest, "User Name or Password is incorrect", Request);
        }

        //[AuthToken]
        [HttpGet]
        public IHttpActionResult WarmUp()
        {
            userServices.GetUser();
            return this.Ok(new { sucess = true });
        }
    }
}
