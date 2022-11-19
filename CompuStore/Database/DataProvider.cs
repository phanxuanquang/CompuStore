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

        public async Task<bool> ChangeDatabase(string configConnectionStringName)
        {
            try
            {
                var configNameEf = string.IsNullOrEmpty(configConnectionStringName) ? Instance.Database.GetType().Name : configConnectionStringName;

                var entityCnxStringBuilder = new EntityConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[configNameEf].ConnectionString);

                var sqlCnxStringBuilder = new SqlConnectionStringBuilder(entityCnxStringBuilder.ProviderConnectionString);

                bool existsDatabase = true;
                await Task.Factory.StartNew(() =>
                {
                    using (SqlConnection cnx = new SqlConnection(sqlCnxStringBuilder.ConnectionString))
                    {
                        try
                        {
                            cnx.Open();
                            cnx.Close();
                        }
                        catch (Exception ex)
                        {
                            existsDatabase = false;
                        }
                    }
                });

                if (existsDatabase)
                {
                    Instance.Database.Database.Connection.ConnectionString = sqlCnxStringBuilder.ConnectionString;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
