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
            return null;
        }

        public List<INVOICE> GetINVOICEs()
        {
            return DataProvider.Instance.Database.INVOICEs.ToList();
        }

        public DETAIL_INVOICE GetDetailBySerialID(string serialID)
        {
            return Database.DataProvider.Instance.Database.DETAIL_INVOICE.Where(detail => detail.PRODUCT.SERIAL_ID == serialID).FirstOrDefault();
        }

        public Exception SaveInvoiceToDB(List<PRODUCT> listProduct, int idCustomer, int idStaff, DateTime invoiceDate, double vat, string idStore = null)
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
                double? price = product.DETAIL_SPECS.PRICE;
                if (price == null)
                {
                    price = 1000000;
                }
                DETAIL_INVOICE detail = new DETAIL_INVOICE()
                {
                    ID_INVOICE = invoice.ID,
                    PRODUCT_ID = product.PRODUCT_ID,
                    PRICE_PER_UNIT = (double)price
                };
                Database.DataProvider.Instance.Database.DETAIL_INVOICE.Add(detail);
                product.IN_WAREHOUSE = false;
            }
            try
            {
                Database.DataProvider.Instance.Database.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex;
            }
            return new Exception("done");
        }
    }
}
