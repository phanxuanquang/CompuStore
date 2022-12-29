using CompuStore.Database.Models;
using CompuStore.GUI.Forms.SubForms.Warehouse.DetailSpecsProduct;
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
        #region Variable
        private COMMON_SPECS commonSpecs = null;
        private IMPORT_WAREHOUSE importWarehouse = null;
        #endregion

        #region Set editable
        private void SetEditable()
        {
            if (importWarehouse != null)
            {
                Finish_Button.Visible = true;
                AddProductByExcel_Button.Visible = true;
                AddProduct_Button.Visible = true;
                DeleteProduct_Button.Visible = true;
            }
        }
        #endregion

        public EditDetailInvoiceImportWarehouse_Form() { }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        #region Loading data
        private Task LoadingData(IProgress<int> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                if (commonSpecs != null)
                {
                    int counter = 0;
                    LINE_UP lineup = commonSpecs.LINE_UP;

                    if (initProduct == null)
                    {
                        //Loading data from database
                        //Load only once time
                        initProduct = new List<ModelProduct>();
                        if (importWarehouse != null)
                        {
                            IEnumerable<DETAIL_IMPORT_WAREHOUSE> detailImportWarehouse = importWarehouse.DETAIL_IMPORT_WAREHOUSE.Where(item => item.PRODUCT.DETAIL_SPECS.ID_COMMON_SPECS == commonSpecs.ID);
                            foreach (DETAIL_IMPORT_WAREHOUSE detailImport in detailImportWarehouse)
                            {
                                PRODUCT product = detailImport.PRODUCT;
                                DETAIL_SPECS detail = product.DETAIL_SPECS;
                                UNIQUE_SPECS uniqueSpecs = detail.UNIQUE_SPECS;
                                DISPLAY_SPECS display = uniqueSpecs.DISPLAY_SPECS;
                                COLOR color = detail.COLOR;

                                initProduct.Add(ModelProduct.DatabaseToModel(product, detailImport, lineup, display, uniqueSpecs, commonSpecs, color));
                                productList.Add(ModelProduct.DatabaseToModel(product, detailImport, lineup, display, uniqueSpecs, commonSpecs, color));
                            }
                        }
                        else
                        {
                            ICollection<DETAIL_SPECS> detailSpecs = commonSpecs.DETAIL_SPECS;
                            foreach (DETAIL_SPECS detail in detailSpecs)
                            {
                                UNIQUE_SPECS uniqueSpecs = detail.UNIQUE_SPECS;
                                DISPLAY_SPECS display = uniqueSpecs.DISPLAY_SPECS;
                                COLOR color = detail.COLOR;
                                ICollection<PRODUCT> products = detail.PRODUCTs;

                                foreach (PRODUCT product in products)
                                {
                                    DETAIL_IMPORT_WAREHOUSE detailImport = product.DETAIL_IMPORT_WAREHOUSE.First(item => item.PRODUCT_ID == product.PRODUCT_ID);
                                    initProduct.Add(ModelProduct.DatabaseToModel(product, detailImport, lineup, display, uniqueSpecs, commonSpecs, color));
                                    productList.Add(ModelProduct.DatabaseToModel(product, detailImport, lineup, display, uniqueSpecs, commonSpecs, color));
                                }
                            }
                        }
                    }


                    foreach (ModelProduct product in productList)
                    {
                        if (TableData_DataGridView.InvokeRequired)
                        {
                            TableData_DataGridView.Invoke(new Action(() => bindingTable.Add(product)));
                        }
                        else
                        {
                            bindingTable.Add(product);
                        }
                        progress.Report(++counter);
                    }
                }
            });
        }

        protected override void Custom_Load(object sender, EventArgs e)
        {
            Progress<int> progress = new Progress<int>();
            Waiting_Form waiting = new Waiting_Form();
            bindingTable.Clear();
            waiting.FormClosing += (owner, ev) =>
            {
                LineUp_ComboBox.SelectedValue = commonSpecs.ID_LINE_UP;
                NameProduct_ComboBox.SelectedValue = commonSpecs.ID;
                Manufacturer_ComboBox.SelectedValue = commonSpecs.ID_LINE_UP;
                ReleaseDate_DateTimePicker.Value = commonSpecs.RELEASED_YEAR.Value;
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
        #endregion

        #region Event
        private void TableData_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IList<ModelProduct> models = new List<ModelProduct>();
                ModelProduct model = bindingTable[e.RowIndex];
                if (model != null)
                {
                    BaseDetailSpecsProduct_Form detailSpecs = null;
                    if (importWarehouse == null)
                    {
                        detailSpecs = new OverviewDetailSpecsProduct_Form();
                        models = bindingTable.Where(item => item.CompareSpecs(model)).ToList();
                    }
                    else
                    {
                        detailSpecs = new ImportDetailSpecsProduct_Form();
                        models.Add(model);
                    }
                    detailSpecs.ShowDialog(this, models, importWarehouse == null ? false : true);
                }
            }
        }
        #endregion

        #region IO Handle
        public override ResultDetailInvoiceImportWarehouse ShowDialog(IWin32Window owner, IMPORT_WAREHOUSE importWarehouse, COMMON_SPECS commonSpecs)
        {
            this.commonSpecs = commonSpecs;
            this.importWarehouse = importWarehouse;
            SetEditable();
            Load += Custom_Load;
            TableData_DataGridView.CellDoubleClick += TableData_DataGridView_CellDoubleClick;

            return base.ShowDialog(owner, importWarehouse, commonSpecs);
        }
        #endregion
        /*protected override void CheckChange()
        {
            
        }*/
    }
}
