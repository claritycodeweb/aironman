using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using AIronMan.DataSource.DbConfig.Contract;
using AIronMan.Domain;

namespace AIronMan.DataSource.DbConfig
{
    public class MssqlConfig : IDbConfig
    {
        public void Configuration(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DB>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Post>().HasRequired(p => p.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.BlogId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags).WithMany(t => t.Posts)
                .Map(mc =>
                {
                    mc.ToTable("PostJoinTag");
                    mc.MapLeftKey("PostId");
                    mc.MapRightKey("TagId");
                });

            modelBuilder.Entity<PortfolioNode>()
            .HasMany(p => p.Tags).WithMany(t => t.PortfolioNodes)
            .Map(mc =>
            {
                mc.ToTable("PortfolioJoinTag");
                mc.MapLeftKey("PortfolioNodeId");
                mc.MapRightKey("TagId");
            });

            modelBuilder.Entity<Page>().HasOptional(t => t.PageParent).WithMany().HasForeignKey(t => t.PageParentId);

            modelBuilder.Entity<User>()
            .HasMany(p => p.Roles).WithMany(t => t.Users)
            .Map(mc =>
            {
                mc.ToTable("UserJoinRole");
                mc.MapLeftKey("UserId");
                mc.MapRightKey("RoleId");
            });

            modelBuilder.Entity<PageTemplate>()
                .HasKey(u => new
                {
                    u.TemplateId,
                    u.Lang,
                    u.Id
                });
        }
    }
}
