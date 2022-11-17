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
    }
}
