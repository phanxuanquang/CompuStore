using CompuStore.Database.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.Tab.Warehouse
{
    public partial class Warehouse_UC : UserControl
    {
        class ImportWarehouseCustom
        {
            private string nameID;
            private DateTime? importDate;
            private double total;
            private DISTRIBUTOR distributor;

            public DISTRIBUTOR DISTRIBUTOR
            {
                set
                {
                    distributor = value;
                }
            }

            public string NAME_ID
            {
                get
                {
                    return nameID;
                }
                set
                {
                    nameID = value;
                }
            }

            public DateTime? IMPORT_DATE
            {
                get
                {
                    return importDate;
                }
                set
                {
                    importDate = value;
                }
            }

            public double TOTAL
            {
                get
                {
                    return total;
                }
                set
                {
                    total = value;
                }
            }

            public string DISTRIBUTOR_NAME
            {
                get
                {
                    return distributor.NAME;
                }
            }
        }

        class CommonSpecsCustom
        {
            private string nameId;
            private string name;
            private LINE_UP lineup;
            private DateTime? releasedYear;

            public LINE_UP LINE_UP
            {
                set
                {
                    lineup = value;
                }
            }

            public string NAME_ID
            {
                get
                {
                    return nameId;
                }
                set
                {
                    nameId = value;
                }
            }

            public string NAME
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public string NAME_LINE_UP
            {
                get
                {
                    return lineup.NAME;
                }
            }

            public string MANUFACTURER
            {
                get
                {
                    return lineup.MANUFACTURER;
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
        }

        private BindingList<ImportWarehouseCustom> importWarehouseBinding;
        private static readonly Dictionary<string, string> columnVisiableImportWarehouse = new Dictionary<string, string> { 
            { "NAME_ID", "Mã nhập hàng" }, 
            { "IMPORT_DATE", "Ngày nhập hàng" }, 
            { "TOTAL", "Tổng giá trị" }, 
            { "DISTRIBUTOR_NAME", "Nhà phân phối" } };
        private BindingList<CommonSpecsCustom> commonSpecsBinding;
        private static readonly Dictionary<string, string> columnVisiableCommonSpecs = new Dictionary<string, string> {
            { "NAME_ID", "Mã sản phẩm" },
            { "NAME", "Tên sản phẩm" },
            { "NAME_LINE_UP", "Dòng sản phẩm" },
            { "MANUFACTURER", "Nhà sản xuất" },
            { "ReleasedYear", "Năm ra mắt" } };

        enum SEE_WHAT
        {
            IMPORT_WAREHOUSE, COMMON_SPECS, NONE
        }
        private SEE_WHAT seeWhat = SEE_WHAT.NONE;

        public Warehouse_UC()
        {
            InitializeComponent();
        }

        private Task LoadingBinding()
        {
            return Task.Factory.StartNew(() =>
            {
                IQueryable<ImportWarehouseCustom> viewImportWarehouse = from warehouse in Database.DataProvider.Instance.Database.IMPORT_WAREHOUSE
                                                                        select new ImportWarehouseCustom { NAME_ID = warehouse.NAME_ID, IMPORT_DATE = warehouse.IMPORT_DATE, TOTAL = warehouse.TOTAL, DISTRIBUTOR = warehouse.DISTRIBUTOR };
                IQueryable<CommonSpecsCustom> viewCommonSpecs = from specs in Database.DataProvider.Instance.Database.COMMON_SPECS
                                                                select new CommonSpecsCustom { LINE_UP = specs.LINE_UP, NAME = specs.NAME, NAME_ID = specs.NAME_ID, RELEASED_YEAR = specs.RELEASED_YEAR };
                importWarehouseBinding = new BindingList<ImportWarehouseCustom>(viewImportWarehouse.ToList());
                commonSpecsBinding = new BindingList<CommonSpecsCustom>(viewCommonSpecs.ToList());
                SeeProduct_Click(null, null);
                SeeInvoiceImportWarehouse_Click(null, null);
            });
        }

        private void ImportWarehouse_Click(object sender, EventArgs e)
        {
            DetailInvoiceImportWarehouse_Form detail = new DetailInvoiceImportWarehouse_Form();
            detail.ShowDialog(this);
        }

        private void SeeProduct_Click(object sender, EventArgs e)
        {
            seeWhat = SEE_WHAT.COMMON_SPECS;
            if (TableData_DataGridView.InvokeRequired)
            {
                TableData_DataGridView.Invoke(new Action(() =>
                {
                    TableData_DataGridView.DataSource = commonSpecsBinding;
                }));
            }
            else
            {
                TableData_DataGridView.DataSource = commonSpecsBinding;
            }
        }

        private void SeeInvoiceImportWarehouse_Click(object sender, EventArgs e)
        {
            seeWhat = SEE_WHAT.IMPORT_WAREHOUSE;
            if (TableData_DataGridView.InvokeRequired)
            {
                TableData_DataGridView.Invoke(new Action(() =>
                {
                    TableData_DataGridView.DataSource = importWarehouseBinding;
                }));
            }
            else
            {
                TableData_DataGridView.DataSource = importWarehouseBinding;
            }
        }

        private async void Warehouse_UC_Load(object sender, EventArgs e)
        {
            //show wating form
            await LoadingBinding();
            //close wating form
        }

        private void TableData_DataGridView_DataSourceChanged(object sender, EventArgs e)
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

        private void TableData_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (seeWhat)
                {
                    case SEE_WHAT.COMMON_SPECS:
                        string nameIdCommonSpecs = (sender as DataGridView).Rows[e.RowIndex].Cells[0].Value as string;
                        COMMON_SPECS commonSpecs = Database.Services.CommonSpecsServices.Instance.GetCommonSpecsByNameID(nameIdCommonSpecs);
                        if (commonSpecs != null)
                        {
                            DetailInvoiceImportWarehouse_Form form = new DetailInvoiceImportWarehouse_Form(commonSpecs);
                            form.ShowDialog();
                        }
                        break;
                    case SEE_WHAT.IMPORT_WAREHOUSE:
                        break;
                }
            }
        }
    }
}
