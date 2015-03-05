using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.DataSource;
using AIronMan.Domain;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Collections;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using AIronMan.Logging;
using AIronMan.Services.Providers;

namespace AIronMan.Services
{
    public class PortfolioService : ServiceBase, IPortfolioService
    {
        public PortfolioService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        { }

        public PortfolioHeader CreatePortfolio(PortfolioHeader entity, ref ErrorCode.PortfolioServiceStatus status)
        {
            User crUser = User;
            Guid siteId = SiteId;

            var sliders = Context.PortfolioHeaderRepository.Filter(m => m.Name.Trim().ToLower().Equals(entity.Name.Trim().ToLower()) && m.SiteId == siteId);

            if (sliders.Any())
            {
                status = ErrorCode.PortfolioServiceStatus.NameAlreadyExists;
                return entity;
            }

            entity.CrUser = crUser;
            entity.LmUser = crUser;
            entity.CrDate = DateTime.Now;
            entity.LmDate = DateTime.Now;
            entity.SiteId = siteId;

            Context.PortfolioHeaderRepository.Create(entity);
            Context.Save();

            return entity;
        }

        public PortfolioHeader UpdatePortfolio(PortfolioHeader entity, ref ErrorCode.PortfolioServiceStatus status)
        {
            var portfolios = Context.PortfolioHeaderRepository.Filter(m => m.Name.Trim().ToLower().Equals(entity.Name.Trim().ToLower()) && m.Id != entity.Id);

            if (portfolios.Any())
            {
                status = ErrorCode.PortfolioServiceStatus.NameAlreadyExists;
                return entity;
            }


            User crUser = User;
            PortfolioHeader entityFromDb = Context.PortfolioHeaderRepository.Find(entity.Id);
            entityFromDb.Name = entity.Name;
            entityFromDb.EnableComments = entity.EnableComments;
            entityFromDb.NameUrl = entity.NameUrl;
            entityFromDb.Title = entity.Title;
            entityFromDb.Description = entity.Description;
            entityFromDb.LayoutForGroupProject = entity.LayoutForGroupProject;
            entityFromDb.LayoutForSingleProject = entity.LayoutForSingleProject;

            entityFromDb.LmUser = crUser;
            entityFromDb.LmDate = DateTime.Now;

            Context.PortfolioHeaderRepository.Update(entityFromDb);
            Context.Save();

            return entity;
        }

        public PortfolioNode CreatePortfolioStep(PortfolioNode entity, IEnumerable<string> category, int userId, ref ErrorCode.PortfolioServiceStatus status)
        {
            if (entity.PortfolioId == 0)
            {
                status = ErrorCode.PortfolioServiceStatus.PortfolioHeaderIsRequiredForNode;
                return entity;
            }

            var portfolios = Context.PortfolioNodeRepository.Filter(m =>
                m.TitleUrl.Trim().ToLower().Equals(entity.TitleUrl.Trim().ToLower()) &&
                m.PortfolioId == entity.PortfolioId);

            if (portfolios.Any())
            {
                status = ErrorCode.PortfolioServiceStatus.TitleForNodeAlreadyExists;
                return entity;
            }

            //server.MapPath(entity.ImageLocalPath);

            //if (String.IsNullOrEmpty(entity.ImageProjectThumbUrlPath)) {
            //    status = ErrorCode.PortfolioServiceStatus.ImageProjectThumbUrlPathIsRequired;
            //    return entity;
            //}

            //if (String.IsNullOrEmpty(entity.ImageProjectUrlPath)) {
            //    status = ErrorCode.PortfolioServiceStatus.ImageProjectUrlPathIsRequired;
            //    return entity;
            //}

            User crUser = Context.UserRepository.Find(userId);
            ICollection<Tag> categoryList = new List<Tag>();
            foreach (String item in category)
            {
                Tag existsCategory = Context.TagRepository.Find(m => m.Name == item);

                categoryList.Add(existsCategory ?? new Tag() { Name = item });
            }

            entity.CrUser = crUser;
            entity.LmUser = crUser;
            entity.CrDate = DateTime.Now;
            entity.LmDate = DateTime.Now;
            entity.Tags = categoryList;

            Context.PortfolioNodeRepository.Create(entity);
            Context.Save();

            return entity;
        }

