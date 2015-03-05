using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.Domain;
using AIronMan.Domain.Mapping;

namespace AIronMan.Services {
    public interface IPostService {
        IQueryable<Post> GetPost();
        IQueryable<Post> GetPosts(string bloggerName, string tag, string search);
        Post CreatePost(int blogId,string title, string shortContent, string content, bool isActive, IEnumerable<String> tags, string metaTitle, ref ErrorCode.PostServiceStatus status);
        Post UpdatePost(Post postEntry, IEnumerable<string> tags, ref ErrorCode.PostServiceStatus status);
        Post GetPostById(int id);
        int DeletePost(int id, ref ErrorCode.PostServiceStatus status);
        void ChangeVisible(int id, bool isVisible, ref ErrorCode.PostServiceStatus status);
        Comment CreateComment(Comment commentEntry, SettingMap settings, bool isAdmin ,ref ErrorCode.PostServiceStatus status);
        bool DeleteComment(int id, ref ErrorCode.PostServiceStatus status); 
        IEnumerable<Comment> GetAllCommentByPostId(int postId);
        Post GetPostWithCommentsById(int id);
    }
}
