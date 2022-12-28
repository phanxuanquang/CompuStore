using CompuStore.Database.Models;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services.ProductServices
{
    internal class ProductServices
    {
        private static ProductServices instance;

        public static ProductServices Instance => instance ?? (instance = new ProductServices());

        private ProductServices() { }

        public List<PRODUCT> GetPRODUCTs()
        {
            return DataProvider.Instance.Database.PRODUCTs.ToList();
        }

        public PRODUCT GetProductBySerial(string serial) => DataProvider.Instance.Database.PRODUCTs.Where(item => item.SERIAL_ID == serial).FirstOrDefault();

        protected async Task<bool> DeleteProduct(PRODUCT target)
        {
            if (target == null)
                throw new ArgumentNullException();
            DataProvider.Instance.Database.PRODUCTs.Remove(target);
            await DataProvider.Instance.Database.SaveChangesAsync();
            return true;
        }

        public async Task<PRODUCT> ImportProduct(ModelProduct product)
        {
            if (product == null) return null;

            PRODUCT dbProduct = new PRODUCT();

            LINE_UP lineup = await LineUpServices.Instance.GetLineUp(product);
            DISPLAY_SPECS displaySpecs = await DisplaySpecsServices.Instance.GetDislaySpecs(product);
            COLOR color = await ColorServices.Instance.GetColor(product);
            COMMON_SPECS commonSpecs = await CommonSpecsServices.Instance.GetCommonSpecs(product, lineup);
            UNIQUE_SPECS uniqueSpecs = await UniqueSpecsServices.Instance.GetUniqueSpecs(product, displaySpecs);
            DETAIL_SPECS detailSpecs = await DetailSpecsServices.Instance.GetDetailSpecs(product, commonSpecs, uniqueSpecs, color);

            dbProduct.SERIAL_ID = product.Serial;
            dbProduct.ID_DETAIL_SPECS = detailSpecs.ID;
            dbProduct.IN_WAREHOUSE = true;

            DataProvider.Instance.Database.PRODUCTs.Add(dbProduct);
            await DataProvider.Instance.Database.SaveChangesAsync();

            return dbProduct;
        }

        public async Task<bool?> RemoveProduct(ModelProduct model)
        {
            if (model == null)
                throw new ArgumentNullException();
            try
            {
                PRODUCT product = GetProductBySerial(model.Serial);
                if (product.IN_WAREHOUSE == false)
                    return null;
                DETAIL_IMPORT_WAREHOUSE detail = DetailImportWarehouseServices.Instance.GetDetailImportWarehouseByProduct(product.PRODUCT_ID);
                await DetailImportWarehouseServices.Instance.DeleteDetailImportWarehouse(detail);
                await DeleteProduct(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool?> ChangeInfo(KeyValuePair<ModelProduct, ModelProduct> product)
        {
            if (product.Key == null || product.Value == null)
                throw new ArgumentNullException();
            try
            {
                PRODUCT current = GetProductBySerial(product.Key.Serial);
                if (current.IN_WAREHOUSE == false)
                    return null;
                ModelProduct update = product.Value;

                DETAIL_IMPORT_WAREHOUSE detailImport = DetailImportWarehouseServices.Instance.GetDetailImportWarehouseByProduct(current.PRODUCT_ID);

                LINE_UP lineup = await LineUpServices.Instance.GetLineUp(update);
                DISPLAY_SPECS displaySpecs = await DisplaySpecsServices.Instance.GetDislaySpecs(update);
                COLOR color = await ColorServices.Instance.GetColor(update);
                COMMON_SPECS commonSpecs = await CommonSpecsServices.Instance.GetCommonSpecs(update, lineup);
                UNIQUE_SPECS uniqueSpecs = await UniqueSpecsServices.Instance.GetUniqueSpecs(update, displaySpecs);
                DETAIL_SPECS detailSpecs = await DetailSpecsServices.Instance.GetDetailSpecs(update, commonSpecs, uniqueSpecs, color);

                current.ID_DETAIL_SPECS = detailSpecs.ID;
                current.SERIAL_ID = update.Serial;
                detailImport.PRICE_PER_UNIT = update.Price;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
