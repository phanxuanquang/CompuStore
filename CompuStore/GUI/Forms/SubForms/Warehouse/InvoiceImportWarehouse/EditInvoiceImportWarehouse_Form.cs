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
        private IMPORT_WAREHOUSE importWarehouse = null;
        BindingList<ICommonSpecsCustom> bindingTable = null;
        ImportWarehouseCustom convertImportWarehouse = null;
        List<ICommonSpecsGroup<DETAIL_IMPORT_WAREHOUSE>> commonSpecsGroups = null;

        #region Implement interface
        private class ImportWarehouseCustom
        {
            public int IDImportWarehouse { get; set; }

            public string NameIDImportWarehouse { get; set; }

            public int IDDistributor { get; set; }

            public string NameDistributor { get; set; }

            public int IDStore { get; set; }

            public string NameStore { get; set; }

            public DateTime? ImportDate { get; set; }

            public int IDStaff { get; set; }

            public string NameIDStaff { get; set; }

            public string NameStaff { get; set; }

            public double Total { get; set; }

            public static ImportWarehouseCustom Convert(IMPORT_WAREHOUSE model)
            {
                ImportWarehouseCustom result = null;
                if (model != null)
                {
                    result = new ImportWarehouseCustom();
                    result.IDImportWarehouse = model.ID;
                    result.NameIDImportWarehouse = model.NAME_ID;
                    result.ImportDate = model.IMPORT_DATE;
                    result.IDDistributor = model.ID_DISTRIBUTOR;
                    result.NameDistributor = model.DISTRIBUTOR.NAME;
                    result.IDStore = model.ID_STORE;
                    result.NameStore = model.STORE.NAME;
                    result.IDStore = model.ID_STORE;
                    result.IDStaff = model.ID_STAFF;
                    result.NameIDStaff = model.STAFF.NAME_ID;
                    result.NameStaff = model.STAFF.INFOR.NAME;
                    result.Total = model.TOTAL;
                }
                return result;
            }
        }

        private class EditInvoiceCommonSpecsGroup : ICommonSpecsGroup<DETAIL_IMPORT_WAREHOUSE>
        {
            List<DETAIL_IMPORT_WAREHOUSE> _detailSpecs;

            double ICommonSpecsGroup<DETAIL_IMPORT_WAREHOUSE>.maxTotal
            {
                get
                {
                    double? max = null;
                    foreach (DETAIL_IMPORT_WAREHOUSE detail in _detailSpecs)
                    {
                        if (detail.PRICE_PER_UNIT > max || max == null)
                        {
                            max = detail.PRICE_PER_UNIT;
                        }
                    }
                    return max == null ? 0.0 : max.Value;
                }
            }
            double ICommonSpecsGroup<DETAIL_IMPORT_WAREHOUSE>.minTotal
            {
                get
                {
                    double? min = null;
                    foreach (DETAIL_IMPORT_WAREHOUSE detail in _detailSpecs)
                    {
                        if (detail.PRICE_PER_UNIT < min || min == null)
                        {
                            min = detail.PRICE_PER_UNIT;
                        }
                    }
                    return min == null ? 0.0 : min.Value;
                }
            }
            DETAIL_IMPORT_WAREHOUSE ICommonSpecsGroup<DETAIL_IMPORT_WAREHOUSE>.Represent
            {
                get => _detailSpecs?.FirstOrDefault();
            }

            public IList<DETAIL_IMPORT_WAREHOUSE> detailSpecs
            {
                get => _detailSpecs;
                set
                {
                    if (value is List<DETAIL_IMPORT_WAREHOUSE>)
                    {
                        _detailSpecs = (List<DETAIL_IMPORT_WAREHOUSE>)value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            public EditInvoiceCommonSpecsGroup(List<DETAIL_IMPORT_WAREHOUSE> detailSpecs)
            {

                if (detailSpecs != null)
                {
                    _detailSpecs = detailSpecs;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        private class EditInvoiceCommonSpecs : ICommonSpecsCustom
        {
            private int _ID;
            private string _NameID;
            private string _NameCommonSpecs;
            private string _LineUp;
            private string _Manufacturer;
            private DateTime? _ReleaseDate;
            private int _Quantity;
            private string _RangeTotal;

            int ICommonSpecsCustom.ID { get => _ID; set => _ID = value; }
            string ICommonSpecsCustom.NameID { get => _NameID; set => _NameID = value; }
            string ICommonSpecsCustom.NameCommonSpecs { get => _NameCommonSpecs; set => _NameCommonSpecs = value; }
            string ICommonSpecsCustom.LineUp { get => _LineUp; set => _LineUp = value; }
            string ICommonSpecsCustom.Manufacturer { get => _Manufacturer; set => _Manufacturer = value; }
            DateTime? ICommonSpecsCustom.ReleaseDate { get => _ReleaseDate; set => _ReleaseDate = value; }
            int ICommonSpecsCustom.Quantity { get => _Quantity; set => _Quantity = value; }
            string ICommonSpecsCustom.RangeTotal { get => _RangeTotal; set => _RangeTotal = value; }

            public EditInvoiceCommonSpecs(ICommonSpecsGroup<DETAIL_IMPORT_WAREHOUSE> group)
            {
                if (group != null)
                {
                    COMMON_SPECS common = group.Represent?.PRODUCT.DETAIL_SPECS.COMMON_SPECS;
                    if (common != null)
                    {
                        _ID = common.ID;
                        _NameID = common.NAME_ID;
                        LINE_UP lineup = common.LINE_UP;
                        _LineUp = lineup.NAME;
                        _Manufacturer = lineup.MANUFACTURER;
                        _ReleaseDate = common.RELEASED_YEAR;
                        _NameCommonSpecs = common.NAME;
                        _RangeTotal = string.Format("{0} - {1} {2}", group.minTotal, group.maxTotal, "VNĐ");
                        _Quantity = group.detailSpecs.Count;
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        #endregion

        public EditInvoiceImportWarehouse_Form(IMPORT_WAREHOUSE importWarehouse)
        {
            this.importWarehouse = importWarehouse;
            Load += InvoiceImportWarehouse_Form_Load;
            FormClosing += InvoiceImportWarehouse_Form_FormClosing;
            TableData_DataGridView.CellDoubleClick += TableData_DataGridView_CellDoubleClick;
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
                    Distributor_Combobox.SelectedValue = convertImportWarehouse.IDDistributor;
                    DateTimeImportWarehouse_DateTimePicker.Value = convertImportWarehouse.ImportDate.Value;
                    ImportToStore_Combobox.SelectedValue = convertImportWarehouse.IDStore;
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

        private void TableData_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nameIdCommonSpecs = (sender as DataGridView).Rows[e.RowIndex].Cells["NameID"].Value as string;
            COMMON_SPECS commonSpecs = Database.Services.CommonSpecsServices.Instance.GetCommonSpecsByNameID(nameIdCommonSpecs);
            if (commonSpecs != null)
            {
                BaseDetailInvoiceImportWarehouse_Form form = new EditDetailInvoiceImportWarehouse_Form(importWarehouse, commonSpecs);
                form.ShowDialog();
            }
        }

        private async void AddProductByExcel_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tab-seperator values | *.tsv";

            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.CheckFileExists)
            {
                ModelProduct[] products = ModelProduct.GetTSV(openFileDialog.FileName);
                int? storeIDSelected = ImportToStore_Combobox.SelectedValue as int?;
                int? distributorID = Distributor_Combobox.SelectedValue as int?;
                if (products != null && storeIDSelected != null && LoginServices.Instance.CurrentStaff != null && distributorID != null)
                {
                    STORE store = StoreServices.Instance.GetStoreByID(storeIDSelected.Value);
                    STAFF staff = LoginServices.Instance.CurrentStaff;
                    DISTRIBUTOR distributor = DistributorServices.Instance.GetDistributorByID(distributorID.Value);
                    if (store != null && distributor != null)
                    {
                        (IMPORT_WAREHOUSE, List<ModelProduct>) respone = await ImportServices.Instance.Import(products, store, staff, distributor);
                        importWarehouse = respone.Item1;
                        MessageBox.Show(string.Format("Chấp nhận {0}/{1}", products.Length - respone.Item2.Count, products.Length));
                        InvoiceImportWarehouse_Form_Load(null, null);
                    }
                }
            }
        }

        private void InvoiceImportWarehouse_Form_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
