using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;

namespace AIronMan.DataSource {
    public class PageRepository: Repository<Page> , IPageRepository{
        public PageRepository(DB context) : base(context) { }
    }
}
