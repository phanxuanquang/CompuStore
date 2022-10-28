using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.GUI;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public partial class BaseInvoiceImportWarehouse_Form : Form
    {
        #region Interface
        protected interface ICommonSpecsGroup<TModel> where TModel : class
        {
            double maxTotal { get;}
            double minTotal { get;}
            TModel Represent { get; }
            IList<TModel> detailSpecs { get; set; }
        }

        protected interface ICommonSpecsCustom
        {
            int ID { get; set; }

            string NameID { get; set; }

            string NameCommonSpecs { get; set; }

            string LineUp { get; set; }

            string Manufacturer { get; set; }

            DateTime? ReleaseDate { get; set; }

            int Quantity { get; set; }

            string RangeTotal { get; set; }
        }

        protected class DistributorCustom
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

        protected class StoreCustom
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
        #endregion

        private static readonly Dictionary<string, string> translater = new Dictionary<string, string> {
            { "NameCommonSpecs", "Tên sản phẩm" },
            { "LineUp", "Dòng sản phẩm" },
            { "Manufacturer", "Nhà sản xuất" },
            { "ReleaseDate", "Năm ra mắt" },
            { "Quantity", "Số lượng|Số lượng sản phẩm nhập" },
            { "RangeTotal", "Giá tiền|Khoảng giá từ cấu hình thấp đến cao nhất" }};
        BindingList<DistributorCustom> bindingDistributor = null;
        BindingList<StoreCustom> bindingStore = null;

        public BaseInvoiceImportWarehouse_Form()
        {
            InitializeComponent();
            TableData_DataGridView.DataSource = typeof(ICommonSpecsCustom);
            Load += BaseInvoiceImportWarehouse_Form_Load;
        }

        #region Loading data
        private Task LoadingData(IProgress<bool> progress)
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

                progress.Report(true);
            });
        }

        private void BaseInvoiceImportWarehouse_Form_Load(object sender, EventArgs e)
        {
            bindingStore = new BindingList<StoreCustom>();
            bindingDistributor = new BindingList<DistributorCustom>();

            Progress<bool> progress = new Progress<bool>();
            Waiting_Form waiting = new Waiting_Form();
            Task runLoading = LoadingData(progress);

            waiting.FormClosed += (owner, ev) =>
            {
                Distributor_Combobox.DataSource = bindingDistributor;
                Distributor_Combobox.ValueMember = "ID";
                Distributor_Combobox.DisplayMember = "Name";

                ImportToStore_Combobox.DataSource = bindingStore;
                ImportToStore_Combobox.ValueMember = "ID";
                ImportToStore_Combobox.DisplayMember = "Name";

                StaffImport_Value.Text = string.Format("{0} | {1}", LoginServices.Instance.CurrentStaff.INFOR.NAME, LoginServices.Instance.CurrentStaff.NAME_ID);
            };

            runLoading.GetAwaiter().OnCompleted(() => waiting.Close());

            progress.ProgressChanged += (owner, value) =>
            {
                if (value && !waiting.IsDisposed && waiting.shown)
                {
                    waiting.Close();
                }
            };

            waiting.ShowDialog(this);
        }

        private void TableData_DataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            grid.SuspendLayout();
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (translater.ContainsKey(column.Name))
                {
                    if (column.Name == "ReleaseDate")
                    {
                        column.DefaultCellStyle.Format = "yyyy";
                    }
                    string headerText = translater[column.Name];
                    string[] split = headerText.Split('|');
                    column.HeaderText = split[0];
                    if (split.Length > 1)
                    {
                        column.ToolTipText = split[1];
                    }
                }
                else
                {
                    column.Visible = false;
                }
            }
            grid.ResumeLayout(true);
        }
        #endregion

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
