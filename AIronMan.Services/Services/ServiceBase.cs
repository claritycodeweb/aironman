using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

        protected ServiceBase(UnitOfWork context, ICacheProvider cache, ILogger logger)
        {
            Context = context;
            Cache = cache;
            Logger = logger;
        }


        #region Calling User Info

        protected string UserName
        {
            get
            {
                HttpCookie cookie;
                cookie = HttpContext.Current.Request.Cookies.Get("username1");
                if (cookie != null)
                {
                    return cookie.Value;
                }
                return "";
            }
        }

        protected int UserId
        {
            get
            {
                HttpCookie cookie;
                cookie = HttpContext.Current.Request.Cookies.Get("userid1");
                if (cookie != null)
                {
                    return int.Parse(cookie.Value);
                }
                return 0;
            }
        }

        protected string Email
        {
            get
            {
                HttpCookie cookie;
                cookie = HttpContext.Current.Request.Cookies.Get("email1");
                if (cookie != null)
                {
                    return cookie.Value;
                }
                return "";
            }
        }

        protected User User
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies.Get("usersessionobject1");
                return cookie != null ? (User)new JavaScriptSerializer().Deserialize(cookie.Value, typeof(Domain.User)) : null;
            }
        }

        #endregion


        protected Guid SiteId
        {
            get
            {
                var siteId =  Context.SiteRepository.GetCurrentSiteIdFromWebConfig();
                if (siteId == Guid.Empty)
                {
                    Logger.Error("Empty siteid");
                }
                return siteId;
            }
        }
    }
}
