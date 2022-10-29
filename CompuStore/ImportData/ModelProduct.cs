using CompuStore.Database.Models;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;

namespace CompuStore.ImportData
{
    public class ModelProduct
    {
        public class Port
        {
            public string PortPhysic { get; set; }
            public string PortProtocol { get; set; }
            public string Quantity { get; set; }
        }

        public class Color
        {
            public System.Drawing.Color ColorCode { get; set; }
            public string ColorName { get; set; }
        }

        public class RAM
        {
            //Unit: GB
            public int CapacityRAM { get; set; }
            //Unit: MHz
            public string BusRAM { get; set; }
            public string TypeRAM { get; set; }
        }

        public string Serial { get; set; }

        public string LineUp { get; set; }

        public string Manufacturer { get; set; }

        public string Country { get; set; }

        public string IdPanel { get; set; }

        //split by 'x'
        //[0]: (x)pixels
        //[1]: (y)pixels
        public string ResolutionString
        {
            get
            {
                return Resolution == null ? string.Empty : string.Join("x", Resolution);
            }
            set
            {
                if (value != null)
                {
                    string[] resolution = value.Split('x');
                    List<double> parseResolution = new List<double>();
                    foreach (string dimension in resolution)
                    {
                        if (double.TryParse(dimension.Trim(), out double size))
                        {
                            parseResolution.Add(size);
                        }
                    }
                    Resolution = parseResolution.ToArray();
                }
            }
        }
        public double[] Resolution;

        //unit: inch
        public double? SizePanel { get; set; }

        public int? Brightness { get; set; }

        public string TypePanel { get; set; }

        //split by '_'. each item split by ':'
        public string SpaceColorString
        {
            get
            {
                string spaceColor = "";
                if (SpaceColor != null)
                {
                    List<string> spaceColors = new List<string>();
                    foreach (KeyValuePair<ENUM_SPACE_COLOR, double> entry in SpaceColor)
                    {
                        string item = "";
                        switch (entry.Key)
                        {
                            case ENUM_SPACE_COLOR.DCI_P3:
                                item = string.Format("{0}:{1}%", "DCI-P3 color gamut", entry.Value);
                                break;
                            case ENUM_SPACE_COLOR.AdobeRGBProfile:
                                item = string.Format("{0}:{1}%", "Adobe RGB profile", entry.Value);
                                break;
                            case ENUM_SPACE_COLOR.sRGB:
                                item = string.Format("{0}:{1}%", "sRGB color space", entry.Value);
                                break;
                        }
                        if (!string.IsNullOrEmpty(item))
                        {
                            spaceColors.Add(item);
                        }
                    }
                    spaceColor = string.Join("_", spaceColors);
                }
                return spaceColor;
            }
            set
            {
                if (value != null)
                {
                    string[] spaceColor = value.Split('_');
                    if (spaceColor != null)
                    {
                        for (int _index = 0; _index < spaceColor.Length; _index++)
                        {
                            string[] eachSpaceColor = spaceColor[_index].Split(':');
                            if (eachSpaceColor.Length > 1 && double.TryParse(eachSpaceColor[1].Substring(0, eachSpaceColor[1].Length - 1), out double eachSpaceColorValue))
                            {
                                if (SpaceColor == null)
                                {
                                    SpaceColor = new SortedDictionary<ENUM_SPACE_COLOR, double>();
                                }
                                if (eachSpaceColor[0].CompareTo("Adobe RGB profile") == 0)
                                {
                                    SpaceColor.Add(ENUM_SPACE_COLOR.AdobeRGBProfile, eachSpaceColorValue);
                                }
                                else if (eachSpaceColor[0].CompareTo("sRGB color space") == 0)
                                {
                                    SpaceColor.Add(ENUM_SPACE_COLOR.sRGB, eachSpaceColorValue);
                                }
                                else if (eachSpaceColor[0].CompareTo("DCI-P3 color gamut") == 0)
                                {
                                    SpaceColor.Add(ENUM_SPACE_COLOR.DCI_P3, eachSpaceColorValue);
                                }
                            }
                        }
                        if (SpaceColor != null && SpaceColor.Count == 0)
                        {
                            SpaceColor = null;
                        }
                    }
                }
            }
        }
        public enum ENUM_SPACE_COLOR
        {
            AdobeRGBProfile, sRGB, DCI_P3
        }
        public SortedDictionary<ENUM_SPACE_COLOR, double> SpaceColor;

        public int? RefreshRate { get; set; }

        public bool? CanTouchPanel { get; set; }

        public string TypeScreen { get; set; }

