using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    internal class CommonSpecsServices
    {
        private static CommonSpecsServices instance;

        public static CommonSpecsServices Instance => instance ?? (instance = new CommonSpecsServices());

        private CommonSpecsServices() { }

        public COMMON_SPECS GetCommonSpecsByNameID(string nameId)
        {
            return DataProvider.Instance.Database.COMMON_SPECS.FirstOrDefault(item => item.NAME_ID.CompareTo(nameId) == 0);
        }
    }
}
