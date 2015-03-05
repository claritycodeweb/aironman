using AIronMan.Logging;
using AIronMan.Services;
using AIronMan.Services.Providers;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace AIronMan.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = BuildUnityContainer();

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IBlogService, BlogService>();
            container.RegisterType<IPostService, PostService>();
            container.RegisterType<ISettingService, SettingService>();
            container.RegisterType<ICacheProvider, DefaultCacheProvider>();
            container.RegisterType<IPageService, PageService>();
            container.RegisterType<IFileService, FileService>();
            container.RegisterType<ITagService, TagService>();
            container.RegisterType<ISiteService, SiteService>();
            container.RegisterType<IPageTemplateService, PageTemplateService>();
            container.RegisterType<ISliderService, SliderService>();
            container.RegisterType<ILayoutService, LayoutService>();
            container.RegisterType<IPortfolioService, PortfolioService>();
            container.RegisterType<ICommentService, CommentService>();
            container.RegisterType<ILangService, LangService>();
            container.RegisterType<ILogger, NLogger>();
            container.RegisterType<ICacheProvider, DefaultCacheProvider>();

            // e.g. container.RegisterType<ITestService, TestService>();

            return container;
        }
    }
}