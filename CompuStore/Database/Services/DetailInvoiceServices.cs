using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    using Models;
    internal class DetailInvoiceServices
    {
        private static DetailInvoiceServices instance;
        public static DetailInvoiceServices Instance => instance ?? (instance = new DetailInvoiceServices());

        private DetailInvoiceServices() { }

        public List<DETAIL_INVOICE> GetDETAIL_INVOICEs()
        {
            return Database.DataProvider.Instance.Database.DETAIL_INVOICE.ToList();
        }

    }
}
