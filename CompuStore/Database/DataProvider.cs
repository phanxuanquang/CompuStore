using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database
{
    using Database.Models;
    public class DataProvider
    {
        private static DataProvider instance;

        public CompuStoreDBEntities Database { get; set; }
        public static DataProvider Instance => instance ?? (instance = new DataProvider());
        private DataProvider()
        {
            Database = new CompuStoreDBEntities();
        }
    }
}
