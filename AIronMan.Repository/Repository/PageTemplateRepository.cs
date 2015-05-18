using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;
using System.Configuration;

namespace AIronMan.Repository {
    public class PageTemplateRepository : Repository<PageTemplate>, IPageTemplateRepository {
        public PageTemplateRepository(DB context) : base(context) { }

    }
}
