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
            double? maxTotal { get;}
            double? minTotal { get;}
            TModel Represent { get; }
            IList<TModel> detailSpecs { get; set; }
        }

        protected interface ICommonSpecsCustom
        {
            int? ID { get; set; }

            string NameID { get; set; }

            string NameCommonSpecs { get; set; }

            string LineUp { get; set; }

            string Manufacturer { get; set; }

            DateTime? ReleaseDate { get; set; }

            int? Quantity { get; set; }

            string RangeTotal { get; set; }
        }

        private class ComboBoxBinding
        {
            public int ID { get; set; }
            public string Value { get; set; }
        }
        protected class ImportWarehouseCustom
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
        #endregion

        #region Variable
        private BindingList<ComboBoxBinding> bindingDistributor = null;
        private BindingList<ComboBoxBinding> bindingStore = null;
        #endregion

        #region Translater
        private static readonly Dictionary<string, string> translater = new Dictionary<string, string> {
            { "NameCommonSpecs", "Tên sản phẩm" },
            { "LineUp", "Dòng sản phẩm" },
            { "Manufacturer", "Nhà sản xuất" },
            { "ReleaseDate", "Năm ra mắt" },
            { "Quantity", "Số lượng|Số lượng sản phẩm nhập" },
            { "RangeTotal", "Giá tiền|Khoảng giá từ cấu hình thấp đến cao nhất" }};
        #endregion

        #region Set default if View | Edit
        private void SetDefaultComboBox(ComboBox control, string value)
        {
            if (control != null)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    BindingList<string> binding = control.DataSource as BindingList<string>;
                    if (binding != null)
                    {
                        if (!binding.Contains(value))
                            binding.Add(value);
                    }
                    else
                    {
                        binding = new BindingList<string>();
                        binding.Add(value);
                        control.DataSource = binding;
                    }
                    control.SelectedIndex = binding.IndexOf(value);
                }
                else
                {
                    control.SelectedIndex = -1;
                }
            }
        }
        #endregion

        protected BaseInvoiceImportWarehouse_Form()
        {
            InitializeComponent();
            if (DeviceDpi > 96)
            {
                TableData_DataGridView.ColumnHeadersHeight = 48;
                TableData_DataGridView.RowTemplate.Height = 48;
            }
            TableData_DataGridView.DataSource = typeof(ICommonSpecsCustom);
            Load += BaseInvoiceImportWarehouse_Form_Load;
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
        private Task LoadingData(IProgress<bool> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                IQueryable<DISTRIBUTOR> distributorQueryable = Database.DataProvider.Instance.Database.DISTRIBUTORs;
                foreach (DISTRIBUTOR distributor in distributorQueryable)
                {
                    if (bindingDistributor != null)
                    {
                        bindingDistributor.Add(new ComboBoxBinding { ID = distributor.ID, Value = distributor.NAME });
                    }
                }

                IQueryable<STORE> storeQueryable = Database.DataProvider.Instance.Database.STOREs;
                foreach (STORE store in storeQueryable)
                {
                    if (bindingStore != null)
                    {
                        bindingStore.Add(new ComboBoxBinding { ID = store.ID, Value = store.NAME });
                    }
                }

                progress.Report(true);
            });
        }

        private void BaseInvoiceImportWarehouse_Form_Load(object sender, EventArgs e)
        {
            bindingStore = new BindingList<ComboBoxBinding>();
            bindingDistributor = new BindingList<ComboBoxBinding>();

            Progress<bool> progress = new Progress<bool>();
            Waiting_Form waiting = new Waiting_Form();
            Task runLoading = LoadingData(progress);

            waiting.FormClosed += (owner, ev) =>
            {
                Distributor_ComboBox.DataSource = bindingDistributor;
                Distributor_ComboBox.ValueMember = "ID";
                Distributor_ComboBox.DisplayMember = "Value";
                SetDefaultComboBox(Distributor_ComboBox, null);

                ImportToStore_ComboBox.DataSource = bindingStore;
                ImportToStore_ComboBox.ValueMember = "ID";
                ImportToStore_ComboBox.DisplayMember = "Value";
                SetDefaultComboBox(ImportToStore_ComboBox, null);

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

        #region Event
        private void Distributor_ComboBox_Leave(object sender, EventArgs e)
        {
            ComboBox control = sender as ComboBox;
            BindingList<ComboBoxBinding> binding = control?.DataSource as BindingList<ComboBoxBinding>;
            string currentText = control?.Text;
            if (control == null || binding == null || currentText == null || binding.FirstOrDefault(item => item.Value.Equals(currentText)) == null)
            {
                control.Focus();
                MessageBox.Show("Thông tin chưa hợp lệ! Vui lòng nhập lại.", "Lỗi nhập");
            }
        }

        private void Distributor_ComboBox_InsertKeyPressed(object sender, string value)
        {
            ComboBox control = sender as ComboBox;
            BindingList<ComboBoxBinding> binding = control?.DataSource as BindingList<ComboBoxBinding>;

            if (control != null && binding != null)
            {
                ComboBoxBinding find = binding.FirstOrDefault(item => item.Value == value);
                if (find == null)
                {
                    switch (MessageBox.Show("Giá trị chưa tồn tại trên CSDL. Bạn có muốn tạo mới?", "Thông tin chưa tồn tại.", MessageBoxButtons.YesNoCancel))
                    {
                        case DialogResult.Yes:
                            ComboBoxBinding newItem = new ComboBoxBinding { ID = binding.Count * -1, Value = value };
                            binding.Add(newItem);
                            control.SelectedIndex = binding.IndexOf(newItem);
                            break;
                        case DialogResult.No:
                            control.Text = string.Empty;
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
                else
                {
                    control.SelectedIndex = binding.IndexOf(find);
                }
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }
        #endregion

        #region Validation
        protected virtual List<string> ValidationInvoiceImportWarehouse()
        {
            List<string> result = new List<string>();
            if (Distributor_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn nhà cung cấp");
            if (ImportToStore_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn nhập vào cửa hàng");
            return result;
        }

        public virtual void ShowDialog(IWin32Window owner, IMPORT_WAREHOUSE importWarehouse, bool edit)
        {
            if ((edit && this is AddInvoiceImportWarehouse_Form) || !edit)
                base.ShowDialog();
            else
                throw new InvalidOperationException();
        }
        #endregion

        #region IO Handle
        protected virtual void Exit_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
