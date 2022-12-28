using CompuStore.Database.Models;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services.ProductServices
{
    internal class ImportWarehouseServices
    {
        private static ImportWarehouseServices instance;

        public static ImportWarehouseServices Instance => instance ?? (instance = new ImportWarehouseServices());

        private ImportWarehouseServices() { }

        public IMPORT_WAREHOUSE GetImportWarehouseByNameID(string nameID)
        {
            return DataProvider.Instance.Database.IMPORT_WAREHOUSE.FirstOrDefault(item => item.NAME_ID == nameID);
        }

        public Task<int> UpdateImportWarehouse(IMPORT_WAREHOUSE target, STORE store, STAFF staff, DISTRIBUTOR distributor, DateTime? importDate)
        {
            if (target == null) return null;
            target.STORE = store ?? target.STORE;
            target.STAFF = staff ?? target.STAFF;
            target.DISTRIBUTOR = distributor ?? target.DISTRIBUTOR;
            target.IMPORT_DATE = importDate ?? target.IMPORT_DATE;
            return DataProvider.Instance.Database.SaveChangesAsync();
        }

        private async Task<IMPORT_WAREHOUSE> CreateInvoiceImportWareHouse(STORE store, STAFF staff, DISTRIBUTOR distributor, DateTime? importDate)
        {
            if (store == null || staff == null || distributor == null) throw new ArgumentNullException();
            IMPORT_WAREHOUSE model = new IMPORT_WAREHOUSE { ID_STORE = store.ID, ID_STAFF = staff.ID, ID_DISTRIBUTOR = distributor.ID, IMPORT_DATE = importDate ?? DateTime.Now };
            DataProvider.Instance.Database.IMPORT_WAREHOUSE.Add(model);
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

        public async Task<(IMPORT_WAREHOUSE, List<ModelProduct>)> Import(ModelProduct[] products, STORE store, STAFF staff, DISTRIBUTOR distributor, DateTime? importDate)
        {
            if (products == null || store == null || staff == null || distributor == null || importDate == null) throw new ArgumentNullException();

            IMPORT_WAREHOUSE invoice = await CreateInvoiceImportWareHouse(store, staff, distributor, importDate);
            List<ModelProduct> errorImport = new List<ModelProduct>();

            for (int index = 0; index < products.Length; index++)
            {
                try
                {
                    PRODUCT model = await ProductServices.Instance.ImportProduct(products[index]);
                    await DetailImportWarehouseServices.Instance.CreateDetailImportWarehouse(invoice, model, products[index].Price);
                }
                catch (AggregateException)
                {
                    errorImport.Add(products[index]);
                }
            }

            return (invoice, errorImport);
        }
    }
}
