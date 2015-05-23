using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

using AIronMan.Domain;

namespace AIronMan.Services
{
    public interface ISiteService
    {
        Guid GetCurrentSiteId();
        Task<IEnumerable<Site>> Get();
        AIronMan.Domain.Site Create(string name, string url, string folderPath, String themeLocalization, bool isActive, ref ErrorCode.SiteServiceStatus status);
        AIronMan.Domain.Site Update(Domain.Site entity, ref ErrorCode.SiteServiceStatus status);
        int Delete(Guid id, ref ErrorCode.SiteServiceStatus status);

        Domain.Site GetCurrentSite();
    }
}
