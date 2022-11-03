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

        public Exception SaveWarrantyToDB(int idInvoice, int idStaff, int productID, string reasonWarranty, DateTime receiveDate, DateTime returnDate, string statusWarranty)
        {
            RECEIVE_WARRANTY receive = new RECEIVE_WARRANTY()
            {
                ID_INVOICE = idInvoice,
                ID_STAFF = idStaff,
                PRODUCT_ID = productID,
                REASON_WARRANTY = reasonWarranty,
                RECEIVE_DATE = receiveDate,
                RETURN_DATE = returnDate,
                STATUS_WARRANTY = statusWarranty
            };
            Database.DataProvider.Instance.Database.RECEIVE_WARRANTY.Add(receive);
            try
            {
                DataProvider.Instance.Database.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex;
            }
            return new Exception("done");
        }
    }
}
