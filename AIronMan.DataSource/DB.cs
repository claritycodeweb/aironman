using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using AIronMan.Domain;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AIronMan.DataSource {
    public class DB : DbContext {
        public DB() : base("ApplicationServices") { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<File> Files { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<PageTemplate> PageTemplates { get; set; }
        public DbSet<SliderHeader> SliderHeaders { get; set; }
        public DbSet<SliderStep> SliderStep { get; set; }
        public DbSet<Layout> Layouts { get; set; }
        public DbSet<PortfolioHeader> PortfolioHeaders { get; set; }
        public DbSet<PortfolioNode> PortfolioNodes { get; set; }
        //public DbSet<CategoryPortfolio> CategoryPortfolio { get; set; }
        public DbSet<Lang> Langs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer<AIronMan.DataSource.DB>(null);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Post>().HasRequired(p => p.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.BlogId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags).WithMany(t => t.Posts)
                .Map(mc => {
                    mc.ToTable("PostJoinTag");
                    mc.MapLeftKey("PostId");
                    mc.MapRightKey("TagId");
                });

            modelBuilder.Entity<PortfolioNode>()
            .HasMany(p => p.Tags).WithMany(t => t.PortfolioNodes)
            .Map(mc => {
                mc.ToTable("PortfolioJoinTag");
                mc.MapLeftKey("PortfolioNodeId");
                mc.MapRightKey("TagId");
            });

            modelBuilder.Entity<Page>().HasOptional(t => t.PageParent).WithMany().HasForeignKey(t => t.PageParentId);

            modelBuilder.Entity<User>()
            .HasMany(p => p.Roles).WithMany(t => t.Users)
            .Map(mc => {
                mc.ToTable("UserJoinRole");
                mc.MapLeftKey("UserId");
                mc.MapRightKey("RoleId");
            });
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            modelBuilder.Entity<PageTemplate>()
                .HasKey(u => new {
                    u.TemplateId,
                    u.Lang,
                    u.Id
                });
        }
    }
}
