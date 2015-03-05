using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;


namespace AIronMan.Services {
    public interface IBlogService {
        IQueryable<Blog> GetBlog();
        IQueryable<Post> GetPosts(string bloggerName, string tag, string search);
        IQueryable<Post> GetPostsVisible(string bloggerName, string tag, string search);
        Blog CreateBlog(Blog entity, ref ErrorCode.BlogServiceStatus status);
        Blog GetBlogById(int id);
        Blog UpdateBlog(Blog entity, ref ErrorCode.BlogServiceStatus status);
        int DeleteBlog(int id, ref ErrorCode.PostServiceStatus status);

        #region Client optimalization query
        Blog GetSmallPostsObjectForClientLayout(int blogId, int takeCount);
        #endregion
    }
}
