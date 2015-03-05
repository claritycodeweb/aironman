
using AIronMan.DataSource;
using AIronMan.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AIronMan.Logging;
using AIronMan.Services.Providers;

namespace AIronMan.Services
{
    public class BlogService : ServiceBase, IBlogService
    {
        public BlogService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        {}

        /// <summary>
        /// Get All blogs, order by lmdate desc
        /// </summary>
        /// <returns></returns>
        public IQueryable<Blog> GetBlog()
        {
            Guid siteId = Context.SiteRepository.GetCurrentSiteIdFromWebConfig();
            IQueryable<Blog> allBlogs = Context.BlogRepository.All().Where(m => m.SiteId == siteId).Include(m => m.CrUser);
            //allBlogs.Sort((x, y) => -x.LmDate.CompareTo(y.LmDate));
            return allBlogs.OrderByDescending(x => x.LmDate);
        }

        public IQueryable<Post> GetPostsVisible(string bloggerName, string tag, string search)
        {
            var query = Context.PostRepository.Filter(x => x.IsVisible);

            if (!String.IsNullOrEmpty(bloggerName))
            {
                query = query.Where(x => x.Blog.BloggerName == bloggerName && x.Blog.IsActive);
            }

            if (!String.IsNullOrEmpty(tag))
            {
                query = query.Where(e => e.Tags.Count(t => t.Name.Equals(tag, StringComparison.OrdinalIgnoreCase)) > 0);
            }

            query = query.Include(m => m.CrUser);
            query = query.Include(m => m.Comments);

            return query.OrderByDescending(x => x.CrDate);
        }

        public class BlogComparer : IComparer<Blog>
        {
            public int Compare(Blog x, Blog y)
            {
                return x.LmDate.CompareTo(y.LmDate);
            }
        }

        public IQueryable<Post> GetPosts(string bloggerName, string tag, string search)
        {
            var query = Context.PostRepository.All();

            if (!String.IsNullOrEmpty(bloggerName))
            {
                query = query.Where(x => x.Blog.BloggerName == bloggerName && x.Blog.IsActive);
            }

            if (!String.IsNullOrEmpty(tag))
            {
                query = query.Where(e => e.Tags.Count(t => t.Name.Equals(tag, StringComparison.OrdinalIgnoreCase)) > 0);
            }

            if (!String.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.Title.Contains(search));
            }

            query = query.Include(m => m.CrUser);
            query = query.Include(m => m.Comments);

            return query.OrderByDescending(x => x.CrDate);
        }

        public Blog GetBlogById(int id)
        {
            return Context.BlogRepository.Find(id);
        }

        public Blog CreateBlog(Blog entity, ref ErrorCode.BlogServiceStatus status)
        {
            Guid siteId = SiteId;

            var sliders = Context.BlogRepository.Filter(m => m.BloggerName.Trim().ToLower().Equals(entity.BloggerName.Trim().ToLower()) && m.SiteId == siteId);

            if (sliders.Any())
            {
                status = ErrorCode.BlogServiceStatus.NameAlreadyExists;
                return entity;
            }
            User crUser = User;

            entity.CrUser = crUser;
            entity.LmUser = crUser;
            entity.CrDate = DateTime.Now;
            entity.LmDate = DateTime.Now;
            entity.SiteId = siteId;

            Context.BlogRepository.Create(entity);
            Context.Save();

            return entity;
        }

        public Blog UpdateBlog(Blog entity, ref ErrorCode.BlogServiceStatus status)
        {
            var blogs = Context.BlogRepository.Filter(m => m.BloggerName.Trim().ToLower().Equals(entity.BloggerName.Trim().ToLower()) && m.Id != entity.Id);

            if (blogs.Any())
            {
                status = ErrorCode.BlogServiceStatus.NameAlreadyExists;
                return entity;
            }

            User crUser = User;
            Blog entityFromDb = Context.BlogRepository.Find(entity.Id);
            entityFromDb.Title = entity.Title;
            entityFromDb.IsActive = entity.IsActive;
            entityFromDb.Title = entity.Title;
            entityFromDb.LayoutForGroupPost = entity.LayoutForGroupPost;
            entityFromDb.LayoutForSinglePost = entity.LayoutForSinglePost;

            entityFromDb.LmUser = crUser;
            entityFromDb.LmDate = DateTime.Now;

            Context.BlogRepository.Update(entityFromDb);
            Context.Save();

            return entity;
        }

        public int DeleteBlog(int id, ref ErrorCode.PostServiceStatus status)
        {
            var blogToDelete = Context.BlogRepository.Find(id);

            if (blogToDelete != null)
            {
                Context.BlogRepository.Delete(blogToDelete);
                Context.Save();
                return 0;
            }
            status = ErrorCode.PostServiceStatus.UnknownError;
            return -1;
        }

        public Blog GetSmallPostsObjectForClientLayout(int blogId, int takeCount)
        {
            var posts = Context.PostRepository.Filter(m => m.BlogId == blogId && m.IsVisible);

            var nodes = posts.Select(m => new
            {
                m.Id,
                m.ShortContent,
                m.Title,
                m.TitleUrl,
                m.CrDate
            })
            .OrderByDescending(m => m.CrDate)
            .Take(takeCount)
            .ToList()
            .Select(m => new Post()
            {
                Id = m.Id,
                CrDate = m.CrDate,
                ShortContent = m.ShortContent,
                Title = m.Title,
                TitleUrl = m.TitleUrl,
                //PortfolioHeader = new PortfolioHeader() { NameUrl = m.NameUrl }
            }).ToList();

            Blog model = new Blog
            {
                Posts = nodes,
                BloggerName = Context.BlogRepository
                    .Filter(m => m.Id == blogId)
                    .Select(m => m.BloggerName)
                    .FirstOrDefault()
            };

            return model;
        }
    }
}
