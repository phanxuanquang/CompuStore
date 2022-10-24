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

        class mymodel
        {
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
        }

        private async Task LoadingData()
        {
            await Task.Run(() =>
            {
                List<ModelProduct> models = new List<ModelProduct>();
                ICollection<DETAIL_SPECS> detailSpecs = commonSpecs.DETAIL_SPECS;
                LINE_UP lineup = commonSpecs.LINE_UP;
                foreach(DETAIL_SPECS detail in detailSpecs)
                {
                    UNIQUE_SPECS uniqueSpecs = detail.UNIQUE_SPECS;
                    DISPLAY_SPECS display = uniqueSpecs.DISPLAY_SPECS;
                    ICollection<PRODUCT> products = detail.PRODUCTs;

                    foreach(PRODUCT product in products)
                    {
                        ModelProduct modelProduct = new ModelProduct();
                        modelProduct.Serial = product.SERIAL_ID;
                        modelProduct.RAM = uniqueSpecs.RAM;
                        modelProduct.RatioPanel = display.RATIO;
                        modelProduct.IdPanel = display.NAME_ID;
                        modelProduct.CPU = uniqueSpecs.CPU;
                        modelProduct.LineUp = lineup.NAME;
                        modelProduct.Country = lineup.COUNTRY;
                        modelProduct.Manufacturer = lineup.MANUFACTURER;
                        modelProduct.ReleaseDate = commonSpecs.RELEASED_YEAR;
                        modelProduct.RefreshRate = display.REFRESH_RATE;
                        models.Add(modelProduct);
                    }
                }
                binding = new BindingList<ModelProduct>(models);
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
