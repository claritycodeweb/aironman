using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;

namespace AIronMan.DataSource {
    public class PortfolioHeaderRepository : Repository<PortfolioHeader>, IPortfolioHeaderRepository {
        public PortfolioHeaderRepository(DB context) : base(context) { }
    }
}
