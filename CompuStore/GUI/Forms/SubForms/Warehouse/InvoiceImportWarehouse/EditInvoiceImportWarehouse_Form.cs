using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public class EditInvoiceImportWarehouse_Form : BaseInvoiceImportWarehouse_Form
    {
        #region Implement interface
        private class EditInvoiceCommonSpecsGroup : ICommonSpecsGroup<DETAIL_IMPORT_WAREHOUSE>
        {
            DETAIL_IMPORT_WAREHOUSE ICommonSpecsGroup<DETAIL_IMPORT_WAREHOUSE>.Represent
            {
                get => detailSpecs?.FirstOrDefault();
            }

            public IList<DETAIL_IMPORT_WAREHOUSE> detailSpecs { get; set; }

            public double? maxTotal
            {
                get
                {
                    double? max = null;
                    foreach (DETAIL_IMPORT_WAREHOUSE detail in detailSpecs)
                    {
                        if (detail.PRICE_PER_UNIT > max || max == null)
                        {
                            max = detail.PRICE_PER_UNIT;
                        }
                    }
                    return max == null ? 0.0 : max.Value;
                }
            }

            public double? minTotal
            {
                get
                {
                    double? min = null;
                    foreach (DETAIL_IMPORT_WAREHOUSE detail in detailSpecs)
                    {
                        if (detail.PRICE_PER_UNIT < min || min == null)
                        {
                            min = detail.PRICE_PER_UNIT;
                        }
                    }
                    return min == null ? 0.0 : min.Value;
                }
            }

            public EditInvoiceCommonSpecsGroup(List<DETAIL_IMPORT_WAREHOUSE> detailSpecs)
            {

                if (detailSpecs != null)
                {
                    this.detailSpecs = detailSpecs;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        private class EditInvoiceCommonSpecs : ICommonSpecsCustom
        {
            public EditInvoiceCommonSpecs(ICommonSpecsGroup<DETAIL_IMPORT_WAREHOUSE> group)
            {
                if (group != null)
                {
                    COMMON_SPECS common = group.Represent?.PRODUCT.DETAIL_SPECS.COMMON_SPECS;
                    if (common != null)
                    {
                        ID = common.ID;
                        NameID = common.NAME_ID;
                        LINE_UP lineup = common.LINE_UP;
                        LineUp = lineup.NAME;
                        Manufacturer = lineup.MANUFACTURER;
                        ReleaseDate = common.RELEASED_YEAR;
                        NameCommonSpecs = common.NAME;
                        RangeTotal = string.Format("{0} - {1} {2}", group.minTotal, group.maxTotal, "VNĐ");
                        Quantity = group.detailSpecs.Count;
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }

            public int? ID { get; set; }
            public string NameID { get; set; }
            public string NameCommonSpecs { get; set; }
            public string LineUp { get; set; }
            public string Manufacturer { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public int? Quantity { get; set; }
            public string RangeTotal { get; set; }
        }
        #endregion

        #region Variable
        private IMPORT_WAREHOUSE importWarehouse = null;
        BindingList<ICommonSpecsCustom> bindingTable = null;
        ImportWarehouseCustom convertImportWarehouse = null;
        List<ICommonSpecsGroup<DETAIL_IMPORT_WAREHOUSE>> commonSpecsGroups = null;
        #endregion

        public EditInvoiceImportWarehouse_Form()
        {
            Load += InvoiceImportWarehouse_Form_Load;
            TableData_DataGridView.CellDoubleClick += TableData_DataGridView_CellDoubleClick;
            AddProductByExcel_Button.Click += NavToEdit;
            AddProduct_Button.Click += NavToEdit;
            DeleteProduct_Button.Click += NavToEdit;
        }

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
                if (importWarehouse != null)
                {
                    int counter = 0;
                    convertImportWarehouse = ImportWarehouseCustom.Convert(importWarehouse);
                    IEnumerable<IGrouping<int, DETAIL_IMPORT_WAREHOUSE>> groups = importWarehouse.DETAIL_IMPORT_WAREHOUSE.GroupBy(item => item.PRODUCT.DETAIL_SPECS.ID_COMMON_SPECS);
                    foreach(IGrouping<int, DETAIL_IMPORT_WAREHOUSE> item in groups)
                    {
                        ICommonSpecsGroup<DETAIL_IMPORT_WAREHOUSE> commonSpecsGroup = new EditInvoiceCommonSpecsGroup(item.ToList());
                        ICommonSpecsCustom commonSpecsCustom = new EditInvoiceCommonSpecs(commonSpecsGroup);
                        commonSpecsGroups.Add(commonSpecsGroup);
                        if (TableData_DataGridView.InvokeRequired)
                        {
                            TableData_DataGridView.Invoke(new Action(() => bindingTable.Add(commonSpecsCustom)));
                        }
                        else
                        {
                            bindingTable.Add(commonSpecsCustom);
                        }
                        progress.Report(++counter);
                    }
                }
            });
        }

        private void InvoiceImportWarehouse_Form_Load(object sender, EventArgs e)
        {
            bindingTable = new BindingList<ICommonSpecsCustom>();
            commonSpecsGroups = new List<ICommonSpecsGroup<DETAIL_IMPORT_WAREHOUSE>>();
            TableData_DataGridView.DataSource = bindingTable;

            Progress<int> progress = new Progress<int>();
            Waiting_Form waiting = new Waiting_Form();
            Task runLoading = LoadingData(progress);

            waiting.FormClosed += (owner, ev) =>
            {
                if (convertImportWarehouse != null)
                {
                    Distributor_ComboBox.SelectedValue = convertImportWarehouse.IDDistributor;
                    DateTimeImportWarehouse_DateTimePicker.Value = convertImportWarehouse.ImportDate.Value;
                    ImportToStore_ComboBox.SelectedValue = convertImportWarehouse.IDStore;
                    TotalImportWarehouse_Value.Text = convertImportWarehouse.Total.ToString();
                    IDImportWarehouse_Value.Text = convertImportWarehouse.NameIDImportWarehouse;
                }
            };

            runLoading.GetAwaiter().OnCompleted(() => waiting.Close());

            int stoppingWaitingCounter = 5;

            progress.ProgressChanged += (owner, value) =>
            {
                if (value >= stoppingWaitingCounter && !waiting.IsDisposed && waiting.shown)
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
            string nameIdCommonSpecs = (sender as DataGridView).Rows[e.RowIndex].Cells["NameID"].Value as string;
            COMMON_SPECS commonSpecs = Database.Services.CommonSpecsServices.Instance.GetCommonSpecsByNameID(nameIdCommonSpecs);
            if (commonSpecs != null)
            {
                BaseDetailInvoiceImportWarehouse_Form form = new EditDetailInvoiceImportWarehouse_Form();
                form.ShowDialog(this, importWarehouse, commonSpecs);
            }
        }

        private void NavToEdit(object sender, EventArgs e)
        {
            BaseInvoiceImportWarehouse_Form editInvoice = new AddInvoiceImportWarehouse_Form();
            hasChanged = editInvoice.ShowDialog(this, importWarehouse, true);
        }
        #endregion

        #region IO Handle
        public override bool ShowDialog(IWin32Window owner, IMPORT_WAREHOUSE importWarehouse, bool edit = false)
        {
            this.importWarehouse = importWarehouse;
            return base.ShowDialog(owner, importWarehouse, false) || hasChanged;
        }
        #endregion
    }
}
