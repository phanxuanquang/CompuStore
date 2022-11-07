using CompuStore.Database.Models;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services.ProductServices
{
    internal class DisplaySpecsServices
    {
        private static DisplaySpecsServices instance;

        public static DisplaySpecsServices Instance => instance ?? (instance = new DisplaySpecsServices());

        private DisplaySpecsServices() { }

        public async Task<DISPLAY_SPECS> GetDislaySpecs(ModelProduct product)
        {
            if (product == null) return null;

            DISPLAY_SPECS model = MappingModelProduct.Instance.CreateDisplaySpecsByModelProduct(product);

            return await Controller.Instance.GetData(DataProvider.Instance.Database.DISPLAY_SPECS,
                item =>
                item.CODE_DISPLAY == model.CODE_DISPLAY ||
                item.RESOLUTION == model.RESOLUTION &&
                item.SIZE == model.SIZE &&
                item.BRIGHTNESS == model.BRIGHTNESS &&
                item.PANEL == model.PANEL &&
                item.COLOR_SPACE == model.COLOR_SPACE &&
                item.REFRESH_RATE == model.REFRESH_RATE &&
                item.IS_TOUCH_PANEL == model.IS_TOUCH_PANEL &&
                item.SCREEN_TYPE == model.SCREEN_TYPE &&
                item.RATIO == model.RATIO,
                model
                );
        }
    }
}
