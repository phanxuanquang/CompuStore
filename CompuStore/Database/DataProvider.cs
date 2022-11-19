using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database
{
    using Database.Models;
    using System.Data.Entity.Core.EntityClient;
    using System.Data.Entity;
    using System.Data.SqlClient;

    public class DataProvider
    {
        private static DataProvider instance;

        public CompuStoreDBEntities Database { get; set; }
        public static DataProvider Instance => instance ?? (instance = new DataProvider());
        private DataProvider()
        {
            Database = new CompuStoreDBEntities();
        }

        public static bool ChangeDatabase(string configConnectionStringName)
        {
            try
            {
                var configNameEf = string.IsNullOrEmpty(configConnectionStringName) ? Instance.Database.GetType().Name : configConnectionStringName;

                var entityCnxStringBuilder = new EntityConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[configNameEf].ConnectionString);

                var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);

                Instance.Database.Database.Connection.ConnectionString = sqlCnxStringBuilder.ConnectionString;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
