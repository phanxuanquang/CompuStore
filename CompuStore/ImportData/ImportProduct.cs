using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.ImportData
{
    using CompuStore.Database;
    using Database.Models;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Windows.Forms;

    internal class ImportProduct
    {
        public const string template = "../../../Resource/Template/data_sample.csv";

        public ModelProduct[] GetCSV()
        {
            string[] x = File.ReadAllLines(template, Encoding.UTF8);
            ModelProduct[] products = new ModelProduct[x.Length];
            for (int index = 1; index < x.Length; index++)
            {
                ModelProduct.TryParse(x[index], out products[index]);
            }

            return products;
        }

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
                new LINE_UP { NAME = product.LineUp, MANUFACTURER = product.Manufacturer, COUNTRY = product.Country }
                );
        }

        private async Task<COLOR> GetColor(ModelProduct product)
        {
            if (product == null) return null;

            return await GetData(DataProvider.Instance.Database.COLORs,
                item => item.COLOR_CODE == product.ColorCode && item.COLOR_NAME == product.ColorName,
                new COLOR { COLOR_CODE = product.ColorCode, COLOR_NAME = product.ColorName }
                );
        }

        private async Task<DISPLAY_SPECS> GetDislaySpecs(ModelProduct product)
        {
            if (product == null) return null;

            string resolution = product.Resolution == null ? null : string.Join("x", product.Resolution);

            return await GetData(DataProvider.Instance.Database.DISPLAY_SPECS,
                item =>
                item.CODE_DISPLAY == product.IdPanel ||
                item.RESOLUTION == resolution &&
                item.SIZE == product.SizePanel &&
                item.BRIGHTNESS == product.Brightness &&
                item.PANEL == product.TypePanel &&
                item.COLOR_SPACE == product.SpaceColor &&
                item.REFRESH_RATE == product.RefreshRate &&
                item.IS_TOUCH_PANEL == product.CanTouchPanel &&
                item.SCREEN_TYPE == product.TypeScreen &&
                item.RATIO == product.RatioPanel,
                new DISPLAY_SPECS { CODE_DISPLAY = product.IdPanel, 
                    RESOLUTION = resolution, 
                    SIZE = product.SizePanel, 
                    BRIGHTNESS = product.Brightness, 
                    PANEL = product.TypePanel, 
                    COLOR_SPACE = product.SpaceColor, 
                    REFRESH_RATE = product.RefreshRate, 
                    IS_TOUCH_PANEL = product.CanTouchPanel, 
                    SCREEN_TYPE = product.TypeScreen, 
                    RATIO = product.RatioPanel }
                );
        }

        private async Task<COMMON_SPECS> GetCommonSpecs(ModelProduct product, LINE_UP lineup)
        {
            if (product == null || lineup == null) return null;

            string ports = product.Ports == null ? null : string.Join("_", product.Ports);
            string dimensions = product.SizeProduct == null ? null : string.Join("x", product.SizeProduct);

            return await GetData(DataProvider.Instance.Database.COMMON_SPECS,
                item =>
                item.ID_LINE_UP == lineup.ID &&
                item.NAME == product.NameProduct &&
                item.RELEASED_YEAR == product.ReleaseDate &&
                item.CASE_MATERIAL == product.CaseMaterial &&
                item.PORT == ports &&
                item.WEBCAM == product.Webcam &&
                item.DIMENSIONS == dimensions &&
                item.OS == product.OS &&
                item.WIFI == product.Wifi &&
                item.BLUETOOTH == product.Bluetooth,
                new COMMON_SPECS
                {
                    ID_LINE_UP = lineup.ID,
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
                }
                );
        }

        private async Task<UNIQUE_SPECS> GetUniqueSpecs(ModelProduct product, DISPLAY_SPECS displaySpecs)
        {
            if (product == null || displaySpecs == null) return null;

            string gpu = product.GPU == null ? null : string.Join(" ", product.GPU);

            return await GetData(DataProvider.Instance.Database.UNIQUE_SPECS,
                item =>
                item.ID_DISPLAY_SPECS == displaySpecs.ID &&
                item.CPU == product.CPU &&
                item.IGPU == product.iGPU &&
                item.RAM == product.RAM &&
                item.TYPE_DRIVE == product.TypeDrive &&
                item.SIZE_DRIVE == product.DriveCapacity &&
                item.GPU == gpu &&
                item.BATTERY_CAPACITY == product.BatteryCapacity &&
                item.WEIGHT == product.Weight,
                new UNIQUE_SPECS { ID_DISPLAY_SPECS = displaySpecs.ID, 
                    CPU = product.CPU, 
                    IGPU = product.iGPU, 
                    RAM = product.RAM, 
                    TYPE_DRIVE = product.TypeDrive, 
                    SIZE_DRIVE = product.DriveCapacity, 
                    GPU = gpu, 
                    BATTERY_CAPACITY = product.BatteryCapacity, 
                    WEIGHT = product.Weight }
                );
        }

        private async Task<DETAIL_SPECS> GetDetailSpecs(ModelProduct product, COMMON_SPECS commonSpecs, UNIQUE_SPECS uniqueSpecs, COLOR color)
        {
            if (product == null || commonSpecs == null || uniqueSpecs == null || color == null || color.COLOR_CODE == null) return null;

            return await GetData(DataProvider.Instance.Database.DETAIL_SPECS,
                item =>
                item.ID_COMMON_SPECS == commonSpecs.ID &&
                item.ID_UNIQUE_SPECS == uniqueSpecs.ID &&
                item.COLOR_CODE == color.COLOR_CODE &&
                item.PRICE == product.Price,
                new DETAIL_SPECS { ID_COMMON_SPECS = commonSpecs.ID, ID_UNIQUE_SPECS = uniqueSpecs.ID, COLOR_CODE = color.COLOR_CODE, PRICE = product.Price, QUANTITY = 0 }
                );
        }

        public async Task<PRODUCT> InsertProduct(ModelProduct product)
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
