﻿using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.Tab.Warehouse
{
    public partial class DetailInvoiceImportWarehouse_Form : Form
    {
        private COMMON_SPECS commonSpecs = null;
        BindingList<ModelProduct> binding = null;
        Task task = null;
        CancellationTokenSource cancellationTokenSource = null;

        private static readonly Dictionary<string, string> translater = new Dictionary<string, string> {
            { "ReleasedDate", "Năm ra mắt|Năm hãng ra mắt đến công chúng" },
            { "LineUp", "Dòng sản phẩm" },
            { "Country", "Nơi sản xuất" },
            { "Manufacturer", "Nhà sản xuất" },
            { "SizePanel", "Kích thước màn hình|Đơn vị: inch" },
            { "Brightness", "Độ sáng:Đơn vị: nit" },
            { "TypePanel", "Tấm nền" },
            { "SpaceColorString", "Độ phủ màu|Độ chính xác màu hiện thị trên màn hình so với khi in ấn" },
            { "RefreshRate", "Tốc độ làm tươi" },
            { "CanTouchPanel", "Cảm ứng" },
            { "RatioPanelString", "Tỉ lệ màn hình" },
            { "CPU", "CPU" },
            { "GPU", "GPU" },
            { "RAMString", "RAM" },
            { "iGPU", "iGPU" },
            { "TypeStorage", "Chuẩn ổ cứng" },
            { "StorageCapacity", "Dung lượng ổ cứng" },
            { "GPUString", "Card đồ hoại rời" },
            { "BatteryCapacity", "Dung lượng pin" }};

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
                            modelProduct.TypeStorage = uniqueSpecs.TYPE_STORAGE;
                            modelProduct.StorageCapacity = uniqueSpecs.STORAGE_CAPACITY;
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
            Form form = new Form();
            form.Show();
            loading.GetAwaiter().OnCompleted(() =>
            {
                TableData_DataGridView.DataSource = binding;
                form.Close();
            });

        }

        private void TableData_DataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            /*DataGridView grid = sender as DataGridView;
            grid.SuspendLayout();
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (translater.ContainsKey(column.Name))
                {
                    if (column.Name == "RELEASED_YEAR")
                    {
                        column.DefaultCellStyle.Format = "yyyy";
                    }
                    column.HeaderText = translater[column.Name];
                }
                else
                {
                    column.Visible = false;
                }
            }
            grid.ResumeLayout(true);*/
        }

        private void AddProductByExcel_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tab-seperator values | *.tsv";

            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.CheckFileExists)
            {
                ModelProduct[] products = ModelProduct.GetTSV(openFileDialog.FileName);

                if (task == null || task.IsCompleted)
                {
                    cancellationTokenSource = new CancellationTokenSource();
                    CancellationToken token = cancellationTokenSource.Token;

                    task = Task.Factory.StartNew(() =>
                    {
                        for (int index = 0; index < products.Length && !token.IsCancellationRequested; index++)
                        {
                            try
                            {
                                if (TotalImportWarehouse_Label.InvokeRequired)
                                    TotalImportWarehouse_Label.Invoke(new Action(() => TotalImportWarehouse_Label.Text = string.Format("Completed {0}/{1}", index, products.Length)));
                                else
                                    TotalImportWarehouse_Label.Text = string.Format("Completed {0}/{1}", index, products.Length);

                                ProductServices.InstanceImport.Import(products[index]).Wait();
                            }
                            catch (AggregateException)
                            {
                                MessageBox.Show(string.Format("Product serial: {0} already exists in the system", products[index].Serial));
                            }
                        }
                    }, token);

                    task.GetAwaiter().OnCompleted(() =>
                    {
                        if (token.IsCancellationRequested)
                        {
                            if (TotalImportWarehouse_Label.InvokeRequired)
                                TotalImportWarehouse_Label.Invoke(new Action(() => TotalImportWarehouse_Label.Text = "Canceled"));
                            else
                                TotalImportWarehouse_Label.Text = "Canceled";
                        }
                        else
                        {
                            if (TotalImportWarehouse_Label.InvokeRequired)
                                TotalImportWarehouse_Label.Invoke(new Action(() => TotalImportWarehouse_Label.Text = "Insert completed"));
                            else
                                TotalImportWarehouse_Label.Text = "Insert completed";
                        }
                        cancellationTokenSource.Dispose();
                        cancellationTokenSource = null;
                    });
                }
            }
        }
    }
}