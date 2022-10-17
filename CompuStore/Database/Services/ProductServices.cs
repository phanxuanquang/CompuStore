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

namespace CompuStore.Database.Services
{
    internal class ProductServices
    {
        private static ProductServices instance;

        private static ImportProduct _instanceImport;

        public static ProductServices Instance => instance ?? (instance = new ProductServices());

        public static ImportProduct InstanceImport => _instanceImport ?? (_instanceImport = new ImportProduct());

        private ProductServices() { }

        public PRODUCT GetProductBySerial(string serial) => DataProvider.Instance.Database.PRODUCTs.Where(item => item.SERIAL_ID == serial).FirstOrDefault();

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

        public DISPLAY_SPECS CreateDisplaySpecsByModelProduct(ModelProduct product) {
            if (product == null) throw new ArgumentNullException();

            string resolution = product.Resolution == null ? null : string.Join("x", product.Resolution);

            return new DISPLAY_SPECS
            {
                CODE_DISPLAY = product.IdPanel,
                RESOLUTION = resolution,
                SIZE = product.SizePanel,
                BRIGHTNESS = product.Brightness,
                PANEL = product.TypePanel,
                COLOR_SPACE = product.SpaceColor,
                REFRESH_RATE = product.RefreshRate,
                IS_TOUCH_PANEL = product.CanTouchPanel,
                SCREEN_TYPE = product.TypeScreen,
                RATIO = product.RatioPanel
            };
        }

        public COMMON_SPECS CreateCommonSpecsByModelProduct(ModelProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            string ports = product.Ports == null ? null : string.Join("_", product.Ports);
            string dimensions = product.SizeProduct == null ? null : string.Join("x", product.SizeProduct);

            return new COMMON_SPECS
            {
                NAME = product.NameProduct,
                RELEASED_YEAR = product.ReleaseDate,
                CASE_MATERIAL = product.CaseMaterial,
                PORT = ports,
                WEBCAM = product.Webcam,
                DIMENSIONS = dimensions,
                OS = product.OS,
                WIFI = product.Wifi,
                BLUETOOTH = product.Bluetooth,
                QUANTITY = 0
            };
        }

        public UNIQUE_SPECS CreateUniqueSpecsByModelProduct(ModelProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            string gpu = product.GPU == null ? null : string.Join(" ", product.GPU);

            return new UNIQUE_SPECS
            {
                CPU = product.CPU,
                IGPU = product.iGPU,
                RAM = product.RAM,
                TYPE_DRIVE = product.TypeDrive,
                SIZE_DRIVE = product.DriveCapacity,
                GPU = gpu,
                BATTERY_CAPACITY = product.BatteryCapacity,
                WEIGHT = product.Weight
            };
        }

        public DETAIL_SPECS CreateDetailSpecsByModelProduct(ModelProduct product)
        {
            if (product == null) throw new ArgumentNullException();

            //Note: Lúc nhập hàng thì price là giá của nhập hàng, giá của sản phẩm là giá nhập hàng * tỉ lệ lợi nhuận
            return new DETAIL_SPECS { /*PRICE = product.Price,*/ QUANTITY = 0 };
        }

        public class ImportProduct
        {
            private async Task<TEntity> GetData<TEntity>(DbSet<TEntity> tableTarget,
            Expression<Func<TEntity, bool>> whereQuery, TEntity entity) where TEntity : class
            {
                TEntity find = tableTarget.Where(whereQuery).FirstOrDefault();

                if (find == null)
                {
                    tableTarget.Add(entity);
                    await DataProvider.Instance.Database.SaveChangesAsync();

                    find = entity;
                }

                return find;
            }

            private async Task<LINE_UP> GetLineUp(ModelProduct product)
            {
                if (product == null) return null;

                return await GetData(DataProvider.Instance.Database.LINE_UP,
                    item => item.NAME == product.LineUp && item.MANUFACTURER == product.Manufacturer && item.COUNTRY == product.Country,
                    Instance.CreateLineUpByModelProduct(product)
                    );
            }

            private async Task<COLOR> GetColor(ModelProduct product)
            {
                if (product == null) return null;

                return await GetData(DataProvider.Instance.Database.COLORs,
                    item => item.COLOR_CODE == product.ColorCode && item.COLOR_NAME == product.ColorName,
                    Instance.CreateColorByModelProduct(product)
                    );
            }

