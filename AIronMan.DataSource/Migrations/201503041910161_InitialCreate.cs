namespace AIronMan.DataSource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
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
                .ForeignKey("dbo.Site", t => t.SiteId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.CrUser_Id)
                .ForeignKey("dbo.User", t => t.LmUser_Id)
                .Index(t => t.SiteId)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.Site",
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
                .ForeignKey("dbo.User", t => t.CrUser_Id)
                .ForeignKey("dbo.User", t => t.LmUser_Id)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.User",
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
                "dbo.Role",
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
                .ForeignKey("dbo.User", t => t.CrUser_Id)
                .ForeignKey("dbo.User", t => t.LmUser_Id)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.Post",
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
                .ForeignKey("dbo.Blog", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.CrUser_Id)
                .ForeignKey("dbo.User", t => t.LmUser_Id)
                .Index(t => t.BlogId)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.Comment",
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
                .ForeignKey("dbo.Post", t => t.PostId)
                .ForeignKey("dbo.PortfolioNode", t => t.PortfolioNodeId)
                .Index(t => t.PostId)
                .Index(t => t.PortfolioNodeId);
            
            CreateTable(
                "dbo.PortfolioNode",
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
                .ForeignKey("dbo.PortfolioHeader", t => t.PortfolioId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.CrUser_Id)
                .ForeignKey("dbo.User", t => t.LmUser_Id)
                .Index(t => t.PortfolioId)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PortfolioHeader",
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
                .ForeignKey("dbo.Site", t => t.SiteId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.CrUser_Id)
                .ForeignKey("dbo.User", t => t.LmUser_Id)
                .Index(t => t.SiteId)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 255),
                        DisplayName = c.String(maxLength: 400),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Site", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.Page",
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
                .ForeignKey("dbo.Site", t => t.SiteId, cascadeDelete: true)
                .ForeignKey("dbo.Page", t => t.PageParentId)
                .ForeignKey("dbo.SliderHeader", t => t.SliderHeaderId)
                .ForeignKey("dbo.PortfolioHeader", t => t.PortfolioHeaderId)
                .ForeignKey("dbo.Blog", t => t.BlogId)
                .ForeignKey("dbo.User", t => t.CrUser_Id)
                .ForeignKey("dbo.User", t => t.LmUser_Id)
                .Index(t => t.SiteId)
                .Index(t => t.PageParentId)
                .Index(t => t.SliderHeaderId)
                .Index(t => t.PortfolioHeaderId)
                .Index(t => t.BlogId)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.SliderHeader",
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
                .ForeignKey("dbo.User", t => t.CrUser_Id)
                .ForeignKey("dbo.User", t => t.LmUser_Id)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.SliderStep",
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
                .ForeignKey("dbo.SliderHeader", t => t.SliderId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.CrUser_Id)
                .ForeignKey("dbo.User", t => t.LmUser_Id)
                .Index(t => t.SliderId)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.PageTemplate",
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
                .ForeignKey("dbo.Site", t => t.SiteId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.CrUser_Id)
                .ForeignKey("dbo.User", t => t.LmUser_Id)
                .Index(t => t.SiteId)
                .Index(t => t.CrUser_Id)
                .Index(t => t.LmUser_Id);
            
            CreateTable(
                "dbo.Layout",
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
                "dbo.Lang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LangCode = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserJoinRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
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
                .ForeignKey("dbo.PortfolioNode", t => t.PortfolioNodeId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
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
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PostJoinTag", new[] { "TagId" });
            DropIndex("dbo.PostJoinTag", new[] { "PostId" });
            DropIndex("dbo.PortfolioJoinTag", new[] { "TagId" });
            DropIndex("dbo.PortfolioJoinTag", new[] { "PortfolioNodeId" });
            DropIndex("dbo.UserJoinRole", new[] { "RoleId" });
            DropIndex("dbo.UserJoinRole", new[] { "UserId" });
            DropIndex("dbo.PageTemplate", new[] { "LmUser_Id" });
            DropIndex("dbo.PageTemplate", new[] { "CrUser_Id" });
            DropIndex("dbo.PageTemplate", new[] { "SiteId" });
            DropIndex("dbo.SliderStep", new[] { "LmUser_Id" });
            DropIndex("dbo.SliderStep", new[] { "CrUser_Id" });
            DropIndex("dbo.SliderStep", new[] { "SliderId" });
            DropIndex("dbo.SliderHeader", new[] { "LmUser_Id" });
            DropIndex("dbo.SliderHeader", new[] { "CrUser_Id" });
            DropIndex("dbo.Page", new[] { "LmUser_Id" });
            DropIndex("dbo.Page", new[] { "CrUser_Id" });
            DropIndex("dbo.Page", new[] { "BlogId" });
            DropIndex("dbo.Page", new[] { "PortfolioHeaderId" });
            DropIndex("dbo.Page", new[] { "SliderHeaderId" });
            DropIndex("dbo.Page", new[] { "PageParentId" });
            DropIndex("dbo.Page", new[] { "SiteId" });
            DropIndex("dbo.Setting", new[] { "SiteId" });
            DropIndex("dbo.PortfolioHeader", new[] { "LmUser_Id" });
            DropIndex("dbo.PortfolioHeader", new[] { "CrUser_Id" });
            DropIndex("dbo.PortfolioHeader", new[] { "SiteId" });
            DropIndex("dbo.PortfolioNode", new[] { "LmUser_Id" });
            DropIndex("dbo.PortfolioNode", new[] { "CrUser_Id" });
            DropIndex("dbo.PortfolioNode", new[] { "PortfolioId" });
            DropIndex("dbo.Comment", new[] { "PortfolioNodeId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropIndex("dbo.Post", new[] { "LmUser_Id" });
            DropIndex("dbo.Post", new[] { "CrUser_Id" });
            DropIndex("dbo.Post", new[] { "BlogId" });
            DropIndex("dbo.Role", new[] { "LmUser_Id" });
            DropIndex("dbo.Role", new[] { "CrUser_Id" });
            DropIndex("dbo.Site", new[] { "LmUser_Id" });
            DropIndex("dbo.Site", new[] { "CrUser_Id" });
            DropIndex("dbo.Blog", new[] { "LmUser_Id" });
            DropIndex("dbo.Blog", new[] { "CrUser_Id" });
            DropIndex("dbo.Blog", new[] { "SiteId" });
            DropForeignKey("dbo.PostJoinTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.PostJoinTag", "PostId", "dbo.Post");
            DropForeignKey("dbo.PortfolioJoinTag", "TagId", "dbo.Tag");
            DropForeignKey("dbo.PortfolioJoinTag", "PortfolioNodeId", "dbo.PortfolioNode");
            DropForeignKey("dbo.UserJoinRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserJoinRole", "UserId", "dbo.User");
            DropForeignKey("dbo.PageTemplate", "LmUser_Id", "dbo.User");
            DropForeignKey("dbo.PageTemplate", "CrUser_Id", "dbo.User");
            DropForeignKey("dbo.PageTemplate", "SiteId", "dbo.Site");
            DropForeignKey("dbo.SliderStep", "LmUser_Id", "dbo.User");
            DropForeignKey("dbo.SliderStep", "CrUser_Id", "dbo.User");
            DropForeignKey("dbo.SliderStep", "SliderId", "dbo.SliderHeader");
            DropForeignKey("dbo.SliderHeader", "LmUser_Id", "dbo.User");
            DropForeignKey("dbo.SliderHeader", "CrUser_Id", "dbo.User");
            DropForeignKey("dbo.Page", "LmUser_Id", "dbo.User");
            DropForeignKey("dbo.Page", "CrUser_Id", "dbo.User");
            DropForeignKey("dbo.Page", "BlogId", "dbo.Blog");
            DropForeignKey("dbo.Page", "PortfolioHeaderId", "dbo.PortfolioHeader");
            DropForeignKey("dbo.Page", "SliderHeaderId", "dbo.SliderHeader");
            DropForeignKey("dbo.Page", "PageParentId", "dbo.Page");
            DropForeignKey("dbo.Page", "SiteId", "dbo.Site");
            DropForeignKey("dbo.Setting", "SiteId", "dbo.Site");
            DropForeignKey("dbo.PortfolioHeader", "LmUser_Id", "dbo.User");
            DropForeignKey("dbo.PortfolioHeader", "CrUser_Id", "dbo.User");
            DropForeignKey("dbo.PortfolioHeader", "SiteId", "dbo.Site");
            DropForeignKey("dbo.PortfolioNode", "LmUser_Id", "dbo.User");
            DropForeignKey("dbo.PortfolioNode", "CrUser_Id", "dbo.User");
            DropForeignKey("dbo.PortfolioNode", "PortfolioId", "dbo.PortfolioHeader");
            DropForeignKey("dbo.Comment", "PortfolioNodeId", "dbo.PortfolioNode");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "LmUser_Id", "dbo.User");
            DropForeignKey("dbo.Post", "CrUser_Id", "dbo.User");
            DropForeignKey("dbo.Post", "BlogId", "dbo.Blog");
            DropForeignKey("dbo.Role", "LmUser_Id", "dbo.User");
            DropForeignKey("dbo.Role", "CrUser_Id", "dbo.User");
            DropForeignKey("dbo.Site", "LmUser_Id", "dbo.User");
            DropForeignKey("dbo.Site", "CrUser_Id", "dbo.User");
            DropForeignKey("dbo.Blog", "LmUser_Id", "dbo.User");
            DropForeignKey("dbo.Blog", "CrUser_Id", "dbo.User");
            DropForeignKey("dbo.Blog", "SiteId", "dbo.Site");
            DropTable("dbo.PostJoinTag");
            DropTable("dbo.PortfolioJoinTag");
            DropTable("dbo.UserJoinRole");
            DropTable("dbo.Lang");
            DropTable("dbo.Layout");
            DropTable("dbo.PageTemplate");
            DropTable("dbo.SliderStep");
            DropTable("dbo.SliderHeader");
            DropTable("dbo.Page");
            DropTable("dbo.Setting");
            DropTable("dbo.PortfolioHeader");
            DropTable("dbo.Tag");
            DropTable("dbo.PortfolioNode");
            DropTable("dbo.Comment");
            DropTable("dbo.Post");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Site");
            DropTable("dbo.Blog");
        }
    }
}
