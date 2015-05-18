using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using AIronMan.Repository;
using AIronMan.Domain;
using AIronMan.Logging;
using AIronMan.Services.Providers;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Collections;
using System.Web;

namespace AIronMan.Services
{
    public class PageTemplateService : ServiceBase, IPageTemplateService
    {
        public PageTemplateService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        { }

        public IQueryable<PageTemplate> Get()
        {
            return Context.PageTemplateRepository.All().OrderByDescending(x => x.CrDate);
        }

        public PageTemplate Create(string name, string content, bool isActive, int userId, ref ErrorCode.PageTemplateServiceStatus status)
        {
            PageTemplate entity = null;
            Guid siteId = Context.SiteRepository.GetCurrentSiteIdFromWebConfig();
            if (String.IsNullOrEmpty(name))
            {
                status = ErrorCode.PageTemplateServiceStatus.NameRequired;
                return entity;
            }

            if (String.IsNullOrEmpty(content))
            {
                status = ErrorCode.PageTemplateServiceStatus.ContentRequired;
                return entity;
            }

            if (Context.PageTemplateRepository.Contains(m => m.Name.ToLower().Trim() == name.ToLower().Trim() && m.SiteId == siteId))
            {
                status = ErrorCode.PageTemplateServiceStatus.NameAlreadyExists;
                return entity;
            }

            User crUser = Context.UserRepository.Find(userId);

            List<String> langs = Context.LangRepository.All().Select(m => m.LangCode).ToList();

            int newId = 1;

            if (Context.PageTemplateRepository.Count > 0)
            {
                newId = Context.PageTemplateRepository.All().Max(m => m.TemplateId) + 1;
            }

            foreach (var cLang in langs)
            {
                entity = new PageTemplate();
                entity.TemplateId = (int)newId;
                entity.Name = name.Trim();
                entity.Content = content;
                entity.IsActive = isActive;
                entity.Lang = cLang;

                entity.SiteId = siteId;
                entity.CrUser = crUser;
                entity.LmUser = crUser;
                entity.CrDate = DateTime.Now;
                entity.LmDate = DateTime.Now;

                Context.PageTemplateRepository.Create(entity);
            }
            Context.Save();

            return entity;
        }

        public PageTemplate Update(PageTemplate entity, int userId, ref ErrorCode.PageTemplateServiceStatus status)
        {
            if (String.IsNullOrEmpty(entity.Name))
            {
                status = ErrorCode.PageTemplateServiceStatus.NameRequired;
                return entity;
            }

            if (String.IsNullOrEmpty(entity.Content))
            {
                status = ErrorCode.PageTemplateServiceStatus.ContentRequired;
                return entity;
            }
            Guid siteId = SiteId;
            if (Context.PageTemplateRepository.Contains(m => m.Name.ToLower().Trim() == entity.Name.ToLower().Trim() && m.SiteId == siteId && m.TemplateId != entity.TemplateId))
            {
                status = ErrorCode.PageTemplateServiceStatus.NameAlreadyExists;
                return entity;
            }

            PageTemplate entityFromDb = Context.PageTemplateRepository.Filter(m => m.Id == entity.Id).FirstOrDefault();
            entityFromDb.Name = entity.Name.Trim();
            entityFromDb.Content = entity.Content;
            entityFromDb.IsActive = entity.IsActive;

            User crUser = Context.UserRepository.Find(userId);

            entityFromDb.LmDate = DateTime.Now;
            entityFromDb.LmUser = crUser;

            Context.PageTemplateRepository.Update(entityFromDb);
            Context.Save();

            return entityFromDb;
        }

        public int Delete(int id, ref ErrorCode.PageTemplateServiceStatus status)
        {
            PageTemplate pageToDelete = Context.PageTemplateRepository.Find(id);

            int rtn = Context.PageTemplateRepository.Delete(pageToDelete);
            Context.Save();

            return rtn;
        }

        public PageTemplate GetById(int id)
        {
            return Context.PageTemplateRepository.Filter(m => m.Id == id).FirstOrDefault();
        }
    }
}
