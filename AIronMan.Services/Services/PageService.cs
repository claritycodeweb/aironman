using AIronMan.Repository;
using AIronMan.Domain;
using AIronMan.Logging;
using AIronMan.Services.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AIronMan.Services
{
    public class PageService : ServiceBase, IPageService
    {

        public PageService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        { }

        public IQueryable<Page> GetAll()
        {
            Guid siteId = Context.SiteRepository.GetCurrentSiteIdFromWebConfig();
            IQueryable<Page> pages = Context.PageRepository
                .Filter(m => m.SiteId == siteId).OrderBy(x => x.SortOrder);
            //var sortedlist = pages.OrderBy(x => x.SortOrder);
            //var sortedlist = pages.OrderBy(x => x.PageParentId == null ? x.Id : x.PageParentId).ThenBy(x => x.Id);
            //Sort((x, y) => x.SortOrder.CompareTo(y.SortOrder));

            return pages;
        }

        public Page CreatePage(Page entity, ref ErrorCode.PageServiceStatus status)
        {
            Guid siteId = SiteId;

            if (Context.PageRepository.Contains(x => x.Name.ToLower() == entity.Name.ToLower() && x.SiteId == siteId))
            {
                status = ErrorCode.PageServiceStatus.NameAlreadyExists;
                return entity;
            }

            if (Context.PageRepository.Contains(x => x.Url.ToLower() == entity.Url.ToLower() && x.SiteId == siteId))
            {
                status = ErrorCode.PageServiceStatus.UrlAlreadyExists;
                return entity;
            }

            var layoutCheck = Context.LayoutRepository
                .Filter(m =>
                    m.Name == entity.PageLayout)
                .Select(m => new
                {
                    m.IsSlider,
                    m.IsPotfolio,
                    m.IsBlog,
                    m.IsGallery
                })
                .FirstOrDefault();

            if (layoutCheck.IsSlider && entity.SliderHeaderId == null)
            {
                status = ErrorCode.PageServiceStatus.SliderIdIsRequiredForSelectedLayout;
                return entity;
            }
            else if (!layoutCheck.IsSlider)
            {
                entity.SliderHeaderId = null;
            }

            if (layoutCheck.IsPotfolio && entity.PortfolioHeaderId == null)
            {
                status = ErrorCode.PageServiceStatus.PortfolioIdIsRequiredForSelectedLayout;
                return entity;
            }
            else if (!layoutCheck.IsPotfolio)
            {
                entity.PortfolioHeaderId = null;
            }

            if (layoutCheck.IsBlog && entity.BlogId == null)
            {
                status = ErrorCode.PageServiceStatus.BlogIdIsRequiredForSelectedLayout;
                return entity;
            }
            else if (!layoutCheck.IsBlog)
            {
                entity.BlogId = null;
            }

            int lastOrder = 0;
            if (Context.PageRepository.All().Any(m => m.SiteId == siteId))
            {
                lastOrder = entity.PageParentId == null ?
                   Context.PageRepository.All().Where(m => m.SiteId == siteId).Select(m => m.SortOrder).Max() :
                   Context.PageRepository.All().Where(m => m.SiteId == siteId && (m.Id == entity.PageParentId || m.PageParentId == entity.PageParentId)).Select(m => m.SortOrder).Max();
            }

            entity.SortOrder = lastOrder + 1;
            entity.Url = entity.Url.TrimEnd('/').TrimStart('/').Replace(' ', '-').ToLower();

            while (entity.Url.Contains("//"))
            {
                entity.Url = entity.Url.Replace("//", "/");
            }

            User crUser = User;
            entity.CrUser = crUser;
            entity.LmUser = crUser;
            entity.CrDate = DateTime.Now;
            entity.LmDate = DateTime.Now;
            entity.SiteId = siteId;
            Context.PageRepository
                .Filter(m =>
                    m.SortOrder > lastOrder &&
                    m.SiteId == siteId)
                .ToList()
                .ForEach(m => m.SortOrder += 1);

            Page newPage = Context.PageRepository.Create(entity);
            Context.Save();

            return newPage;
        }

        public int DeletePage(int pageId, ref ErrorCode.PageServiceStatus status)
        {
            Page toDelete = Context.PageRepository.Find(pageId);

            int rtn = Context.PageRepository.Delete(toDelete);

            Context.PageRepository
                .Filter(m =>
                    m.SortOrder > toDelete.SortOrder)
                .ToList()
                .ForEach(m =>
                    m.SortOrder = m.SortOrder - 1);

            Context.Save();

            return rtn;
        }

        public void ChangeOrder(int pageId, DownUp downOrUp, ref ErrorCode.PageServiceStatus status)
        {
            Page page = Context.PageRepository.Find(pageId);
            Guid siteId = SiteId;
            if (downOrUp == DownUp.Down && Context.PageRepository.Filter(x => x.PageParentId == null && x.SiteId == siteId).Select(x => x.SortOrder).Max() > page.SortOrder)
            {
                //szukamy elementu zanajdującego się poniżej i podnosimy go
                int sort1 = Context.PageRepository
                    .Filter(m =>
                        m.SortOrder > page.SortOrder &&
                        m.PageParentId == null &&
                        m.SiteId == siteId)
                    .Select(m => m.SortOrder)
                    .Min();

                page = Context.PageRepository
                    .Filter(x =>
                        x.SortOrder == sort1 && x.SiteId == siteId)
                    .Single();

                downOrUp = DownUp.Up;
            }

            if (downOrUp == DownUp.Up && page.SortOrder > 1)
            {
                if (page.PageParentId == null)
                {

                    int sortOrderBefore = Context.PageRepository
                        .Filter(m =>
                            m.SortOrder < page.SortOrder &&
                            m.PageParentId == null &&
                            m.SiteId == siteId)
                        .Select(m => m.SortOrder)
                        .Max();

                    int sortOrderDown = Context.PageRepository
                        .Filter(x =>
                            x.SiteId == siteId &&
                            (x.Id == page.Id || x.PageParentId == page.Id))
                        .Select(x => x.SortOrder)
                        .Min();

                    int pageBeforeId = Context.PageRepository
                        .Filter(x =>
                            x.SortOrder == sortOrderBefore &&
                            x.SiteId == siteId)
                        .Single()
                        .Id;

                    var pageFromFrontToDown = Context.PageRepository
                        .Filter(x =>
                            x.SiteId == siteId &&
                            (x.Id == pageBeforeId || x.PageParentId == pageBeforeId))
                        .AsEnumerable();

                    var pageFromDownToUp = Context.PageRepository
                        .Filter(x =>
                            x.SiteId == siteId
                            && (x.Id == page.Id || x.PageParentId == page.Id))
                       .AsEnumerable();

                    pageFromFrontToDown
                        .ToList()
                        .ForEach(x => x.SortOrder += (pageFromDownToUp.Count()));

                    pageFromDownToUp.ToList().ForEach(x => x.SortOrder -= (sortOrderDown - sortOrderBefore));

                    Context.Save();
                }
            }
        }

        public IEnumerable<Page> GetAllCachePage()
        {
            var pages = Cache.Get("menu") as IEnumerable<Page>;

            // If it's not in the cache, we need to read it from the repository
            if (pages == null)
            {
                // Get the repository data
                pages = GetAll().ToList();

                if (pages.Any())
                {
                    // Put this data into the cache for 30 minutes
                    Cache.Set("menu", pages, 30);
                }
            }

            return pages;
        }

        public Page UpdatePage(Page entity, ref ErrorCode.PageServiceStatus status)
        {
            Page pageFromDb = Context.PageRepository.Find(entity.Id);

            var layoutCheck = Context.LayoutRepository
                .Filter(m =>
                    m.Name == entity.PageLayout)
                .Select(m => new
                {
                    m.IsSlider,
                    m.IsPotfolio,
                    m.IsBlog,
                    m.IsGallery
                })
                .FirstOrDefault();

            if (layoutCheck.IsSlider && entity.SliderHeaderId == null)
            {
                status = ErrorCode.PageServiceStatus.SliderIdIsRequiredForSelectedLayout;
                return entity;
            }

            if (layoutCheck.IsPotfolio && entity.PortfolioHeaderId == null)
            {
                status = ErrorCode.PageServiceStatus.PortfolioIdIsRequiredForSelectedLayout;
                return entity;
            }

            if (layoutCheck.IsBlog && entity.BlogId == null)
            {
                status = ErrorCode.PageServiceStatus.BlogIdIsRequiredForSelectedLayout;
                return entity;
            }

            if (entity.PageParentId != pageFromDb.PageParentId)
            {
                Context.PageRepository.Delete(pageFromDb);
                Context.PageRepository
                    .Filter(m =>
                        m.SortOrder > pageFromDb.SortOrder)
                    .ToList()
                    .ForEach(m =>
                        m.SortOrder = m.SortOrder - 1);

                Context.Save();

                Guid siteId = SiteId;
                int lastOrder = 0;
                if (Context.PageRepository.All().Any(m => m.SiteId == siteId))
                {
                    lastOrder = entity.PageParentId == null ?
                       Context.PageRepository.All().Where(m => m.SiteId == siteId).Select(m => m.SortOrder).Max() :
                       Context.PageRepository.All().Where(m => m.SiteId == siteId && (m.Id == entity.PageParentId || m.PageParentId == entity.PageParentId)).Select(m => m.SortOrder).Max();
                }

                entity.SortOrder = lastOrder + 1;
                entity.Url = entity.Url.TrimEnd('/').TrimStart('/').Replace(' ', '-').ToLower();

                while (entity.Url.Contains("//"))
                {
                    entity.Url = entity.Url.Replace("//", "/");
                }

                User crUser = User;
                entity.Id = pageFromDb.Id;
                entity.CrUser = crUser;
                entity.LmUser = crUser;
                entity.CrDate = DateTime.Now;
                entity.LmDate = DateTime.Now;
                entity.SiteId = siteId;
                Context.PageRepository
                    .Filter(m =>
                        m.SortOrder > lastOrder &&
                        m.SiteId == siteId)
                    .ToList()
                    .ForEach(m => m.SortOrder += 1);

                Context.PageRepository.Create(entity);
                Context.Save();
            }
            else
            {
                pageFromDb.LmDate = DateTime.Now;
                pageFromDb.PageTitle = entity.PageTitle;
                pageFromDb.Name = entity.Name;
                pageFromDb.PageLayout = entity.PageLayout;
                pageFromDb.Url = entity.Url.TrimEnd('/').TrimStart('/').Replace(' ', '-').ToLower();

                while (pageFromDb.Url.Contains("//"))
                {
                    pageFromDb.Url = pageFromDb.Url.Replace("//", "/");
                }

                pageFromDb.Active = entity.Active;
                pageFromDb.DisplayPageTitle = entity.DisplayPageTitle;
                pageFromDb.MainMenu = entity.MainMenu;
                pageFromDb.MenuTitle = entity.MenuTitle;
                pageFromDb.MetaTitle = entity.MetaTitle;
                pageFromDb.Authorized = entity.Authorized;
                pageFromDb.MetaDescription = entity.MetaDescription;
                pageFromDb.MetaKeywords = entity.MetaKeywords;
                pageFromDb.LmUser = User;
                pageFromDb.PageTempleteContentId = entity.PageTempleteContentId;
                pageFromDb.UnderConstruction = entity.UnderConstruction;
                pageFromDb.SliderHeaderId = layoutCheck.IsSlider ? entity.SliderHeaderId : null;
                pageFromDb.PortfolioHeaderId = layoutCheck.IsPotfolio ? entity.PortfolioHeaderId : null;
                pageFromDb.BlogId = layoutCheck.IsBlog ? entity.BlogId : null;

                Context.PageRepository.Update(pageFromDb);
                Context.Save();
            }
            return entity;
        }

        public Page FindPageById(int id)
        {
            return Context.PageRepository.Find(id);
        }
    }
}
