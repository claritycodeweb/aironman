using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AIronMan.Domain;

namespace AIronMan.Services {
    public interface ITagService {

        IQueryable<Tag> Get(string tagName = "");

        IQueryable<Tag> GetTagsByBlogName(string bloggerName);
        IQueryable<Tag> GetTagsByPortfolioName(string portfolioName);
        IQueryable<Tag> GetTagsByPortfolioId(int id);

        #region Client optimalization query
        IEnumerable<Tag> GetSmallTagsObjectForClientLayout(int blogId);
        #endregion
    }
}
