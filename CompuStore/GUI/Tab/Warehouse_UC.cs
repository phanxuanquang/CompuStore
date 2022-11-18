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

            public static ImportWarehouseCustom Convert(IMPORT_WAREHOUSE model)
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

            public static CommonSpecsCustom Convert(COMMON_SPECS model)
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
        protected static readonly Dictionary<string, string> columnVisiableImportWarehouse = new Dictionary<string, string> {
            { "NameID", "Mã nhập hàng" },
            { "ImportDate", "Ngày nhập hàng" },
            { "Total", "Tổng giá trị" },
            { "Quantity", "Số lượng" },
            { "DistributorName", "Nhà phân phối" } };
        protected static readonly Dictionary<string, string> columnVisiableCommonSpecs = new Dictionary<string, string> {
            //{ "NAME_ID", "Mã sản phẩm" },
            { "NAME", "Tên sản phẩm" },
            { "NAME_LINE_UP", "Dòng sản phẩm" },
            { "MANUFACTURER", "Nhà sản xuất" },
            { "ReleasedYear", "Năm ra mắt" } };
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
            InitializeComponent();
        }

        #region Loading data
        protected Task LoadingData(IProgress<int> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    IQueryable<IMPORT_WAREHOUSE> importWarehouseQueryable = Database.DataProvider.Instance.Database.IMPORT_WAREHOUSE;
                    foreach (IMPORT_WAREHOUSE model in importWarehouseQueryable)
                    {
                        if (importWarehouseBinding != null)
                        {
                            importWarehouseBinding.Add(ImportWarehouseCustom.Convert(model));
                        }
                    }
                    progress.Report(0);
                    IQueryable<COMMON_SPECS> commonSpecsQueryable = Database.DataProvider.Instance.Database.COMMON_SPECS;
                    foreach (COMMON_SPECS model in commonSpecsQueryable)
                    {
                        if (commonSpecsBinding != null)
                        {
                            commonSpecsBinding.Add(CommonSpecsCustom.Convert(model));
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
            Task runLoading = LoadingData(progress);
            importWarehouseBinding = new BindingList<ImportWarehouseCustom>();
            commonSpecsBinding = new BindingList<CommonSpecsCustom>();

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
            Dictionary<string, string> columnVisible = seeWhat == SEE_WHAT.COMMON_SPECS ? columnVisiableCommonSpecs : columnVisiableImportWarehouse;
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (columnVisible.ContainsKey(column.Name))
                {
                    if (column.Name == "RELEASED_YEAR")
                    {
                        column.DefaultCellStyle.Format = "yyyy";
                    }
                    column.HeaderText = columnVisible[column.Name];
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
                    if(seeWhat == SEE_WHAT.COMMON_SPECS)
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

        protected void ImportWarehouse_Click(object sender, EventArgs e)
        {
            BaseInvoiceImportWarehouse_Form import = new AddInvoiceImportWarehouse_Form();
            import.ShowDialog(this, null, false);
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

        protected void GridDataTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (seeWhat)
                {
                    case SEE_WHAT.COMMON_SPECS:
                        string nameIdCommonSpecs = (sender as DataGridView).Rows[e.RowIndex].Cells["NAME_ID"].Value as string;
                        COMMON_SPECS commonSpecs = Database.Services.CommonSpecsServices.Instance.GetCommonSpecsByNameID(nameIdCommonSpecs);
                        if (commonSpecs != null)
                        {
                            BaseDetailInvoiceImportWarehouse_Form form = new EditDetailInvoiceImportWarehouse_Form();
                            form.ShowDialog(this, null, commonSpecs);
                        }
                        break;
                    case SEE_WHAT.IMPORT_WAREHOUSE:
                        string nameIdImportWarehouse = (sender as DataGridView).Rows[e.RowIndex].Cells["NAME_ID"].Value as string;
                        IMPORT_WAREHOUSE importWarehouse = ImportWarehouseServices.Instance.GetImportWarehouseByNameID(nameIdImportWarehouse);
                        if (importWarehouse != null)
                        {
                            BaseInvoiceImportWarehouse_Form form = new EditInvoiceImportWarehouse_Form();
                            form.ShowDialog(this, importWarehouse, false);
                        }
                        break;
                }
            }
        }
        #endregion
    }
}