        public PortfolioNode UpdatePortfolioStep(PortfolioNode entity, IEnumerable<string> categories, int userId, ref ErrorCode.PortfolioServiceStatus status)
        {

            var portfolios = Context.PortfolioNodeRepository.Filter(m =>
                m.TitleUrl.Trim().ToLower().Equals(entity.TitleUrl.Trim().ToLower()) &&
                m.PortfolioId == entity.PortfolioId &&
                m.Id != entity.Id);

            if (portfolios.Any())
            {
                status = ErrorCode.PortfolioServiceStatus.TitleForNodeAlreadyExists;
                return entity;
            }

            //if (String.IsNullOrEmpty(entity.ImageProjectThumbUrlPath)) {
            //    status = ErrorCode.PortfolioServiceStatus.ImageProjectThumbUrlPathIsRequired;
            //    return entity;
            //}

            //if (String.IsNullOrEmpty(entity.ImageProjectUrlPath)) {
            //    status = ErrorCode.PortfolioServiceStatus.ImageProjectUrlPathIsRequired;
            //    return entity;
            //}

            User crUser = Context.UserRepository.Find(userId);
            PortfolioNode entityFromDb = Context.PortfolioNodeRepository.Find(entity.Id);
            entityFromDb.Title = entity.Title;
            entityFromDb.TitleUrl = entity.TitleUrl;
            entityFromDb.Content = entity.Content;
            entityFromDb.ShortContent = entity.ShortContent;
            entityFromDb.ImageProjectThumbUrlPath = entity.ImageProjectThumbUrlPath;
            entityFromDb.ImageProjectUrlPath = entity.ImageProjectUrlPath;
            entityFromDb.IsVisible = entity.IsVisible;
            entityFromDb.PortfolioId = entity.PortfolioId;
            if (!String.IsNullOrEmpty(entity.ProjectUrlPath))
            {
                entityFromDb.ProjectUrlPath = entity.ProjectUrlPath.ToLower().Contains("http:") ? entity.ProjectUrlPath : "http://" + entity.ProjectUrlPath;
            }
            entityFromDb.Author = entity.Author;
            entityFromDb.ImageProjectLocalPath = entity.ImageProjectLocalPath;
            entityFromDb.ImageProjectThumbLocalPath = entity.ImageProjectThumbLocalPath;
            entityFromDb.DownloadFilePath = entity.DownloadFilePath;

            entityFromDb.CrUser = crUser;
            entityFromDb.LmUser = crUser;
            //entityFromDb.CrDate = DateTime.Now;
            entityFromDb.LmDate = DateTime.Now;

            AddCategory(entityFromDb, categories);

            Context.PortfolioNodeRepository.Update(entityFromDb);
            Context.Save();

            return entity;
        }

        public IQueryable<PortfolioHeader> GetPortfolioWithNode()
        {
            Guid siteId = SiteId;
            return Context.PortfolioHeaderRepository
                .Filter(m => m.SiteId == siteId)
                .Include(m => m.PortfolioNodes)
                .OrderByDescending(x => x.CrDate);
        }

        public IQueryable<PortfolioNode> GetAllPortfolioNode()
        {
            var query = Context.PortfolioNodeRepository.All();

            return query;
        }

        public IQueryable<PortfolioNode> GetPortfolioNode(int portfolioHeaderId)
        {
            var query = Context.PortfolioNodeRepository.Filter(m => m.PortfolioId == portfolioHeaderId);

            return query;
        }

