using AIronMan.DataSource.DbConfig.Contract;

namespace AIronMan.DataSource.DbConfig
{
    public enum Dbms
    {
        Mssql, Postgresql
    }

    public static class DbConfigFactory
    {
        public static IDbConfig Create(Dbms animalType)
        {
            IDbConfig dbConfig = null;
            switch (animalType)
            {
                case Dbms.Mssql:
                    dbConfig = new MssqlConfig();
                    break;
                case Dbms.Postgresql:
                    dbConfig = new PostgresqlConfig();
                    break;
                default:
                    dbConfig = new MssqlConfig();
                    break;
            }
            return dbConfig;
        }
    }
}
