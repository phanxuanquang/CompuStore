using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.ImportData
{
    using Database.Models;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Drawing.Drawing2D;

    internal class ImportProduct
    {
        public const string template = "../../../Resource/Template/data_sample.csv";
        public static CompuStoreDBEntities instance = null;

        public ImportProduct()
        {
            instance = instance ?? new CompuStoreDBEntities();
        }

        public void ImportData()
        {
            string[] x = File.ReadAllLines(template);
            ModelProduct[] products = new ModelProduct[x.Length];
            for (int index = 1; index < x.Length; index++)
            {
                ModelProduct.TryParse(x[index], out products[index]);
            }

            //GetLineUp(products[3]);
            //GetColor(products[1]);
            //GetDislaySpecs(products[1]);
            //GetCommonSpecs(products[1], GetLineUp(products[1]));
            //GetUniqueSpecs(products[1], GetDislaySpecs(products[1]));

            foreach(ModelProduct product in products)
            {
                InsertProduct(product, GetDetailSpecs(product, GetCommonSpecs(product, GetLineUp(product)), GetUniqueSpecs(product, GetDislaySpecs(product)), GetColor(product)));
            }
        }

        private LINE_UP GetLineUp(ModelProduct product)
        {
            if (product == null) return null;

            LINE_UP lineup = instance.LINE_UP.Where(item => item.NAME == product.LineUp && item.MANUFACTURER == product.Manufacturer && item.COUNTRY == product.Country).FirstOrDefault();
            if (lineup == null)
            {
                instance.Database.ExecuteSqlCommand("INSERT INTO LINE_UP (NAME, MANUFACTURER, COUNTRY) VALUES (@name, @manufacturer, @country)",
                    new SqlParameter("@name", product.LineUp),
                    new SqlParameter("@manufacturer",
                    product.Manufacturer),
                    new SqlParameter("@country", product.Country));

                lineup = instance.LINE_UP.Where(item => item.NAME == product.LineUp && item.MANUFACTURER == product.Manufacturer && item.COUNTRY == product.Country).FirstOrDefault();
            }
            return lineup;
        }

        private COLOR GetColor(ModelProduct product)
        {
            if (product == null) return null;

            COLOR color = instance.COLOR.Where(item => item.COLOR_CODE == product.ColorCode && item.COLOR_NAME == product.ColorName).FirstOrDefault();
            if (color == null)
            {
                instance.Database.ExecuteSqlCommand("INSERT INTO COLOR VALUES (@colorCode, @colorName)",
                    new SqlParameter("@colorCode", product.ColorCode),
                    new SqlParameter("@colorName", product.ColorName));

                color = instance.COLOR.Where(item => item.COLOR_CODE == product.ColorCode && item.COLOR_NAME == product.ColorName).FirstOrDefault();
            }
            return color;
        }

        private DISPLAY_SPECS GetDislaySpecs(ModelProduct product)
        {
            if (product == null) return null;

            string resolution = string.Join("x", product.Resolution);
            decimal size = decimal.Parse(product.SizePanel.ToString());

            DISPLAY_SPECS display = instance.DISPLAY_SPECS.Where(item =>
                item.CODE_DISPLAY == product.IdPanel ||
                item.RESOLUTION == resolution &&
                item.SIZE == size &&
                item.BRIGHTNESS == product.Brightness &&
                item.PANEL == product.TypePanel &&
                item.COLOR_SPACE == product.SpaceColor &&
                item.RefreshRate == product.RefreshRate &&
                item.IS_TOUCH_PANEL == product.CanTouchPanel &&
                item.SCREEN_TYPE == product.TypeScreen &&
                item.RATIO == product.RatioPanel
            ).FirstOrDefault();

            if (display == null)
            {
                instance.Database.ExecuteSqlCommand("INSERT INTO DISPLAY_SPECS (CODE_DISPLAY, RESOLUTION, SIZE, BRIGHTNESS, PANEL, COLOR_SPACE, RefreshRate, IS_TOUCH_PANEL, SCREEN_TYPE, RATIO) VALUES (@idDisplay, @resolution, @size, @brightness, @panel, @colorSpace, @refreshRate, @isTouchPanel, @screenType, @ratio)",
                    new SqlParameter("@idDisplay", product.IdPanel),
                    new SqlParameter("@resolution", string.Join("x", product.Resolution)),
                    new SqlParameter("@size", product.SizePanel),
                    new SqlParameter("@brightness", product.Brightness),
                    new SqlParameter("@panel", product.TypePanel),
                    new SqlParameter("@colorSpace", product.SpaceColor),
                    new SqlParameter("@refreshRate", product.RefreshRate),
                    new SqlParameter("@isTouchPanel", product.CanTouchPanel),
                    new SqlParameter("@screenType", product.TypeScreen),
                    new SqlParameter("@ratio", product.RatioPanel)
                    );

                display = instance.DISPLAY_SPECS.Where(item =>
                    item.CODE_DISPLAY == product.IdPanel ||
                    item.RESOLUTION == resolution &&
                    item.SIZE == size &&
                    item.BRIGHTNESS == product.Brightness &&
                    item.PANEL == product.TypePanel &&
                    item.COLOR_SPACE == product.SpaceColor &&
                    item.RefreshRate == product.RefreshRate &&
                    item.IS_TOUCH_PANEL == product.CanTouchPanel &&
                    item.SCREEN_TYPE == product.TypeScreen &&
                    item.RATIO == product.RatioPanel
                ).FirstOrDefault();
            }
            return display;
        }

        private COMMON_SPECS GetCommonSpecs(ModelProduct product, LINE_UP lineup)
        {
            if (product == null || lineup == null || lineup.ID == null) return null;

            string ports = string.Join("-", product.Ports);
            string dimensions = string.Join("x", product.SizeProduct);

            COMMON_SPECS commonSpecs = instance.COMMON_SPECS.Where(item =>
                item.ID_LINE_UP == lineup.ID &&
                item.NAME == product.NameProduct &&
                item.RELEASED_YEAR == product.ReleaseDate &&
                item.CASE_MATERIAL == product.CaseMaterial &&
                item.PORT == ports &&
                item.WEBCAM == product.Webcam &&
                item.DIMENSIONS == dimensions &&
                item.OS == product.OS &&
                item.WIFI == product.Wifi &&
                item.BLUETOOTH == product.Bluetooth
            ).FirstOrDefault();

            if (commonSpecs == null)
            {
                instance.Database.ExecuteSqlCommand("INSERT INTO COMMON_SPECS (ID_LINE_UP, NAME, RELEASED_YEAR, CASE_MATERIAL, PORT, WEBCAM, DIMENSIONS, OS, WIFI, BLUETOOTH) VALUES (@idLineUp, @name, @releasedDate, @caseMaterial, @port, @webcam, @dimensions, @os, @wifi, @bluetooth)",
                    new SqlParameter("@idLineUp", lineup.ID),
                    new SqlParameter("@name", product.NameProduct),
                    new SqlParameter("@releasedDate", product.ReleaseDate),
                    new SqlParameter("@caseMaterial", product.CaseMaterial),
                    new SqlParameter("@port", ports),
                    new SqlParameter("@webcam", product.Webcam),
                    new SqlParameter("@dimensions", dimensions),
                    new SqlParameter("@os", product.OS),
                    new SqlParameter("@wifi", product.Wifi),
                    new SqlParameter("@bluetooth", product.Bluetooth)
                    );

                commonSpecs = instance.COMMON_SPECS.Where(item =>
                    item.ID_LINE_UP == lineup.ID &&
                    item.NAME == product.NameProduct &&
                    item.RELEASED_YEAR == product.ReleaseDate &&
                    item.CASE_MATERIAL == product.CaseMaterial &&
                    item.PORT == ports &&
                    item.WEBCAM == product.Webcam &&
                    item.DIMENSIONS == dimensions &&
                    item.OS == product.OS &&
                    item.WIFI == product.Wifi &&
                    item.BLUETOOTH == product.Bluetooth
                ).FirstOrDefault();
            }
            return commonSpecs;
        }

        private UNIQUE_SPECS GetUniqueSpecs(ModelProduct product, DISPLAY_SPECS displaySpecs)
        {
            if (product == null || displaySpecs == null || displaySpecs.ID == null) return null;

            string gpu = string.Join(" ", product.GPU);
            decimal batteryCapacity = decimal.Parse(product.BatteryCapacity.ToString());
            decimal weight = decimal.Parse(product.Weight.ToString());

            UNIQUE_SPECS uniqueSpecs = instance.UNIQUE_SPECS.Where(item =>
                item.ID_DISPLAY_SPECS == displaySpecs.ID &&
                item.CPU == product.CPU &&
                item.IGPU == product.iGPU &&
                item.RAM == product.RAM &&
                item.TYPE_DRIVE == product.TypeDrive &&
                item.SIZE_DRIVE == product.DriveCapacity &&
                item.GPU == gpu &&
                item.BATTERY_CAPACITY == batteryCapacity &&
                item.WEIGHT == weight
            ).FirstOrDefault();

            if (uniqueSpecs == null)
            {
                instance.Database.ExecuteSqlCommand("INSERT INTO UNIQUE_SPECS (ID_DISPLAY_SPECS, CPU, IGPU, RAM, TYPE_DRIVE, SIZE_DRIVE, GPU, BATTERY_CAPACITY, WEIGHT) VALUES (@idDisplaySpecs, @cpu, @iGPU, @ram, @typeDrive, @sizeDrive, @gpu, @batteryCapacity, @weight)",
                    new SqlParameter("@idDisplaySpecs", displaySpecs.ID),
                    new SqlParameter("@cpu", product.CPU),
                    new SqlParameter("@iGPU", product.iGPU),
                    new SqlParameter("@ram", product.RAM),
                    new SqlParameter("@typeDrive", product.TypeDrive),
                    new SqlParameter("@sizeDrive", product.DriveCapacity),
                    new SqlParameter("@gpu", gpu),
                    new SqlParameter("@batteryCapacity", product.BatteryCapacity),
                    new SqlParameter("@weight", weight)
                    );

                uniqueSpecs = instance.UNIQUE_SPECS.Where(item =>
                    item.ID_DISPLAY_SPECS == displaySpecs.ID &&
                    item.CPU == product.CPU &&
                    item.IGPU == product.iGPU &&
                    item.RAM == product.RAM &&
                    item.TYPE_DRIVE == product.TypeDrive &&
                    item.SIZE_DRIVE == product.DriveCapacity &&
                    item.GPU == gpu &&
                    item.BATTERY_CAPACITY == batteryCapacity &&
                    item.WEIGHT == weight
                ).FirstOrDefault();
            }
            return uniqueSpecs;
        }

        private DETAIL_SPECS GetDetailSpecs(ModelProduct product, COMMON_SPECS commonSpecs, UNIQUE_SPECS uniqueSpecs, COLOR color)
        {
            if (product == null || commonSpecs == null || uniqueSpecs == null || color == null || commonSpecs.ID == null || uniqueSpecs.ID == null || color.COLOR_CODE == null) return null;

            decimal price = decimal.Parse(product.Price.ToString());

            DETAIL_SPECS detailSpecs = instance.DETAIL_SPECS.Where(item =>
                item.ID_COMMON_SPECS == commonSpecs.ID &&
                item.ID_UNIQUE_SPECS == uniqueSpecs.ID &&
                item.COLOR_CODE == color.COLOR_CODE &&
                item.PRICE == price
            ).FirstOrDefault();

            if (detailSpecs == null)
            {
                instance.Database.ExecuteSqlCommand("INSERT INTO DETAIL_SPECS (ID_COMMON_SPECS, ID_UNIQUE_SPECS, COLOR_CODE, PRICE) VALUES (@idCommonSpecs, @idUniqueSpecs, @colorCode, @price)",
                    new SqlParameter("@idCommonSpecs", commonSpecs.ID),
                    new SqlParameter("@idUniqueSpecs", uniqueSpecs.ID),
                    new SqlParameter("@colorCode", color.COLOR_CODE),
                    new SqlParameter("@price", price)
                    );

                detailSpecs = instance.DETAIL_SPECS.Where(item =>
                    item.ID_COMMON_SPECS == commonSpecs.ID &&
                    item.ID_UNIQUE_SPECS == uniqueSpecs.ID &&
                    item.COLOR_CODE == color.COLOR_CODE &&
                    item.PRICE == price
                ).FirstOrDefault();
            }
            return detailSpecs;
        }

        private PRODUCT InsertProduct(ModelProduct product, DETAIL_SPECS detailSpecs, bool inWarehouse = true)
        {
            if (product == null || detailSpecs == null || detailSpecs.ID == null) return null;

            PRODUCT dbProduct = new PRODUCT();
            dbProduct.SERIAL_ID = product.Serial;
            dbProduct.ID_DETAIL_SPECS = detailSpecs.ID;
            dbProduct.IN_WAREHOUSE = inWarehouse;

            instance.PRODUCT.Add(dbProduct);
            instance.SaveChanges();

            return dbProduct;
        }
    }
}
