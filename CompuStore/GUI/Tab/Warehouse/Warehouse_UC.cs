﻿using CompuStore.Database.Models;
using CompuStore.GUI;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.Tab.Warehouse
{
    public partial class Warehouse_UC : UserControl
    {
        class ImportWarehouseCustom
        {
            public int id;
            public string nameID;
            public DateTime? importDate;
            public double total;
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
                    result.IMPORT_DATE = model.IMPORT_DATE;
                    result.NAME_ID = model.NAME_ID;
                    result.TOTAL = model.TOTAL;
                    result.id = model.ID;
                }
                return result;
            }
        }

        class CommonSpecsCustom
        {
            public int id;
            public string nameId;
            public string name;
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

        private Task LoadingData(IProgress<int> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    IQueryable<IMPORT_WAREHOUSE> importWarehouseQueryable = Database.DataProvider.Instance.Database.IMPORT_WAREHOUSE;
                    foreach(IMPORT_WAREHOUSE model in importWarehouseQueryable)
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

        private void ImportWarehouse_Click(object sender, EventArgs e)
        {
            InvoiceImportWarehouse_Form import = new InvoiceImportWarehouse_Form();
            import.ShowDialog(this);
        }

        private void SeeProduct_Click(object sender, EventArgs e)
        {
            seeWhat = SEE_WHAT.COMMON_SPECS;
            AddBindingToDataGridView(commonSpecsBinding);
        }

        private void SeeInvoiceImportWarehouse_Click(object sender, EventArgs e)
        {
            seeWhat = SEE_WHAT.IMPORT_WAREHOUSE;
            AddBindingToDataGridView(importWarehouseBinding);
        }

        private void AddBindingToDataGridView(IBindingList binding)
        {
            if (TableData_DataGridView.InvokeRequired)
            {
                TableData_DataGridView.Invoke(new Action(() =>
                {
                    TableData_DataGridView.DataSource = binding;
                }));
            }
            else
            {
                TableData_DataGridView.DataSource = binding;
            }
        }

        private void Warehouse_UC_Load(object sender, EventArgs e)
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
