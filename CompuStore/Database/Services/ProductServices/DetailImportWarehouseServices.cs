using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services.ProductServices
{
    internal class DetailImportWarehouseServices
    {
        private static DetailImportWarehouseServices instance;

        public static DetailImportWarehouseServices Instance => instance ?? (instance = new DetailImportWarehouseServices());

        private DetailImportWarehouseServices() { }

        public DETAIL_IMPORT_WAREHOUSE GetDetailImportWarehouseByProduct(int productID)
        {
            return DataProvider.Instance.Database.DETAIL_IMPORT_WAREHOUSE.FirstOrDefault(item => item.PRODUCT_ID == productID);
        }

        public Task<int> UpdateDetailImportWarehouse(DETAIL_IMPORT_WAREHOUSE target, PRODUCT product, double? pricePerUnit)
        {
            if (target == null) return null;
            target.PRODUCT = product ?? target.PRODUCT;
            target.PRICE_PER_UNIT = pricePerUnit ?? target.PRICE_PER_UNIT;
            return DataProvider.Instance.Database.SaveChangesAsync();
        }

        public async Task<DETAIL_IMPORT_WAREHOUSE> CreateDetailImportWarehouse(IMPORT_WAREHOUSE invoice, PRODUCT product, double? price)
        {
            if (invoice == null || product == null || price == null) throw new ArgumentNullException();

            DETAIL_IMPORT_WAREHOUSE model = new DETAIL_IMPORT_WAREHOUSE { ID_IMPORT_WAREHOUSE = invoice.ID, PRODUCT_ID = product.PRODUCT_ID, PRICE_PER_UNIT = price };
            DataProvider.Instance.Database.DETAIL_IMPORT_WAREHOUSE.Add(model);
            try
            {
                await DataProvider.Instance.Database.SaveChangesAsync();
                return model;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteDetailImportWarehouse(DETAIL_IMPORT_WAREHOUSE target)
        {
            if (target == null)
                throw new ArgumentNullException();
            DataProvider.Instance.Database.DETAIL_IMPORT_WAREHOUSE.Remove(target);
            await DataProvider.Instance.Database.SaveChangesAsync();
            return true;
        }
    }
}
