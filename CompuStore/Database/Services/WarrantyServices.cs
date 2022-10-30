using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    using Models;
    internal class WarrantyServices
    {
        private static WarrantyServices instance;
        public static WarrantyServices Instance => instance ?? (instance = new WarrantyServices());

        private WarrantyServices() { }

        public List<RECEIVE_WARRANTY> GetWarrantys()
        {
            return DataProvider.Instance.Database.RECEIVE_WARRANTY.ToList();
        }
    }
}
