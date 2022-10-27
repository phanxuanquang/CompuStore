using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.GUI;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI.Forms.Warehouse
{
    public partial class DetailInvoiceImportWarehouse_Form : Form
    {
        private class ModelProductCustom
        {
            public List<ModelProduct> productsTheSame;

            public ModelProduct product
            {
                get
                {
                    return productsTheSame?.First() ?? null;
                }
                set
                {
                    if (value != null)
                    {
                        if (productsTheSame == null)
                            productsTheSame = new List<ModelProduct>();
                        productsTheSame.Add(value);
                    }
                }
            }

            public bool IsTheSameGroup(ModelProduct _product)
            {
                ModelProduct template = product;
                if (template == null) return true;
                return template.CompareSpecs(_product);
            }
        }

        private COMMON_SPECS commonSpecs = null;
        BindingList<ModelProduct> binding = null;
        Task task = null;
        CancellationTokenSource cancellationTokenSource = null;
        List<ModelProductCustom> groupBinding = null;

        private static readonly Dictionary<string, string> translater = new Dictionary<string, string> {
            { "LineUp", "Dòng sản phẩm" },
            { "Country", "Nơi sản xuất" },
            { "Manufacturer", "Nhà sản xuất" },
            { "SizePanel", "Kích thước màn hình|Đơn vị: inch" },
            { "Brightness", "Độ sáng|Đơn vị: nit" },
            { "TypePanel", "Tấm nền" },
            { "SpaceColorString", "Độ phủ màu|Độ chính xác màu hiện thị trên màn hình so với khi in ấn" },
            { "RefreshRate", "Tốc độ làm tươi|Đơn vị: Hz" },
            { "CanTouchPanel", "Cảm ứng" },
            { "RatioPanelString", "Tỉ lệ màn hình" },
            { "CPU", "CPU" },
            { "GPU", "GPU" },
            { "RAMString", "RAM" },
            { "iGPU", "iGPU" },
            { "TypeStorage", "Chuẩn ổ cứng" },
            { "StorageCapacity", "Dung lượng ổ cứng|Đơn vị: GB" },
            { "GPUString", "Card đồ hoại rời" },
            { "Weight", "Khối lượng|Đơn vị: Kg" },
            { "NameProduct", "Tên sản phẩm" },
            { "ReleaseDate", "Năm ra mắt|Năm hãng ra mắt đến công chúng" },
            { "CaseMaterial", "Vật liệu vỏ" },
            { "PortString", "Cổng kết nối" },
            { "Webcam", "Webcam" },
            { "SizeProductString", "Kích thước máy|Đơn vị: mm" },
            { "OS", "Hệ điều hành" },
            { "Wifi", "Chuẩn Wifi" },
            { "Bluetooth", "Chuẩn Bluetooth" },
            { "ColorCode", "Màu sắc" }};

        public DetailInvoiceImportWarehouse_Form(COMMON_SPECS commonSpecs = null)
        {
            InitializeComponent();
            this.commonSpecs = commonSpecs;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddProduct_Button_Click(object sender, EventArgs e)
        {

        }

        private Task LoadingData(IProgress<int> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                if (commonSpecs != null)
                {
                    int counter = 0;
                    groupBinding = new List<ModelProductCustom>();
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
                            ModelProductCustom group = groupBinding.Find(item => item.IsTheSameGroup(modelProduct));
                            if (group != null)
                            {
                                group.product = modelProduct;
                            }
                            else
                            {
                                group = new ModelProductCustom();
                                group.product = modelProduct;
                                groupBinding.Add(group);

                                if (TableData_DataGridView.InvokeRequired)
                                {
                                    TableData_DataGridView.Invoke(new Action(() => binding.Add(group.product)));
                                }
                                else
                                {
                                    binding.Add(modelProduct);
                                }
                                progress.Report(++counter);
                            }
                        }
                    }
                }
            });
        }

        private void DetailInvoiceImportWarehouse_Form_Load(object sender, EventArgs e)
        {
            binding = new BindingList<ModelProduct>();
            TableData_DataGridView.DataSource = binding;
            Progress<int> progress = new Progress<int>();
            Waiting_Form waiting = new Waiting_Form();
            Task runLoading = LoadingData(progress);

            const int stopWaitingCoutner = 20;

            runLoading.GetAwaiter().OnCompleted(() => waiting.Close());

            progress.ProgressChanged += (owner, value) =>
            {
                if (value >= stopWaitingCoutner && !waiting.IsDisposed && waiting.shown)
                {
                    waiting.Close();
                }
            };

            waiting.ShowDialog(this);
        }

        private void TableData_DataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            grid.SuspendLayout();
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (translater.ContainsKey(column.Name))
                {
                    if (column.Name == "ReleaseDate")
                    {
                        column.DefaultCellStyle.Format = "yyyy";
                    }
                    string headerText = translater[column.Name];
                    string[] split = headerText.Split('|');
                    column.HeaderText = split[0];
                    if (split.Length > 1)
                    {
                        column.ToolTipText = split[1];
                    }
                }
                else
                {
                    column.Visible = false;
                }
            }
            grid.ResumeLayout(true);
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

        private void TableData_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                ModelProduct model = binding[e.RowIndex];
                if (model != null)
                {
                    ModelProductCustom group = groupBinding.Find(item => item.product.Equals(model));
                    DetailSpecsProduct_Form detailSpecs = new DetailSpecsProduct_Form();
                    detailSpecs.ShowDialog(this, group.productsTheSame.ToArray());
                }
            }
        }

        private void TableData_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowCount > 0)
            {
                DataGridView grid = sender as DataGridView;

                DataGridViewColumn colorModelCol = grid.Columns["ColorModel"];
                DataGridViewColumn colorCodeCol = grid.Columns["ColorCode"];
                DataGridViewColumn colorNameCol = grid.Columns["ColorName"];
                DataGridViewCell toolTipColor = grid.Rows[e.RowIndex].Cells[colorNameCol.Index];
                DataGridViewCell color = grid.Rows[e.RowIndex].Cells[colorModelCol.Index];
                DataGridViewCell cell = grid.Rows[e.RowIndex].Cells[colorCodeCol.Index];
                DataGridViewCellStyle style = cell.Style;
                cell.ToolTipText = toolTipColor.Value.ToString();
                style.ForeColor = style.SelectionForeColor = style.BackColor = style.SelectionBackColor = (color.Value as ImportData.ModelProduct.Color).ColorCode;
                ModelProduct currentRow = binding[e.RowIndex];
            }
        }
    }
}
