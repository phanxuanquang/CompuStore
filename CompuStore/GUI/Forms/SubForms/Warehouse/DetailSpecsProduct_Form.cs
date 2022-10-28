using CompuStore.Database.Models;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public partial class DetailSpecsProduct_Form : Form
    {
        private List<ModelProduct> products;
        private bool editable = true;

        public DetailSpecsProduct_Form()
        {
            InitializeComponent();
        }

        #region Set Editable
        private void SetEditable(bool editable)
        {
            Serials_TextBox.Enabled = editable;
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
            CodeDisplay_TextBox.Enabled = editable;
            HasCodeDisplay_CheckBox.Enabled = editable;
            TypeStorage_ComboBox.Enabled = editable;
            StorageCapacity_ComboBox.Enabled = editable;
            WifiStandard_ComboBox.Enabled = editable;
            BluetoothStandard_ComboBox.Enabled = editable;
            if (editable)
            {
                ColorPicker_Button.Click += ColorPicker_Button_Click;
            }
            else ColorPicker_Button.Click -= ColorPicker_Button_Click;
            NameColor_TextBox.Enabled = editable;
            Ports_DataGridView.ReadOnly = !editable;
            Price_TextBox.Enabled = editable;
        }
        #endregion

        #region Set Value if View | Edit
        private void SetDefaultComboBox(ComboBox control, string value)
        {
            if (control != null && !string.IsNullOrEmpty(value))
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
                control.SelectedIndex = binding.Count - 1;
            }
        }

        private void SetDefaultData()
        {
            NameProductValue_Label.Text = products.First().NameProduct;
            string serials = "";
            for (int index = 0; index < products.Count; index++)
            {
                serials += products[index].Serial + '\n';
            }
            Serials_TextBox.Text = serials;
            SetDefaultComboBox(Lineup_ComboBox, products.First().LineUp);
            Manufacturer_ComboBox.DataSource = new string[] { products.First().Manufacturer };
            Country_ComboBox.DataSource = new string[] { products.First().Country };
            CPU_ComboBox.DataSource = new string[] { products.First().CPU };
            string[] infoRAM = products.First().RAMString.Split(' ');
            Capacity_RAM_ComboBox.DataSource = new string[] { infoRAM.Length == 3 ? infoRAM[0]:"" };
            TypeRAM_ComboBox.DataSource = new string[] { infoRAM.Length == 3 ? infoRAM[1] : "" };
            BusRAM_ComboBox.DataSource = new string[] { infoRAM.Length == 3 ? infoRAM[2] : "" };
            iGPU_ComboBox.DataSource = products.Select(x => x.iGPU).Distinct().ToList();
            GPU_ComboBox.DataSource = products.Select(x => x.GPUString).Distinct().ToList();
            Weight_TextBox.Text = products.First().Weight.ToString();
            X_Dimension_TextBox.Text = products.First().SizeProduct[0].ToString();
            Y_Dimension_TextBox.Text = products.First().SizeProduct[1].ToString();
            Z_Dimension_TextBox.Text = products.First().SizeProduct[2].ToString();
            Material_ComboBox.DataSource = new string[] { products.First().CaseMaterial };
            Webcam_ComboBox.DataSource = products.Select(x => x.Webcam).Distinct().ToList();
            OS_ComboBox.DataSource = products.Select(x => x.OS).Distinct().ToList();
            X_Pixel_ComboBox.DataSource = products.Select(x => x.Resolution[0]).Distinct().ToList();
            Y_Pixel_ComboBox.DataSource = products.Select(x => x.Resolution[1]).Distinct().ToList();
            TypePanel_ComboBox.DataSource = products.Select(x => x.TypePanel).Distinct().ToList();
            RefreshRate_ComboBox.DataSource = products.Select(x => x.RefreshRate).Distinct().ToList();
            Brightness_TextBox.Text = products.First().Brightness.ToString();
            SizePanel_ComboBox.DataSource = products.Select(x => x.SizePanel).Distinct().ToList();
            X_Ratio_ComboBox.DataSource = products.First().RatioPanel.Clone();
            X_Ratio_ComboBox.SelectedIndex = 0;
            Y_Ratio_ComboBox.DataSource = products.First().RatioPanel.Clone();
            Y_Ratio_ComboBox.SelectedIndex = 1;
            Touchscreen_ToggleButton.Checked = products.First().CanTouchPanel ?? false;
            TypeScreen_ComboBox.DataSource = new string[] { products.First().TypeScreen };
            if (products.First().SpaceColor != null)
            {
                if (products.First().SpaceColor.TryGetValue(ModelProduct.ENUM_SPACE_COLOR.sRGB, out double sRGB))
                {
                    ColorSpace_sRGB_TextBox.Text = sRGB.ToString();
                    ColorSpace_sRGB_TextBox.Enabled = true;
                }
                if (products.First().SpaceColor.TryGetValue(ModelProduct.ENUM_SPACE_COLOR.DCI_P3, out double dcip3))
                {
                    ColorSpace_DCIP3_TextBox.Text = dcip3.ToString();
                    ColorSpace_DCIP3_TextBox.Enabled = true;
                }
                if (products.First().SpaceColor.TryGetValue(ModelProduct.ENUM_SPACE_COLOR.AdobeRGBProfile, out double adobe))
                {
                    ColorSpace_AdobeRGB_TextBox.Text = adobe.ToString();
                    ColorSpace_AdobeRGB_TextBox.Enabled = true;
                }
            }
            HasCodeDisplay_CheckBox.Checked = false;
            CodeDisplay_TextBox.Text = products.First().IdPanel;
            TypeStorage_ComboBox.DataSource = products.Select(x => x.TypeStorage).Distinct().ToList();
            StorageCapacity_ComboBox.DataSource = products.Select(x => x.StorageCapacity).Distinct().ToList();
            WifiStandard_ComboBox.DataSource = products.Select(x => x.Wifi).Distinct().ToList();
            BluetoothStandard_ComboBox.DataSource = products.Select(x => x.Bluetooth).Distinct().ToList();
            ColorDialog.Color = products.First().ColorModel.ColorCode;
            ColorPicker_Button.FillColor = ColorDialog.Color;
            NameColor_TextBox.Text = products.First().ColorModel.ColorName;

            for (int index = 0; index < products.First().Ports.Length; index++)
            {
                Ports_DataGridView.Rows.Add(products.First().Ports[index].PortProtocol, products.First().Ports[index].PortPhysic, products.First().Ports[index].Quantity);
            }

            Price_TextBox.Text = products.First().Price.ToString();
        }
        #endregion

        #region Loading data
        private List<string> GetDistinctValue<TModel>(IQueryable<TModel> query, Expression<Func<TModel, string>> select) where TModel : class
        {
            return query.Select(select).Distinct().ToList();
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
        }

        private void AssignBinding(MainBindingData binding)
        {
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
        #endregion

        private void CheckChange()
        {
            ModelProduct checkModel = new ModelProduct();
            checkModel.NameProduct = NameProductValue_Label.Text;
            string[] serials = Serials_TextBox.Text.Split('\n');
            checkModel.LineUp = Lineup_ComboBox.SelectedText;
            checkModel.Manufacturer = Manufacturer_ComboBox.SelectedText;
            checkModel.Country = Country_ComboBox.SelectedText;
            checkModel.CPU = CPU_ComboBox.SelectedText;
            checkModel.RAMString = string.Format("{0}GB {1} {2}", Capacity_RAM_ComboBox.SelectedText, TypeRAM_ComboBox.SelectedText, BusRAM_ComboBox.SelectedText);
            checkModel.iGPU = iGPU_ComboBox.SelectedText;
            checkModel.GPUString = GPU_ComboBox.SelectedText;
            checkModel.Weight = double.Parse(Weight_TextBox.Text);
            checkModel.SizeProductString = string.Format("{0}x{1}x{2}", X_Dimension_TextBox.Text, Y_Dimension_TextBox.Text, Z_Dimension_TextBox.Text);
            checkModel.CaseMaterial = Material_ComboBox.SelectedText;
            checkModel.Webcam = Webcam_ComboBox.SelectedText;
            checkModel.ResolutionString = string.Format("{0}x{1}", X_Pixel_ComboBox.SelectedText, Y_Pixel_ComboBox.SelectedText);
            checkModel.TypePanel = TypePanel_ComboBox.SelectedText;
            checkModel.RefreshRate = int.Parse(RefreshRate_ComboBox.SelectedText);
            checkModel.Brightness = int.Parse(Brightness_TextBox.Text);
            checkModel.SizePanel = double.Parse(SizePanel_ComboBox.SelectedText);
            checkModel.RatioPanelString = string.Format("{0}:{1}", X_Ratio_ComboBox.SelectedText, Y_Ratio_ComboBox.SelectedText);
            checkModel.CanTouchPanel = Touchscreen_ToggleButton.Checked;
            checkModel.TypeScreen = TypeScreen_ComboBox.SelectedText;
            checkModel.IdPanel = CodeDisplay_TextBox.Text;
            checkModel.TypeStorage = TypeStorage_ComboBox.SelectedText;
            checkModel.StorageCapacity = int.Parse(StorageCapacity_ComboBox.SelectedText);
            checkModel.Wifi = WifiStandard_ComboBox.SelectedText;
            checkModel.Bluetooth = BluetoothStandard_ComboBox.SelectedText;
            checkModel.ColorCode = ColorDialog.Color.ToString();
            checkModel.ColorName = NameColor_TextBox.Text;
            checkModel.Price = double.Parse(Price_TextBox.Text);


            if (products.First().SpaceColor != null)
            {
                if (products.First().SpaceColor.TryGetValue(ModelProduct.ENUM_SPACE_COLOR.sRGB, out double sRGB))
                {
                    ColorSpace_sRGB_TextBox.Text = sRGB.ToString();
                    ColorSpace_sRGB_TextBox.Enabled = true;
                }
                if (products.First().SpaceColor.TryGetValue(ModelProduct.ENUM_SPACE_COLOR.DCI_P3, out double dcip3))
                {
                    ColorSpace_DCIP3_TextBox.Text = dcip3.ToString();
                    ColorSpace_DCIP3_TextBox.Enabled = true;
                }
                if (products.First().SpaceColor.TryGetValue(ModelProduct.ENUM_SPACE_COLOR.AdobeRGBProfile, out double adobe))
                {
                    ColorSpace_AdobeRGB_TextBox.Text = adobe.ToString();
                    ColorSpace_AdobeRGB_TextBox.Enabled = true;
                }
            }

            for (int index = 0; index < products.First().Ports.Length; index++)
            {
                Ports_DataGridView.Rows.Add(products.First().Ports[index].PortProtocol, products.First().Ports[index].PortPhysic, products.First().Ports[index].Quantity);
            }
        }

        public List<ModelProduct> ShowDialog(IWin32Window owner, List<ModelProduct> preModels, bool editable = true)
        {
            if (preModels != null)
            {
                this.editable = editable;
                products = preModels;
            }
            base.ShowDialog();
            CheckChange();
            return preModels;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Confirm_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ColorPicker_Button_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() == DialogResult.OK)
            {
                ColorPicker_Button.FillColor = ColorDialog.Color;
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            editable = !editable;
            SetEditable(editable);
        }

        private void HasCodeDisplay_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox control = sender as CheckBox;
            CodeDisplay_TextBox.ReadOnly = !control.Checked;
        }

        private async void DetailSpecsProduct_Form_Load(object sender, EventArgs e)
        {
            Edit_Button.Visible = this.editable;
            SetEditable(this.editable);
            await LoadingData();
            SetDefaultData();
        }
    }
}
