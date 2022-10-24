using CompuStore.Database.Models;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.Tab.Warehouse
{
    public partial class DetailInvoiceImportWarehouse_Form : Form
    {
        private COMMON_SPECS commonSpecs = null;
        BindingList<ModelProduct> binding = null;

        public DetailInvoiceImportWarehouse_Form(COMMON_SPECS commonSpecs = null)
        {
            InitializeComponent();
            this.commonSpecs = commonSpecs;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DateTimeImportWarehouse_Label_Click(object sender, EventArgs e)
        {
            DateTimeImportWarehouse_DateTimePicker.Visible = !DateTimeImportWarehouse_DateTimePicker.Visible;
            if (!DateTimeImportWarehouse_DateTimePicker.Visible)
            {
                DateTimeImportWarehouse_Label.Text = DateTimeImportWarehouse_DateTimePicker.Value.ToString("hh:mm:ss dd/MM/yyyy");
            }
        }

        private void AddProduct_Button_Click(object sender, EventArgs e)
        {
            //để test xem form được chưa
            DetailSpecsProduct_Form frm = new DetailSpecsProduct_Form();
            ModelProduct[] products = ModelProduct.GetTSV("../../Resources/Template/data_sample.tsv");
            frm.ShowDialog(this, products);
        }

        private async Task LoadingData()
        {
            await Task.Run(() =>
            {
                if (commonSpecs != null)
                {
                    List<ModelProduct> models = new List<ModelProduct>();
                    ICollection<DETAIL_SPECS> detailSpecs = commonSpecs.DETAIL_SPECS;
                    LINE_UP lineup = commonSpecs.LINE_UP;
                    foreach (DETAIL_SPECS detail in detailSpecs)
                    {
                        UNIQUE_SPECS uniqueSpecs = detail.UNIQUE_SPECS;
                        DISPLAY_SPECS display = uniqueSpecs.DISPLAY_SPECS;
                        COLOR color = detail.COLOR;
                        ICollection<PRODUCT> products = detail.PRODUCTs;

                        foreach (PRODUCT product in products)
                        {
                            ModelProduct modelProduct = new ModelProduct();
                            modelProduct.Serial = product.SERIAL_ID;
                            modelProduct.LineUp = lineup.NAME;
                            modelProduct.Manufacturer = lineup.MANUFACTURER;
                            modelProduct.Country = lineup.COUNTRY;
                            modelProduct.IdPanel = display.CODE_DISPLAY;
                            modelProduct.ResolutionString = display.RESOLUTION;
                            modelProduct.SizePanel = display.SIZE;
                            modelProduct.Brightness = display.BRIGHTNESS;
                            modelProduct.TypePanel = display.PANEL;
                            modelProduct.SpaceColorString = display.COLOR_SPACE;
                            modelProduct.RefreshRate = display.REFRESH_RATE;
                            modelProduct.CanTouchPanel = display.IS_TOUCH_PANEL;
                            modelProduct.TypeScreen = display.SCREEN_TYPE;
                            modelProduct.RatioPanelString = display.RATIO;
                            modelProduct.CPU = uniqueSpecs.CPU;
                            modelProduct.iGPU = uniqueSpecs.IGPU;
                            modelProduct.RAMString = uniqueSpecs.RAM;
                            modelProduct.TypeDrive = uniqueSpecs.TYPE_DRIVE;
                            modelProduct.DriveCapacity = uniqueSpecs.SIZE_DRIVE;
                            modelProduct.GPUString = uniqueSpecs.GPU;
                            modelProduct.BatteryCapacity = uniqueSpecs.BATTERY_CAPACITY;
                            modelProduct.Weight = uniqueSpecs.WEIGHT;
                            modelProduct.NameProduct = commonSpecs.NAME;
                            modelProduct.ReleaseDate = commonSpecs.RELEASED_YEAR;
                            modelProduct.CaseMaterial = commonSpecs.CASE_MATERIAL;
                            modelProduct.PortString = commonSpecs.PORT;
                            modelProduct.Webcam = commonSpecs.WEBCAM;
                            modelProduct.SizeProductString = commonSpecs.DIMENSIONS;
                            modelProduct.OS = commonSpecs.OS;
                            modelProduct.Wifi = commonSpecs.WIFI;
                            modelProduct.Bluetooth = commonSpecs.BLUETOOTH;
                            modelProduct.Price = detail.PRICE;
                            modelProduct.ColorCode = color.COLOR_CODE;
                            modelProduct.ColorName = color.COLOR_NAME;
                            models.Add(modelProduct);
                        }
                    }
                    binding = new BindingList<ModelProduct>(models);
                }
            });
        }

        private void DetailInvoiceImportWarehouse_Form_Load(object sender, EventArgs e)
        {
            Task loading = LoadingData();
            loading.GetAwaiter().OnCompleted(() =>
            {
                TableData_DataGridView.DataSource = binding;
            });

        }
    }
}
