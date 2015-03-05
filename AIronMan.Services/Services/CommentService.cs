using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.DataSource;
using AIronMan.Logging;
using AIronMan.Services.Providers;

namespace AIronMan.Services
{
    public class CommentService : ServiceBase, ICommentService
    {
        public CommentService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        { }

        public Domain.Comment CreateComment(Domain.Comment commentEntry, Domain.Mapping.SettingMap settings, bool isAdmin, ref ErrorCode.PostServiceStatus status)
        {
            DateTime crDate = DateTime.Now;
            //commentModel.Post = context.PostRepository.Find(commentModel.PostId);

            IEnumerable<String> spamWords = settings.SpamWords.Split(',').Select(m => m.Trim());

            if (spamWords.Any(item => commentEntry.Content.Contains(item)))
            {
                commentEntry.IsBlock = true;
                status = ErrorCode.PostServiceStatus.BlockCommentYouUseSpamWords;
            }

            commentEntry.IsAdmin = isAdmin;
            commentEntry.LmDate = crDate;
            commentEntry.CrDate = crDate;
            commentEntry.Visible = true;

            Context.CommentRepository.Create(commentEntry);
            Context.Save();

            return commentEntry;
        }


        public IEnumerable<Domain.Comment> GetAllCommentByPostId(int postId)
        {
            return Context.CommentRepository.All().Where(m => m.PostId == postId);
        }

        public IEnumerable<Domain.Comment> GetAllCommentByPortfolioNodeId(int portfolioNodeId)
        {
            return Context.CommentRepository.All().Where(m => m.PortfolioNodeId == portfolioNodeId);
        }


        public bool Delete(int id, ref ErrorCode.CommentServiceStatus status)
        {
            var commentToDelete = Context.CommentRepository.Find(id);

            if (commentToDelete != null)
            {
                Context.CommentRepository.Delete(commentToDelete);
                Context.Save();
                return true;
            }
            status = ErrorCode.CommentServiceStatus.UnknownError;
            return false;
        }


        public IEnumerable<Domain.Comment> GetSmallCommentsObjectForClientLayout(int blogId, int takeCount)
        {
            //var posts = context.PostRepository.All().Where(m => m.BlogId == blogId);

            var comments = Context.CommentRepository.All().Where(m => m.Post.BlogId == blogId && m.Visible == true && m.IsBlock == false);

            var small = comments.Select(m => new
            {
                //Id = m.Id,
                UserName = m.UserName,
                Content = m.Content,
                CrDate = m.CrDate,
                TitleUrl = m.Post.TitleUrl,
                Title = m.Post.Title,
                PostCrDate = m.Post.CrDate,
                BloggerName = m.Post.Blog.BloggerName,
                PostId = m.Post.Id
            }).OrderByDescending(m => m.CrDate)
            .Take(takeCount).ToList()
               .Select(m => new Domain.Comment()
               {
                   //Id = m.Id,
                   UserName = m.UserName,
                   Content = m.Content,
                   CrDate = m.CrDate,
                   Post = new Domain.Post()
                   {
                       Id = m.PostId,
                       TitleUrl = m.TitleUrl,
                       Title = m.Title,
                       CrDate = m.PostCrDate,
                       Blog = new Domain.Blog() { BloggerName = m.BloggerName }
                   }
               }).ToList();

            return small;
        }
    }
}
