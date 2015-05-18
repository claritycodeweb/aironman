using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;

namespace AIronMan.Repository {
    public class PortfolioHeaderRepository : Repository<PortfolioHeader>, IPortfolioHeaderRepository {
        public PortfolioHeaderRepository(DB context) : base(context) { }
    }
}
