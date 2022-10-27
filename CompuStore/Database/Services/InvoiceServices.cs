using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    internal class InvoiceServices
    {
        private static InvoiceServices _instance;
        public static InvoiceServices Instance => _instance ?? (_instance = new InvoiceServices());

        public List<INVOICE> GetINVOICEs()
        {
            return DataProvider.Instance.Database.INVOICEs.ToList();
        }

    }
}
