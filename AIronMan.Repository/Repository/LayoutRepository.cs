using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;

namespace AIronMan.Repository {
    public class LayoutRepository : Repository<Layout>, ILayoutRepository {
        public LayoutRepository(DB context) : base(context) { }
    }
}
