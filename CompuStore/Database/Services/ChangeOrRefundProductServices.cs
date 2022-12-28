using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    internal class ChangeOrRefundProductServices
    {
        private static ChangeOrRefundProductServices instance;
        public static ChangeOrRefundProductServices Instance => instance ?? (instance = new ChangeOrRefundProductServices());

        private ChangeOrRefundProductServices() { }

        public List<CHANGE_OR_REFUND_PRODUCT> GetCHANGE_OR_REFUND_PRODUCTs()
        {
            return DataProvider.Instance.Database.CHANGE_OR_REFUND_PRODUCT.ToList();
        }

        public Exception SaveCOrreFundToDB(int idInvoice, int idStaff, int productID, int productRe, string reason , DateTime returnDate)
        {
            CHANGE_OR_REFUND_PRODUCT receive = new CHANGE_OR_REFUND_PRODUCT()
            {
                ID_INVOICE = idInvoice,
                ID_HANDLING_STAFF = idStaff,
                PRODUCT_ID = productID,
                PRODUCT_ID_RE = productRe,
                REASON = reason,
                RETURN_DATE = returnDate,
            };
            PRODUCT pro = Database.DataProvider.Instance.Database.PRODUCTs.Where(item => item.PRODUCT_ID == productID).FirstOrDefault();
            if (pro != null)
            {
                pro.IN_WAREHOUSE = true;
            }
            PRODUCT proRe = Database.DataProvider.Instance.Database.PRODUCTs.Where(item => item.PRODUCT_ID == productRe).FirstOrDefault();
            if (proRe != null)
            {
                proRe.IN_WAREHOUSE = false;
            }

            Database.DataProvider.Instance.Database.CHANGE_OR_REFUND_PRODUCT.Add(receive);
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
