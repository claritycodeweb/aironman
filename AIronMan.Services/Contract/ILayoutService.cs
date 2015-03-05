using AIronMan.Domain;
using System.Collections.Generic;


namespace AIronMan.Services
{
    public interface ILayoutService
    {
        IEnumerable<Layout> GetAllLayout();
        IEnumerable<Layout> GetBlogLayout();
        IEnumerable<Layout> GetSliderLayout();
        IEnumerable<Layout> GetGalleryLayout();
        IEnumerable<Layout> GetPortfolioLayout();

        IEnumerable<Layout> GetAllLayoutNoModule();
    }
}
