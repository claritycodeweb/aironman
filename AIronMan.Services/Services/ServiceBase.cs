using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

using AIronMan.DataSource;
using AIronMan.Domain;
using AIronMan.Logging;
using AIronMan.Services.Providers;
using System.Web.Script.Serialization;

namespace AIronMan.Services
{
    public abstract class ServiceBase
    {
        protected UnitOfWork Context;
        protected ILogger Logger;
        protected ICacheProvider Cache;
        protected readonly string Token;
        protected readonly FormsAuthenticationTicket TokenTicket;

        protected ServiceBase(UnitOfWork context, ICacheProvider cache, ILogger logger)
        {
            Context = context;
            Cache = cache;
            Logger = logger;

            Token = HttpContext.Current.Request.Headers.Get("Authorization");
            TokenTicket = Utility.Token.DecryptToken(Token);
        }


        #region Calling User Info

        protected string UserName
        {
            get
            {
                if (!String.IsNullOrEmpty(Token))
                {
                    return this.TokenTicket.Name;
                }
                return "";
            }
        }

        protected int UserId
        {
            get
            {
                if (!String.IsNullOrEmpty(Token))
                {
                    return int.Parse(this.TokenTicket.UserData.Split(',')[1]);
                }
                return 0;
            }
        }

        protected string Email
        {
            get
            {
                return "";
            }
        }

        protected User User
        {
            get
            {
                User user = new User();
                user.Id = this.UserId;
                user.UserName = this.UserName;

                return user;
            }
        }

        #endregion


        protected Guid SiteId
        {
            get
            {
                var siteId = Context.SiteRepository.GetCurrentSiteIdFromWebConfig();
                if (siteId == Guid.Empty)
                {
                    Logger.Error("Empty siteid");
                }
                return siteId;
            }
        }
    }
}
