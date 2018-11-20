using System.Configuration;
using System.Data.SQLite;

namespace JustRipe.Data
{
    public  class SQLiteDb
    {

        public static SQLiteConnection DbConnection()
        {
            return new System.Data.SQLite.SQLiteConnection(LoadConnectionString());
        }

        private static string LoadConnectionString(string id = "SQLiteConnectionString")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}