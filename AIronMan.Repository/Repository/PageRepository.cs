using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;

namespace AIronMan.Repository {
    public class PageRepository: Repository<Page> , IPageRepository{
        public PageRepository(DB context) : base(context) { }
    }
}
