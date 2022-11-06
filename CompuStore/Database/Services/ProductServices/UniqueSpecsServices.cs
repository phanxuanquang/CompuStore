using CompuStore.Database.Models;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services.ProductServices
{
    internal class UniqueSpecsServices
    {
        private static UniqueSpecsServices instance;

        public static UniqueSpecsServices Instance => instance ?? (instance = new UniqueSpecsServices());

        private UniqueSpecsServices() { }

        public async Task<UNIQUE_SPECS> GetUniqueSpecs(ModelProduct product, DISPLAY_SPECS displaySpecs)
        {
            if (product == null || displaySpecs == null) return null;

            UNIQUE_SPECS model = MappingModelProduct.Instance.CreateUniqueSpecsByModelProduct(product);
            model.ID_DISPLAY_SPECS = displaySpecs.ID;

            return await Controller.Instance.GetData(DataProvider.Instance.Database.UNIQUE_SPECS,
                item =>
                item.ID_DISPLAY_SPECS == model.ID_DISPLAY_SPECS &&
                item.CPU == model.CPU &&
                item.IGPU == model.IGPU &&
                item.RAM == model.RAM &&
                item.TYPE_STORAGE == model.TYPE_STORAGE &&
                item.STORAGE_CAPACITY == model.STORAGE_CAPACITY &&
                item.GPU == model.GPU &&
                item.BATTERY_CAPACITY == model.BATTERY_CAPACITY &&
                item.WEIGHT == model.WEIGHT,
                model
                );
        }
    }
}
