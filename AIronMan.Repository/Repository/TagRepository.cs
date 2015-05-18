using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;
using System.Linq.Expressions;
using System.Data.Entity;

namespace AIronMan.Repository {
    public class TagRepository : Repository<Tag>, ITagRepository {
        public TagRepository(DB context) : base(context) { }

    }
}

