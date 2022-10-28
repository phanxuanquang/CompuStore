using CompuStore.Database.Models;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public class EditDetailInvoiceImportWarehouse_Form : BaseDetailInvoiceImportWarehouse_Form
    {
        private COMMON_SPECS commonSpecs = null;
        BindingList<ModelProduct> bindingTable = null;
        Task task = null;
        CancellationTokenSource cancellationTokenSource = null;
        List<ModelProductGroup> groupBinding = null;

        public EditDetailInvoiceImportWarehouse_Form(COMMON_SPECS commonSpecs = null)
        {
            this.commonSpecs = commonSpecs;
            Load += DetailInvoiceImportWarehouse_Form_Load;
            TableData_DataGridView.CellDoubleClick += TableData_DataGridView_CellDoubleClick;
            AddProductByExcel_Button.Click += AddProductByExcel_Button_Click;
        }

        private Task LoadingData(IProgress<int> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                if (commonSpecs != null)
                {
                    int counter = 0;
                    groupBinding = new List<ModelProductGroup>();
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
                            ModelProductGroup group = groupBinding.Find(item => item.IsTheSameGroup(modelProduct));
                            if (group != null)
                            {
                                group.product = modelProduct;
                            }
                            else
                            {
                                group = new ModelProductGroup();
                                group.product = modelProduct;
                                groupBinding.Add(group);

                                if (TableData_DataGridView.InvokeRequired)
                                {
                                    TableData_DataGridView.Invoke(new Action(() => bindingTable.Add(group.product)));
                                }
                                else
                                {
                                    bindingTable.Add(modelProduct);
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
            bindingTable = new BindingList<ModelProduct>();
            TableData_DataGridView.DataSource = bindingTable;
            Progress<int> progress = new Progress<int>();
            Waiting_Form waiting = new Waiting_Form();
            waiting.FormClosing += (owner, ev) =>
            {
                LineUp_ComboBox.SelectedValue = commonSpecs.ID_LINE_UP;
                NameProduct_ComboBox.SelectedValue = commonSpecs.ID;
                Manufacturer_ComboBox.SelectedValue = commonSpecs.ID_LINE_UP;
            };
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

        private void AddProductByExcel_Button_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog openFileDialog = new OpenFileDialog();
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
            }*/
        }

        private void TableData_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ModelProduct model = bindingTable[e.RowIndex];
                if (model != null)
                {
                    ModelProductGroup group = groupBinding.Find(item => item.product.Equals(model));
                    DetailSpecsProduct_Form detailSpecs = new DetailSpecsProduct_Form();
                    detailSpecs.ShowDialog(this, group.productsTheSame);
                }
            }
        }
    }
}
