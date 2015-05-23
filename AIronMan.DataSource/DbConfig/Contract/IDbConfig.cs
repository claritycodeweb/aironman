using System.Data.Entity;

namespace AIronMan.DataSource.DbConfig.Contract
{
    public interface IDbConfig
    {
        void Configuration(DbModelBuilder modelBuilder);
    }
}
