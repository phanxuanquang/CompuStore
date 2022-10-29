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
    public class AddDetailInvoiceImportWarehouse_Form:BaseDetailInvoiceImportWarehouse_Form
    {
        private List<ModelProduct> productsList = null;
        BindingList<ModelProduct> bindingTable = null;
        Task task = null;
        CancellationTokenSource cancellationTokenSource = null;
        List<ModelProductGroup> groupBinding = null;

        public AddDetailInvoiceImportWarehouse_Form(List<ModelProduct> products)
        {
            this.productsList = products;
            Load += DetailInvoiceImportWarehouse_Form_Load;
            TableData_DataGridView.CellDoubleClick += TableData_DataGridView_CellDoubleClick;
            AddProductByExcel_Button.Click += AddProductByExcel_Button_Click;
        }

        private Task LoadingData(IProgress<int> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                if (productsList != null)
                {
                    int counter = 0;
                    groupBinding = new List<ModelProductGroup>();
                    foreach(ModelProduct model in productsList)
                    {
                        ModelProductGroup group = groupBinding.Find(item => item.IsTheSameGroup(model));
                        if (group != null)
                        {
                            group.product = model;
                        }
                        else
                        {
                            group = new ModelProductGroup();
                            group.product = model;
                            groupBinding.Add(group);

                            if (TableData_DataGridView.InvokeRequired)
                            {
                                TableData_DataGridView.Invoke(new Action(() => bindingTable.Add(group.product)));
                            }
                            else
                            {
                                bindingTable.Add(model);
                            }
                            progress.Report(++counter);
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
                ModelProduct model = productsList.First();
                LineUp_ComboBox.SelectedText = model.LineUp;
                NameProduct_ComboBox.SelectedText = model.NameProduct;
                Manufacturer_ComboBox.SelectedText = model.Manufacturer;
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
