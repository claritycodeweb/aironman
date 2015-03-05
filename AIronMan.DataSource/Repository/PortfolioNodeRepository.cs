using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;

namespace AIronMan.DataSource {
    public class PortfolioNodeRepository : Repository<PortfolioNode>, IPortfolioNodeRepository  {
        public PortfolioNodeRepository(DB context) : base(context) { }
    }
}
