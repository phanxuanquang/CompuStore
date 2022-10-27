using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    using Models;
    internal class InvoiceServices
    {
        private static InvoiceServices instance;
        public static InvoiceServices Instance => instance ?? (instance = new InvoiceServices());

        private InvoiceServices() { }

        public List<INVOICE> GetListInvoiceOfStaff(string idStaff)
        {
        }

        public bool SaveInvoiceHasCusToDB(List<PRODUCT> listProduct, int idCustomer, int idStaff, DateTime invoiceDate, double vat, string idStore = null)
        {
            INVOICE invoice = new INVOICE()
            {
                ID_CUSTOMER = idCustomer,
                ID_STAFF = idStaff,
                INVOICE_DATE = invoiceDate,
                VAT = vat,
            };
            Database.DataProvider.Instance.Database.INVOICEs.Add(invoice);
            foreach(var product in listProduct)
            {
                DETAIL_INVOICE detail = new DETAIL_INVOICE()
                {
                    ID_INVOICE = invoice.ID,
                    SERIAL_ID = product.SERIAL_ID,
                    PRICE_PER_UNIT = (double)product.DETAIL_SPECS.PRICE
                };
                Database.DataProvider.Instance.Database.DETAIL_INVOICE.Add(detail);
            }
            try
            {
                Database.DataProvider.Instance.Database.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
