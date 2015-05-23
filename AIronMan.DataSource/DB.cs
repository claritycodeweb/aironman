using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data.Entity;

using AIronMan.DataSource.DbConfig;
using AIronMan.DataSource.DbConfig.Contract;
using AIronMan.Domain;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace AIronMan.DataSource
{
    public class DB : DbContext
    {
        public DB() : base("ApplicationServices") { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var dbName = ConfigurationManager.AppSettings["DataBase"];
            if (!string.IsNullOrEmpty(dbName))
            {
                IDbConfig dbConf = DbConfigFactory.Create((Dbms)Enum.Parse(typeof(Dbms), dbName));
                dbConf.Configuration(modelBuilder);
            }
            else
            {
                throw new Exception("No database name settings in web.config.");
            }
        }
    }
}
