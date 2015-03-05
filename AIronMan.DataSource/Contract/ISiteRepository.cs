using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;


namespace AIronMan.DataSource {
    public interface ISiteRepository : IRepository<Site> {
        Guid GetCurrentSiteIdFromWebConfig();
    }
}
