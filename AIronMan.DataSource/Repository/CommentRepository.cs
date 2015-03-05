using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;
using System.Linq.Expressions;
using System.Data.Entity;

namespace AIronMan.DataSource {
    public class CommentRepository : Repository<Comment>, ICommentRepository {
        public CommentRepository(DB context) : base(context) { }
    }
}
