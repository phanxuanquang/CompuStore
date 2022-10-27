using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.GUI;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI.Forms.Warehouse
{
    public partial class InvoiceImportWarehouse_Form : Form
    {
        private IMPORT_WAREHOUSE importWarehouse = null;
        BindingList<CommonSpecsCustom> bindingTable = null;
        BindingList<DistributorCustom> bindingDistributor = null;
        BindingList<StoreCustom> bindingStore = null;
        ImportWarehouseCustom convertImportWarehouse = null;
        List<CommonSpecsGroup> commonSpecsGroups = null;

        private class DistributorCustom
        {
            public int ID { get; set; }

            public string Name { get; set; }

            public static DistributorCustom Convert(DISTRIBUTOR model)
            {
                DistributorCustom result = null;
                if (model != null)
                {
                    result = new DistributorCustom();
                    result.ID = model.ID;
                    result.Name = model.NAME;
                }
                return result;
            }
        }

        private class StoreCustom
        {
            public int ID { get; set; }

            public string Name { get; set; }

            public static StoreCustom Convert(STORE model)
            {
                StoreCustom result = null;
                if (model != null)
                {
                    result = new StoreCustom();
                    result.ID = model.ID;
                    result.Name = model.NAME;
                }
                return result;
            }
        }

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

        private class CommonSpecsGroup
        {
            public double maxTotal
            {
                get
                {
                    double? min = null;
                    if (detailSpecs != null)
                    {
                        foreach (DETAIL_SPECS detail in detailSpecs)
                        {
                            if (detail.PRICE < min || min == null)
                            {
                                min = detail.PRICE;
                            }
                        }
                    }
                    return min == null ? 0.0 : min.Value;
                }
            }

            public double minTotal
            {
                get
                {
                    double? max = null;
                    if (detailSpecs != null)
                    {
                        foreach (DETAIL_SPECS detail in detailSpecs)
                        {
                            if (detail.PRICE > max || max == null)
                            {
                                max = detail.PRICE;
                            }
                        }
                    }
                    return max == null ? 0.0 : max.Value;
                }
            }

            public List<DETAIL_SPECS> detailSpecs = null;

            public COMMON_SPECS Represent
            {
                get
                {
                    return detailSpecs?.First().COMMON_SPECS;
                }
            }

            public CommonSpecsGroup(List<DETAIL_SPECS> detailSpecs)
            {
                this.detailSpecs = detailSpecs;
            }
        }

        private class CommonSpecsCustom
        {
            public int ID;

            public string NameID { get; set; }

            public string NameCommonSpecs { get; set; }

            public string LineUp { get; set; }

            public string Manufacturer { get; set; }

            public DateTime? ReleaseDate { get; set; }

            public int Quantity { get; set; }

            public string RangeTotal { get; set; }

            public static CommonSpecsCustom Convert(CommonSpecsGroup group)
            {
                CommonSpecsCustom result = null;
                if (group != null)
                {
                    COMMON_SPECS common = group.Represent;
                    if (common != null)
                    {
                        result = new CommonSpecsCustom();
                        result.ID = common.ID;
                        result.NameID = common.NAME_ID;
                        LINE_UP lineup = common.LINE_UP;
                        result.LineUp = lineup.NAME;
                        result.Manufacturer = lineup.MANUFACTURER;
                        result.ReleaseDate = common.RELEASED_YEAR;
                        result.NameCommonSpecs = common.NAME;
                        result.RangeTotal = string.Format("{0} - {1} {2}", group.minTotal, group.maxTotal, "VNĐ");
                        result.Quantity = group.detailSpecs.Count;
                    }
                }
                return result;
            }
        }

        public InvoiceImportWarehouse_Form(IMPORT_WAREHOUSE importWarehouse = null)
        {
            this.importWarehouse = importWarehouse;
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    double minPrice = 0.0, maxPrice = 0.0;
                    IEnumerable<IGrouping<int, DETAIL_SPECS>> groups = importWarehouse.DETAIL_IMPORT_WAREHOUSE.Select(item => item.PRODUCT).Select(item => item.DETAIL_SPECS).GroupBy(item => item.ID_COMMON_SPECS);
                    foreach (IGrouping<int, DETAIL_SPECS> group in groups)
                    {
                        if (commonSpecsGroups != null && bindingTable != null)
                        {
                            CommonSpecsGroup commonSpecsGroup = new CommonSpecsGroup(group.ToList());
                            CommonSpecsCustom commonSpecsCustom = CommonSpecsCustom.Convert(commonSpecsGroup);
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
            commonSpecsGroups = new List<CommonSpecsGroup>();
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
            string nameIdCommonSpecs = (sender as DataGridView).Rows[e.RowIndex].Cells[0].Value as string;
            COMMON_SPECS commonSpecs = Database.Services.CommonSpecsServices.Instance.GetCommonSpecsByNameID(nameIdCommonSpecs);
            if (commonSpecs != null)
            {
                DetailInvoiceImportWarehouse_Form form = new DetailInvoiceImportWarehouse_Form(commonSpecs);
                form.ShowDialog();
            }
        }

        private void AddProductByExcel_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tab-seperator values | *.tsv";

            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.CheckFileExists)
            {
                ModelProduct[] products = ModelProduct.GetTSV(openFileDialog.FileName);
                int x = 0;
            }
        }
    }
}
