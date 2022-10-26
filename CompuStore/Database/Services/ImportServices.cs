using CompuStore.Database.Models;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CompuStore.Database.Services.ProductServices;

namespace CompuStore.Database.Services
{
    internal class ImportServices
    {
        private static ImportServices instance;

        public static ImportServices Instance => instance ?? (instance = new ImportServices());

        private ImportServices() { }

        public IMPORT_WAREHOUSE GetImportWarehouseByNameID(string nameID)
        {
            return DataProvider.Instance.Database.IMPORT_WAREHOUSE.FirstOrDefault(item => item.NAME_ID.CompareTo(nameID) == 0);
        }

        private async Task<IMPORT_WAREHOUSE> CreateInvoiceImportWareHouse(STORE store, STAFF staff, DISTRIBUTOR distributor)
        {
            if (store == null || staff == null || distributor == null) throw new ArgumentNullException();
            IMPORT_WAREHOUSE model = new IMPORT_WAREHOUSE { ID_STORE = store.ID, ID_STAFF = staff.ID, ID_DISTRIBUTOR = distributor.ID, IMPORT_DATE = DateTime.Now };
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

        private async Task<DETAIL_IMPORT_WAREHOUSE> CreateDetailImportWarehouse(IMPORT_WAREHOUSE invoice, PRODUCT product, double? price)
        {
            if (invoice == null || product == null || price == null) throw new ArgumentNullException();

            DETAIL_IMPORT_WAREHOUSE model = new DETAIL_IMPORT_WAREHOUSE { ID_IMPORT_WAREHOUSE = invoice.ID, SERIAL_ID = product.SERIAL_ID, PRICE_PER_UNIT = price };
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

        public async Task<(IMPORT_WAREHOUSE, List<ModelProduct>)> Import(ModelProduct[] products, STORE store, STAFF staff, DISTRIBUTOR distributor)
        {
            if (products == null) throw new ArgumentNullException();

            IMPORT_WAREHOUSE invoice = await CreateInvoiceImportWareHouse(store, staff, distributor);
            List<ModelProduct> errorImport = new List<ModelProduct>();

            for (int index = 0; index < products.Length; index++)
            {
                try
                {
                    await InstanceImport.Import(products[index]).ContinueWith((import) =>
                    {
                        PRODUCT model = import.Result;
                        CreateDetailImportWarehouse(invoice, model, products[index].Price).Wait();
                    });
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
