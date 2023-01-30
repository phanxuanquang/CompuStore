using CompuStore.Database;
using CompuStore.Database.Models;
using CompuStore.Database.Services.ProductServices;
using CompuStore.GUI;
using CompuStore.GUI.Forms.SubForms.Warehouse;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.Tab
{
    public partial class Warehouse_UC : BaseTab
    {
        #region Class
        protected class ImportWarehouseCustom
        {
            public int id;

            public int? N0 { get; set; }

            public string NameID { get; set; }

            public DateTime? ImportDate { get; set; }

            public double Total { get; set; }

            public int distributorID;
            public string distributorName;

            public DISTRIBUTOR DISTRIBUTOR
            {
                set
                {
                    distributorID = value.ID;
                    distributorName = value.NAME;
                }
            }

            public int Quantity { get; set; }

            public string DistributorName
            {
                get
                {
                    return distributorName;
                }
            }

            public static ImportWarehouseCustom Convert(IMPORT_WAREHOUSE model, int? n0)
            {
                ImportWarehouseCustom result = null;
                if (model != null)
                {
                    result = new ImportWarehouseCustom();
                    result.DISTRIBUTOR = model.DISTRIBUTOR;
                    result.ImportDate = model.IMPORT_DATE;
                    result.NameID = model.NAME_ID;
                    result.Total = model.TOTAL;
                    result.id = model.ID;
                    result.Quantity = model.DETAIL_IMPORT_WAREHOUSE.Count;
                    result.N0 = n0;
                }
                return result;
            }
        }

        protected class CommonSpecsCustom
        {
            public int id;
            public int lineupID;
            public string lineupName;
            public string lineupManufacturer;
            public DateTime? releasedYear;

            public LINE_UP LINE_UP
            {
                set
                {
                    lineupID = value.ID;
                    lineupName = value.NAME;
                    lineupManufacturer = value.MANUFACTURER;
                }
            }

            public int? N0 { get; set; }

            public string NAME_ID { get; set; }

            public string NAME { get; set; }

            public string NAME_LINE_UP
            {
                get
                {
                    return lineupName;
                }
            }

            public string MANUFACTURER
            {
                get
                {
                    return lineupManufacturer;
                }
            }

            public string ReleasedYear
            {
                get
                {
                    return releasedYear?.ToString("yyyy");
                }
            }

            public DateTime? RELEASED_YEAR
            {
                set
                {
                    releasedYear = value;
                }
            }

            public static CommonSpecsCustom Convert(COMMON_SPECS model, int? n0)
            {
                CommonSpecsCustom result = null;
                if (model != null)
                {
                    result = new CommonSpecsCustom();
                    result.LINE_UP = model.LINE_UP;
                    result.NAME = model.NAME;
                    result.NAME_ID = model.NAME_ID;
                    result.id = model.ID;
                    result.RELEASED_YEAR = model.RELEASED_YEAR;
                    result.N0 = n0;
                }
                return result;
            }
        }
        #endregion

        #region Variable
        protected BindingList<ImportWarehouseCustom> importWarehouseBinding;
        protected BindingList<CommonSpecsCustom> commonSpecsBinding;
        protected enum SEE_WHAT
        {
            IMPORT_WAREHOUSE, COMMON_SPECS, NONE
        }
        protected SEE_WHAT seeWhat = SEE_WHAT.NONE;
        #endregion

        #region Translater
        protected static readonly Dictionary<string, (string, DataGridViewContentAlignment)> columnVisibleImportWarehouse = new Dictionary<string, (string, DataGridViewContentAlignment)> {
            { "N0", ("STT", DataGridViewContentAlignment.MiddleCenter) },
            { "NameID", ("Mã nhập hàng", DataGridViewContentAlignment.MiddleCenter) },
            { "ImportDate", ("Ngày nhập hàng", DataGridViewContentAlignment.MiddleCenter) },
            { "Total", ("Tổng giá trị", DataGridViewContentAlignment.MiddleRight) },
            { "Quantity", ("Số lượng", DataGridViewContentAlignment.MiddleRight) },
            { "DistributorName", ("Nhà phân phối", DataGridViewContentAlignment.MiddleLeft) } };
        protected static readonly Dictionary<string, (string, DataGridViewContentAlignment)> columnVisibleCommonSpecs = new Dictionary<string, (string, DataGridViewContentAlignment)> {
            //{ "NAME_ID", "Mã sản phẩm" },
            { "N0", ("STT", DataGridViewContentAlignment.MiddleCenter) },
            { "NAME", ("Tên sản phẩm" , DataGridViewContentAlignment.MiddleLeft)},
            { "NAME_LINE_UP", ("Dòng sản phẩm", DataGridViewContentAlignment.MiddleLeft) },
            { "MANUFACTURER", ("Nhà sản xuất", DataGridViewContentAlignment.MiddleLeft) },
            { "ReleasedYear", ("Năm ra mắt", DataGridViewContentAlignment.MiddleCenter) } };
        #endregion

        public Warehouse_UC()
        {
            Bottom_1.Text = "Xem hóa đơn nhập hàng";
            Button_2.Text = "Xem sản phẩm";
            Button_3.Text = "Nhập hàng";
            Bottom_1.Click += SeeInvoiceImportWarehouse_Click;
            Button_2.Click += SeeProduct_Click;
            Button_3.Click += ImportWarehouse_Click;
            SearchBox.TextChanged += SearchBox_TextChanged;
            GridDataTable.DataSourceChanged += GridDataTable_DataSourceChanged;
            GridDataTable.CellDoubleClick += GridDataTable_CellDoubleClick;
            Load += Warehouse_UC_Load;
        }

        #region Loading data
        protected Task LoadingData(IProgress<int> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    int index = 1;
                    IQueryable<IMPORT_WAREHOUSE> importWarehouseQueryable = Database.DataProvider.Instance.Database.IMPORT_WAREHOUSE;
                    foreach (IMPORT_WAREHOUSE model in importWarehouseQueryable)
                    {
                        if (importWarehouseBinding != null)
                        {
                            importWarehouseBinding.Add(ImportWarehouseCustom.Convert(model, index++));
                        }
                    }
                    progress.Report(0);
                    index = 1;
                    IQueryable<COMMON_SPECS> commonSpecsQueryable = Database.DataProvider.Instance.Database.COMMON_SPECS;
                    foreach (COMMON_SPECS model in commonSpecsQueryable)
                    {
                        if (commonSpecsBinding != null)
                        {
                            commonSpecsBinding.Add(CommonSpecsCustom.Convert(model, index++));
                        }
                    }
                    progress.Report(1);
                }
                catch
                {
                    Thread.Sleep(5000);
                    LoadingData(progress);
                }
            });
        }

        protected void Warehouse_UC_Load(object sender, EventArgs e)
        {
            Progress<int> progress = new Progress<int>();
            Waiting_Form waiting = new Waiting_Form();
            importWarehouseBinding = new BindingList<ImportWarehouseCustom>();
            commonSpecsBinding = new BindingList<CommonSpecsCustom>();
            Task runLoading = LoadingData(progress);

            const int stopWaitingCounter = 1;

            runLoading.GetAwaiter().OnCompleted(() => waiting.Close());

            progress.ProgressChanged += (owner, value) =>
            {
                //Stop wating form when loaded invoice import warehouse. CommonSpecs continue load
                if (value >= stopWaitingCounter && !waiting.IsDisposed && waiting.shown)
                {
                    waiting.Close();
                    SeeInvoiceImportWarehouse_Click(null, null);
                }
            };

            waiting.ShowDialog(this);
        }

        protected void GridDataTable_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            grid.SuspendLayout();
            grid.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.NotSet;
            Dictionary<string, (string, DataGridViewContentAlignment)> columnVisible = seeWhat == SEE_WHAT.COMMON_SPECS ? columnVisibleCommonSpecs : columnVisibleImportWarehouse;
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (columnVisible.ContainsKey(column.Name))
                {
                    if (column.Name == "ReleasedYear")
                    {
                        column.DefaultCellStyle.Format = "yyyy";
                    }
                    if (column.Name == "Total")
                    {
                        column.DefaultCellStyle.Format = "#,#";
                    }
                    (string, DataGridViewContentAlignment) translater = columnVisible[column.Name];
                    column.HeaderText = translater.Item1;
                    column.DefaultCellStyle.Alignment = translater.Item2;
                    if (column.Name == "N0")
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else
                {
                    column.Visible = false;
                }
            }
            grid.ResumeLayout(true);
        }
        #endregion

        #region Event
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox control = sender as Guna2TextBox;
            if (control != null)
            {
                string search = control.Text;
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[GridDataTable.DataSource];
                currencyManager1.SuspendBinding();

                foreach (DataGridViewRow row in GridDataTable.Rows)
                {
                    if (seeWhat == SEE_WHAT.COMMON_SPECS)
                    {
                        CommonSpecsCustom binding = row.DataBoundItem as CommonSpecsCustom;
                        row.Visible = binding.NAME.ToLower().Contains(search);
                    }
                    else
                    {
                        ImportWarehouseCustom binding = row.DataBoundItem as ImportWarehouseCustom;
                        row.Visible = binding.NameID.ToLower().StartsWith(search) ||
                            binding.DistributorName.ToLower().Contains(search) ||
                            binding.ImportDate.Value.ToString("dd/MM/yyyy").StartsWith(search);
                    }
                }

                currencyManager1.ResumeBinding();
            }
        }

        protected async void ImportWarehouse_Click(object sender, EventArgs e)
        {
            BaseInvoiceImportWarehouse_Form import = new AddInvoiceImportWarehouse_Form();
            bool hasChanged = import.ShowDialog(this, null, false);
            if (hasChanged)
            {
                IMPORT_WAREHOUSE newest = DataProvider.Instance.Database.IMPORT_WAREHOUSE.OrderByDescending(item => item.IMPORT_DATE).Take(1).FirstOrDefault();
                if (newest != null)
                    await Controller.Instance.Reload(newest);
                Warehouse_UC_Load(null, null);
            }
        }

        protected void SeeProduct_Click(object sender, EventArgs e)
        {
            seeWhat = SEE_WHAT.COMMON_SPECS;
            AddBindingToDataGridView(commonSpecsBinding);
        }

        protected void SeeInvoiceImportWarehouse_Click(object sender, EventArgs e)
        {
            seeWhat = SEE_WHAT.IMPORT_WAREHOUSE;
            AddBindingToDataGridView(importWarehouseBinding);
        }

        protected void AddBindingToDataGridView(IBindingList binding)
        {
            if (GridDataTable.InvokeRequired)
            {
                GridDataTable.Invoke(new Action(() =>
                {
                    GridDataTable.DataSource = binding;
                }));
            }
            else
            {
                GridDataTable.DataSource = binding;
            }
        }

        protected async void GridDataTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                bool hasChanged = false;
                IMPORT_WAREHOUSE importWarehouse = null;
                switch (seeWhat)
                {
                    case SEE_WHAT.COMMON_SPECS:
                        CommonSpecsCustom selectedCommon = (sender as DataGridView).Rows[e.RowIndex].DataBoundItem as CommonSpecsCustom;
                        COMMON_SPECS commonSpecs = Database.Services.CommonSpecsServices.Instance.GetCommonSpecsByNameID(selectedCommon.NAME_ID);
                        if (commonSpecs != null)
                        {
                            BaseDetailInvoiceImportWarehouse_Form form = new EditDetailInvoiceImportWarehouse_Form();
                            form.ShowDialog(this, null, commonSpecs);
                        }
                        break;
                    case SEE_WHAT.IMPORT_WAREHOUSE:
                        ImportWarehouseCustom selectedImport = (sender as DataGridView).Rows[e.RowIndex].DataBoundItem as ImportWarehouseCustom;
                        importWarehouse = ImportWarehouseServices.Instance.GetImportWarehouseByNameID(selectedImport.NameID);
                        if (importWarehouse != null)
                        {
                            BaseInvoiceImportWarehouse_Form form = new EditInvoiceImportWarehouse_Form();
                            hasChanged = form.ShowDialog(this, importWarehouse, false);
                        }
                        break;
                }

                if (hasChanged)
                {
                    await Controller.Instance.Reload(importWarehouse);
                    Warehouse_UC_Load(null, null);
                }
            }
        }
        #endregion
    }
}