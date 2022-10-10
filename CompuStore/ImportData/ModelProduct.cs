using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.ImportData
{
    class ModelProduct
    {
        public string Serial;

        public string LineUp;
        public string Manufacturer;
        public string Country;

        public string IdPanel;
        //split by 'x'
        //[0]: (x)pixels
        //[1]: (y)pixels
        public string[] Resolution;
        //unit: inch
        public double? SizePanel;
        public int? Brightness;
        public string TypePanel;
        public string SpaceColor;
        public int? RefreshRate;
        public bool? CanTouchPanel;
        public string TypeScreen;
        public string RatioPanel;

        public string CPU;
        public string iGPU;
        public string RAM;
        public string TypeDrive;
        //unit: GB
        public int? DriveCapacity;
        //split by space
        //[0]: (manufacturer) GPU
        //[1-last-1]: (name) GPU
        //[last]: (VRAM) GPU
        public string[] GPU;
        public double? BatteryCapacity;
        public double? Weight;

        public string NameProduct;
        public DateTime? ReleaseDate;
        public string CaseMaterial;
        //split by dash
        public string[] Ports;
        public string Webcam;
        //split by x
        //[0]: (x) dimension
        //[1]: (y) dimension
        //[2]: (z) dimension
        public string[] SizeProduct;
        public string OS;
        public string Wifi;
        public string Bluetooth;
        public double? Price;

        public string ColorCode;
        public string ColorName;

        public static bool TryParse(string singleLineCSV, out ModelProduct model)
        {
            string[] split = singleLineCSV.Split(',');
            if (split.Length > 0 && int.TryParse(split.First(), out int index))
            {
                try
                {
                    model = new ModelProduct();
                    model.Serial = split[1];
                    model.LineUp = split[2];
                    model.Manufacturer = split[3];
                    model.Country = split[4];
                    model.IdPanel = split[5];
                    model.Resolution = split[6].Split('x');
                    if (double.TryParse(split[7], out double sizePanel))
                    {
                        model.SizePanel = sizePanel;
                    }
                    else
                    {
                        model.SizePanel = null;
                    }
                    if (int.TryParse(split[8], out int brightness))
                    {
                        model.Brightness = brightness;
                    }
                    else
                    {
                        model.Brightness = null;
                    }
                    model.TypePanel = split[9];
                    model.SpaceColor = split[10];
                    if (int.TryParse(split[11], out int refreshRate))
                    {
                        model.RefreshRate = refreshRate;
                    }
                    else
                    {
                        model.RefreshRate = null;
                    }
                    if (int.TryParse(split[12], out int canTouchPanel))
                    {
                        model.CanTouchPanel = canTouchPanel == 1 ? true : false;
                    }
                    else
                    {
                        model.CanTouchPanel = null;
                    }
                    model.TypeScreen = split[13];
                    model.RatioPanel = split[14];
                    model.CPU = split[15];
                    model.iGPU = split[16];
                    model.RAM = split[17];
                    model.TypeDrive = split[18];
                    if (int.TryParse(split[19].Substring(0, split[19].Length-2), out int driveCapacity))
                    {
                        model.DriveCapacity = driveCapacity;
                    }
                    else
                    {
                        model.DriveCapacity = null;
                    }
                    string[] gpu = split[20].Split(' ');
                    model.GPU = new string[] { gpu.First(), string.Join(" ", gpu.Skip(1).Take(gpu.Length - 2)), gpu.Last() };
                    if (double.TryParse(split[21], out double bateryCapacity))
                    {
                        model.BatteryCapacity = bateryCapacity;
                    }
                    else
                    {
                        model.BatteryCapacity = null;
                    }
                    if (double.TryParse(split[22], out double weight))
                    {
                        model.Weight = weight;
                    }
                    else
                    {
                        model.Weight = null;
                    }
                    model.NameProduct = split[23];
                    if (DateTime.TryParseExact(
                        String.Format("{0}/{1}/{2}", "01", "01", split[24]),
                        "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None,
                        out DateTime releaseDate))
                    {
                        model.ReleaseDate = releaseDate;
                    }
                    else
                    {
                        model.ReleaseDate = null;
                    }
                    model.CaseMaterial = split[25];
                    model.Ports = split[26].Split('-');
                    model.Webcam = split[27];
                    model.SizeProduct = split[28].Split('x');
                    model.OS = split[29];
                    model.Wifi = split[30];
                    model.Bluetooth = split[31];
                    if (double.TryParse(split[32], out double price))
                    {
                        model.Price = price;
                    }
                    else
                    {
                        model.Price = null;
                    }
                    model.ColorCode = split[33];
                    model.ColorName = split[34];
                    return true;
                }
                catch
                {
                    model = null;
                    return false;
                }
            }
            else
            {
                model = null;
                return false;
            }
        }

        /*public static bool TryParse(PRODUCT product, out ModelProduct model)
        {

        }*/
    }
}