        //split by :
        //[0]: ratio x
        //[1]: ratio y
        public string RatioPanelString
        {
            get
            {
                return RatioPanel == null ? string.Empty : string.Join(":", RatioPanel);
            }
            set
            {
                if (value != null)
                {
                    string[] ratio = value.Split(':');
                    List<double> parseRatio = new List<double>();
                    foreach (string dimension in ratio)
                    {
                        if (double.TryParse(dimension.Trim(), out double size))
                        {
                            parseRatio.Add(size);
                        }
                    }
                    RatioPanel = parseRatio.ToArray();
                }
            }
        }
        public double[] RatioPanel;

        public string CPU { get; set; }

        public string iGPU { get; set; }

        //unit: GB
        //format: 16GB DDR5 5400MHz
        public string RAMString
        {
            get
            {
                return InfoRAM == null ? string.Empty : string.Format("{0}GB {1} {2}", InfoRAM.CapacityRAM, InfoRAM.TypeRAM, InfoRAM.BusRAM);
            }
            set
            {
                if (value != null)
                {
                    string[] info = value.Split(' ');
                    if (int.TryParse(info[0].Substring(0, info[0].Length - 2), out int CapacityRAM))
                    {
                        InfoRAM = new RAM { CapacityRAM = CapacityRAM, TypeRAM = info[1], BusRAM = info[2] };
                    }
                }
            }
        }
        public RAM InfoRAM;

        public string TypeStorage { get; set; }

        //unit: GB
        public int? StorageCapacity { get; set; }

        //split by space
        //[0]: (manufacturer) GPU
        //[1-last-1]: (name) GPU
        //[last]: (VRAM) GPU
        public string GPUString
        {
            get
            {
                return GPU == null ? null : string.Join(" ", GPU);
            }
            set
            {
                if (value != null && !string.IsNullOrWhiteSpace(value) && !string.IsNullOrEmpty(value))
                {
                    string[] gpu = value.Split(' ');
                    GPU = new string[] { gpu.First(), string.Join(" ", gpu.Skip(1).Take(gpu.Length - 2)), gpu.Last() };
                }
            }
        }
        public string[] GPU;

        public double? BatteryCapacity { get; set; }

        public double? Weight { get; set; }

