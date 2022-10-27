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
        BindingList<CommonSpecsCustom> bindingTable = null;
        BindingList<DistributorCustom> bindingDistributor = null;
        BindingList<StoreCustom> bindingStore = null;
        ImportWarehouseCustom convertImportWarehouse = null;
        List<CommonSpecsGroup<DETAIL_SPECS>> commonSpecsGroups = null;

        #region Defind Custom Model
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

        private class EditInvoiceCommonSpecsGroup : CommonSpecsGroup<DETAIL_SPECS>
        {
            List<DETAIL_SPECS> _detailSpecs;

            double CommonSpecsGroup<DETAIL_SPECS>.maxTotal
            {
                get
                {
                    double? max = null;
                    foreach (DETAIL_SPECS detail in _detailSpecs)
                    {
                        if (detail.PRICE > max || max == null)
                        {
                            max = detail.PRICE;
                        }
                    }
                    return max == null ? 0.0 : max.Value;
                }
            }
            double CommonSpecsGroup<DETAIL_SPECS>.minTotal
            {
                get
                {
                    double? min = null;
                    foreach (DETAIL_SPECS detail in _detailSpecs)
                    {
                        if (detail.PRICE < min || min == null)
                        {
                            min = detail.PRICE;
                        }
                    }
                    return min == null ? 0.0 : min.Value;
                }
            }
            DETAIL_SPECS CommonSpecsGroup<DETAIL_SPECS>.Represent
            {
                get => _detailSpecs?.FirstOrDefault();
            }

            public IList<DETAIL_SPECS> detailSpecs
            {
                get => _detailSpecs;
                set
                {
                    if (value is List<DETAIL_SPECS>)
                    {
                        _detailSpecs = (List<DETAIL_SPECS>)value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            public EditInvoiceCommonSpecsGroup(List<DETAIL_SPECS> detailSpecs)
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

        private class EditInvoiceCommonSpecs : CommonSpecsCustom
        {
            private int _ID;
            private string _NameID;
            private string _NameCommonSpecs;
            private string _LineUp;
            private string _Manufacturer;
            private DateTime? _ReleaseDate;
            private int _Quantity;
            private string _RangeTotal;

            int CommonSpecsCustom.ID { get => _ID; set => _ID = value; }
            string CommonSpecsCustom.NameID { get => _NameID; set => _NameID = value; }
            string CommonSpecsCustom.NameCommonSpecs { get => _NameCommonSpecs; set => _NameCommonSpecs = value; }
            string CommonSpecsCustom.LineUp { get => _LineUp; set => _LineUp = value; }
            string CommonSpecsCustom.Manufacturer { get => _Manufacturer; set => _Manufacturer = value; }
            DateTime? CommonSpecsCustom.ReleaseDate { get => _ReleaseDate; set => _ReleaseDate = value; }
            int CommonSpecsCustom.Quantity { get => _Quantity; set => _Quantity = value; }
            string CommonSpecsCustom.RangeTotal { get => _RangeTotal; set => _RangeTotal = value; }

            public EditInvoiceCommonSpecs(CommonSpecsGroup<DETAIL_SPECS> group)
            {
                if (group != null)
                {
                    COMMON_SPECS common = group.Represent?.COMMON_SPECS;
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

        private Task LoadingData(IProgress<int> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                IQueryable<DISTRIBUTOR> distributorQueryable = Database.DataProvider.Instance.Database.DISTRIBUTORs;
                foreach (DISTRIBUTOR distributor in distributorQueryable)
                {
                    if (bindingDistributor != null)
                    {
                        bindingDistributor.Add(DistributorCustom.Convert(distributor));
                    }
                }

                IQueryable<STORE> storeQueryable = Database.DataProvider.Instance.Database.STOREs;
                foreach (STORE store in storeQueryable)
                {
                    if (bindingStore != null)
                    {
                        bindingStore.Add(StoreCustom.Convert(store));
                    }
                }

                progress.Report(0);

                if (importWarehouse != null)
                {
                    convertImportWarehouse = ImportWarehouseCustom.Convert(importWarehouse);
                    IEnumerable<IGrouping<int, DETAIL_SPECS>> groups = importWarehouse.DETAIL_IMPORT_WAREHOUSE.Select(item => item.PRODUCT).Select(item => item.DETAIL_SPECS).GroupBy(item => item.ID_COMMON_SPECS);
                    foreach (IGrouping<int, DETAIL_SPECS> group in groups)
                    {
                        if (commonSpecsGroups != null && bindingTable != null)
                        {
                            CommonSpecsGroup<DETAIL_SPECS> commonSpecsGroup = new EditInvoiceCommonSpecsGroup(group.ToList());
                            CommonSpecsCustom commonSpecsCustom = new EditInvoiceCommonSpecs(commonSpecsGroup);
                            commonSpecsGroups.Add(commonSpecsGroup);
                            if (TableData_DataGridView.InvokeRequired)
                            {
                                TableData_DataGridView.Invoke(new Action(() => bindingTable.Add(commonSpecsCustom)));
                            }
                            else
                            {
                                bindingTable.Add(commonSpecsCustom);
                            }
                        }
                    }
                }

                progress.Report(1);
            });
        }

        private void InvoiceImportWarehouse_Form_Load(object sender, EventArgs e)
        {
            bindingTable = new BindingList<CommonSpecsCustom>();
            bindingStore = new BindingList<StoreCustom>();
            bindingDistributor = new BindingList<DistributorCustom>();
            commonSpecsGroups = new List<CommonSpecsGroup<DETAIL_SPECS>>();
            TableData_DataGridView.DataSource = bindingTable;

            Progress<int> progress = new Progress<int>();
            Waiting_Form waiting = new Waiting_Form();
            Task runLoading = LoadingData(progress);

            const int stopWaitingCoutner = 1;

            waiting.FormClosed += (owner, ev) =>
            {
                Distributor_Combobox.DataSource = bindingDistributor;
                Distributor_Combobox.ValueMember = "ID";
                Distributor_Combobox.DisplayMember = "Name";

                ImportToStore_Combobox.DataSource = bindingStore;
                ImportToStore_Combobox.ValueMember = "ID";
                ImportToStore_Combobox.DisplayMember = "Name";

                if (convertImportWarehouse != null)
                {
                    Distributor_Combobox.SelectedValue = convertImportWarehouse.IDDistributor;
                    DateTimeImportWarehouse_DateTimePicker.Value = convertImportWarehouse.ImportDate.Value;
                    ImportToStore_Combobox.SelectedValue = convertImportWarehouse.IDStore;
                    TotalImportWarehouse_Value.Text = convertImportWarehouse.Total.ToString();
                    StaffImport_Value.Text = string.Format("{0} | {1}", convertImportWarehouse.NameStaff, convertImportWarehouse.NameIDStaff);
                    IDImportWarehouse_Value.Text = convertImportWarehouse.NameIDImportWarehouse;
                }
                else
                {
                    StaffImport_Value.Text = string.Format("{0} | {1}", LoginServices.Instance.CurrentStaff.INFOR.NAME, LoginServices.Instance.CurrentStaff.NAME_ID);
                }
            };

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

        private void TableData_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nameIdCommonSpecs = (sender as DataGridView).Rows[e.RowIndex].Cells["NameID"].Value as string;
            COMMON_SPECS commonSpecs = Database.Services.CommonSpecsServices.Instance.GetCommonSpecsByNameID(nameIdCommonSpecs);
            if (commonSpecs != null)
            {
                DetailInvoiceImportWarehouse_Form form = new DetailInvoiceImportWarehouse_Form(commonSpecs);
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
