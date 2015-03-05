using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.DataSource;
using AIronMan.Domain;
using System.Linq.Expressions;
using System.Data.Entity;
using AIronMan.Logging;
using AIronMan.Services.Providers;

namespace AIronMan.Services
{
    public class LayoutService : ServiceBase, ILayoutService
    {
        public LayoutService(UnitOfWork context, ICacheProvider cache, ILogger logger)
            : base(context, cache, logger)
        { }

        public IEnumerable<Layout> GetAllLayout()
        {
            IEnumerable<Layout> layouts = Cache.Get("layouts") as IEnumerable<Layout>;
            if (layouts == null)
            {
                layouts = Context.LayoutRepository.All();
                Cache.Set("layouts", layouts, 3600);
            }

            return layouts;
        }

        public IEnumerable<Layout> GetBlogLayout()
        {
            return GetAllLayout().Where(m => m.IsBlog);
        }

        public IEnumerable<Layout> GetSliderLayout()
        {
            return GetAllLayout().Where(m => m.IsSlider);
        }

        public IEnumerable<Layout> GetGalleryLayout()
        {
            return GetAllLayout().Where(m => m.IsGallery);
        }

        public IEnumerable<Layout> GetPortfolioLayout()
        {
            return GetAllLayout().Where(m => m.IsPotfolio).OrderBy(x => x.Name);
        }

        public IEnumerable<Layout> GetAllLayoutNoModule()
        {
            return GetAllLayout().Where(m => m.OnlyForModule == String.Empty);
        }
    }
}
