using CompuStore.Database.Models;
using CompuStore.ImportData;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public partial class BaseDetailSpecsProduct_Form : Form
    {
        #region Class
        public class ResultDetailSpecsProduct
        {
            public enum TypeReturn
            {
                NoChanged, SpecsChanged, ProductChanged, NewProduct
            }
            public TypeReturn typeReturn;
            public ModelProduct sendPayload;
            public ModelProduct receivePayload;
        }

        private class MainBindingData
        {
            public BindingList<string> lineup { get; set; }
            public BindingList<string> manufacturer { get; set; }
            public BindingList<string> country { get; set; }
            public BindingList<string> cpu { get; set; }
            public BindingList<string> iGPU { get; set; }
            public BindingList<string> gpu { get; set; }
            public BindingList<string> typeStorage { get; set; }
            public BindingList<string> storageCapacity { get; set; }
            public BindingList<string> material { get; set; }
            public BindingList<string> webcam { get; set; }
            public BindingList<string> os { get; set; }
            public BindingList<string> wifi { get; set; }
            public BindingList<string> bluetooth { get; set; }
            public BindingList<string> refreshRate { get; set; }
            public BindingList<string> sizePanel { get; set; }
            public BindingList<string> typePanel { get; set; }
            public BindingList<string> typeScreen { get; set; }
            public BindingList<string> ramCapacity { get; set; }
            public BindingList<string> typeRAM { get; set; }
            public BindingList<string> busRAM { get; set; }
            public BindingList<string> xResolution { get; set; }
            public BindingList<string> yResolution { get; set; }
            public BindingList<string> xRatioPanel { get; set; }
            public BindingList<string> yRatioPanel { get; set; }
            public BindingList<string> codeDisplay { get; set; }
        }
        #endregion

        #region Variable
        protected ModelProduct product;
        protected bool editable = true;
        protected BindingList<ModelProduct.Port> bindingPorts;
        protected ResultDetailSpecsProduct resultChanged;
        private BindingList<string> bindingCodeDisplay = null;
        #endregion

        #region Translater
        protected static readonly Dictionary<string, string> portTranslater = new Dictionary<string, string> {
            { "PortPhysic", "Chuẩn giao tiếp" },
            { "PortProtocol", "Chuẩn vật lý" },
            { "Quantity", "Số lượng" }};
        #endregion

        protected virtual void AddInitializeComponent() { }

        protected BaseDetailSpecsProduct_Form()
        {
            InitializeComponent();
            AddInitializeComponent();
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

        #region Set Editable
        protected virtual void SetEditable(bool editable)
        {
            Lineup_ComboBox.Enabled = editable;
            Manufacturer_ComboBox.Enabled = editable;
            Country_ComboBox.Enabled = editable;
            CPU_ComboBox.Enabled = editable;
            Capacity_RAM_ComboBox.Enabled = editable;
            BusRAM_ComboBox.Enabled = editable;
            TypeRAM_ComboBox.Enabled = editable;
            iGPU_ComboBox.Enabled = editable;
            GPU_ComboBox.Enabled = editable;
            Weight_TextBox.Enabled = editable;
            X_Dimension_TextBox.Enabled = editable;
            Y_Dimension_TextBox.Enabled = editable;
            Z_Dimension_TextBox.Enabled = editable;
            Material_ComboBox.Enabled = editable;
            Webcam_ComboBox.Enabled = editable;
            OS_ComboBox.Enabled = editable;
            X_Pixel_ComboBox.Enabled = editable;
            Y_Pixel_ComboBox.Enabled = editable;
            RefreshRate_ComboBox.Enabled = editable;
            SizePanel_ComboBox.Enabled = editable;
            ColorSpace_sRGB_TextBox.Enabled = editable;
            ColorSpace_AdobeRGB_TextBox.Enabled = editable;
            ColorSpace_DCIP3_TextBox.Enabled = editable;
            TypePanel_ComboBox.Enabled = editable;
            Brightness_TextBox.Enabled = editable;
            X_Ratio_ComboBox.Enabled = editable;
            Y_Ratio_ComboBox.Enabled = editable;
            TypeScreen_ComboBox.Enabled = editable;
            TouchScreen_CheckBox.Enabled = editable;
            HasCodeDisplay_CheckBox.Enabled = editable;
            TypeStorage_ComboBox.Enabled = editable;
            StorageCapacity_ComboBox.Enabled = editable;
            WifiStandard_ComboBox.Enabled = editable;
            BluetoothStandard_ComboBox.Enabled = editable;
            BatteryCapacity_TextBox.Enabled = editable;
            if (editable)
            {
                ColorPicker_Button.Click += ColorPicker_Button_Click;
            }
            else ColorPicker_Button.Click -= ColorPicker_Button_Click;
            NameColor_TextBox.Enabled = editable;
            Ports_DataGridView.ReadOnly = !editable;
        }
        #endregion

        #region Set Value if View | Edit
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

        protected virtual void SetDefaultData()
        {
            NameProductValue_Label.Text = product?.NameProduct;
            Weight_TextBox.Text = product?.Weight?.ToString();
            X_Dimension_TextBox.Text = product?.SizeProduct?[0].ToString();
            Y_Dimension_TextBox.Text = product?.SizeProduct?[1].ToString();
            Z_Dimension_TextBox.Text = product?.SizeProduct?[2].ToString();
            Brightness_TextBox.Text = product?.Brightness?.ToString();
            TouchScreen_CheckBox.Checked = product?.CanTouchPanel ?? false;
            HasCodeDisplay_CheckBox.Checked = false;
            ColorDialog.Color = product?.ColorModel?.ColorCode ?? Color.Black;
            ColorPicker_Button.FillColor = ColorDialog.Color;
            NameColor_TextBox.Text = product?.ColorModel?.ColorName;
            BatteryCapacity_TextBox.Text = product?.BatteryCapacity?.ToString();

            if (product?.SpaceColor != null)
            {
                if (product.SpaceColor.TryGetValue(ModelProduct.ENUM_SPACE_COLOR.sRGB, out double sRGB))
                {
                    ColorSpace_sRGB_TextBox.Text = sRGB.ToString();
                    ColorSpace_sRGB_TextBox.Enabled = true;
                }
                if (product.SpaceColor.TryGetValue(ModelProduct.ENUM_SPACE_COLOR.DCI_P3, out double dcip3))
                {
                    ColorSpace_DCIP3_TextBox.Text = dcip3.ToString();
                    ColorSpace_DCIP3_TextBox.Enabled = true;
                }
                if (product.SpaceColor.TryGetValue(ModelProduct.ENUM_SPACE_COLOR.AdobeRGBProfile, out double adobe))
                {
                    ColorSpace_AdobeRGB_TextBox.Text = adobe.ToString();
                    ColorSpace_AdobeRGB_TextBox.Enabled = true;
                }
            }

            for (int index = 0; index < product?.Ports?.Length; index++)
            {
                bindingPorts.Add(product.Ports[index]);
            }

            SetDefaultComboBox(Lineup_ComboBox, product?.LineUp);
            SetDefaultComboBox(Manufacturer_ComboBox, product?.Manufacturer);
            SetDefaultComboBox(Country_ComboBox, product?.Country);
            SetDefaultComboBox(CPU_ComboBox, product?.CPU);
            SetDefaultComboBox(Capacity_RAM_ComboBox, product?.InfoRAM?.CapacityRAM.ToString());
            SetDefaultComboBox(TypeRAM_ComboBox, product?.InfoRAM?.TypeRAM.ToString());
            SetDefaultComboBox(BusRAM_ComboBox, product?.InfoRAM?.BusRAM.ToString());
            SetDefaultComboBox(iGPU_ComboBox, product?.iGPU);
            SetDefaultComboBox(GPU_ComboBox, product?.GPUString);
            SetDefaultComboBox(Material_ComboBox, product?.CaseMaterial);
            SetDefaultComboBox(Webcam_ComboBox, product?.Webcam);
            SetDefaultComboBox(OS_ComboBox, product?.OS);
            SetDefaultComboBox(X_Pixel_ComboBox, product?.Resolution?[0].ToString());
            SetDefaultComboBox(Y_Pixel_ComboBox, product?.Resolution?[1].ToString());
            SetDefaultComboBox(TypePanel_ComboBox, product?.TypePanel);
            SetDefaultComboBox(RefreshRate_ComboBox, product?.RefreshRate.ToString());
            SetDefaultComboBox(SizePanel_ComboBox, product?.SizePanel.ToString());
            SetDefaultComboBox(X_Ratio_ComboBox, product?.RatioPanel?[0].ToString());
            SetDefaultComboBox(Y_Ratio_ComboBox, product?.RatioPanel?[1].ToString());
            SetDefaultComboBox(TypeScreen_ComboBox, product?.TypeScreen);
            SetDefaultComboBox(TypeStorage_ComboBox, product?.TypeStorage);
            SetDefaultComboBox(StorageCapacity_ComboBox, product?.StorageCapacity.ToString());
            SetDefaultComboBox(WifiStandard_ComboBox, product?.Wifi);
            SetDefaultComboBox(BluetoothStandard_ComboBox, product?.Bluetooth);
            SetDefaultComboBox(CodeDisplay_ComboBox, product?.IdPanel);
        }
        #endregion

        #region Loading data
        private List<string> GetDistinctValue<TModel>(IQueryable<TModel> query, Expression<Func<TModel, string>> select) where TModel : class
        {
            return query.Select(select).Where(item => item != null).Distinct().ToList();
        }

        private void AssignBinding(MainBindingData binding)
        {
            this.SuspendLayout();
            Lineup_ComboBox.DataSource = binding.lineup;
            Manufacturer_ComboBox.DataSource = binding.manufacturer;
            Country_ComboBox.DataSource = binding.country;
            CPU_ComboBox.DataSource = binding.cpu;
            iGPU_ComboBox.DataSource = binding.iGPU;
            GPU_ComboBox.DataSource = binding.gpu;
            TypeStorage_ComboBox.DataSource = binding.typeStorage;
            StorageCapacity_ComboBox.DataSource = binding.storageCapacity;
            Material_ComboBox.DataSource = binding.material;
            Webcam_ComboBox.DataSource = binding.webcam;
            OS_ComboBox.DataSource = binding.os;
            WifiStandard_ComboBox.DataSource = binding.wifi;
            BluetoothStandard_ComboBox.DataSource = binding.bluetooth;
            RefreshRate_ComboBox.DataSource = binding.refreshRate;
            SizePanel_ComboBox.DataSource = binding.sizePanel;
            TypePanel_ComboBox.DataSource = binding.typePanel;
            TypeScreen_ComboBox.DataSource = binding.typeScreen;
            Capacity_RAM_ComboBox.DataSource = binding.ramCapacity;
            TypeRAM_ComboBox.DataSource = binding.typeRAM;
            BusRAM_ComboBox.DataSource = binding.busRAM;
            X_Pixel_ComboBox.DataSource = binding.xResolution;
            Y_Pixel_ComboBox.DataSource = binding.yResolution;
            X_Ratio_ComboBox.DataSource = binding.xRatioPanel;
            Y_Ratio_ComboBox.DataSource = binding.yRatioPanel;
            CodeDisplay_ComboBox.DataSource = binding.codeDisplay;
            this.ResumeLayout(true);
        }

        private Task LoadingData()
        {
            return Task.Factory.StartNew(() =>
            {
                IQueryable<COMMON_SPECS> commonSpecsQueryable = Database.DataProvider.Instance.Database.COMMON_SPECS;
                IQueryable<LINE_UP> lineupQueryable = Database.DataProvider.Instance.Database.LINE_UP;
                IQueryable<DISPLAY_SPECS> displaySpecsQueryable = Database.DataProvider.Instance.Database.DISPLAY_SPECS;
                IQueryable<DETAIL_SPECS> detailSpecsQueryable = Database.DataProvider.Instance.Database.DETAIL_SPECS;
                IQueryable<UNIQUE_SPECS> uniqueSpecsQueryable = Database.DataProvider.Instance.Database.UNIQUE_SPECS;

                MainBindingData binding = new MainBindingData
                {
                    lineup = new BindingList<string>(GetDistinctValue(lineupQueryable, item => item.NAME)),
                    manufacturer = new BindingList<string>(GetDistinctValue(lineupQueryable, item => item.MANUFACTURER)),
                    country = new BindingList<string>(GetDistinctValue(lineupQueryable, item => item.COUNTRY)),
                    cpu = new BindingList<string>(GetDistinctValue(uniqueSpecsQueryable, item => item.CPU)),
                    iGPU = new BindingList<string>(GetDistinctValue(uniqueSpecsQueryable, item => item.IGPU)),
                    gpu = new BindingList<string>(GetDistinctValue(uniqueSpecsQueryable, item => item.GPU)),
                    typeStorage = new BindingList<string>(GetDistinctValue(uniqueSpecsQueryable, item => item.TYPE_STORAGE)),
                    storageCapacity = new BindingList<string>(GetDistinctValue(uniqueSpecsQueryable, item => item.STORAGE_CAPACITY.ToString())),
                    material = new BindingList<string>(GetDistinctValue(commonSpecsQueryable, item => item.CASE_MATERIAL)),
                    webcam = new BindingList<string>(GetDistinctValue(commonSpecsQueryable, item => item.WEBCAM)),
                    os = new BindingList<string>(GetDistinctValue(commonSpecsQueryable, item => item.OS)),
                    wifi = new BindingList<string>(GetDistinctValue(commonSpecsQueryable, item => item.WIFI)),
                    bluetooth = new BindingList<string>(GetDistinctValue(commonSpecsQueryable, item => item.BLUETOOTH)),
                    refreshRate = new BindingList<string>(GetDistinctValue(displaySpecsQueryable, item => item.REFRESH_RATE.ToString())),
                    sizePanel = new BindingList<string>(GetDistinctValue(displaySpecsQueryable, item => item.SIZE.ToString())),
                    typePanel = new BindingList<string>(GetDistinctValue(displaySpecsQueryable, item => item.PANEL)),
                    typeScreen = new BindingList<string>(GetDistinctValue(displaySpecsQueryable, item => item.SCREEN_TYPE)),
                    codeDisplay = new BindingList<string>(GetDistinctValue(displaySpecsQueryable, item => item.CODE_DISPLAY))
                };
                List<string> ram = GetDistinctValue(uniqueSpecsQueryable, item => item.RAM);
                List<string> resolution = GetDistinctValue(displaySpecsQueryable, item => item.RESOLUTION);
                List<string> ratioPanel = GetDistinctValue(displaySpecsQueryable, item => item.RATIO);

                binding.ramCapacity = new BindingList<string>(ram.Select(item =>
                {
                    string[] split = item.Split(' ');
                    return split[0].Substring(0, split[0].Length - 2);
                }).Distinct().ToList());

                binding.typeRAM = new BindingList<string>(ram.Select(item => item.Split(' ')[1]).Distinct().ToList());

                binding.busRAM = new BindingList<string>(ram.Select(item => item.Split(' ')[2]).Distinct().ToList());

                binding.xResolution = new BindingList<string>(resolution.Select(item => item.Split('x')[0]).Distinct().ToList());

                binding.yResolution = new BindingList<string>(resolution.Select(item => item.Split('x')[1]).Distinct().ToList());

                binding.xRatioPanel = new BindingList<string>(ratioPanel.Select(item => item.Split(':')[0]).Distinct().ToList());

                binding.yRatioPanel = new BindingList<string>(ratioPanel.Select(item => item.Split(':')[1]).Distinct().ToList());

                //auto or manual code display
                bindingCodeDisplay = binding.codeDisplay;

                //optional
                binding.gpu.Insert(0, string.Empty);
                binding.webcam.Insert(0, string.Empty);
                binding.codeDisplay.Insert(0, string.Empty);
                binding.bluetooth.Insert(0, string.Empty);
                binding.wifi.Insert(0, string.Empty);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        AssignBinding(binding);
                    }));
                }
                else
                {
                    AssignBinding(binding);
                }
            });
        }

        private void Ports_DataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            grid.SuspendLayout();
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (portTranslater.ContainsKey(column.Name))
                {
                    string headerText = portTranslater[column.Name];
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
        #endregion

        #region IO Handle
        public virtual ResultDetailSpecsProduct ShowDialog(IWin32Window owner, IList<ModelProduct> payload, bool editable = true)
        {
            resultChanged = new ResultDetailSpecsProduct();
            this.editable = editable;
            product = payload.First();
            base.ShowDialog();
            return resultChanged;
        }

        protected virtual void Exit_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Event
        private void ColorPicker_Button_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                ColorPicker_Button.FillColor = ColorDialog.Color;
            }
        }

        private async void DetailSpecsProduct_Form_Load(object sender, EventArgs e)
        {
            bindingPorts = new BindingList<ModelProduct.Port>();
            Ports_DataGridView.DataSource = bindingPorts;
            Edit_Button.Visible = this.editable;
            await LoadingData();
            SetDefaultData();
            SetEditable(this.editable);
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            editable = !editable;
            SetEditable(editable);
        }

        private void AddNewItemToComboBox(object sender, string value)
        {
            ComboBox control = sender as ComboBox;
            BindingList<string> binding = control?.DataSource as BindingList<string>;

            if (control != null && binding != null)
            {
                int index = binding.IndexOf(value);
                if (index == -1)
                {
                    switch (MessageBox.Show("Giá trị chưa tồn tại trên CSDL. Bạn có muốn tạo mới?", "Thông tin chưa tồn tại.", MessageBoxButtons.YesNoCancel))
                    {
                        case DialogResult.Yes:
                            binding.Add(value);
                            control.SelectedIndex = binding.IndexOf(value);
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
                    control.SelectedIndex = index;
                }
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void HasCodeDisplay_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox control = sender as CheckBox;
            if (control.Checked)
            {
                CodeDisplay_ComboBox.DataSource = null;
                CodeDisplay_ComboBox.DropDownStyle = ComboBoxStyle.Simple;
                CodeDisplay_ComboBox.AutoCompleteMode = AutoCompleteMode.None;
                CodeDisplay_ComboBox.AutoCompleteSource = AutoCompleteSource.None;
                CodeDisplay_ComboBox.Leave -= ValidationComboBox;
                CodeDisplay_ComboBox.InsertKeyPressed -= AddNewItemToComboBox;
            }
            else
            {
                CodeDisplay_ComboBox.DataSource = bindingCodeDisplay;
                CodeDisplay_ComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                CodeDisplay_ComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                CodeDisplay_ComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                CodeDisplay_ComboBox.Leave += ValidationComboBox;
                CodeDisplay_ComboBox.InsertKeyPressed += AddNewItemToComboBox;
            }
        }
        #endregion

        #region Validation
        private void ValidationComboBox(object sender, EventArgs e)
        {
            ComboBox control = sender as ComboBox;
            BindingList<string> binding = control?.DataSource as BindingList<string>;
            string currentText = control?.Text;
            if (control?.Equals(CodeDisplay_ComboBox) == true && HasCodeDisplay_CheckBox.Checked) return;
            if (control == null || binding == null || currentText == null || binding.FirstOrDefault(item => item.Equals(currentText)) == null)
            {
                control.Focus();
                MessageBox.Show("Thông tin chưa hợp lệ! Vui lòng nhập lại.", "Lỗi nhập");
            }
        }

        protected virtual void CheckChange() { }

        protected virtual List<string> ValidationDetailSpecs()
        {
            List<string> result = new List<string>();
            if (Lineup_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn dòng sản phẩm");
            if (Manufacturer_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn nhà sản xuất");
            if (Country_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn nơi sản xuất");
            if (CPU_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn CPU");
            if (Capacity_RAM_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn dung lượng RAM");
            if (BusRAM_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn BUS RAM");
            if (TypeRAM_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn loại RAM");
            if (iGPU_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn iGPU");
            if (string.IsNullOrEmpty(Weight_TextBox.Text) || !double.TryParse(Weight_TextBox.Text, out double weight))
                result.Add("Chưa nhập cân nặng");
            if (string.IsNullOrEmpty(X_Dimension_TextBox.Text) || !double.TryParse(X_Dimension_TextBox.Text, out double xSize))
                result.Add("Chưa nhập chiều dài sản phẩm");
            if (string.IsNullOrEmpty(Y_Dimension_TextBox.Text) || !double.TryParse(Y_Dimension_TextBox.Text, out double ySize))
                result.Add("Chưa nhập chiều rộng sản phẩm");
            if (string.IsNullOrEmpty(Z_Dimension_TextBox.Text) || !double.TryParse(Z_Dimension_TextBox.Text, out double zSize))
                result.Add("Chưa nhập chiều cao sản phẩm");
            if (Material_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn vật liệu máy");
            if (Webcam_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn Webcam");
            if (OS_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn hệ điều hành");
            if (X_Pixel_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn chiều ngang màn hình");
            if (Y_Pixel_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn chiều dọc màn hình");
            if (RefreshRate_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn tần số quét");
            if (SizePanel_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn kích thước màn hình");
            if (TypePanel_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn loại tấm nền");
            if (string.IsNullOrEmpty(BatteryCapacity_TextBox.Text) || !int.TryParse(Brightness_TextBox.Text, out int brightness))
                result.Add("Chưa nhập độ sáng màn hình");
            if (X_Ratio_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn tỉ lệ màn hình");
            if (Y_Ratio_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn tỉ lệ màn hình");
            if (TypeScreen_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn loại màn hình");
            if ((HasCodeDisplay_CheckBox.Checked && string.IsNullOrEmpty(CodeDisplay_ComboBox.Text)) || CodeDisplay_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn mã màn hình");
            if (TypeStorage_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn loại ổ cứng");
            if (StorageCapacity_ComboBox.SelectedIndex < 0)
                result.Add("Chưa chọn dung lượng ổ cứng");
            if (string.IsNullOrEmpty(BatteryCapacity_TextBox.Text) || !double.TryParse(BatteryCapacity_TextBox.Text, out double battery))
                result.Add("Chưa nhập dung lượng pin");
            return result;
        }
        #endregion
    }
}
