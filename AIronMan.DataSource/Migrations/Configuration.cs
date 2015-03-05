namespace AIronMan.DataSource.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AIronMan.Domain;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<AIronMan.DataSource.DB>
    {
        public Configuration()
        {
            /*
            Database.SetInitializer(new DropCreateDatabaseAlways<AIronMan.DataSource.DB>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; */
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AIronMan.DataSource.DB context)
        {
            new List<User> {
                        new User{
                                    Id = 1, UserName = "admin", Email="rafalpisarczyk@gmail.com",Password="BMLNNAgbhrV3JjNOL8+7GtSV9yL9++BsUTqG5WfyQ1Y=", PasswordSalt = "3EGmM/oOxh/Eg5/tHiVbbQ==", IsLockedOut = false ,CrDate= DateTime.Now, LmDate = DateTime.Now, IsApproved = true, 
                                    LastLoginDate = new DateTime(1870,1,1), LastPasswordChangeDate =  new DateTime(1870,1,1)
                            },
                        new User{
                                    Id = 2, UserName = "rafalp", Email="rafal@admin.pl",Password="CqAz8iFMnZdR1/SJtj5AlwTttbualZS48YzmcVGflqo=", PasswordSalt = "ORVbSflAOc4dk0TMfAZWXA==", IsLockedOut = false, CrDate= DateTime.Now, LmDate = DateTime.Now, IsApproved = true, 
                                    LastLoginDate = new DateTime(1870,1,1), LastPasswordChangeDate =  new DateTime(1870,1,1)
                            }
                    }.ForEach(b => context.Users.AddOrUpdate(s => s.Id, b));

            User adminUser = context.Users.Find(1);
            User rafal = context.Users.Find(2);

            new List<Role> {
                        new Role{ Name = "user", LmUser = adminUser, CrUser = adminUser, LmDate = DateTime.Now, CrDate = DateTime.Now},
                                            new Role{ Name = "admin", LmUser = adminUser, CrUser = adminUser, LmDate = DateTime.Now, CrDate = DateTime.Now},

                    }.ForEach(b => context.Roles.AddOrUpdate(s => s.Name, b));

            new List<Layout> { new AIronMan.Domain.Layout { Name = "_Layout", IsVisible = true, IsBlog = false, IsGallery = false, 
                        IsPotfolio = false, IsSlider = true, OnlyForModule="" }, 
                        new AIronMan.Domain.Layout { Name = "_LayoutSBPxD001", IsVisible = true, IsBlog = true, IsGallery = false, 
                        IsPotfolio = true, IsSlider = true, OnlyForModule="" }, 
                        new AIronMan.Domain.Layout { Name = "_LayoutPxR001", IsVisible = true, IsBlog = false, IsGallery = false, 
                        IsPotfolio = true, IsSlider = false, OnlyForModule="" }, 
                        new AIronMan.Domain.Layout { Name = "_LayoutBxR001", IsVisible = true, IsBlog = true, IsGallery = false, 
                        IsPotfolio = false, IsSlider = false, OnlyForModule="" }, 
                        new AIronMan.Domain.Layout { Name = "_LayoutPxL001", IsVisible = true, IsBlog = false, IsGallery = false, 
                        IsPotfolio = true, IsSlider = false, OnlyForModule="" },
                        new AIronMan.Domain.Layout { Name = "_LayoutPxD001", IsVisible = true, IsBlog = false, IsGallery = false, 
                        IsPotfolio = true, IsSlider = false, OnlyForModule="" },
                        new AIronMan.Domain.Layout { Name = "_LayoutPxT001", IsVisible = true, IsBlog = false, IsGallery = false, 
                        IsPotfolio = true, IsSlider = false, OnlyForModule="" },
                        new AIronMan.Domain.Layout { Name = "_LayoutPxFull3ColMax001", IsVisible = true, IsBlog = false, IsGallery = false, 
                        IsPotfolio = true, IsSlider = false, OnlyForModule="" },
                        new AIronMan.Domain.Layout { Name = "_LayoutSPxFull3ColMax001", IsVisible = true, IsBlog = false, IsGallery = false, 
                        IsPotfolio = true, IsSlider = true, OnlyForModule="" },
                        new AIronMan.Domain.Layout { Name = "_LayoutSubMxR001", IsVisible = true, IsBlog = false, IsGallery = false, 
                        IsPotfolio = false, IsSlider = false, OnlyForModule="" },
                        new AIronMan.Domain.Layout { Name = "_LayoutPxFull4ColMax001", IsVisible = true, IsBlog = false, IsGallery = false, 
                        IsPotfolio = true, IsSlider = false, OnlyForModule="" },
                        new AIronMan.Domain.Layout { Name = "_LayoutSPxFull4001", IsVisible = true, IsBlog = false, IsGallery = false, 
                        IsPotfolio = true, IsSlider = true, OnlyForModule="" },
                        new AIronMan.Domain.Layout { Name = "_LayoutContactGeoV1", IsVisible = true, IsBlog = false, IsGallery = false, 
                        IsPotfolio = false, IsSlider = false, OnlyForModule="" },
                        new AIronMan.Domain.Layout { Name = "_LayoutContactGeoV2Full", IsVisible = true, IsBlog = false, IsGallery = false, 
                        IsPotfolio = false, IsSlider = false, OnlyForModule="", Description = "Full page google map size" },
                                       new AIronMan.Domain.Layout { Name = "_LayoutSimple", IsVisible = true, IsBlog = false, IsGallery = false, IsPotfolio = false, IsSlider = false, OnlyForModule="" },
                                       new AIronMan.Domain.Layout { Name = "_LayoutContactGeo", IsVisible = true, IsBlog = false, IsGallery = false, IsPotfolio = false, IsSlider = false , OnlyForModule=""},
                                       new AIronMan.Domain.Layout { Name = "_LayoutContactSimple", IsVisible = true, IsBlog = false, IsGallery = false, IsPotfolio = false, IsSlider = false , OnlyForModule=""},
                                       new AIronMan.Domain.Layout { Name = "_Portfolio3ColumnsWithTextClassic", IsVisible = true, IsBlog = false, IsGallery = false, IsPotfolio = true, IsSlider = false, 
                                           OnlyForModule="PortfolioGroup" },
                                       new AIronMan.Domain.Layout { Name = "_Portfolio1ColumnsWithTextClassic", IsVisible = true, IsBlog = false, IsGallery = false, IsPotfolio = true, IsSlider = false, 
                                           OnlyForModule="PortfolioGroup" },
                                       new AIronMan.Domain.Layout { Name = "_Portfolio3ColumnsWithTextClassicResp", IsVisible = true, IsBlog = false, IsGallery = false, IsPotfolio = true, IsSlider = false, 
                                           OnlyForModule="PortfolioGroup" },
                                       new AIronMan.Domain.Layout { Name = "_PortfolioFullColumn", IsVisible = true, IsBlog = false, IsGallery = false, IsPotfolio = true, IsSlider = false, 
                                           OnlyForModule="PortfolioSingle" },
                                       new AIronMan.Domain.Layout { Name = "_PortfolioHalfColumnWithCategory", IsVisible = true, IsBlog = false, IsGallery = false, IsPotfolio = true, IsSlider = false, 
                                           OnlyForModule="PortfolioSingle" },
                                       new AIronMan.Domain.Layout { Name = "_BlogHalfColumnWithTags", IsVisible = true, IsBlog = true, IsGallery = false, IsPotfolio = false, IsSlider = false, 
                                           OnlyForModule="BlogSingle" },
                                       new AIronMan.Domain.Layout { Name = "_Blog1ColumnsTextWithTags", IsVisible = true, IsBlog = true, IsGallery = false, IsPotfolio = false, IsSlider = false, 
                                           OnlyForModule="BlogGroup" },
                                       new AIronMan.Domain.Layout { Name = "_Blog1ColumnsWithTextClassic", IsVisible = true, IsBlog = true, IsGallery = false, IsPotfolio = false, IsSlider = false, 
                                           OnlyForModule="BlogGroup" },
                                       new AIronMan.Domain.Layout { Name = "_PortfolioFullColumnWithProjectDetails", IsVisible = true, IsBlog = false, IsGallery = false, IsPotfolio = true, IsSlider = false, 
                                           OnlyForModule="PortfolioSingle" }
                    }.ForEach(b => context.Layouts.AddOrUpdate(s => s.Name, b));

            //new List<CategoryPortfolio> { new CategoryPortfolio { Name = "NET" }, 
            //                                          new CategoryPortfolio { Name = "Java" }, 
            //                                          new CategoryPortfolio { Name = "Portfolio" }, 
            //                                          new CategoryPortfolio { Name = "Blog" }}.ForEach(b => context.CategoryPortfolio.AddOrUpdate(b));

            new List<Tag> { 
                    new Tag { Name = "CSharp" }, 
                    new Tag { Name = "Programowanie" }, 
                    new Tag { Name = "NET" },
                    new Tag { Name = "Java" },
                    new Tag { Name = "Portfolio" },
                    new Tag { Name = "Blog" },
            }.ForEach(b => context.Tags.AddOrUpdate(s => s.Name, b));

            new List<Lang> { 
                        new Lang { LangCode="pl", Description="Polski - PL" },  
                        new Lang { LangCode="en", Description="English - EN" }
                    }.ForEach(b => context.Langs.AddOrUpdate(s => s.LangCode, b));

            ClarityPrepareData(context);
            ShadePrepareData(context);
            MindPrepareData(context);
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //to avoid creating duplicate seed data. E.g.

            //  context.People.AddOrUpdate(
            //    p => p.FullName,
            //    new Person { FullName = "Andrew Peters" },
            //    new Person { FullName = "Brice Lambson" },
            //    new Person { FullName = "Rowan Miller" }
            //  );

        }

        public void StartNetCms(DB context)
        {
            User adminUser = context.Users.Find(1);
            Guid guid = Guid.Parse("13D2E93D-F940-4FFF-A51E-A17308CA5F7D");

            new List<Site> {
                    new Site{Id=guid, Name = "StartWebsite", Url = "http://localhost/StartWebsite", FolderPath="C:\\inetpub\\wwwroot\\StartWebsite", IsActive = true,  CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now},
                }.ForEach(b => context.Sites.AddOrUpdate(s => s.Id, b));
            Site site = context.Sites.Find(guid);

            new List<Setting> {
                    new Setting {Site = site, SiteId = site.Id, Name = "smtp-server",Description = "The server name for your SMTP server.",DisplayName = "Server",Value = "smtp.live.com"},
                    new Setting {Site = site, SiteId = site.Id, Name = "smtp-from",Description = "The email address from which emails will be sent.",DisplayName = "From",Value = "r.pisarczyk@hotmail.com"},
                    new Setting {Site = site, SiteId = site.Id, Name = "smtp-auth-username",Description = "If your SMTP server requires authentication, enter your username here, or leave it empty.",DisplayName = "Username",Value = "your-email"},
                    new Setting {Site = site, SiteId = site.Id, Name = "smtp-to",Description = "The email address you want comment notification emails to be sent to.",DisplayName = "To",Value = "your-email"},
                    new Setting {Site = site, SiteId = site.Id, Name = "shortcuticon",Description = "Shortcut Icon",DisplayName = "Shortcut Icon",Value = "icon/clarity.png"},
                    new Setting {Site = site, SiteId = site.Id, Name = "backendcolor",Description = "Backend color.",DisplayName = "Backend Color",Value = "#71b1d1"},
                    new Setting {Site = site, SiteId = site.Id, Name = "logo",Description = "Logo.",DisplayName = "Logo",Value = "logos/clarity_logo_v0.png"},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-theme",Description = "Theme being used by the blog at the moment",DisplayName = "Theme",Value = "ClarityTheme"},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-title",Description = "Text: The title shown at the top in the browser.",DisplayName = "Title",Value = "Rafa³ Pisarczyk - home website"},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-introduction",Description = "Markdown: The introductory text that is shown on the home page.",DisplayName = "Introduction",Value = "Welcome to your my page."},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-links",Description = "HTML: A list of links shown at the top of each page.",DisplayName = "Main Links",Value = "<li><a href=\"/projects\">Projects</a></li>"},
                    new Setting {Site = site, SiteId = site.Id, Name = "search-author",Description = "Text: Your name.",DisplayName = "Author",Value = "Pisarczyk Rafa³"},
                    new Setting {Site = site, SiteId = site.Id, Name = "search-keywords",Description = "Comma-separated text: Keywords shown to search engines.",DisplayName = "Keywords",Value = ".net, c#, test"},
                    new Setting {Site = site, SiteId = site.Id, Name = "search-description",Description = "Text: The description shown to search engines in the meta description tag.",DisplayName = "Description",Value = "My website."},
                    new Setting {Site = site, SiteId = site.Id, Name = "spam-blacklist",Description = "Comments with these words (case-insensitive) will automatically be marked as spam, in addition to Akismet.",DisplayName = "Spam Blacklist",Value = "casino"},
                    new Setting {Site = site, SiteId = site.Id, Name = "default-page",Description = "Page name: When users visit the root (//) of your site, it will be equivalent to visiting the page you specify here.",DisplayName = "Default Page",Value = "home"},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-footer",Description = "HTML: This will appear at the bottom of the page - use it to add copyright information, links to any web hosts, people or technologies that helped you to build the site, and so on.",DisplayName = "Footer",Value = "<p>Powered by <a href=\"http://www.claritycode.com\">ClarityCode</a>, the blog engine of real developers.</p>"},                   
                    new Setting {Site = site, SiteId = site.Id, Name = "enable-disqus-comments",Description = "Enable the Disqus commenting system. Note - this will still require the theme to also use Disqus.",DisplayName = "Enable Disque Comments",Value = "False"},
                    new Setting {Site = site, SiteId = site.Id, Name = "disqus-shortname",Description = "The shortname of your Disqus comments, configured on the Disqus website.",DisplayName = "Shortname for Disqus",Value = "your-disqus-page"},
                }.ForEach(b => context.Settings.AddOrUpdate(s => new { s.Name, s.SiteId }, b));
        }

        public void ClarityPrepareData(DB context)
        {
            User adminUser = context.Users.Find(1);
            Guid guid = Guid.Parse("13D2E93D-F940-4FFF-A51E-A17308CA5F7D");
            new List<Site> {
                    new Site{Id=guid, Name = "Clarity", Url = "http://localhost/DemoEFCF", FolderPath="D:\\vs2010\\DemoEFCF\\DemoEFCF", IsActive = true,  CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now},
                }.ForEach(b => context.Sites.AddOrUpdate(s => s.Id, b));
            Site site = context.Sites.Find(guid);

            //ICollection<Tag> tags = new List<Tag> { new Tag { Name = "C#" }, new Tag { Name = "Programowanie" } };
            ICollection<Comment> comments = new List<Comment> { 
                    new Comment { UserName = adminUser.UserName, Content = "Great article.", Visible = true, IsAdmin = true, Email = adminUser.Email, HomePage = "claritycode.pl", CrDate = DateTime.Now, LmDate = DateTime.Now, }, 
                    new Comment { UserName = "Alex", Content = "One of the best.", Visible = true, IsAdmin = false, Email = "admini@wp.pl", HomePage = "claritycode.pl", CrDate = DateTime.Now, LmDate = DateTime.Now, } };

            ICollection<Tag> categoryPortfolio = context.Tags.Local.AsQueryable().ToList();

            ICollection<Tag> tags = context.Tags.Local.AsQueryable().ToList();

            new List<Blog>{ 
                    new Blog {Site = site, SiteId =  site.Id, BloggerName = "dot-net", 
                            LayoutForGroupPost="_Blog1ColumnsTextWithTags", LayoutForSinglePost="_BlogHalfColumnWithTags", 
                            Title = "My Code First Blog", CrDate = DateTime.Now, LmDate = DateTime.Now,CrUser = adminUser , LmUser = adminUser, IsActive = true,
                            Posts=new List<Post> {
                                new Post { IsVisible =  true,  EnableComments = true, Title="C# description" ,CrDate=System.DateTime.Now, LmDate=System.DateTime.Now, ShortContent = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit", Content="Hello work with new ef code first", CrUser = adminUser , LmUser = adminUser, MetaTitle = "Post 1", Tags = tags , Comments = comments},
                                new Post { IsVisible =  true, EnableComments = true, Title="JUit tests report",CrDate=System.DateTime.Now.AddMilliseconds(10), LmDate=System.DateTime.Now.AddMilliseconds(10), ShortContent ="<img src='/DemoEFCF/images/shadetheme/thumbs/iStock_000006026401Medium-70x50.jpg' alt='' title='This is a Slide example' height='50' width='70' class=\"picture\" style=\"padding-top:5px\">  Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam ", Content="<img src='/DemoEFCF/images/shadetheme/thumbs/iStock_000006026401Medium-70x50.jpg' alt='' title='This is a Slide example' height='50' width='70' class=\"picture\" style=\"padding-top:5px\">  Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam  GoodBay work with entity framework", CrUser = adminUser , MetaTitle = "Post 1",LmUser = adminUser,Tags = tags.Where(m=>m.Name.ToLower() == "Java".ToLower()).ToList() },
                                new Post { IsVisible =  true, EnableComments = false, Title="EntityFramework night",CrDate=System.DateTime.Now.AddMilliseconds(20), LmDate=System.DateTime.Now.AddMilliseconds(20), ShortContent="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", Content="GoodBay work with entity framework", CrUser = adminUser , MetaTitle = "Post 1",LmUser = adminUser,Tags = tags , DisableComments = true}
                            }
                    },
                    new Blog {Site = site, SiteId =  site.Id, BloggerName = "cooking", LayoutForGroupPost = "_Blog1ColumnsTextWithTags", LayoutForSinglePost="_BlogHalfColumnWithTags", Title = "My Life as a Blog",CrDate = DateTime.Now, LmDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser}
                }.ForEach(b => context.Blogs.AddOrUpdate(s => new { s.BloggerName, s.SiteId }, b));

            new List<PortfolioHeader> {
                    new PortfolioHeader{ Site = site, SiteId= site.Id, Name="ThemesClarity", EnableComments=true,  
                        LayoutForGroupProject="_Portfolio3ColumnsWithTextClassic", LayoutForSingleProject="_PortfolioFullColumn", 
                        Description = "Layout project in .net", Title="Themes", CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now, 
                        PortfolioNodes = new List<PortfolioNode>() {
                            new PortfolioNode {
                                Author = "Rafa³ Pisarczyk", Content = "A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link. Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", ShortContent="A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.",
                                Title = "Clarity", IsVisible = true, ImageProjectLocalPath = "portfolio/full/clarity.png", ImageProjectThumbLocalPath="portfolio/banner/clarity.png", 
                                ProjectUrlPath="http://www.claritycodeweb.com/claritytheme", ImageProjectUrlPath = "", ImageProjectThumbUrlPath = "", Tags = categoryPortfolio,
                                //Comments = comments,
                                CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now },
                            new PortfolioNode {
                                Author = "Rafa³ Pisarczyk", Content = "A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link. Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", ShortContent="A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.",
                                Title = "Shade", IsVisible = true, ImageProjectLocalPath = "portfolio/full/shade.png", ImageProjectThumbLocalPath="portfolio/banner/shade.png", 
                                ProjectUrlPath="http://www.claritycodeweb.com/shadetheme", ImageProjectUrlPath = "", ImageProjectThumbUrlPath = "", Tags = categoryPortfolio.Where(m=>m.Name == "Java").ToList(),
                                //Comments = comments,
                                CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now },
                            new PortfolioNode {
                                Author = "Rafa³ Pisarczyk", Content = "A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.", ShortContent="A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.",
                                Title = "Optima", IsVisible = true, ImageProjectLocalPath = "portfolio/full/optima.png", ImageProjectThumbLocalPath="portfolio/banner/optima.png", 
                                ProjectUrlPath="http://www.claritycodeweb.com/optimatheme", ImageProjectUrlPath = "", ImageProjectThumbUrlPath = "", Tags = categoryPortfolio.Take(1).ToList(),
                                CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now.AddMilliseconds(10), LmDate = DateTime.Now.AddMilliseconds(10) },
                            new PortfolioNode {
                                Author = "Rafa³ Pisarczyk", Content = "A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.", ShortContent="A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.",
                                Title = "Mind", IsVisible = true, ImageProjectLocalPath = "portfolio/full/mind.png", ImageProjectThumbLocalPath="portfolio/banner/mind.png", 
                                ProjectUrlPath="http://www.claritycodeweb.com/mindtheme", ImageProjectUrlPath = "", ImageProjectThumbUrlPath = "", Tags = categoryPortfolio.Take(1).ToList(),
                                CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now.AddMilliseconds(10), LmDate = DateTime.Now.AddMilliseconds(10) }
                        }
                    }
                }.ForEach(b => context.PortfolioHeaders.AddOrUpdate(s => s.Name, b));

            new List<SliderHeader> {
                    new SliderHeader {Name = "Clarity", Description= "slider for clarity theme", Transition = "slideRight", Speed = 2000, Pause = 5, LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser,
                        SliderSteps = new List<SliderStep>() {
                            new SliderStep(){ Name = "Step0", ImageLocalPath = "/_t_clarity/slider/step/clarity_front.png", ImageBackground = "", Title = "CLARITY", Content = "Clarity uses a flexible frontpage that uses an amazing slideshow and can display any amount of tabed content, delivered by NetSimpleCMS - admin.", IsActive = true, LinkTo = "http://www.claritycodeweb.com", LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser},
                            new SliderStep(){ Name = "Step1", ImageLocalPath = "/_t_clarity/slider/step/shade_front.png", ImageBackground = "", Title = "SHADE", Content = "Shade uses a flexible frontpage that uses an amazing slideshow and can display any amount of tabed content, delivered by NetSimpleCMS - admin.", IsActive = true, LinkTo = "http://www.claritycodeweb.com/shadetheme", LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser},
                            new SliderStep(){ Name = "Step2", ImageLocalPath = "/_t_clarity/slider/step/optima_theme.png", ImageBackground = "", Title = "OPTIMA", Content = "Optima uses a flexible frontpage that uses an amazing slideshow and can display any amount of tabed content, delivered by NetSimpleCMS - admin.", IsActive = true,  LinkTo = "http://www.claritycodeweb.com/optimatheme",   LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser},
                        new SliderStep(){ Name = "Step3", ImageLocalPath = "/_t_clarity/slider/step/shade_front.png", ImageBackground = "", Title = "MIND", Content = "Mind uses a flexible frontpage that uses an amazing slideshow and can display any amount of tabed content, delivered by NetSimpleCMS - admin.", IsActive = true, LinkTo = "http://www.claritycodeweb.com/optimatheme",  LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser}
                        }},
                }.ForEach(b => context.SliderHeaders.AddOrUpdate(s => s.Name, b));

            SliderHeader slider = context.SliderHeaders.Local.Where(m => m.Name.ToLower() == "Clarity".ToLower()).FirstOrDefault();
            PortfolioHeader portfolio = context.PortfolioHeaders.Local.Where(m => m.Name.ToLower() == "ThemesClarity".ToLower() && m.SiteId == site.Id).FirstOrDefault();
            Blog blog = context.Blogs.Local.Where(m => m.BloggerName == "dot-net" &&  m.SiteId == site.Id).FirstOrDefault();

            new List<PageTemplate> {
                new PageTemplate {TemplateId = 1, Lang = "en", Site =  site, SiteId =site.Id, Name = "_main001", Content = "<div class=\"font-poiret-one callout hero-text \">      <div class=\"font-century-gothic size26\">          <p>              Hello! My name is Rafa³, this is my home website, where i offer you a beautiful              Theme with tons of cool possibilities!</p>          </p>      </div>  </div>  <div class=\"main-box\">      <div class=\"box firstcols\">          <div class=\"title\">              <h4>                  MOBILE OPTIMIZED</h4>          </div>          <div class=\"content\">              <p>                  Responsive Design and Slideshows with touchcontrol.</p>              <a href=\"#\">Read more</a>          </div>      </div>      <div class=\"box\">          <div class=\"title\">              <h4>                  Flexible Layouts</h4>          </div>          <div class=\"content\">              <p>                  The theme uses a flexible template system that enables you to create stunning pages                  out of the box with minimum coding knowledge at all.</p>              <a href=\"#\">Read more</a>          </div>      </div>      <div class=\"box\">          <div class=\"title\">              <h4>                  2D Slider</h4>          </div>          <div class=\"content\">              <p>                  Very powerful and beautiful 2DSlider with many different transictions.</p>              <a href=\"#\">Read more</a>          </div>      </div>      <div class=\"box lastcols\">          <div class=\"title\">              <h4>                  Portfolio galleries              </h4>          </div>          <div class=\"content\">              <p>                  Business or Portfolio, Blog or Photography. Everything already included</p>              <a href=\"#\">Read more</a>          </div>      </div>  </div>  <div class=\"line-auto-width p30\">  </div>  <div class=\"font-century-gothic size26\">      <p>          Recent Themes      </p>  </div>  ",
                IsActive = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now.AddMilliseconds(10), LmDate = DateTime.Now.AddMilliseconds(10)},
                new PageTemplate {TemplateId = 1, Lang = "pl", Site =  site, SiteId =site.Id, Name = "_main001", Content = "<div class=\"font-poiret-one callout hero-text \">      <div class=\"font-century-gothic size26\">          <p>              Czeœæ! My name is Rafa³, this is my home website, where i offer you a beautiful              Theme with tons of cool possibilities!</p>          </p>      </div>  </div>  <div class=\"main-box\">      <div class=\"box firstcols\">          <div class=\"title\">              <h4>                  MOBILE OPTIMIZED</h4>          </div>          <div class=\"content\">              <p>                  Responsive Design and Slideshows with touchcontrol.</p>              <a href=\"#\">Read more</a>          </div>      </div>      <div class=\"box\">          <div class=\"title\">              <h4>                  Flexible Layouts</h4>          </div>          <div class=\"content\">              <p>                  The theme uses a flexible template system that enables you to create stunning pages                  out of the box with minimum coding knowledge at all.</p>              <a href=\"#\">Read more</a>          </div>      </div>      <div class=\"box\">          <div class=\"title\">              <h4>                  2D Slider</h4>          </div>          <div class=\"content\">              <p>                  Very powerful and beautiful 2DSlider with many different transictions.</p>              <a href=\"#\">Read more</a>          </div>      </div>      <div class=\"box lastcols\">          <div class=\"title\">              <h4>                  Portfolio galleries              </h4>          </div>          <div class=\"content\">              <p>                  Business or Portfolio, Blog or Photography. Everything already included</p>              <a href=\"#\">Read more</a>          </div>      </div>  </div>  <div class=\"line-auto-width p30\">  </div>  <div class=\"font-century-gothic size26\">      <p>          Recent Themes      </p>  </div>  ",
                IsActive = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now.AddMilliseconds(10), LmDate = DateTime.Now.AddMilliseconds(10)},
                new PageTemplate {TemplateId = 2, Lang = "en", Site =  site, SiteId =site.Id, Name = "AboutMe_page", Content = "<div class=\"post-content\">  <p style=\"padding-top:10px\">  My name is Rafa³ and I have been a .net software developer for almost 3 years now.  I started learning programming when I was in grade school, using C++. From there I’ve branched out across several different platforms and languages, and would generally classify myself as a jack of all trades.  I tend to stick with Microsoft based platforms but that is mostly due to the volume and types of work available in my area, but I think .NET is one of the best MS product.  </p>  </br>  <p>  I started with .NET programming shortly after .NET 2.0 was released.  I have continued to use .NET in various positions and in work I’ve done for fun.  I think the platform is quite robust and it helps with overall productivity and I think helps to improve the quality of the code.  I am now using features of the .NET 4.5 Framework, including the latest releases of Entity, as well as the new async and parallel task features provided by it.  <p>  </br>  <p>  I put this site up in the hopes of sharing some of the knowledge I’ve gained and will tend to focus on the solutions to problems that really made me work to diagnose and resolve.   </p>  <p>  If you have any questions, comments or orders, please feel free to email <b>rafalpisarczyk@gmail.com</b>.  Thanks for stopping by!  </p>  </br>  <ul><p> <b>Technologies</b> </p>  <li>  - JAVE SE 6.0, Spring MVC 3.0, GAE, Grails  </li>  <li>  - .NET 4.0, MVC3/4, WPF, WinForms  </li>  <li>  - C++, QT Developer  </li>  <li>  - MSSQL Server 2008R2,2012 (T-SQL)  </li>  <li>  - Oracle 11g (PL/SQL)  </li>  <li>  - Postgresql (PL/PGSQL)  </li>  <li>  - JS, (JQuery)   </li>  </div>",
                IsActive = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now.AddMilliseconds(10), LmDate = DateTime.Now.AddMilliseconds(10)},
                new PageTemplate {TemplateId = 2, Lang = "pl", Site =  site, SiteId =site.Id, Name = "AboutMe_page", Content = "<div class=\"post-content\">  <p style=\"padding-top:10px\">  My name is Rafa³ and I have been a .net software developer for almost 3 years now.  I started learning programming when I was in grade school, using C++. From there I’ve branched out across several different platforms and languages, and would generally classify myself as a jack of all trades.  I tend to stick with Microsoft based platforms but that is mostly due to the volume and types of work available in my area, but I think .NET is one of the best MS product.  </p>  </br>  <p>  I started with .NET programming shortly after .NET 2.0 was released.  I have continued to use .NET in various positions and in work I’ve done for fun.  I think the platform is quite robust and it helps with overall productivity and I think helps to improve the quality of the code.  I am now using features of the .NET 4.5 Framework, including the latest releases of Entity, as well as the new async and parallel task features provided by it.  <p>  </br>  <p>  I put this site up in the hopes of sharing some of the knowledge I’ve gained and will tend to focus on the solutions to problems that really made me work to diagnose and resolve.   </p>  <p>  If you have any questions, comments or orders, please feel free to email <b>rafalpisarczyk@gmail.com</b>.  Thanks for stopping by!  </p>  </br>  <ul><p> <b>Technologies</b> </p>  <li>  - JAVE SE 6.0, Spring MVC 3.0, GAE, Grails  </li>  <li>  - .NET 4.0, MVC3/4, WPF, WinForms  </li>  <li>  - C++, QT Developer  </li>  <li>  - MSSQL Server 2008R2,2012 (T-SQL)  </li>  <li>  - Oracle 11g (PL/SQL)  </li>  <li>  - Postgresql (PL/PGSQL)  </li>  <li>  - JS, (JQuery)   </li>  </div>",
                IsActive = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now.AddMilliseconds(10), LmDate = DateTime.Now.AddMilliseconds(10)},
                new PageTemplate {TemplateId = 3, Lang = "en", Site =  site, SiteId =site.Id, Name = "contact_p1", Content = "<div class=\"post-content\">     <div class=\"title\">        Success isn't always about 'GREATNESS'. It's about consistency. Consistent hard work gains success. Greatness will come.!        <div style=\"padding-bottom:20px\">          </div>     </div>     At vero eos et accusamus et iusto odios un dignissimos ducimus qui blan ditiis prasixer esentium voluptatum un deleniti atqueste sites excep turiitate non providentsimils. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, consequunturser magni dolores eos qui ratione voluptatem sequi nesciunt. Lorem ipsum dolor sit amet isse potenti. Vesquam ante aliquet lacusemper elit. Cras neque nulla, convallis non commodo et, euismod nonsese.     <p></p>  </div>",
                IsActive = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now.AddMilliseconds(10), LmDate = DateTime.Now.AddMilliseconds(10)},
                new PageTemplate {TemplateId = 3, Lang = "pl", Site =  site, SiteId =site.Id, Name = "contact_p1", Content = "<div class=\"post-content\">     <div class=\"title\">        This is the best choice!        <div style=\"padding-bottom:20px\">          </div>     </div>     At vero eos et accusamus et iusto odios un dignissimos ducimus qui blan ditiis prasixer esentium voluptatum un deleniti atqueste sites excep turiitate non providentsimils. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, consequunturser magni dolores eos qui ratione voluptatem sequi nesciunt. Lorem ipsum dolor sit amet isse potenti. Vesquam ante aliquet lacusemper elit. Cras neque nulla, convallis non commodo et, euismod nonsese.     <p></p>  </div>",
                IsActive = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now.AddMilliseconds(10), LmDate = DateTime.Now.AddMilliseconds(10)},            
            }.ForEach(b => context.PageTemplates.AddOrUpdate(s => new { s.Name, s.SiteId, s.TemplateId, s.Lang }, b));

            new List<Page> { new Page { Site = site, SiteId = site.Id, Name = "Home", PageParentId = null, MenuTitle="Dashboard", DisplayPageTitle= false,
                Url = "home", PageTitle = "Welcome!", PageLayout="_LayoutSPxFull4001",  MetaTitle = "ClarityCode - CMS and themes",
                MetaDescription = ".net, java, szablony www, web development, themes, responsible web design Rafa³ Pisarczyk ClarityCodeWeb - CMS, budowa stron internetowych", 
                MetaKeywords = ".Net,Net,C#,web development,sql,themes,javascript,js,jquery,java,web design,respansywny,responsible,szablony www,cms,claritycode,claritycodeweb", Authorized = "", 
                MainMenu = true, SortOrder = 1, Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now, PageTempleteContentId = 1, 
                        SliderHeader = slider, SliderHeaderId = slider.Id, PortfolioHeader = portfolio, PortfolioHeaderId =  portfolio.Id }, 
                    new Page { Site = site, SiteId = site.Id, Name = "About", PageParentId = null, Url = "about", MenuTitle="O mnie" ,
                        DisplayPageTitle = true , PageTitle = "Short story about me.", PageLayout="_LayoutContactSimple",  
                        MetaTitle = "ClarityCode - CMS and themes", MetaDescription = ".net, java, szablony www, web development, themes, responsible web design Rafa³ Pisarczyk ClarityCodeWeb - CMS, budowa stron internetowych", 
                        MetaKeywords = ".Net,Net,C#,web development,sql,themes,javascript,js,jquery,java,web design,respansywny,responsible,szablony www,cms,claritycode,claritycodeweb", Authorized = "", 
                        MainMenu = true, PageTempleteContentId = 2, 
                        SortOrder = 2, Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now }, 
                    new Page { Site = site, SiteId = site.Id,  Name = "Blog", PageParentId = null, Url = "blog/dot-net", MenuTitle="O mnie" , 
                        DisplayPageTitle = true , PageTitle = "C# tutorials", PageLayout="_LayoutSimple",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 3, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now }, 
                    new Page { Site = site, SiteId = site.Id,  Name = "Themes", PageParentId = null, Url = "themes", MenuTitle="Latest Themes" , 
                        DisplayPageTitle = true , PageTitle = "Recent Themes", PageLayout="_LayoutPxFull3ColMax001",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 4, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now , PortfolioHeader = portfolio, PortfolioHeaderId = portfolio.Id}, 
                    new Page { Site = site, SiteId = site.Id, Name = "Contact", PageParentId = null, Url = "contact", MenuTitle="Contact me." , 
                        DisplayPageTitle = true , PageTitle = "Contact me if you need support", PageLayout="_LayoutContactGeo",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 5, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now}, 
                    new Page { Site = site, SiteId = site.Id, Name = "Template Files", PageParentId = null, Url = "template", MenuTitle="Contact me." , 
                        DisplayPageTitle = true , PageTitle = "Template", PageLayout="_LayoutSubMxR001",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 6, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now}, 
                    new Page { Site = site, SiteId = site.Id, Name = "Locale", PageParentId = null, Url = "localization", MenuTitle=null ,
                        DisplayPageTitle = false , PageTitle = "Short story about me.", PageLayout="_LayoutContactGeoV2Full",  
                        MetaTitle = "ClarityCode - CMS and themes", MetaDescription = ".net, java, szablony www, web development, themes, responsible web design Rafa³ Pisarczyk ClarityCodeWeb - CMS, budowa stron internetowych", 
                        MetaKeywords = ".Net,Net,C#,web development,sql,themes,javascript,js,jquery,java,web design,respansywny,responsible,szablony www,cms,claritycode,claritycodeweb", Authorized = "", 
                        MainMenu = true, PageTempleteContentId = 3, 
                        SortOrder = 7, Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now }, 
                    new Page { Site = site, SiteId = site.Id, Name = "Page: Sidebar Right", PageParentId = null, Url = "pagesidebarright", MenuTitle="" , 
                        DisplayPageTitle = true , PageTitle = "Page: Sidebar Right", PageLayout="_LayoutSubMxR001",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 8, PageTempleteContentId = 3, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now},
                    new Page { Site = site, SiteId = site.Id, Name = "Blog: Sidebar Right", PageParentId = null, Url = "pagesidebarright1", MenuTitle="" , 
                        DisplayPageTitle = true , PageTitle = "Blog: Sidebar Right", PageLayout="_LayoutBxR001",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 9, PageTempleteContentId = 3, Blog = blog, BlogId = blog.Id,
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now},
                    new Page { Site = site, SiteId = site.Id, Name = "Portfolio: Side Top", PageParentId = null, Url = "pageportfoliotop", MenuTitle="" ,  PortfolioHeader = portfolio, PortfolioHeaderId =  portfolio.Id, 
                        DisplayPageTitle = true , PageTitle = "page portfolio top", PageLayout="_LayoutPxT001",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 10, PageTempleteContentId = 3, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now},
                    new Page { Site = site, SiteId = site.Id, Name = "Portfolio with Blog", PageParentId = null, Url = "pageportfolioblog", MenuTitle="" ,
                        DisplayPageTitle = true , PageTitle = "Portfolio with Blog", PageLayout="_LayoutSBPxD001",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 11, PageTempleteContentId = 3, Blog = blog, BlogId = blog.Id, PortfolioHeader = portfolio, PortfolioHeaderId =  portfolio.Id, SliderHeader = slider, SliderHeaderId = slider.Id,
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now},
                }.ForEach(b => context.Pages.AddOrUpdate(s => new { s.Name, s.SiteId }, b));

            context.SaveChanges();

            int templatePageId = context.Pages.Local.Where(m => m.SiteId == site.Id && m.Name.ToLower() == "template files").FirstOrDefault().Id;

            //Page templatePage =  context.Pages.Local.Where(m => m.SiteId == site.Id && m.Name.ToLower() == "template files").FirstOrDefault();

            new List<Page> { new Page { Site = site, SiteId = site.Id, Name = "Locale", PageParentId = templatePageId, /*PageParent = templatePage,*/ Url = "localization", MenuTitle=null ,
                        DisplayPageTitle = false , PageTitle = "Short story about me.", PageLayout="_LayoutContactGeoV2Full",  
                        MetaTitle = "ClarityCode - CMS and themes", MetaDescription = ".net, java, szablony www, web development, themes, responsible web design Rafa³ Pisarczyk ClarityCodeWeb - CMS, budowa stron internetowych", 
                        MetaKeywords = ".Net,Net,C#,web development,sql,themes,javascript,js,jquery,java,web design,respansywny,responsible,szablony www,cms,claritycode,claritycodeweb", Authorized = "", 
                        MainMenu = true, PageTempleteContentId = 3, 
                        SortOrder = 7, Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now },
                    new Page { Site = site, SiteId = site.Id, Name = "Page: Sidebar Right", PageParentId = templatePageId, /*PageParent = templatePage,*/ Url = "pagesidebarright", MenuTitle="Contact me." , 
                        DisplayPageTitle = true , PageTitle = "Page: Sidebar Right", PageLayout="_LayoutSubMxR001",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 8, PageTempleteContentId = 3, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now},
                    new Page { Site = site, SiteId = site.Id, Name = "Blog: Sidebar Right",  PageParentId = templatePageId,  Url = "pagesidebarright1", MenuTitle="" , Blog = blog, BlogId = blog.Id,
                        DisplayPageTitle = true , PageTitle = "Blog: Sidebar Right", PageLayout="_LayoutBxR001",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 9, PageTempleteContentId = 3, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now},
                    new Page { Site = site, SiteId = site.Id, Name = "Portfolio: Side Top", PageParentId = templatePageId, Url = "pageportfoliotop", MenuTitle="" , PortfolioHeader = portfolio, PortfolioHeaderId =  portfolio.Id,
                        DisplayPageTitle = true , PageTitle = "page portfolio top", PageLayout="_LayoutPxT001",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 10, PageTempleteContentId = 3, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now},
                    new Page { Site = site, SiteId = site.Id, Name = "Portfolio with Blog", PageParentId = templatePageId, Url = "pageportfolioblog", MenuTitle="" ,
                        DisplayPageTitle = true , PageTitle = "Portfolio with Blog", PageLayout="_LayoutSBPxD001",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 11, PageTempleteContentId = 3, Blog = blog, BlogId = blog.Id, PortfolioHeader = portfolio, PortfolioHeaderId =  portfolio.Id, SliderHeader = slider, SliderHeaderId = slider.Id,
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now},
            }.ForEach(b => context.Pages.AddOrUpdate(s => new { s.Name, s.SiteId }, b));


            new List<Setting> {
                    new Setting {Site = site, SiteId = site.Id, Name = "smtp-server",Description = "The server name for your SMTP server.",DisplayName = "Server",Value = "smtp.live.com"},
                    new Setting {Site = site, SiteId = site.Id, Name = "smtp-from",Description = "The email address from which emails will be sent.",DisplayName = "From",Value = "r.pisarczyk@hotmail.com"},
                    new Setting {Site = site, SiteId = site.Id, Name = "smtp-auth-username",Description = "If your SMTP server requires authentication, enter your username here, or leave it empty.",DisplayName = "Username",Value = "r.pisarczyk@hotmail.com"},
                    new Setting {Site = site, SiteId = site.Id, Name = "smtp-to",Description = "The email address you want comment notification emails to be sent to.",DisplayName = "To",Value = "r.pisarczyk@hotmail.com"},
                    new Setting {Site = site, SiteId = site.Id, Name = "shortcuticon",Description = "Shortcut Icon",DisplayName = "Shortcut Icon",Value = "icon/clarity.png"},
                    new Setting {Site = site, SiteId = site.Id, Name = "backendcolor",Description = "Kolor t³a.",DisplayName = "Backend Color",Value = "#71b1d1"},
                    new Setting {Site = site, SiteId = site.Id, Name = "logo",Description = "Logo.",DisplayName = "Logo",Value = "logos/clarity_logo_v0.png"},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-theme",Description = "Theme being used by the blog at the moment",DisplayName = "Theme",Value = "ClarityTheme"},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-title",Description = "Text: The title shown at the top in the browser.",DisplayName = "Title",Value = "ClarityCode - CMS and themes by Rafa³ Pisarczyk"},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-introduction",Description = "Markdown: The introductory text that is shown on the home page.",DisplayName = "Introduction",Value = "Welcome to your my page."},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-links",Description = "HTML: A list of links shown at the top of each page.",DisplayName = "Main Links",Value = "<li><a href=\"/projects\">Projects</a></li>"},
                    new Setting {Site = site, SiteId = site.Id, Name = "search-author",Description = "Text: Your name.",DisplayName = "Author",Value = "Pisarczyk Rafa³"},
                    new Setting {Site = site, SiteId = site.Id, Name = "search-keywords",Description = "Comma-separated text: Keywords shown to search engines.",DisplayName = "Keywords",Value = ".net, c#, test"},
                    new Setting {Site = site, SiteId = site.Id, Name = "search-description",Description = "Text: The description shown to search engines in the meta description tag.",DisplayName = "Description",Value = "Rafa³ Pisarczyk ClarityCodeWeb - CMS, .net, java, szablony www, web development, themes, responsible web design, budowa stron internetowych"},
                    new Setting {Site = site, SiteId = site.Id, Name = "spam-blacklist",Description = "Comments with these words (case-insensitive) will automatically be marked as spam, in addition to Akismet.",DisplayName = "Spam Blacklist",Value = "casino"},
                    new Setting {Site = site, SiteId = site.Id, Name = "default-page",Description = "Page name: When users visit the root (//) of your site, it will be equivalent to visiting the page you specify here.",DisplayName = "Default Page",Value = "home"},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-footer",Description = "HTML: This will appear at the bottom of the page - use it to add copyright information, links to any web hosts, people or technologies that helped you to build the site, and so on.",DisplayName = "Footer",Value = "<p>Powered by <a href=\"http://www.claritycode.com\">ClarityCode</a>, the blog engine of real developers.</p>"},                   
                    new Setting {Site = site, SiteId = site.Id, Name = "enable-disqus-comments",Description = "Enable the Disqus commenting system. Note - this will still require the theme to also use Disqus.",DisplayName = "Enable Disque Comments",Value = "False"},
                    new Setting {Site = site, SiteId = site.Id, Name = "disqus-shortname",Description = "The shortname of your Disqus comments, configured on the Disqus website.",DisplayName = "Shortname for Disqus",Value = "claritycode"},
                }.ForEach(b => context.Settings.AddOrUpdate(s => new { s.Name, s.SiteId }, b));
        }

        public void ShadePrepareData(DB context)
        {
            User adminUser = context.Users.Find(1);
            Guid guid = Guid.Parse("CE17E265-D3E4-4C3C-85BB-3521E80E2756");
            new List<Site> {
                    new Site{Id=guid, Name = "Shade", Url = "http://localhost/DemoEFCFShade", FolderPath="D:\\vs2010\\DemoEFCF\\DemoEFCFShade", IsActive = true,  CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now},
                }.ForEach(b => context.Sites.AddOrUpdate(s => s.Id, b));
            Site site = context.Sites.Find(guid);

            //ICollection<Tag> tags = new List<Tag> { new Tag { Name = "C#" }, new Tag { Name = "Programowanie" } };
            ICollection<Comment> commentsPortfolio = new List<Comment> { 
                    new Comment { UserName = adminUser.UserName, Content = "Great portfolio. Shade", Visible = true, IsAdmin = true, Email = adminUser.Email, HomePage = "claritycode.pl", CrDate = DateTime.Now, LmDate = DateTime.Now, }, 
                    new Comment { UserName = "Alex", Content = "One of the best portfolio. Shade", Visible = true, IsAdmin = false, Email = "admini@wp.pl", HomePage = "claritycode.pl", CrDate = DateTime.Now, LmDate = DateTime.Now, } };

            ICollection<Comment> commentsBlog = new List<Comment> { 
                    new Comment { UserName = adminUser.UserName, Content = "Great article Blog, Shade", Visible = true, IsAdmin = true, Email = adminUser.Email, HomePage = "claritycode.pl", CrDate = DateTime.Now, LmDate = DateTime.Now, }, 
                    new Comment { UserName = "Alex", Content = "One of the best Blog, Shade", Visible = true, IsAdmin = false, Email = "admini@wp.pl", HomePage = "claritycode.pl", CrDate = DateTime.Now, LmDate = DateTime.Now, } };


            ICollection<Tag> categoryPortfolio = context.Tags.Local.AsQueryable().ToList();

            new List<PortfolioHeader> {
                    new PortfolioHeader{ Site = site, SiteId = site.Id, Name="shadeprojects", EnableComments=true, 
                        LayoutForGroupProject="_Portfolio3ColumnsWithTextClassic", LayoutForSingleProject="_PortfolioFullColumn", 
                        Description = "Layout project in .net", Title="Themes", CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now, 
                        PortfolioNodes = new List<PortfolioNode>() {
                            new PortfolioNode {
                                Author = "Rafa³ Pisarczyk", Content = "A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link. Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", ShortContent="A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.",
                                Title = "Shade", IsVisible = true, ImageProjectLocalPath = "portfolio/full/shade.png", ImageProjectThumbLocalPath="portfolio/banner/shade.png", 
                                ProjectUrlPath="http://www.claritycodeweb.com/shadetheme", ImageProjectUrlPath = "", ImageProjectThumbUrlPath = "", Tags = categoryPortfolio,
                                Comments = commentsPortfolio,
                                CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now },
                            new PortfolioNode {
                                Author = "Rafa³ Pisarczyk", Content = "A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.", ShortContent="A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.",
                                Title = "Optima", IsVisible = true, ImageProjectLocalPath = "portfolio/full/optima.png", ImageProjectThumbLocalPath="portfolio/banner/optima.png", 
                                ProjectUrlPath="http://www.claritycodeweb.com/optimatheme", ImageProjectUrlPath = "", ImageProjectThumbUrlPath = "", Tags = categoryPortfolio.Take(1).ToList(),
                                CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now.AddMilliseconds(10), LmDate = DateTime.Now.AddMilliseconds(10) },
                            new PortfolioNode {
                                Author = "Rafa³ Pisarczyk", Content = "A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.", ShortContent="A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.",
                                Title = "Mind", IsVisible = true, ImageProjectLocalPath = "portfolio/full/mind.png", ImageProjectThumbLocalPath="portfolio/banner/mind.png", 
                                ProjectUrlPath="http://www.claritycodeweb.com/mindtheme", ImageProjectUrlPath = "", ImageProjectThumbUrlPath = "", Tags = categoryPortfolio.Take(1).ToList(),
                                CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now.AddMilliseconds(10), LmDate = DateTime.Now.AddMilliseconds(10) }
                        }
                    }
                }.ForEach(b => context.PortfolioHeaders.AddOrUpdate(s => s.Name, b));

            new List<SliderHeader> {
                    new SliderHeader {Name = "Shade", Description= "slider for shade theme", Transition = "fade", Speed = 2000, Pause = 5, LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser,
                        SliderSteps = new List<SliderStep>() {
                            new SliderStep(){ Name = "Step1", ImageLocalPath = "/_t_shade/slider/step/apple_in_a_box_1024x768.jpg", ImageBackground = "", Title = "Apple in the box", Content = "Shade uses a flexible frontpage that uses an amazing slideshow and can display any amount of tabed content, delivered by NetSimpleCMS - admin.", IsActive = true, LinkTo = "http://www.claritycodeweb.com/shadetheme", LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser},
                            new SliderStep(){ Name = "Step2", ImageLocalPath = "/_t_shade/slider/step/time_to_play_1024x768.jpg", ImageBackground = "", Title = "Time to play", Content = "Optima uses a flexible frontpage that uses an amazing slideshow and can display any amount of tabed content, delivered by NetSimpleCMS - admin.", IsActive = true,  LinkTo = "http://www.claritycodeweb.com/optimatheme",   LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser},
                        new SliderStep(){ Name = "Step3", ImageLocalPath = "/_t_shade/slider/step/robot_1280x800.jpg", ImageBackground = "", Title = "Robot", Content = "Mind uses a flexible frontpage that uses an amazing slideshow and can display any amount of tabed content, delivered by NetSimpleCMS - admin.", IsActive = true, LinkTo = "http://www.claritycodeweb.com/optimatheme",  LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser}
                        }},
                }.ForEach(b => context.SliderHeaders.AddOrUpdate(s => s.Name, b));

            ICollection<Tag> tags = context.Tags.Local.AsQueryable().ToList();

            new List<Blog>{ 
                    new Blog {Site = site, SiteId =  site.Id, BloggerName = "java-ee", 
                            LayoutForGroupPost="_Blog1ColumnsTextWithTags", LayoutForSinglePost="_BlogHalfColumnWithTags", 
                            Title = "My Code First Blog", CrDate = DateTime.Now, LmDate = DateTime.Now,CrUser = adminUser , LmUser = adminUser, IsActive = true,
                            Posts=new List<Post> {
                                new Post { IsVisible =  true,  EnableComments = true, Title="C# description" ,CrDate=System.DateTime.Now, LmDate=System.DateTime.Now, ShortContent = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit", Content="Hello work with new ef code first", CrUser = adminUser , LmUser = adminUser, MetaTitle = "Post 1", Tags = tags , Comments = commentsBlog },
                                new Post { IsVisible =  true, EnableComments = true, Title="JUit tests report",CrDate=System.DateTime.Now.AddMilliseconds(10), LmDate=System.DateTime.Now.AddMilliseconds(10), ShortContent ="<img src='/DemoEFCF/images/shadetheme/thumbs/iStock_000006026401Medium-70x50.jpg' alt='' title='This is a Slide example' height='50' width='70' class=\"picture\">  Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam ", Content="<img src='/DemoEFCF/images/shadetheme/thumbs/iStock_000006026401Medium-70x50.jpg' alt='' title='This is a Slide example' height='50' width='70' class=\"picture\">  Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam  GoodBay work with entity framework", CrUser = adminUser , MetaTitle = "Post 1",LmUser = adminUser,Tags = tags },
                                new Post { IsVisible =  true, EnableComments = false, Title="EntityFramework night",CrDate=System.DateTime.Now.AddMilliseconds(20), LmDate=System.DateTime.Now.AddMilliseconds(20), ShortContent="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", Content="GoodBay work with entity framework", CrUser = adminUser , MetaTitle = "Post 1",LmUser = adminUser,Tags = tags , DisableComments = true}
                            }
                    },
                    new Blog {Site = site, SiteId =  site.Id, BloggerName = "spring-mvc", LayoutForGroupPost = "_Blog1ColumnsTextWithTags", LayoutForSinglePost="_BlogHalfColumnWithTags", Title = "My Life as a Blog",CrDate = DateTime.Now, LmDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser}                    
                }.ForEach(b => context.Blogs.AddOrUpdate(s => new { s.BloggerName, s.SiteId }, b));

            SliderHeader slider = context.SliderHeaders.Local.Where(m => m.Name.ToLower() == "Shade".ToLower()).FirstOrDefault();
            PortfolioHeader portfolio = context.PortfolioHeaders.Local.Where(m => m.Name.ToLower() == "shadeprojects".ToLower()).FirstOrDefault();

            new List<Page> { new Page { Site = site, SiteId = site.Id, Name = "Home", PageParentId = null, MenuTitle="Dashboard", Url = "home", PageTitle = "Welcome!", PageLayout="_Layout",  MetaTitle = null, MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 1, Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now,
                        SliderHeader = slider, SliderHeaderId = slider.Id }, 
                    new Page { Site = site, SiteId = site.Id, Name = "About", PageParentId = null, Url = "about", MenuTitle="O mnie" ,DisplayPageTitle = true , PageTitle = "Short story about me.", PageLayout="_LayoutSimple",  MetaTitle = null, MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 2, Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now }, 
                    new Page { Site = site, SiteId = site.Id, Name = "Blog", PageParentId = null, Url = "blog/spring-mvc", MenuTitle="O mnie" , 
                        DisplayPageTitle = true , PageTitle = "C# tutorials", PageLayout="_LayoutSimple",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 3, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now }, 
                    new Page { Site = site, SiteId = site.Id, Name = "Portfolio", PageParentId = null, Url = "portfolio/shadeprojects", MenuTitle="Projekty .Net" , 
                        DisplayPageTitle = true , PageTitle = "Projekty .Net", PageLayout="_LayoutSimple",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 4, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now }, 
                }.ForEach(b => context.Pages.AddOrUpdate(s => new { s.Name, s.SiteId }, b));


            new List<Setting> {
                    new Setting {Site = site,SiteId = site.Id, Name = "shortcuticon",Description = "Shortcut Icon",DisplayName = "Shortcut Icon",Value = "icon/shade.png"},
                    new Setting {Site = site,SiteId = site.Id, Name = "backendcolor",Description = "Kolor t³a.",DisplayName = "Backend Color",Value = "#185EA2"},
                    new Setting {Site = site,SiteId = site.Id, Name = "logo",Description = "Logo.",DisplayName = "Logo",Value = "logos/logo_Shade_v0.png"},
                    new Setting {Site = site,SiteId = site.Id, Name = "ui-theme",Description = "Theme being used by the blog at the moment",DisplayName = "Theme",Value = "ShadeTheme"},
                    new Setting {Site = site,SiteId = site.Id, Name = "ui-title",Description = "Text: The title shown at the top in the browser.",DisplayName = "Title",Value = "Rafa³ Pisarczyk - home website"},
                    new Setting {Site = site,SiteId = site.Id, Name = "ui-introduction",Description = "Markdown: The introductory text that is shown on the home page.",DisplayName = "Introduction",Value = "Welcome to your my page."},
                    new Setting {Site = site,SiteId = site.Id, Name = "ui-links",Description = "HTML: A list of links shown at the top of each page.",DisplayName = "Main Links",Value = "<li><a href=\"/projects\">Projects</a></li>"},
                    new Setting {Site = site,SiteId = site.Id, Name = "search-author",Description = "Text: Your name.",DisplayName = "Author",Value = "Pisarczyk Rafa³"},
                    new Setting {Site = site,SiteId = site.Id, Name = "search-keywords",Description = "Comma-separated text: Keywords shown to search engines.",DisplayName = "Keywords",Value = ".net, c#, test"},
                    new Setting {Site = site, SiteId = site.Id,Name = "search-description",Description = "Text: The description shown to search engines in the meta description tag.",DisplayName = "Description",Value = "My website."},
                    new Setting {Site = site,SiteId = site.Id, Name = "spam-blacklist",Description = "Comments with these words (case-insensitive) will automatically be marked as spam, in addition to Akismet.",DisplayName = "Spam Blacklist",Value = "casino"},
                    new Setting {Site = site,SiteId = site.Id, Name = "default-page",Description = "Page name: When users visit the root (//) of your site, it will be equivalent to visiting the page you specify here.",DisplayName = "Default Page",Value = "home"},
                    new Setting {Site = site,SiteId = site.Id, Name = "ui-footer",Description = "HTML: This will appear at the bottom of the page - use it to add copyright information, links to any web hosts, people or technologies that helped you to build the site, and so on.",DisplayName = "Footer",Value = "<p>Powered by <a href=\"http://www.claritycode.com\">ClarityCode</a>, the blog engine of real developers.</p>"},                   
                    new Setting {Site = site,SiteId = site.Id, Name = "enable-disqus-comments",Description = "Enable the Disqus commenting system. Note - this will still require the theme to also use Disqus.",DisplayName = "Enable Disque Comments",Value = "False"},
                    new Setting {Site = site,SiteId = site.Id, Name = "disqus-shortname",Description = "The shortname of your Disqus comments, configured on the Disqus website.",DisplayName = "Shortname for Disqus",Value = "claritycode"},
                }.ForEach(b => context.Settings.AddOrUpdate(s => new { s.Name, s.SiteId }, b));

        }

        public void MindPrepareData(DB context)
        {
            User adminUser = context.Users.Find(1);
            Guid guid = Guid.Parse("53FA0D8A-2096-4548-B680-D164EFE161CF");
            new List<Site> {
                    new Site{Id=guid, Name = "Mind", Url = "http://localhost/DemoEFCFMind", FolderPath="D:\\vs2010\\DemoEFCF\\DemoEFCFMind", IsActive = true,  CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now},
                }.ForEach(b => context.Sites.AddOrUpdate(s => s.Id, b));
            Site site = context.Sites.Find(guid);

            ICollection<Comment> commentsPost = new List<Comment> { 
                    new Comment { UserName = adminUser.UserName, Content = "Great article. Mind", Visible = true, IsAdmin = true, Email = adminUser.Email, HomePage = "claritycode.pl", CrDate = DateTime.Now, LmDate = DateTime.Now, }, 
                    new Comment { UserName = "Alex", Content = "One of the best. Mind", Visible = true, IsAdmin = false, Email = "admini@wp.pl", HomePage = "claritycode.pl", CrDate = DateTime.Now, LmDate = DateTime.Now, } };

            ICollection<Tag> categoryPortfolio = context.Tags.Local.AsQueryable().ToList();

            new List<PortfolioHeader> {
                    new PortfolioHeader{ Site = site, SiteId = site.Id, Name="mindthemes", EnableComments=true, 
                        LayoutForGroupProject="_Portfolio3ColumnsWithTextClassic", LayoutForSingleProject="_PortfolioFullColumn", 
                        Description = "Layout project in .net", Title="Themes", CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now, 
                        PortfolioNodes = new List<PortfolioNode>() {
                            new PortfolioNode {
                                Author = "Rafa³ Pisarczyk", Content = "A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link. Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", ShortContent="A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.",
                                Title = "Shade", IsVisible = true, ImageProjectLocalPath = "portfolio/full/shade.png", ImageProjectThumbLocalPath="portfolio/banner/shade.png", 
                                ProjectUrlPath="http://www.claritycodeweb.com/shadetheme", ImageProjectUrlPath = "", ImageProjectThumbUrlPath = "", Tags = categoryPortfolio,
                                /*Comments = commentsPost,*/
                                CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now },
                            new PortfolioNode {
                                Author = "Rafa³ Pisarczyk", Content = "A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.", ShortContent="A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.",
                                Title = "Optima", IsVisible = true, ImageProjectLocalPath = "portfolio/full/optima.png", ImageProjectThumbLocalPath="portfolio/banner/optima.png", 
                                ProjectUrlPath="http://www.claritycodeweb.com/optimatheme", ImageProjectUrlPath = "", ImageProjectThumbUrlPath = "", Tags = categoryPortfolio.Take(1).ToList(),
                                CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now.AddMilliseconds(10), LmDate = DateTime.Now.AddMilliseconds(10) },
                            new PortfolioNode {
                                Author = "Rafa³ Pisarczyk", Content = "A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.", ShortContent="A look into your html code and see right away that you are using one div block for all the images(slides). On the example code on the link.",
                                Title = "Mind", IsVisible = true, ImageProjectLocalPath = "portfolio/full/mind.png", ImageProjectThumbLocalPath="portfolio/banner/mind.png", 
                                ProjectUrlPath="http://www.claritycodeweb.com/mindtheme", ImageProjectUrlPath = "", ImageProjectThumbUrlPath = "", Tags = categoryPortfolio.Take(1).ToList(),
                                CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now.AddMilliseconds(10), LmDate = DateTime.Now.AddMilliseconds(10) }
                        }
                    }
                }.ForEach(b => context.PortfolioHeaders.AddOrUpdate(s => s.Name, b));

            new List<SliderHeader> {
                    new SliderHeader {Name = "Mind", Description= "slider for mind theme", Transition = "fade", Speed = 2000, Pause = 5, LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser,
                        SliderSteps = new List<SliderStep>() {
                            new SliderStep(){ Name = "Step1", ImageLocalPath = "/_t_mind/slider/step/Bannery.baner_strona_glownagk-is-211.png", ImageBackground = "/_t_mind/slider/banner/baner_strona_glowna_boki.jpg", Title = "SHADE", Content = "Shade uses a flexible frontpage that uses an amazing slideshow and can display any amount of tabed content, delivered by NetSimpleCMS - admin.", IsActive = true, LinkTo = "http://www.claritycodeweb.com/shadetheme", LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser},
                            new SliderStep(){ Name = "Step2", ImageLocalPath = "/_t_mind/slider/step/Bannery.baner_produkty_multimediagk-is-211.jpg", ImageBackground = "/_t_mind/slider/banner/baner_produkty_multimedia_boki.jpg", Title = "OPTIMA", Content = "Optima uses a flexible frontpage that uses an amazing slideshow and can display any amount of tabed content, delivered by NetSimpleCMS - admin.", IsActive = true,  LinkTo = "http://www.claritycodeweb.com/optimatheme",   LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser},
                            new SliderStep(){ Name = "Step3", ImageLocalPath = "/_t_mind/slider/step/Slajder.baner_finanse4gk-is-211.jpg", ImageBackground = "/_t_mind/slider/banner/baner_finanse4_boki.jpg", Title = "MIND", Content = "Mind uses a flexible frontpage that uses an amazing slideshow and can display any amount of tabed content, delivered by NetSimpleCMS - admin.", IsActive = true, LinkTo = "http://www.claritycodeweb.com/optimatheme",  LmDate = DateTime.Now, CrDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser}
                        }},
                }.ForEach(b => context.SliderHeaders.AddOrUpdate(s => s.Name, b));

            SliderHeader slider = context.SliderHeaders.Local.Where(m => m.Name.ToLower() == "Mind".ToLower()).FirstOrDefault();
            PortfolioHeader portfolio = context.PortfolioHeaders.Local.Where(m => m.Name.ToLower() == "mindthemes".ToLower()).FirstOrDefault();

            new List<Page> { new Page { Site = site, SiteId = site.Id, Name = "Home", PageParentId = null, MenuTitle="Dashboard", Url = "home", PageTitle = "Welcome!", PageLayout="_Layout",  MetaTitle = null, MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 1, Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now, 
                        SliderHeader = slider, SliderHeaderId = slider.Id}, 
                    new Page { Site = site, SiteId = site.Id, Name = "About", PageParentId = null, Url = "about", MenuTitle="O mnie" ,DisplayPageTitle = true , PageTitle = "Short story about me.", PageLayout="_LayoutSimple",  MetaTitle = null, MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 2, Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now }, 
                    new Page { Site = site, SiteId = site.Id, Name = "Blog", PageParentId = null, Url = "blog/mind-image", MenuTitle="O mnie" , 
                        DisplayPageTitle = true , PageTitle = "C# tutorials", PageLayout="_LayoutSimple",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 3, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now }, 
                    new Page { Site = site, SiteId = site.Id, Name = "Themes", PageParentId = null, Url = "themes", MenuTitle="Latest Themes" , 
                        DisplayPageTitle = true , PageTitle = "Recent Themes", PageLayout="_LayoutPxFull3ColMax001",  MetaTitle = null, 
                        MetaDescription = null, MetaKeywords = null, Authorized = "", MainMenu = true, SortOrder = 4, 
                        Active = true, CrUser = adminUser, LmUser = adminUser, CrDate = DateTime.Now, LmDate = DateTime.Now , PortfolioHeader = portfolio, PortfolioHeaderId = portfolio.Id}, 
                }.ForEach(b => context.Pages.AddOrUpdate(s => new { s.Name, s.SiteId }, b));

            ICollection<Tag> tags = context.Tags.Local.AsQueryable().ToList();

            new List<Blog>{ 
                    new Blog {Site = site, SiteId = site.Id, BloggerName = "mind-image", 
                            LayoutForGroupPost="_Blog1ColumnsTextWithTags", LayoutForSinglePost="_BlogHalfColumnWithTags", 
                            Title = "My Code First Blog", CrDate = DateTime.Now, LmDate = DateTime.Now,CrUser = adminUser , LmUser = adminUser, IsActive = true,
                            Posts=new List<Post> {
                                new Post { IsVisible =  true,  EnableComments = true, Title="Mind image - 1" ,CrDate=System.DateTime.Now, LmDate=System.DateTime.Now, ShortContent = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit", Content="Hello work with new ef code first", CrUser = adminUser , LmUser = adminUser, MetaTitle = "Post 1", Tags = tags , Comments = commentsPost},
                                new Post { IsVisible =  true, EnableComments = true, Title="Mind image - 2",CrDate=System.DateTime.Now.AddMilliseconds(10), LmDate=System.DateTime.Now.AddMilliseconds(10), ShortContent ="<img src='/DemoEFCF/images/shadetheme/thumbs/iStock_000006026401Medium-70x50.jpg' alt='' title='This is a Slide example' height='50' width='70' class=\"picture\">  Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam ", Content="<img src='/DemoEFCF/images/shadetheme/thumbs/iStock_000006026401Medium-70x50.jpg' alt='' title='This is a Slide example' height='50' width='70' class=\"picture\">  Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam  GoodBay work with entity framework", CrUser = adminUser , MetaTitle = "Post 1",LmUser = adminUser,Tags = tags },
                                new Post { IsVisible =  true, EnableComments = false, Title="Mind image - 3",CrDate=System.DateTime.Now.AddMilliseconds(20), LmDate=System.DateTime.Now.AddMilliseconds(20), ShortContent="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", Content="GoodBay work with entity framework", CrUser = adminUser , MetaTitle = "Post 1",LmUser = adminUser,Tags = tags , DisableComments = true}
                            }
                    },
                    new Blog {Site = site, BloggerName = "mind-today", LayoutForGroupPost = "_Blog1ColumnsTextWithTags", LayoutForSinglePost="_BlogHalfColumnWithTags", Title = "My Life as a Blog",CrDate = DateTime.Now, LmDate = DateTime.Now, CrUser = adminUser, LmUser = adminUser},                
                }.ForEach(b => context.Blogs.AddOrUpdate(s => new { s.BloggerName, s.SiteId }, b));

            new List<Setting> {
                    new Setting {Site = site, SiteId = site.Id, Name = "shortcuticon",Description = "Shortcut Icon",DisplayName = "Shortcut Icon",Value = "icon/mind.png"},
                    new Setting {Site = site, SiteId = site.Id, Name = "backendcolor",Description = "Kolor t³a.",DisplayName = "Backend Color",Value = "#71b1d1"},
                    new Setting {Site = site, SiteId = site.Id, Name = "logo",Description = "Logo.",DisplayName = "Logo",Value = "logos/logo_Mind1.png"},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-theme",Description = "Theme being used by the blog at the moment",DisplayName = "Theme",Value = "MindTheme"},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-title",Description = "Text: The title shown at the top in the browser.",DisplayName = "Title",Value = "Rafa³ Pisarczyk - home website"},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-introduction",Description = "Markdown: The introductory text that is shown on the home page.",DisplayName = "Introduction",Value = "Welcome to your my page."},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-links",Description = "HTML: A list of links shown at the top of each page.",DisplayName = "Main Links",Value = "<li><a href=\"/projects\">Projects</a></li>"},
                    new Setting {Site = site, SiteId = site.Id, Name = "search-author",Description = "Text: Your name.",DisplayName = "Author",Value = "Pisarczyk Rafa³"},
                    new Setting {Site = site, SiteId = site.Id, Name = "search-keywords",Description = "Comma-separated text: Keywords shown to search engines.",DisplayName = "Keywords",Value = ".net, c#, test"},
                    new Setting {Site = site, SiteId = site.Id, Name = "search-description",Description = "Text: The description shown to search engines in the meta description tag.",DisplayName = "Description",Value = "My website."},
                    new Setting {Site = site, SiteId = site.Id, Name = "spam-blacklist",Description = "Comments with these words (case-insensitive) will automatically be marked as spam, in addition to Akismet.",DisplayName = "Spam Blacklist",Value = "casino"},
                    new Setting {Site = site, SiteId = site.Id, Name = "default-page",Description = "Page name: When users visit the root (//) of your site, it will be equivalent to visiting the page you specify here.",DisplayName = "Default Page",Value = "home"},
                    new Setting {Site = site, SiteId = site.Id, Name = "ui-footer",Description = "HTML: This will appear at the bottom of the page - use it to add copyright information, links to any web hosts, people or technologies that helped you to build the site, and so on.",DisplayName = "Footer",Value = "<p>Powered by <a href=\"http://www.claritycode.com\">ClarityCode</a>, the blog engine of real developers.</p>"},                   
                    new Setting {Site = site, SiteId = site.Id, Name = "enable-disqus-comments",Description = "Enable the Disqus commenting system. Note - this will still require the theme to also use Disqus.",DisplayName = "Enable Disque Comments",Value = "False"},
                    new Setting {Site = site, SiteId = site.Id, Name = "disqus-shortname",Description = "The shortname of your Disqus comments, configured on the Disqus website.",DisplayName = "Shortname for Disqus",Value = "claritycode"},
                }.ForEach(b => context.Settings.AddOrUpdate(s => new { s.Name, s.SiteId }, b));
        }
    }
}

