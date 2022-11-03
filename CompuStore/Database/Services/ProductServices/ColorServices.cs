using CompuStore.Database.Models;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services.ProductServices
{
    internal class ColorServices
    {
        private static ColorServices instance;

        public static ColorServices Instance => instance ?? (instance = new ColorServices());

        private ColorServices() { }

        public async Task<COLOR> GetColor(ModelProduct product)
        {
            if (product == null) return null;

            COLOR model = MappingModelProduct.Instance.CreateColorByModelProduct(product);

            return await Controller.Instance.GetData(DataProvider.Instance.Database.COLORs,
                item => item.COLOR_CODE == model.COLOR_CODE && item.COLOR_NAME == model.COLOR_NAME,
                model
                );
        }

        public Task<int> UpdateColor(COLOR target, string colorCode, string colorName)
        {
            if (target == null) return null;
            target.COLOR_CODE = colorCode;
            target.COLOR_NAME = colorName;
            return DataProvider.Instance.Database.SaveChangesAsync();
        }
    }
}
