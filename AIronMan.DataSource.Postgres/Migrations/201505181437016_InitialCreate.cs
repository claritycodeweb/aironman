namespace AIronMan.DataSource.Postgres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 60),
                        BloggerName = c.String(nullable: false, maxLength: 32),
                        LayoutForGroupPost = c.String(nullable: false, maxLength: 150),
                        LayoutForSinglePost = c.String(nullable: false, maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                        CrDate = c.DateTime(nullable: false),
                        LmDate = c.DateTime(nullable: false),
                        CrUser_Id = c.Int(),
                        LmUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CrUser_Id)
                .ForeignKey("dbo.Users", t => t.LmUser_Id)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 16),
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 128),
                        PasswordSalt = c.String(maxLength: 128),
                        LastLoginDate = c.DateTime(nullable: false),
                        LastPasswordChangeDate = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        IsLockedOut = c.Boolean(nullable: false),
                        CrDate = c.DateTime(nullable: false),
                        LmDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        CrDate = c.DateTime(nullable: false),
                        LmDate = c.DateTime(nullable: false),
                        CrUser_Id = c.Int(),
                        LmUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CrUser_Id)
                .ForeignKey("dbo.Users", t => t.LmUser_Id)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsVisible = c.Boolean(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        TitleUrl = c.String(nullable: false, maxLength: 160),
                        ShortContent = c.String(maxLength: 1500),
                        Content = c.String(nullable: false),
                        DownloadFilePath = c.String(maxLength: 500),
                        EnableComments = c.Boolean(nullable: false),
                        BlogId = c.Int(nullable: false),
                        CrDate = c.DateTime(nullable: false),
                        LmDate = c.DateTime(nullable: false),
                        MetaTitle = c.String(),
                        DisableComments = c.Boolean(nullable: false),
                        CrUser_Id = c.Int(),
                        LmUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CrUser_Id)
                .ForeignKey("dbo.Users", t => t.LmUser_Id)
                .Index(t => t.BlogId)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 16),
                        Email = c.String(nullable: false, maxLength: 50),
                        HomePage = c.String(maxLength: 100),
                        IsAdmin = c.Boolean(nullable: false),
                        Visible = c.Boolean(nullable: false),
                        IsBlock = c.Boolean(nullable: false),
                        Content = c.String(nullable: false),
                        PostId = c.Int(),
                        PortfolioNodeId = c.Int(),
                        CrDate = c.DateTime(nullable: false),
                        LmDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PortfolioNodes", t => t.PortfolioNodeId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PortfolioNodeId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.PortfolioNodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PortfolioId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        TitleUrl = c.String(nullable: false, maxLength: 160),
                        ImageProjectThumbLocalPath = c.String(maxLength: 500),
                        ImageProjectThumbUrlPath = c.String(maxLength: 500),
                        ImageProjectLocalPath = c.String(maxLength: 500),
                        ImageProjectUrlPath = c.String(maxLength: 500),
                        Author = c.String(maxLength: 50),
                        ProjectUrlPath = c.String(maxLength: 500),
                        ShortContent = c.String(maxLength: 500),
                        Content = c.String(),
                        IsVisible = c.Boolean(nullable: false),
                        CrDate = c.DateTime(nullable: false),
                        LmDate = c.DateTime(nullable: false),
                        DownloadFilePath = c.String(maxLength: 500),
                        CrUser_Id = c.Int(),
                        LmUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CrUser_Id)
                .ForeignKey("dbo.Users", t => t.LmUser_Id)
                .ForeignKey("dbo.PortfolioHeaders", t => t.PortfolioId, cascadeDelete: true)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.PortfolioHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 32),
                        NameUrl = c.String(nullable: false, maxLength: 32),
                        Title = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 255),
                        LayoutForGroupProject = c.String(nullable: false, maxLength: 150),
                        LayoutForSingleProject = c.String(nullable: false, maxLength: 150),
                        EnableComments = c.Boolean(nullable: false),
                        CrDate = c.DateTime(nullable: false),
                        LmDate = c.DateTime(nullable: false),
                        CrUser_Id = c.Int(),
                        LmUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CrUser_Id)
                .ForeignKey("dbo.Users", t => t.LmUser_Id)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Url = c.String(nullable: false, maxLength: 150),
                        FolderPath = c.String(nullable: false, maxLength: 150),
                        ThemeLocalization = c.String(maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                        CrDate = c.DateTime(nullable: false),
                        LmDate = c.DateTime(nullable: false),
                        CrUser_Id = c.Int(),
                        LmUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CrUser_Id)
                .ForeignKey("dbo.Users", t => t.LmUser_Id)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Langs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LangCode = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Layouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        IsVisible = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 255),
                        IsSlider = c.Boolean(nullable: false),
                        IsPotfolio = c.Boolean(nullable: false),
                        IsGallery = c.Boolean(nullable: false),
                        IsBlog = c.Boolean(nullable: false),
                        OnlyForModule = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteId = c.Guid(nullable: false),
                        PageParentId = c.Int(),
                        Name = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        PageTitle = c.String(),
                        PageLayout = c.String(maxLength: 150),
                        MenuTitle = c.String(),
                        MetaTitle = c.String(),
                        MetaDescription = c.String(),
                        MetaKeywords = c.String(),
                        Authorized = c.String(),
                        MainMenu = c.Boolean(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DisplayPageTitle = c.Boolean(nullable: false),
                        Link = c.String(),
                        UnderConstruction = c.Boolean(nullable: false),
                        PageTempleteContentId = c.Int(),
                        SliderHeaderId = c.Int(),
                        PortfolioHeaderId = c.Int(),
                        BlogId = c.Int(),
                        CrDate = c.DateTime(nullable: false),
                        LmDate = c.DateTime(nullable: false),
                        CrUser_Id = c.Int(),
                        LmUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId)
                .ForeignKey("dbo.Users", t => t.CrUser_Id)
                .ForeignKey("dbo.Users", t => t.LmUser_Id)
                .ForeignKey("dbo.Pages", t => t.PageParentId)
                .ForeignKey("dbo.PortfolioHeaders", t => t.PortfolioHeaderId)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .ForeignKey("dbo.SliderHeaders", t => t.SliderHeaderId)
                .Index(t => t.BlogId)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id)
                .Index(t => t.PageParentId)
                .Index(t => t.PortfolioHeaderId)
                .Index(t => t.SiteId)
                .Index(t => t.SliderHeaderId);
            
            CreateTable(
                "dbo.SliderHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        Description = c.String(maxLength: 255),
                        Transition = c.String(nullable: false),
                        Speed = c.Int(nullable: false),
                        Pause = c.Int(nullable: false),
                        CrDate = c.DateTime(nullable: false),
                        LmDate = c.DateTime(nullable: false),
                        CrUser_Id = c.Int(),
                        LmUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CrUser_Id)
                .ForeignKey("dbo.Users", t => t.LmUser_Id)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.SliderSteps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SliderId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 32),
                        ImageLocalPath = c.String(maxLength: 500),
                        ImageUrlPath = c.String(maxLength: 500),
                        ImageBackground = c.String(maxLength: 500),
                        LinkTo = c.String(maxLength: 500),
                        Title = c.String(maxLength: 125),
                        Content = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        CrDate = c.DateTime(nullable: false),
                        LmDate = c.DateTime(nullable: false),
                        CrUser_Id = c.Int(),
                        LmUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CrUser_Id)
                .ForeignKey("dbo.Users", t => t.LmUser_Id)
                .ForeignKey("dbo.SliderHeaders", t => t.SliderId, cascadeDelete: true)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id)
                .Index(t => t.SliderId);
            
            CreateTable(
                "dbo.PageTemplates",
                c => new
                    {
                        TemplateId = c.Int(nullable: false),
                        Lang = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        SiteId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 32),
                        Content = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CrDate = c.DateTime(nullable: false),
                        LmDate = c.DateTime(nullable: false),
                        CrUser_Id = c.Int(),
                        LmUser_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.TemplateId, t.Lang, t.Id })
                .ForeignKey("dbo.Users", t => t.CrUser_Id)
                .ForeignKey("dbo.Users", t => t.LmUser_Id)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id)
                .Index(t => t.SiteId);

            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 255),
                        DisplayName = c.String(maxLength: 400),
                        Value = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.UserJoinRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.PortfolioJoinTag",
                c => new
                    {
                        PortfolioNodeId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PortfolioNodeId, t.TagId })
                .ForeignKey("dbo.PortfolioNodes", t => t.PortfolioNodeId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PortfolioNodeId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.PostJoinTag",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.TagId })
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Settings", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.PageTemplates", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.PageTemplates", "LmUser_Id", "dbo.Users");
            DropForeignKey("dbo.PageTemplates", "CrUser_Id", "dbo.Users");
            DropForeignKey("dbo.Pages", "SliderHeaderId", "dbo.SliderHeaders");
            DropForeignKey("dbo.SliderSteps", "SliderId", "dbo.SliderHeaders");
            DropForeignKey("dbo.SliderSteps", "LmUser_Id", "dbo.Users");
            DropForeignKey("dbo.SliderSteps", "CrUser_Id", "dbo.Users");
            DropForeignKey("dbo.SliderHeaders", "LmUser_Id", "dbo.Users");
            DropForeignKey("dbo.SliderHeaders", "CrUser_Id", "dbo.Users");
            DropForeignKey("dbo.Pages", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.Pages", "PortfolioHeaderId", "dbo.PortfolioHeaders");
            DropForeignKey("dbo.Pages", "PageParentId", "dbo.Pages");
            DropForeignKey("dbo.Pages", "LmUser_Id", "dbo.Users");
            DropForeignKey("dbo.Pages", "CrUser_Id", "dbo.Users");
            DropForeignKey("dbo.Pages", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.PostJoinTag", "TagId", "dbo.Tags");
            DropForeignKey("dbo.PostJoinTag", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "LmUser_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "CrUser_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "PortfolioNodeId", "dbo.PortfolioNodes");
            DropForeignKey("dbo.PortfolioJoinTag", "TagId", "dbo.Tags");
            DropForeignKey("dbo.PortfolioJoinTag", "PortfolioNodeId", "dbo.PortfolioNodes");
            DropForeignKey("dbo.PortfolioNodes", "PortfolioId", "dbo.PortfolioHeaders");
            DropForeignKey("dbo.PortfolioHeaders", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.Sites", "LmUser_Id", "dbo.Users");
            DropForeignKey("dbo.Sites", "CrUser_Id", "dbo.Users");
            DropForeignKey("dbo.PortfolioHeaders", "LmUser_Id", "dbo.Users");
            DropForeignKey("dbo.PortfolioHeaders", "CrUser_Id", "dbo.Users");
            DropForeignKey("dbo.PortfolioNodes", "LmUser_Id", "dbo.Users");
            DropForeignKey("dbo.PortfolioNodes", "CrUser_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "LmUser_Id", "dbo.Users");
            DropForeignKey("dbo.Blogs", "CrUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserJoinRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserJoinRole", "UserId", "dbo.Users");
            DropForeignKey("dbo.Roles", "LmUser_Id", "dbo.Users");
            DropForeignKey("dbo.Roles", "CrUser_Id", "dbo.Users");
            DropIndex("dbo.Settings", new[] { "SiteId" });
            DropIndex("dbo.PageTemplates", new[] { "SiteId" });
            DropIndex("dbo.PageTemplates", new[] { "LmUser_Id" });
            DropIndex("dbo.PageTemplates", new[] { "CrUser_Id" });
            DropIndex("dbo.Pages", new[] { "SliderHeaderId" });
            DropIndex("dbo.SliderSteps", new[] { "SliderId" });
            DropIndex("dbo.SliderSteps", new[] { "LmUser_Id" });
            DropIndex("dbo.SliderSteps", new[] { "CrUser_Id" });
            DropIndex("dbo.SliderHeaders", new[] { "LmUser_Id" });
            DropIndex("dbo.SliderHeaders", new[] { "CrUser_Id" });
            DropIndex("dbo.Pages", new[] { "SiteId" });
            DropIndex("dbo.Pages", new[] { "PortfolioHeaderId" });
            DropIndex("dbo.Pages", new[] { "PageParentId" });
            DropIndex("dbo.Pages", new[] { "LmUser_Id" });
            DropIndex("dbo.Pages", new[] { "CrUser_Id" });
            DropIndex("dbo.Pages", new[] { "BlogId" });
            DropIndex("dbo.Blogs", new[] { "SiteId" });
            DropIndex("dbo.PostJoinTag", new[] { "TagId" });
            DropIndex("dbo.PostJoinTag", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "LmUser_Id" });
            DropIndex("dbo.Posts", new[] { "CrUser_Id" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "PortfolioNodeId" });
            DropIndex("dbo.PortfolioJoinTag", new[] { "TagId" });
            DropIndex("dbo.PortfolioJoinTag", new[] { "PortfolioNodeId" });
            DropIndex("dbo.PortfolioNodes", new[] { "PortfolioId" });
            DropIndex("dbo.PortfolioHeaders", new[] { "SiteId" });
            DropIndex("dbo.Sites", new[] { "LmUser_Id" });
            DropIndex("dbo.Sites", new[] { "CrUser_Id" });
            DropIndex("dbo.PortfolioHeaders", new[] { "LmUser_Id" });
            DropIndex("dbo.PortfolioHeaders", new[] { "CrUser_Id" });
            DropIndex("dbo.PortfolioNodes", new[] { "LmUser_Id" });
            DropIndex("dbo.PortfolioNodes", new[] { "CrUser_Id" });
            DropIndex("dbo.Posts", new[] { "BlogId" });
            DropIndex("dbo.Blogs", new[] { "LmUser_Id" });
            DropIndex("dbo.Blogs", new[] { "CrUser_Id" });
            DropIndex("dbo.UserJoinRole", new[] { "RoleId" });
            DropIndex("dbo.UserJoinRole", new[] { "UserId" });
            DropIndex("dbo.Roles", new[] { "LmUser_Id" });
            DropIndex("dbo.Roles", new[] { "CrUser_Id" });
            DropTable("dbo.PostJoinTag");
            DropTable("dbo.PortfolioJoinTag");
            DropTable("dbo.UserJoinRole");
            DropTable("dbo.Settings");
            DropTable("dbo.PageTemplates");
            DropTable("dbo.SliderSteps");
            DropTable("dbo.SliderHeaders");
            DropTable("dbo.Pages");
            DropTable("dbo.Layouts");
            DropTable("dbo.Langs");
            DropTable("dbo.Tags");
            DropTable("dbo.Sites");
            DropTable("dbo.PortfolioHeaders");
            DropTable("dbo.PortfolioNodes");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Blogs");
        }
    }
}
