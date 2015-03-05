using AIronMan.DataSource;
using AIronMan.Domain;
using AIronMan.Domain.Mapping;
using AIronMan.Logging;
using AIronMan.Services.Providers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AIronMan.Services
{
    public class PostService : ServiceBase, IPostService
    {

        public PostService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        {}

        public IQueryable<Post> GetPost()
        {
            return Context.PostRepository.All().Include(m => m.CrUser);
        }

        public IQueryable<Post> GetPosts(string bloggerName, string tag, string search)
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

            if (!String.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.Title.Contains(search));
            }

            query = query.Include(m => m.CrUser);
            query = query.Include(m => m.Comments);

            return query.OrderByDescending(x => x.CrDate);
        }

        public Post CreatePost(int blogId,  string title, string shortContent, string content, bool isVisible, IEnumerable<string> tags, string metaTitle, ref ErrorCode.PostServiceStatus status)
        {
            User crUser = User;
            DateTime crDate = DateTime.Now;

            if (Context.PostRepository.Contains(x => x.Title == title && x.BlogId == blogId))
            {
                status = ErrorCode.PostServiceStatus.TitleMustBeUniquePerBlog;
                return new Post();
            }

            ICollection<Tag> tg = new List<Tag>();
            foreach (String item in tags)
            {
                string item1 = item;
                Tag existsTag = Context.TagRepository.Find(m => m.Name == item1);

                if (existsTag != null)
                {
                    tg.Add(existsTag);
                }
                else
                {
                    tg.Add(new Tag() { Name = item });
                }
            }

            var post = new Post()
            {
                Title = title,
                BlogId = blogId,
                ShortContent = shortContent,
                Content = content,
                CrUser = crUser,
                LmUser = crUser,
                CrDate = crDate,
                LmDate = crDate,
                IsVisible = isVisible,
                MetaTitle = metaTitle,
                Tags = tg
            };
            Context.PostRepository.Create(post);
            Context.Save();

            return post;
        }

        public Post GetPostById(int id)
        {
            var query = Context.PostRepository.Filter(m => m.Id == id);
            query = query.Include(m => m.Blog);
            query = query.Include(m => m.Tags);

            return query.SingleOrDefault();
        }

        public Post GetPostWithCommentsById(int id)
        {
            var query = Context.PostRepository.Filter(m => m.Id == id);
            query = query.Include(m => m.Blog);
            query = query.Include(m => m.Tags);
            query = query.Include(m => m.Comments);

            return query.SingleOrDefault();
        }

        public Post UpdatePost(Post postEntry, IEnumerable<string> tags,  ref ErrorCode.PostServiceStatus status)
        {
            User crUser = User;

            Post modelDb = GetPostById(postEntry.Id);
            modelDb.MetaTitle = postEntry.MetaTitle;
            modelDb.ShortContent = postEntry.ShortContent;
            modelDb.Title = postEntry.Title;
            modelDb.Content = postEntry.Content;
            modelDb.BlogId = postEntry.BlogId;
            modelDb.IsVisible = postEntry.IsVisible;
            modelDb.DownloadFilePath = postEntry.DownloadFilePath;
            modelDb.EnableComments = postEntry.EnableComments;
            modelDb.LmDate = DateTime.Now;
            modelDb.LmUser = crUser;

            AddTags(modelDb, tags);

            Context.PostRepository.Update(modelDb);
            Context.Save();
            return modelDb;
        }

        private void AddTags(Post postEntry, IEnumerable<string> tags)
        {
            var existingTags = Context.TagRepository.All().ToList();

            if (postEntry.Tags == null)
            {
                postEntry.Tags = new List<Tag>();
            }

            foreach (var tag in postEntry.Tags.Where(t => !tags.Contains(t.Name)).ToArray())
            {
                postEntry.Tags.Remove(tag);
            }

            foreach (var tag in tags.Where(t => !postEntry.Tags.Select(et => et.Name).Contains(t)).ToArray())
            {
                var existingTag = existingTags.SingleOrDefault(t => t.Name.Equals(tag, StringComparison.OrdinalIgnoreCase));

                if (existingTag == null)
                {
                    existingTag = new Tag() { Name = tag };
                    existingTags.Add(existingTag);
                }

                postEntry.Tags.Add(existingTag);
            }
        }

        public int DeletePost(int id, ref ErrorCode.PostServiceStatus status)
        {
            var postToDelete = Context.PostRepository.Find(id);

            if (postToDelete != null)
            {
                Context.PostRepository.Delete(postToDelete);
                Context.Save();
                return 0;
            }
            status = ErrorCode.PostServiceStatus.UnknownError;
            return -1;
        }

        public void ChangeVisible(int id, bool isVisible, ref ErrorCode.PostServiceStatus status)
        {
            var postToUpdate = Context.PostRepository.Find(id);
            postToUpdate.IsVisible = isVisible;
            Context.PostRepository.Update(postToUpdate);
            Context.Save();
        }

        public Comment CreateComment(Comment commentModel, SettingMap settingModel, bool isAdmin, ref ErrorCode.PostServiceStatus status)
        {
            IEnumerable<String> spamWords = settingModel.SpamWords.Split(',').Select(m => m.Trim());

            if (spamWords.Any(item => commentModel.Content.Contains(item)))
            {
                commentModel.IsBlock = true;
                status = ErrorCode.PostServiceStatus.BlockCommentYouUseSpamWords;
            }
            DateTime crDate = DateTime.Now;

            commentModel.IsAdmin = isAdmin;
            commentModel.LmDate = crDate;
            commentModel.CrDate = crDate;
            commentModel.Visible = true;

            Context.CommentRepository.Create(commentModel);
            Context.Save();

            return commentModel;
        }

        public IEnumerable<Comment> GetAllCommentByPostId(int postId)
        {
            return Context.CommentRepository.All().Where(m => m.PostId == postId);
        }

        public bool DeleteComment(int id, ref ErrorCode.PostServiceStatus status)
        {
            var commentToDelete = Context.CommentRepository.Find(id);

            if (commentToDelete != null)
            {
                Context.CommentRepository.Delete(commentToDelete);
                Context.Save();
                return true;
            }
            status = ErrorCode.PostServiceStatus.UnknownError;
            return false;
        }
    }
}
