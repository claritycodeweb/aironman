using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;

namespace AIronMan.DataSource {
    public class PostRepository : Repository<Post>, IPostRepository {
        public PostRepository(DB context) : base(context) { }
    }
}
