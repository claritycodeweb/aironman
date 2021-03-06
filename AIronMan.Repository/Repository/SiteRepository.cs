﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;
using System.Configuration;

namespace AIronMan.Repository
{
    public class SiteRepository : Repository<Site>, ISiteRepository
    {
        public SiteRepository(DB context) : base(context) { }
        public Guid GetCurrentSiteIdFromWebConfig()
        {
            return Guid.Parse(ConfigurationManager.AppSettings["SiteId"]);
        }
    }
}
