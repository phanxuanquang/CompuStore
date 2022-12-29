using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompuStore.Database.Models;
using CompuStore.Database.Services.ProductServices;
using CompuStore.ImportData;

namespace CompuStore.Database.Services.ProductServices
{
    internal class MappingModelProduct
    {
        private static MappingModelProduct instance;

        public static MappingModelProduct Instance => instance ?? (instance = new MappingModelProduct());

        private MappingModelProduct() { }

        public LINE_UP CreateLineUpByModelProduct(ModelProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            return new LINE_UP { NAME = product.LineUp, MANUFACTURER = product.Manufacturer, COUNTRY = product.Country };
        }

        public COLOR CreateColorByModelProduct(ModelProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            return new COLOR { COLOR_CODE = product.ColorCode, COLOR_NAME = product.ColorName };
        }

        public DISPLAY_SPECS CreateDisplaySpecsByModelProduct(ModelProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            return new DISPLAY_SPECS
            {
                CODE_DISPLAY = product.IdPanel,
                RESOLUTION = product.ResolutionString,
                SIZE = product.SizePanel,
                BRIGHTNESS = product.Brightness,
                PANEL = product.TypePanel,
                COLOR_SPACE = product.SpaceColorString,
                REFRESH_RATE = product.RefreshRate,
                IS_TOUCH_PANEL = product.CanTouchPanel,
                SCREEN_TYPE = product.TypeScreen,
                RATIO = product.RatioPanelString
            };
        }

        public COMMON_SPECS CreateCommonSpecsByModelProduct(ModelProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            return new COMMON_SPECS
            {
                NAME = product.NameProduct,
                RELEASED_YEAR = product.ReleaseDate,
                CASE_MATERIAL = product.CaseMaterial,
                PORT = product.PortString,
                WEBCAM = product.Webcam,
                DIMENSIONS = product.SizeProductString,
                WIFI = product.Wifi,
                BLUETOOTH = product.Bluetooth,
                QUANTITY = 0
            };
        }

        public UNIQUE_SPECS CreateUniqueSpecsByModelProduct(ModelProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            return new UNIQUE_SPECS
            {
                CPU = product.CPU,
                IGPU = product.iGPU,
                RAM = product.RAMString,
                TYPE_STORAGE = product.TypeStorage,
                STORAGE_CAPACITY = product.StorageCapacity,
                GPU = product.GPUString,
                BATTERY_CAPACITY = product.BatteryCapacity,
                WEIGHT = product.Weight,
                OS = product.OS
            };
        }

        public DETAIL_SPECS CreateDetailSpecsByModelProduct(ModelProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            //Note: Lúc nhập hàng thì price là giá của nhập hàng, giá của sản phẩm là giá nhập hàng * tỉ lệ lợi nhuận
            return new DETAIL_SPECS { /*PRICE = product.Price,*/ QUANTITY = 0 };
        }
    }
}
