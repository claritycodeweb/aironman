using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;

namespace AIronMan.Repository {
    public class PortfolioNodeRepository : Repository<PortfolioNode>, IPortfolioNodeRepository  {
        public PortfolioNodeRepository(DB context) : base(context) { }
    }
}