        public string NameProduct { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string CaseMaterial { get; set; }

        //split by unit seperator (_)
        public string PortString
        {
            get
            {
                if (Ports != null)
                {
                    List<string> ports = new List<string>();
                    for (int index = 0; index < Ports.Length; index++)
                    {
                        string port = Ports[index].PortProtocol.CompareTo(Ports[index].PortPhysic) == 0 ? string.Format("{0}:{1}", Ports[index].PortPhysic, Ports[index].Quantity) : string.Format("{0}:{1}x {2}", Ports[index].PortPhysic, Ports[index].Quantity, Ports[index].PortProtocol);
                        ports.Add(port);
                    }
                    return string.Join("_", ports);
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (value != null)
                {
                    List<Port> models = new List<Port>();
                    string[] ports = value.Split('_');
                    for (int index = 0; index < ports.Length; index++)
                    {
                        string port = ports[index];
                        string[] split = port.Split(':');
                        string portPhysic = split[0];
                        string quantityPort = "1";
                        string portProtocol = split[1];
                        if (split[1].Contains('x'))
                        {
                            string[] split2 = split[1].Split('x');
                            quantityPort = split2[0];
                            portProtocol = split2[1].Substring(1);
                        }
                        if (int.TryParse(portProtocol, out int numberic))
                            portProtocol = portPhysic;
                        models.Add(new Port { PortPhysic = portPhysic, PortProtocol = portProtocol, Quantity = quantityPort });
                    }
                    Ports = models.ToArray();
                }
            }
        }
        public Port[] Ports;

        public string Webcam { get; set; }

        //split by x
        //[0]: (x) dimension
        //[1]: (y) dimension
        //[2]: (z) dimension
        public string SizeProductString
        {
            get
            {
                return SizeProduct == null ? string.Empty : string.Join("x", SizeProduct);
            }
            set
            {
                if (value != null)
                {
                    string[] sizeProduct = value.Split('x');
                    List<double> parseSizeProduct = new List<double>();
                    foreach (string dimension in sizeProduct)
                    {
                        string temp = dimension.Trim();
                        if (temp.Contains('-')) temp = temp.Split('-')[0];

                        if (double.TryParse(temp.Trim(), out double size))
                        {
                            parseSizeProduct.Add(size);
                        }
                    }
                    SizeProduct = parseSizeProduct.ToArray();
                }
            }
        }
        public double[] SizeProduct;

        public string OS { get; set; }

        public string Wifi { get; set; }

        public string Bluetooth { get; set; }

        public double? Price { get; set; }

        public Color ColorModel
        {
            get
            {
                return new Color { ColorCode = System.Drawing.Color.FromArgb(Convert.ToInt32("0xFF" + ColorCode.Substring(1), 16)), ColorName = ColorName };
            }
        }

        private string _ColorCode;
        public string ColorCode
        {
            get
            {
                return _ColorCode.ToLower();
            }
            set
            {
                _ColorCode = value.ToLower();
            }
        }

        public string ColorName { get; set; }

        public static bool TryParse(string singleLineCSV, out ModelProduct model)
        {
            string[] split = singleLineCSV.Split('\t');
            if (split.Length > 0 && int.TryParse(split.First(), out int index))
            {
                try
                {
                    model = new ModelProduct();
                    model.Serial = split[1].Length == 0 ? null : split[1];
                    model.LineUp = split[2].Length == 0 ? null : split[2];
                    model.Manufacturer = split[3].Length == 0 ? null : split[3];
                    model.Country = split[4].Length == 0 ? null : split[4];
                    model.IdPanel = split[5].Length == 0 ? null : split[5];
                    model.ResolutionString = split[6].Length == 0 ? null : split[6];
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
                    model.TypePanel = split[9].Length == 0 ? null : split[9];
                    model.SpaceColorString = split[10].Length == 0 ? null : split[10];
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
                    model.TypeScreen = split[13].Length == 0 ? null : split[13];
                    model.RatioPanelString = split[14].Length == 0 ? null : split[14];
                    model.CPU = split[15].Length == 0 ? null : split[15];
                    model.iGPU = split[16].Length == 0 ? null : split[16];
                    model.RAMString = split[17].Length == 0 ? null : split[17];
                    model.TypeStorage = split[18].Length == 0 ? null : split[18];
                    if (int.TryParse(split[19].Substring(0, split[19].Length - 2), out int driveCapacity))
                    {
                        model.StorageCapacity = driveCapacity;
                    }
                    else
                    {
                        model.StorageCapacity = null;
                    }
                    model.GPUString = split[20].Length == 0 ? null : split[20];
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
                    model.NameProduct = split[23].Length == 0 ? null : split[23];
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
                    model.CaseMaterial = split[25].Length == 0 ? null : split[25];
                    model.PortString = split[26].Length == 0 ? null : split[26];
                    model.Webcam = split[27].Length == 0 ? null : split[27];
                    model.SizeProductString = split[28].Length == 0 ? null : split[28];
                    model.OS = split[29].Length == 0 ? null : split[29];
                    model.Wifi = split[30].Length == 0 ? null : split[30];
                    model.Bluetooth = split[31].Length == 0 ? null : split[31];
                    if (double.TryParse(split[32], out double price))
                    {
                        model.Price = price;
                    }
                    else
                    {
                        model.Price = null;
                    }
                    model.ColorCode = split[33].Length == 0 ? null : split[33];
                    model.ColorName = split[34].Length == 0 ? null : split[34];
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

        public bool CompareSpecs(ModelProduct model)
        {
            if (model == null || LineUp != model.LineUp
                || Manufacturer != model.Manufacturer
                || Country != model.Country
                || IdPanel != model.IdPanel
                || ResolutionString != model.ResolutionString
                || SizePanel != model.SizePanel
                || Brightness != model.Brightness
                || TypePanel != model.TypePanel
                || SpaceColorString != model.SpaceColorString
                || RefreshRate != model.RefreshRate
                || RatioPanelString != model.RatioPanelString
                || CanTouchPanel != model.CanTouchPanel
                || TypeScreen != model.TypeScreen
                || CPU != model.CPU
                || iGPU != model.iGPU
                || RAMString != model.RAMString
                || TypeStorage != model.TypeStorage
                || StorageCapacity != model.StorageCapacity
                || GPUString != model.GPUString
                || BatteryCapacity != model.BatteryCapacity
                || Weight != model.Weight
                || NameProduct != model.NameProduct
                || ReleaseDate != model.ReleaseDate
                || CaseMaterial != model.CaseMaterial
                || PortString != model.PortString
                || Webcam != model.Webcam
                || SizeProductString != model.SizeProductString
                || OS != model.OS
                || Wifi != model.Wifi
                || Bluetooth != model.Bluetooth
                || Price != model.Price
                || ColorCode != model.ColorCode
                || ColorName != model.ColorName)
                return false;
            return true;
        }

        public bool CompareProduct(ModelProduct model)
        {
            if (model == null || Serial != model.Serial || !CompareSpecs(model)) return false;
            return true;
        }

        public static ModelProduct[] GetTSV(string pathFile)
        {
            string[] x = File.ReadAllLines(pathFile, Encoding.UTF8);
            ModelProduct[] products = new ModelProduct[x.Length - 1];
            for (int index = 1; index < x.Length; index++)
            {
                TryParse(x[index], out products[index - 1]);
            }

            return products;
        }
    }
}
