using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using AIronMan.DataSource;
using AIronMan.Logging;
using AIronMan.Services.Providers;

namespace AIronMan.Services
{
    public class SiteService : ServiceBase, ISiteService
    {

        public SiteService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        { }


        public Guid GetCurrentSiteId()
        {
            return Context.SiteRepository.GetCurrentSiteIdFromWebConfig();
        }

        public Domain.Site GetCurrentSite()
        {
            var site = Cache.Get("site") as Domain.Site;
            if (site == null)
            {
                Guid id = GetCurrentSiteId();
                site = Get().First(m => m.Id == id);

                Cache.Set("site", site, 30);
            }
            return site;
        }

        public IQueryable<Domain.Site> Get()
        {
            return Context.SiteRepository.All().OrderByDescending(m => m.LmDate);
        }

        public Domain.Site Create(string name, string url, string folderPath, String themeLocalization, bool isActive, ref ErrorCode.SiteServiceStatus status)
        {
            Domain.User crUser = User;
            url = url.TrimEnd('/');
            var sites = Context.SiteRepository.Filter(x => x.Url.Replace("http://wwww.", "").Replace("http://", "") == url.Replace("http://wwww.", "").Replace("http://", ""));

            if (sites.Any())
            {
                status = ErrorCode.SiteServiceStatus.UrlAlreadyDefine;
                return null;
            }

            Domain.Site entity = new Domain.Site
            {
                Name = name,
                Url = url,
                FolderPath = folderPath,
                ThemeLocalization = themeLocalization,
                IsActive = isActive,
                CrDate = DateTime.Now,
                LmDate = DateTime.Now,
                LmUser = crUser,
                CrUser = crUser,
                Id = Guid.NewGuid()
            };

            entity = Context.SiteRepository.Create(entity);
            Context.Save();

            Domain.Page pentity = new Domain.Page
            {
                Name = "Home",
                MenuTitle = "Dashboard",
                Url = "home",
                Active = true,
                MainMenu = true,
                SiteId = entity.Id,
                SortOrder = 1,
                PageLayout = "_Layout",
                CrDate = DateTime.Now,
                LmDate = DateTime.Now,
                CrUser = crUser,
                LmUser = crUser
            };

            Context.PageRepository.Create(pentity);

            Context.Save();
            return entity;
        }

        public Domain.Site Update(Domain.Site entity, ref ErrorCode.SiteServiceStatus status)
        {
            Domain.User lmUser = User;
            Domain.Site entityFromDb = Context.SiteRepository.Find(entity.Id);
            entityFromDb.Name = entity.Name;
            entityFromDb.Url = entity.Url.TrimEnd('/');
            entityFromDb.FolderPath = entity.FolderPath;
            entityFromDb.ThemeLocalization = entity.ThemeLocalization;
            entityFromDb.IsActive = entity.IsActive;
            entityFromDb.LmDate = DateTime.Now;
            entityFromDb.LmUser = lmUser;

            Context.SiteRepository.Update(entityFromDb);
            Context.Save();

            return entity;
        }

        public int Delete(Guid id, ref ErrorCode.SiteServiceStatus status)
        {
            Context.SiteRepository.Delete(m => m.Id == id);
            Context.Save();

            return 1;
        }
    }
}
