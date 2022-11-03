using CompuStore.Database.Models;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services.ProductServices
{
    internal class DetailSpecsServices
    {
        private static DetailSpecsServices instance;

        public static DetailSpecsServices Instance => instance ?? (instance = new DetailSpecsServices());

        private DetailSpecsServices() { }

        public async Task<DETAIL_SPECS> GetDetailSpecs(ModelProduct product, COMMON_SPECS commonSpecs, UNIQUE_SPECS uniqueSpecs, COLOR color)
        {
            if (product == null || commonSpecs == null || uniqueSpecs == null || color == null || color.COLOR_CODE == null) return null;

            DETAIL_SPECS model = MappingModelProduct.Instance.CreateDetailSpecsByModelProduct(product);
            model.ID_COMMON_SPECS = commonSpecs.ID;
            model.ID_UNIQUE_SPECS = uniqueSpecs.ID;
            model.COLOR_CODE = color.COLOR_CODE;

            return await Controller.Instance.GetData(DataProvider.Instance.Database.DETAIL_SPECS,
                item =>
                item.ID_COMMON_SPECS == model.ID_COMMON_SPECS &&
                item.ID_UNIQUE_SPECS == model.ID_UNIQUE_SPECS &&
                item.COLOR_CODE == model.COLOR_CODE &&
                item.PRICE == model.PRICE,
                model
                );
        }
    }
}