            private async Task<DISPLAY_SPECS> GetDislaySpecs(ModelProduct product)
            {
                if (product == null) return null;

                DISPLAY_SPECS model = Instance.CreateDisplaySpecsByModelProduct(product);

                return await GetData(DataProvider.Instance.Database.DISPLAY_SPECS,
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

            private async Task<COMMON_SPECS> GetCommonSpecs(ModelProduct product, LINE_UP lineup)
            {
                if (product == null || lineup == null) return null;

                COMMON_SPECS model = Instance.CreateCommonSpecsByModelProduct(product);
                model.ID_LINE_UP = lineup.ID;

                return await GetData(DataProvider.Instance.Database.COMMON_SPECS,
                    item =>
                    item.ID_LINE_UP == model.ID_LINE_UP &&
                    item.NAME == model.NAME &&
                    item.RELEASED_YEAR == model.RELEASED_YEAR &&
                    item.CASE_MATERIAL == model.CASE_MATERIAL &&
                    item.PORT == model.PORT &&
                    item.WEBCAM == model.WEBCAM &&
                    item.DIMENSIONS == model.DIMENSIONS &&
                    item.OS == model.OS &&
                    item.WIFI == model.WIFI &&
                    item.BLUETOOTH == model.BLUETOOTH,
                    model
                    );
            }

            private async Task<UNIQUE_SPECS> GetUniqueSpecs(ModelProduct product, DISPLAY_SPECS displaySpecs)
            {
                if (product == null || displaySpecs == null) return null;

                UNIQUE_SPECS model = Instance.CreateUniqueSpecsByModelProduct(product);
                model.ID_DISPLAY_SPECS = displaySpecs.ID;

                return await GetData(DataProvider.Instance.Database.UNIQUE_SPECS,
                    item =>
                    item.ID_DISPLAY_SPECS == model.ID_DISPLAY_SPECS &&
                    item.CPU == model.CPU &&
                    item.IGPU == model.IGPU &&
                    item.RAM == model.RAM &&
                    item.TYPE_DRIVE == model.TYPE_DRIVE &&
                    item.SIZE_DRIVE == model.SIZE_DRIVE &&
                    item.GPU == model.GPU &&
                    item.BATTERY_CAPACITY == model.BATTERY_CAPACITY &&
                    item.WEIGHT == model.WEIGHT,
                    model
                    );
            }

            private async Task<DETAIL_SPECS> GetDetailSpecs(ModelProduct product, COMMON_SPECS commonSpecs, UNIQUE_SPECS uniqueSpecs, COLOR color)
            {
                if (product == null || commonSpecs == null || uniqueSpecs == null || color == null || color.COLOR_CODE == null) return null;

                DETAIL_SPECS model = Instance.CreateDetailSpecsByModelProduct(product);
                model.ID_COMMON_SPECS = commonSpecs.ID;
                model.ID_UNIQUE_SPECS = uniqueSpecs.ID;
                model.COLOR_CODE = color.COLOR_CODE;

                return await GetData(DataProvider.Instance.Database.DETAIL_SPECS,
                    item =>
                    item.ID_COMMON_SPECS == model.ID_COMMON_SPECS &&
                    item.ID_UNIQUE_SPECS == model.ID_UNIQUE_SPECS &&
                    item.COLOR_CODE == model.COLOR_CODE &&
                    item.PRICE == model.PRICE,
                    model
                    );
            }

            public async Task<PRODUCT> Import(ModelProduct product)
            {
                if (product == null) return null;

                PRODUCT dbProduct = new PRODUCT();

                LINE_UP lineup = await GetLineUp(product);
                DISPLAY_SPECS displaySpecs = await GetDislaySpecs(product);
                COLOR color = await GetColor(product);
                COMMON_SPECS commonSpecs = await GetCommonSpecs(product, lineup);
                UNIQUE_SPECS uniqueSpecs = await GetUniqueSpecs(product, displaySpecs);
                DETAIL_SPECS detailSpecs = await GetDetailSpecs(product, commonSpecs, uniqueSpecs, color);

                dbProduct.SERIAL_ID = product.Serial;
                dbProduct.ID_DETAIL_SPECS = detailSpecs.ID;
                dbProduct.IN_WAREHOUSE = true;

                DataProvider.Instance.Database.PRODUCTs.Add(dbProduct);
                await DataProvider.Instance.Database.SaveChangesAsync();

                return dbProduct;
            }
        }
    }
}
