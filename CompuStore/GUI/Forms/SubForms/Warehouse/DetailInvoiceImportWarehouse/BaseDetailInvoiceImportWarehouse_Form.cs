using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.GUI;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CompuStore.GUI.Forms.SubForms.Warehouse.BaseDetailSpecsProduct_Form;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public partial class BaseDetailInvoiceImportWarehouse_Form : Form
    {
        #region Interface
        protected class ComboBoxBinding
        {
            public int ID { get; set; }
            public string Value { get; set; }
        }

        public class ResultDetailInvoiceImportWarehouse
        {
            public IList<ModelProduct> NoChanged;
            public IList<ModelProduct> NewProduct;
            public IDictionary<ModelProduct, ModelProduct> SpecsChanged;
            public IList<ModelProduct> Remove;

            public void ResetField(bool access = false)
            {
                if (access)
                {
                    NoChanged = null;
                    NewProduct = null;
                    SpecsChanged = null;
                    Remove = null;
                }
            }
        }
        #endregion

        #region Variable
        protected BindingList<ModelProduct> bindingTable = null;
        protected BindingList<ModelProduct> productList = null;
        protected List<ModelProduct> initProduct;
        BindingList<ComboBoxBinding> bindingNameProduct = null;
        BindingList<ComboBoxBinding> bindingLineUp = null;
        BindingList<ComboBoxBinding> bindingManufacturer = null;
        protected ResultDetailInvoiceImportWarehouse resultChanged;
        #endregion

        #region Translater
        protected static readonly Dictionary<string, string> translater = new Dictionary<string, string> {
            { "Serial", "Serial máy" },
            { "Price", "Giá bán" },
            { "LineUp", "Dòng sản phẩm" },
            { "Country", "Nơi sản xuất" },
            { "Manufacturer", "Nhà sản xuất" },
            { "SizePanel", "Kích thước màn hình|Đơn vị: inch" },
            { "Brightness", "Độ sáng|Đơn vị: nit" },
            { "TypePanel", "Tấm nền" },
            { "SpaceColorString", "Độ phủ màu|Độ chính xác màu hiện thị trên màn hình so với khi in ấn" },
            { "RefreshRate", "Tốc độ làm tươi|Đơn vị: Hz" },
            { "CanTouchPanel", "Cảm ứng" },
            { "RatioPanelString", "Tỉ lệ màn hình" },
            { "CPU", "CPU" },
            { "GPU", "GPU" },
            { "RAMString", "RAM" },
            { "iGPU", "iGPU" },
            { "TypeStorage", "Chuẩn ổ cứng" },
            { "StorageCapacity", "Dung lượng ổ cứng|Đơn vị: GB" },
            { "GPUString", "Card đồ hoại rời" },
            { "Weight", "Khối lượng|Đơn vị: Kg" },
            { "NameProduct", "Tên sản phẩm" },
            { "ReleaseDate", "Năm ra mắt|Năm hãng ra mắt đến công chúng" },
            { "CaseMaterial", "Vật liệu vỏ" },
            { "PortString", "Cổng kết nối" },
            { "Webcam", "Webcam" },
            { "SizeProductString", "Kích thước máy|Đơn vị: mm" },
            { "OS", "Hệ điều hành" },
            { "Wifi", "Chuẩn Wifi" },
            { "Bluetooth", "Chuẩn Bluetooth" },
            { "TypeScreen", "Loại màn hình" },
            { "BatteryCapacity", "Dung lượng pin|Đơn vị: Wh" },
            { "ColorCode", "Màu sắc" }};
        #endregion

        public BaseDetailInvoiceImportWarehouse_Form()
        {
            InitializeComponent();
            AddProductByExcel_Button.Click += AddProductByExcel_Button_Click;
            AddProduct_Button.Click += AddProduct_Button_Click;
            DeleteProduct_Button.Click += DeleteProduct_Button_Click;
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

        #region Event
        private void DeleteProduct_Button_Click(object sender, EventArgs e)
        {
            BindingList<ModelProduct> bindingTable = TableData_DataGridView.DataSource as BindingList<ModelProduct>;
            if (TableData_DataGridView.SelectedRows.Count > 0)
            {
                int currentIndex = TableData_DataGridView.SelectedRows[0].Index;
                ModelProduct target = bindingTable[currentIndex];
                if (MessageBox.Show(
                        string.Format("Bạn chắc chắn sẽ xóa:\nSản phẩm: {0}\nSerial: {1}",
                        target.NameProduct,
                        target.Serial),
                    "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    productList.Remove(target);
                    Custom_Load(null, null);
                }
            }
        }

        private void AddProductByExcel_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tab-seperator values | *.tsv";

            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.CheckFileExists)
            {
                ModelProduct[] products = ModelProduct.GetTSV(openFileDialog.FileName);
                if (products.Select(item => item.NameProduct).Distinct().Count() == 1 && (productList.Count() == 0 || productList.First().NameProduct == products[0].NameProduct))
                {
                    foreach (ModelProduct product in products)
                    {
                        productList.Add(product);
                    }
                    Custom_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Chỉ được nhập 1 sản phâm duy nhất");
                }
            }
        }

        private void AddProduct_Button_Click(object sender, EventArgs e)
        {
            List<string> checkValidation = ValidationDetailInvoiceImportWarehouse();
            if (checkValidation.Count > 0)
            {
                MessageBox.Show(string.Join("\n", checkValidation) + "\n\n" + "VUI LÒNG NHẬP ĐẦY ĐỦ TRƯỚC KHI THÊM SẢN PHẨM MỚI", "Thiếu thông tin");
            }
            else
            {
                BaseDetailSpecsProduct_Form importManual = new ImportDetailSpecsProduct_Form();
                List<ModelProduct> temp = new List<ModelProduct>();
                temp.Add(new ModelProduct
                {
                    //ModelProductGroupBy (AddInvoiceImportWarehouse)
                    NameProduct = productList?.FirstOrDefault()?.NameProduct ?? (NameProduct_ComboBox.SelectedItem as ComboBoxBinding)?.Value.ToString(),
                    Manufacturer = productList?.FirstOrDefault()?.Manufacturer ?? (Manufacturer_ComboBox.SelectedItem as ComboBoxBinding)?.Value.ToString(),
                    LineUp = productList?.FirstOrDefault()?.LineUp ?? (LineUp_ComboBox.SelectedItem as ComboBoxBinding)?.Value.ToString(),
                    Country = productList?.FirstOrDefault()?.Country,
                    ReleaseDate = productList?.FirstOrDefault()?.ReleaseDate ?? DateTime.ParseExact(ReleaseDate_DateTimePicker.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CaseMaterial = productList?.FirstOrDefault()?.CaseMaterial,
                    PortString = productList?.FirstOrDefault()?.PortString,
                    Webcam = productList?.FirstOrDefault()?.Webcam,
                    SizeProductString = productList?.FirstOrDefault()?.SizeProductString,
                    /*OS = productList?.FirstOrDefault()?.OS*/
                    Wifi = productList?.FirstOrDefault()?.Wifi,
                    Bluetooth = productList?.FirstOrDefault()?.Bluetooth,
                });
                BaseDetailSpecsProduct_Form.ResultDetailSpecsProduct afterEdit = importManual.ShowDialog(this, temp);
                Thread.Sleep(1000);
                bool reload = true;
                switch (afterEdit.typeReturn)
                {
                    case BaseDetailSpecsProduct_Form.ResultDetailSpecsProduct.TypeReturn.NewProduct:
                        productList.Add(afterEdit.receivePayload);
                        break;
                    default:
                        reload = false;
                        break;
                }
                if (reload)
                {
                    Custom_Load(null, null);
                }
            }
        }

        private void NameProduct_ComboBox_Leave(object sender, EventArgs e)
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

        private void NameProduct_ComboBox_InsertKeyPressed(object sender, string value)
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

        #region Loading data
        private Task LoadingData(IProgress<bool> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                IQueryable<LINE_UP> lineupQueryable = Database.DataProvider.Instance.Database.LINE_UP;
                foreach (LINE_UP lineup in lineupQueryable)
                {
                    if (bindingLineUp != null)
                    {
                        bindingLineUp.Add(new ComboBoxBinding { ID = lineup.ID, Value = lineup.NAME });
                        bindingManufacturer.Add(new ComboBoxBinding { ID = lineup.ID, Value = lineup.MANUFACTURER });
                    }
                }

                IQueryable<COMMON_SPECS> commonSpecsQueryable = Database.DataProvider.Instance.Database.COMMON_SPECS;
                foreach (COMMON_SPECS commonSpecs in commonSpecsQueryable)
                {
                    if (bindingNameProduct != null)
                    {
                        bindingNameProduct.Add(new ComboBoxBinding { ID = commonSpecs.ID, Value = commonSpecs.NAME });
                    }
                }

                progress.Report(true);
            });
        }

        private void DetailInvoiceImportWarehouse_Form_Load(object sender, EventArgs e)
        {
            bindingTable = new BindingList<ModelProduct>();
            bindingNameProduct = new BindingList<ComboBoxBinding>();
            bindingLineUp = new BindingList<ComboBoxBinding>();
            bindingManufacturer = new BindingList<ComboBoxBinding>();
            TableData_DataGridView.DataSource = bindingTable;
            Progress<bool> progress = new Progress<bool>();
            Waiting_Form waiting = new Waiting_Form();
            waiting.FormClosing += (owner, ev) =>
            {
                LineUp_ComboBox.DataSource = bindingLineUp;
                LineUp_ComboBox.ValueMember = "ID";
                LineUp_ComboBox.DisplayMember = "Value";

                NameProduct_ComboBox.DataSource = bindingNameProduct;
                NameProduct_ComboBox.ValueMember = "ID";
                NameProduct_ComboBox.DisplayMember = "Value";

                Manufacturer_ComboBox.DataSource = bindingManufacturer;
                Manufacturer_ComboBox.ValueMember = "ID";
                Manufacturer_ComboBox.DisplayMember = "Value";
            };

            Task runLoading = LoadingData(progress);

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
            grid.ResumeLayout(false);
            grid.PerformLayout();
        }

        protected virtual void Custom_Load(object sender, EventArgs e) { }

        private void TableData_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowCount > 0)
            {
                DataGridView grid = sender as DataGridView;

                DataGridViewColumn colorModelCol = grid.Columns["ColorModel"];
                DataGridViewColumn colorCodeCol = grid.Columns["ColorCode"];
                DataGridViewColumn colorNameCol = grid.Columns["ColorName"];
                DataGridViewCell toolTipColor = grid.Rows[e.RowIndex].Cells[colorNameCol.Index];
                DataGridViewCell color = grid.Rows[e.RowIndex].Cells[colorModelCol.Index];
                DataGridViewCell cell = grid.Rows[e.RowIndex].Cells[colorCodeCol.Index];
                DataGridViewCellStyle style = cell.Style;
                cell.ToolTipText = toolTipColor.Value?.ToString();
                style.ForeColor = style.SelectionForeColor = style.BackColor = style.SelectionBackColor = (color.Value as ImportData.ModelProduct.Color).ColorCode;
            }
        }
        #endregion

        #region Validation
        protected virtual void CheckChange()
        {
            if (initProduct == null)
            {
                resultChanged.NoChanged = null;
                resultChanged.SpecsChanged = null;
                resultChanged.Remove = null;
                resultChanged.NewProduct = productList.ToList();
            }
            else
            {
                resultChanged.NoChanged = initProduct.Where(item => productList.FirstOrDefault(item2 => item2.CompareProduct(item)) != null).ToList();
                resultChanged.NewProduct = productList.Where(item => item.TypeProduct == ModelProduct.TypeModel.New && initProduct.FirstOrDefault(item2 => item2.Serial == item.Serial) == null).ToList();
                resultChanged.Remove = initProduct.Where(item => productList.FirstOrDefault(item2 => item2.TypeProduct == ModelProduct.TypeModel.New ? item2.Serial == item.Serial : item2.ID == item.ID) == null).ToList();
                resultChanged.SpecsChanged = new Dictionary<ModelProduct, ModelProduct>();
                foreach (ModelProduct product in initProduct)
                {
                    ModelProduct after = product.TypeProduct == ModelProduct.TypeModel.Exist ? productList.FirstOrDefault(item => item.ID == product.ID && item.Serial != product.Serial) : productList.FirstOrDefault(item => item.Serial == product.Serial);
                    if (after != null && (product.TypeProduct == ModelProduct.TypeModel.Exist || !product.StrictCompareSpecs(after)))
                    {
                        resultChanged.SpecsChanged.Add(product, after);
                    }
                }
            }
        }

        protected virtual List<string> ValidationDetailInvoiceImportWarehouse()
        {
            List<string> result = new List<string>();
            if (NameProduct_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn tên sản phẩm");
            if (LineUp_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn dòng sản phẩm");
            if (Manufacturer_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn nhà sản xuất");
            if (ReleaseDate_DateTimePicker.Value.CompareTo(ReleaseDate_DateTimePicker.MinDate) == 0)
                result.Add("Chưa chọn ngày ra mắt");
            return result;
        }

        private void ProductList_ListChanged(object sender, ListChangedEventArgs e)
        {
            BindingList<ModelProduct> owner = sender as BindingList<ModelProduct>;
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    ModelProduct added = owner[e.NewIndex];
                    if (owner.Where(item => item.Serial == added.Serial)?.Count() > 1)
                    {
                        if (MessageBox.Show("Bạn muốn sửa chửa(Yes) hay xóa sản phẩm bị trùng?", "Trùng Serial máy", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            BaseDetailSpecsProduct_Form detailSpecs = new ImportDetailSpecsProduct_Form();
                            BaseDetailSpecsProduct_Form.ResultDetailSpecsProduct afterEdit = detailSpecs.ShowDialog(this, added.ToList());
                            switch (afterEdit.typeReturn)
                            {
                                case BaseDetailSpecsProduct_Form.ResultDetailSpecsProduct.TypeReturn.NewProduct:
                                    owner.Add(afterEdit.receivePayload);
                                    break;
                                case BaseDetailSpecsProduct_Form.ResultDetailSpecsProduct.TypeReturn.ProductChanged:
                                    int index = owner.IndexOf(afterEdit.sendPayload);
                                    owner.Remove(afterEdit.sendPayload);
                                    owner.Insert(index, afterEdit.receivePayload);
                                    break;
                                case BaseDetailSpecsProduct_Form.ResultDetailSpecsProduct.TypeReturn.SpecsChanged:
                                    afterEdit.sendPayload.OverrideData(afterEdit.receivePayload);
                                    break;
                            }
                        }
                        else
                        {
                            owner.Remove(added);
                        }
                    }
                    break;
                case ListChangedType.ItemChanged:
                    break;
                case ListChangedType.ItemDeleted:
                    break;
            }
        }
        #endregion

        #region IO Handle
        private void Exit_Clicked(object sender, EventArgs e)
        {
            List<string> checkValidation = ValidationDetailInvoiceImportWarehouse();
            if (checkValidation?.Count > 0)
            {
                if (MessageBox.Show(string.Join("\n", checkValidation) + "\n\n" + "Quay trở lại(Yes) hay hủy thay đổi(No)?", "Thiếu thông tin", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                CheckChange();
                this.Close();
            }
        }

        public virtual ResultDetailInvoiceImportWarehouse ShowDialog(IWin32Window owner, IMPORT_WAREHOUSE importWarehouse, COMMON_SPECS commonSpecs)
        {
            resultChanged = new ResultDetailInvoiceImportWarehouse();
            productList = new BindingList<ModelProduct>();
            productList.ListChanged += ProductList_ListChanged;
            base.ShowDialog(owner);
            return resultChanged;
        }

        public virtual ResultDetailInvoiceImportWarehouse ShowDialog(IWin32Window owner, List<ModelProduct> products)
        {
            resultChanged = new ResultDetailInvoiceImportWarehouse();
            productList = new BindingList<ModelProduct>();
            if (products != null)
            {
                initProduct = new List<ModelProduct>();
                initProduct.AddRange(products);
                foreach(ModelProduct product in products)
                {
                    productList.Add(product.Clone());
                }
            }
            productList.ListChanged += ProductList_ListChanged;
            base.ShowDialog(owner);
            return resultChanged;
        }
        #endregion
    }
}
