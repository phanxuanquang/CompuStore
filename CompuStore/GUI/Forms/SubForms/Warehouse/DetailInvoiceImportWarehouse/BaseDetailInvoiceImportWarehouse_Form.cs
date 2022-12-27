using CompuStore.Control;
using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.GUI;
using CompuStore.GUI.Forms.SubForms.Warehouse.DetailSpecsProduct;
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
        private Dictionary<string, System.Windows.Forms.Control> listFilter = null;
        #endregion

        #region Translater
        protected static readonly IDictionary<string, (string, DataGridViewContentAlignment)> translater = new Dictionary<string, (string, DataGridViewContentAlignment)> {
            { "Serial", ("Serial máy", DataGridViewContentAlignment.MiddleCenter) },
            { "Price", ("Giá bán",DataGridViewContentAlignment.MiddleCenter) },
            { "Brightness", ("Độ sáng|Đơn vị: nit",DataGridViewContentAlignment.MiddleCenter) },
            { "TypePanel", ("Tấm nền",DataGridViewContentAlignment.MiddleCenter) },
            { "SpaceColorString", ("Độ phủ màu|Độ chính xác màu hiện thị trên màn hình so với khi in ấn",DataGridViewContentAlignment.MiddleLeft) },
            { "RefreshRate", ("Tốc độ làm tươi|Đơn vị: Hz",DataGridViewContentAlignment.MiddleCenter) },
            { "CanTouchPanel", ("Cảm ứng",DataGridViewContentAlignment.MiddleCenter) },
            { "CPU", ("CPU",DataGridViewContentAlignment.MiddleCenter) },
            { "GPU", ("GPU",DataGridViewContentAlignment.MiddleCenter) },
            { "RAMString", ("RAM",DataGridViewContentAlignment.MiddleCenter) },
            { "iGPU", ("iGPU",DataGridViewContentAlignment.MiddleCenter) },
            { "TypeStorage", ("Chuẩn ổ cứng",DataGridViewContentAlignment.MiddleCenter) },
            { "StorageCapacity", ("Dung lượng ổ cứng|Đơn vị: GB",DataGridViewContentAlignment.MiddleCenter) },
            { "GPUString", ("Card đồ hoại rời",DataGridViewContentAlignment.MiddleCenter) },
            { "Weight", ("Khối lượng|Đơn vị: Kg",DataGridViewContentAlignment.MiddleCenter) },
            { "TypeScreen", ("Loại màn hình",DataGridViewContentAlignment.MiddleLeft) },
            { "BatteryCapacity", ("Dung lượng pin|Đơn vị: Wh",DataGridViewContentAlignment.MiddleCenter) },
            { "ColorCode", ("Màu sắc" ,DataGridViewContentAlignment.MiddleCenter)}};
        #endregion

        public BaseDetailInvoiceImportWarehouse_Form()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            if (DeviceDpi > 96)
            {
                TableData_DataGridView.ColumnHeadersHeight = 48;
                TableData_DataGridView.RowTemplate.Height = 48;
            }
            listFilter = new Dictionary<string, System.Windows.Forms.Control>();
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

        private void ComboBox_ChangeSelectedBackgroundColor(object sender, EventArgs e)
        {
            ComboBox control = sender as ComboBox;
            ComboBoxBinding item = control.SelectedItem as ComboBoxBinding;
            if (item.ID != 0)
            {
                control.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32("0xFF" + item.Value.Substring(1), 16));
                control.ForeColor = control.BackColor;
            }
            else
            {
                control.BackColor = Color.WhiteSmoke;
                control.ForeColor = Color.Black;
            }
        }

        private void Control_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox control = sender as ComboBox;

            int index = e.Index >= 0 ? e.Index : 0;
            ComboBoxBinding item = control.Items[index] as ComboBoxBinding;

            Brush brush = null;
            e.DrawBackground();
            brush = item.ID == 0 ? Brushes.WhiteSmoke : new SolidBrush(System.Drawing.Color.FromArgb(Convert.ToInt32("0xFF" + item.Value.Substring(1), 16)));
            e.Graphics.FillRectangle(brush, e.Bounds);
            if (item.ID == 0)
            {
                brush = Brushes.Black;
                e.Graphics.DrawString(item.Value, e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            }

            e.DrawFocusRectangle();
        }

        private void Control_SelectedValueChanged(object sender, EventArgs e)
        {
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[TableData_DataGridView.DataSource];
            currencyManager1.SuspendBinding();
            Dictionary<DataGridViewRow, bool> passedFilter = new Dictionary<DataGridViewRow, bool>();

            foreach (DataGridViewRow row in TableData_DataGridView.Rows)
            {
                if (!passedFilter.ContainsKey(row))
                {
                    passedFilter.Add(row, true);
                }
            }

            foreach (KeyValuePair<string, System.Windows.Forms.Control> key in listFilter)
            {
                ComboBox control = key.Value as ComboBox;
                BindingList<ComboBoxBinding> binding = control?.DataSource as BindingList<ComboBoxBinding>;
                ComboBoxBinding selectedItem = control?.SelectedItem as ComboBoxBinding;

                if (control != null && binding != null && selectedItem != null && selectedItem.ID != 0)
                {
                    foreach (DataGridViewRow row in TableData_DataGridView.Rows)
                    {
                        if (passedFilter[row])
                        {
                            ModelProduct product = row.DataBoundItem as ModelProduct;
                            if (product.GetType().GetProperty(key.Key).GetValue(product, null)?.ToString() != selectedItem.Value)
                            {
                                passedFilter[row] = false;
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<DataGridViewRow, bool> key in passedFilter)
            {
                key.Key.Visible = key.Value;
            }

            currencyManager1.ResumeBinding();
        }

        private void ResetFilter_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, System.Windows.Forms.Control> key in listFilter)
            {
                ComboBox control = key.Value as ComboBox;
                control.SelectedValue = 0;
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

                this.Focus();
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
                    (string, DataGridViewContentAlignment) keyValue = translater[column.Name];
                    string[] split = keyValue.Item1.Split('|');
                    column.HeaderText = split[0];
                    column.CellTemplate.Style.Alignment=keyValue.Item2;
                    if (split.Length > 1)
                    {
                        column.ToolTipText = split[1];
                    }
                    if (!listFilter.ContainsKey(column.Name))
                    {
                        ComboBoxCustom control = new ComboBoxCustom();
                        control.Size = new Size(200, 50);
                        BindingList<ComboBoxBinding> binding = new BindingList<ComboBoxBinding>();
                        binding.Add(new ComboBoxBinding { ID = 0, Value = string.Format("Lọc: {0}", split[0]) });
                        control.Width = TextRenderer.MeasureText(binding.First().Value, control.Font).Width + control.Height * 2;
                        control.DropDownWidth = control.Width;
                        control.DataSource = binding;
                        control.ValueMember = "ID";
                        control.DisplayMember = "Value";
                        control.SelectedValueChanged += Control_SelectedValueChanged;
                        if (column.Name == "ColorCode")
                        {
                            control.DrawMode = DrawMode.OwnerDrawVariable;
                            control.DrawItem += Control_DrawItem;
                            control.SelectedIndexChanged += ComboBox_ChangeSelectedBackgroundColor;
                        }
                        listFilter.Add(column.Name, control);
                        Filter_FlowLayoutPanel.SuspendLayout();
                        Filter_FlowLayoutPanel.Controls.Add(control);
                        Filter_FlowLayoutPanel.ResumeLayout(false);
                        Filter_FlowLayoutPanel.PerformLayout();
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

                ModelProduct added = grid.Rows[e.RowIndex].DataBoundItem as ModelProduct;

                PropertyInfo[] property = added.GetType().GetProperties();
                for (int index = 0; index < property.Length; index++)
                {
                    if (listFilter.TryGetValue(property[index].Name, out System.Windows.Forms.Control control))
                    {
                        ComboBox combo = control as ComboBox;
                        BindingList<ComboBoxBinding> binding = combo.DataSource as BindingList<ComboBoxBinding>;
                        string value = property[index].GetValue(added, null)?.ToString();
                        if (!string.IsNullOrEmpty(value) && binding.FirstOrDefault(item => item.Value == value) == null)
                        {
                            binding.Add(new ComboBoxBinding { ID = binding.Count, Value = value });
                            int width = TextRenderer.MeasureText(value, combo.Font).Width;
                            if (combo.Width < width)
                            {
                                combo.Width = width + combo.Height * 2;
                                combo.DropDownWidth = combo.Width;
                            }
                        }
                    }
                }
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
