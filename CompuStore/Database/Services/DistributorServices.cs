using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    internal class DistributorServices
    {
        private static DistributorServices instance;

        public static DistributorServices Instance => instance ?? (instance = new DistributorServices());

        private DistributorServices() { }

        public DISTRIBUTOR GetDistributorByID(int ID)
        {
            return DataProvider.Instance.Database.DISTRIBUTORs.FirstOrDefault(item => item.ID == ID);
        }
    }
}
