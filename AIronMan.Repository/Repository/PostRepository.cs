using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;

namespace AIronMan.Repository {
    public class PostRepository : Repository<Post>, IPostRepository {
        public PostRepository(DB context) : base(context) { }
    }
}
