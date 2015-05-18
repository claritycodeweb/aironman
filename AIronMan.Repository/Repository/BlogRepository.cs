using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;
using System.Linq.Expressions;
using System.Data.Entity;

namespace AIronMan.Repository {
    public class BlogRepository : Repository<Blog>, IBlogRepository {
        public BlogRepository(DB context) : base(context) { }

        public IQueryable<Blog> GetBlogWithAllPost() {
            return DbSet.Include("Posts").Include("Posts.Tags").AsQueryable();
        }
    }
}
