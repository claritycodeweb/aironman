using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;

namespace AIronMan.Services {
    public interface ICommentService {
        Comment CreateComment(Comment commentEntry, AIronMan.Domain.Mapping.SettingMap settings, bool isAdmin, ref ErrorCode.PostServiceStatus status);
        IEnumerable<AIronMan.Domain.Comment> GetAllCommentByPostId(int postId);
        IEnumerable<AIronMan.Domain.Comment> GetAllCommentByPortfolioNodeId(int portfolioNodeId);
        bool Delete(int id, ref ErrorCode.CommentServiceStatus status);

        #region Client optimalization query
        IEnumerable<Domain.Comment> GetSmallCommentsObjectForClientLayout(int blogId, int takeCount);
        #endregion
    }
}
