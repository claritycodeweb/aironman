using AIronMan.DataSource;
using AIronMan.Domain;
using AIronMan.Logging;
using AIronMan.Services.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AIronMan.Services
{
    public class TagService : ServiceBase, ITagService
    {
        public TagService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        { }

        public IQueryable<Tag> Get(string tagName = "")
        {
            var query = Context.TagRepository.All();

            if (!String.IsNullOrEmpty(tagName))
            {
                query = query.Where(m => m.Name.ToLower() == tagName.ToLower());
            }

            return query;
        }

        public IQueryable<Tag> GetTagsByBlogName(string bloggerName)
        {
            var query = Context.TagRepository.All().Where(m => m.Posts.Any(x => x.Blog.BloggerName == bloggerName)).Distinct();
            return query;
        }

        public IEnumerable<Tag> GetSmallTagsObjectForClientLayout(int blogId)
        {
            //var query = Context.TagRepository.All().Where(m => m.Posts.Where(x => x.Blog.Id == blogId).Count() > 0).GroupBy(m => m.Name).OrderByDescending(m => m.Count()).SelectMany(g => g).ToList();
            var query = Context.TagRepository.All().Where(m => m.Posts.Any(x => x.Blog.Id == blogId)).OrderByDescending(m => m.Name).Distinct();
            return query.ToList();
        }

        public IQueryable<Tag> GetTagsByPortfolioName(string portfolioName)
        {
            var query = Context.TagRepository.All().Where(m => m.PortfolioNodes.Any(x => x.PortfolioHeader.Name == portfolioName)).Distinct();
            return query;
        }

        public IQueryable<Tag> GetTagsByPortfolioId(int id)
        {
            var query = Context.TagRepository.All().Where(m => m.PortfolioNodes.Any(x => x.PortfolioHeader.Id == id)).Distinct();
            return query;
        }
    }
}