        public IQueryable<PortfolioNode> GetPortfolioNode(string portfolioHeaderTitle)
        {
            var query = Context.PortfolioNodeRepository.Filter(m => m.Title.ToLower().Equals(portfolioHeaderTitle));

            return query;
        }

        public IQueryable<PortfolioHeader> GetPortfolioWithoutNode()
        {
            return Context.PortfolioHeaderRepository.All();
        }

        public PortfolioHeader GetPortfolioHeaderById(int id)
        {
            return Context.PortfolioHeaderRepository.Find(id);
        }

        public PortfolioNode GetPortfolioNodeById(int id)
        {
            return Context.PortfolioNodeRepository.Find(id);
        }

        private void AddCategory(PortfolioNode portfolioNodeEntry, IEnumerable<string> categories)
        {
            var existingTags = Context.TagRepository.All().ToList();

            if (portfolioNodeEntry.Tags == null)
            {
                portfolioNodeEntry.Tags = new List<Tag>();
            }

            foreach (var tag in portfolioNodeEntry.Tags.Where(t => !categories.Contains(t.Name)).ToArray())
            {
                portfolioNodeEntry.Tags.Remove(tag);
            }

            foreach (var categoryName in categories.Where(t => !portfolioNodeEntry.Tags.Select(et => et.Name).Contains(t)).ToArray())
            {
                var existingCategory = existingTags.SingleOrDefault(t => t.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

                if (existingCategory == null)
                {
                    existingCategory = new Tag() { Name = categoryName };
                    existingTags.Add(existingCategory);
                }

                portfolioNodeEntry.Tags.Add(existingCategory);
            }
        }

        public IQueryable<PortfolioNode> GetPortfolioNodeVisible(string portfolioName, string category, string search)
        {
            var query = Context.PortfolioNodeRepository.Filter(x => x.IsVisible);


            if (!String.IsNullOrEmpty(portfolioName))
            {
                query = query.Where(x => x.PortfolioHeader.NameUrl.ToLower() == portfolioName.ToLower());
            }

            if (!String.IsNullOrEmpty(category) && category.ToLower().Equals("all"))
            {
                category = "";
            }

            if (!String.IsNullOrEmpty(category))
            {
                query = query.Where(e => e.Tags.Count(t => t.Name.Equals(category, StringComparison.OrdinalIgnoreCase)) > 0);
            }

            query = query.Include(m => m.CrUser);
            query = query.Include(m => m.Comments);

            return query.OrderByDescending(x => x.CrDate);
        }

        public int DeletePortfolioNode(int id, ref ErrorCode.PortfolioServiceStatus status)
        {
            var nodeToDelete = Context.PortfolioNodeRepository.Find(id);

            if (nodeToDelete != null)
            {
                Context.PortfolioNodeRepository.Delete(nodeToDelete);
                Context.Save();
                return 0;
            }
            status = ErrorCode.PortfolioServiceStatus.UnknownError;
            return -1;
        }

        public PortfolioHeader GetPortfolioForClientLayout(int portfolioId, int takeCount)
        {
            var portfolioNode = Context.PortfolioNodeRepository.Filter(m => m.PortfolioHeader.Id == portfolioId && m.IsVisible);

            // TEST 
            //var abc = GetPortfolioForClientLayoutByCq(portfolioId, takeCount);

            var nodes = portfolioNode.Select(m => new
            {
                Id = m.Id,
                ShortContent = m.ShortContent,
                Title = m.Title,
                //NameUrl = m.PortfolioHeader.NameUrl,
                ImageProjectThumbLocalPath = m.ImageProjectThumbLocalPath,
                TitleUrl = m.TitleUrl,
                CrDate = m.CrDate,
                ProjectUrlPath = m.ProjectUrlPath
            }).OrderByDescending(m => m.CrDate).Take(takeCount).ToList()
               .Select(m => new PortfolioNode()
               {
                   Id = m.Id,
                   CrDate = m.CrDate,
                   ShortContent = m.ShortContent,
                   Title = m.Title,
                   ImageProjectThumbLocalPath = m.ImageProjectThumbLocalPath,
                   TitleUrl = m.TitleUrl,
                   ProjectUrlPath = m.ProjectUrlPath
                   //PortfolioHeader = new PortfolioHeader() { NameUrl = m.NameUrl }
               }).ToList();

            nodes.Sort((m, n) => -m.CrDate.CompareTo(n.CrDate));

            PortfolioHeader model = new PortfolioHeader();
            model.PortfolioNodes = nodes;
            model.NameUrl = Context.PortfolioHeaderRepository
                .Filter(m => m.Id == portfolioId)
                .Select(m => m.NameUrl)
                .FirstOrDefault();
            model.Id = portfolioId;

            return model;
        }

        //by compiled query (test), nie działa chyba że się zapytamy select *
        private PortfolioHeader GetPortfolioForClientLayoutByCq(int portfolioId, int takeCount)
        {
            //Customer c = context.Customers.SqlQuery(“select * from Customers where Id = @id”, param).First();
            PortfolioHeader model = new PortfolioHeader();
            SqlParameter param = new SqlParameter("portfolioid", SqlDbType.Int);
            param.Value = 10;
            //try {
            var nodes = Context.PortfolioNodeRepository.GetWithRawSql("select top " + takeCount.ToString() +
                " Id, PortfolioId, ShortContent, Title, ImageProjectThumbLocalPath, TitleUrl, CrDate from dbo.PortfolioNodes where IsVisible = 1 and PortfolioId = @portfolioid", param).ToList();
            model.PortfolioNodes = nodes;
            model.NameUrl = Context.PortfolioHeaderRepository.Filter(m => m.Id == portfolioId).Select(m => m.NameUrl).FirstOrDefault();
            model.Id = portfolioId;

            Trace.Write("output CONSOLE -> " + nodes.Count.ToString());

            //} catch (Exception ex) {
            //    Console.WriteLine(ex.Message);
            //}

            return model;
        }

        public PortfolioHeader GetPortfolioWithCategoryForClientLayout(int portfolioId, int takeCount)
        {
            var portfolioNode = Context.PortfolioNodeRepository.Filter(m => m.PortfolioHeader.Id == portfolioId && m.IsVisible);

            var nodes = portfolioNode.Select(m => new
            {
                Id = m.Id,
                ShortContent = m.ShortContent,
                Title = m.Title,
                //NameUrl = m.PortfolioHeader.NameUrl,
                ImageProjectThumbLocalPath = m.ImageProjectThumbLocalPath,
                TitleUrl = m.TitleUrl,
                CrDate = m.CrDate,
                Category = m.Tags,
                ProjectUrlPath = m.ProjectUrlPath
            }).OrderByDescending(m => m.CrDate).Take(takeCount).ToList()
               .Select(m => new PortfolioNode()
               {
                   Id = m.Id,
                   CrDate = m.CrDate,
                   ShortContent = m.ShortContent,
                   Title = m.Title,
                   ImageProjectThumbLocalPath = m.ImageProjectThumbLocalPath,
                   TitleUrl = m.TitleUrl,
                   Tags = m.Category,
                   ProjectUrlPath = m.ProjectUrlPath
                   //PortfolioHeader = new PortfolioHeader() { NameUrl = m.NameUrl }
               }).ToList();


            nodes.Sort((m, n) => -m.CrDate.CompareTo(n.CrDate));

            PortfolioHeader model = new PortfolioHeader
            {
                PortfolioNodes = nodes,
                NameUrl = Context.PortfolioHeaderRepository
                    .Filter(m => m.Id == portfolioId)
                    .Select(m => m.NameUrl)
                    .FirstOrDefault(),
                Id = portfolioId
            };

            return model;
        }


        public IQueryable<PortfolioHeader> GetPortfolioInSiteWithoutNode()
        {
            return Context.PortfolioHeaderRepository.Filter(m => m.SiteId == SiteId);
        }
    }
}
