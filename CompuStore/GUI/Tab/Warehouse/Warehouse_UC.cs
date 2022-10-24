using CompuStore.Database.Models;
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

            public string MANUFACTUERE
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
        private static readonly string[] columnVisiableImportWarehouse = { "NAME_ID", "IMPORT_DATE", "TOTAL", "DISTRIBUTOR" };
        private BindingList<CommonSpecsCustom> commonSpecsBinding;
        private static readonly string[] columnVisiableCommonSpecs = { "NAME_ID", "NAME", "LINE_UP", "RELEASED_YEAR" };
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
                var x = from f in Database.DataProvider.Instance.Database.IMPORT_WAREHOUSE
                        select new { f.NAME_ID, f.IMPORT_DATE, f.TOTAL, f.DISTRIBUTOR.NAME };
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
            if (TableData_DataGridVIew.InvokeRequired)
            {
                TableData_DataGridVIew.Invoke(new Action(() =>
                {
                    TableData_DataGridVIew.DataSource = commonSpecsBinding;
                }));
            }
            else
            {
                TableData_DataGridVIew.DataSource = commonSpecsBinding;
            }
        }

        private void SeeInvoiceImportWarehouse_Click(object sender, EventArgs e)
        {
            seeWhat = SEE_WHAT.IMPORT_WAREHOUSE;
            if (TableData_DataGridVIew.InvokeRequired)
            {
                TableData_DataGridVIew.Invoke(new Action(() =>
                {
                    TableData_DataGridVIew.DataSource = importWarehouseBinding;
                }));
            }
            else
            {
                TableData_DataGridVIew.DataSource = importWarehouseBinding;
            }
        }

        private void TableData_DataGridVIew_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            grid.SuspendLayout();
            string[] columnVisible = seeWhat == SEE_WHAT.COMMON_SPECS ? columnVisiableCommonSpecs : columnVisiableImportWarehouse;
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (!columnVisible.Contains(column.Name))
                {
                    column.Visible = false;
                }
                else if (column.Name == "RELEASED_YEAR")
                {
                    column.DefaultCellStyle.Format = "yyyy";
                }
            }
            grid.ResumeLayout(true);
        }

        private async void Warehouse_UC_Load(object sender, EventArgs e)
        {
            //show wating form
            await LoadingBinding();
            //close wating form
        }
    }
}
