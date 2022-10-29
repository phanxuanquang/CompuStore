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
    public partial class DetailSpecsProduct_Form : Form
    {
        private List<ModelProduct> products;
        private bool editable = true;

        public DetailSpecsProduct_Form()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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
        private void SetEditable(bool editable)
        {
            //Serials_TextBox.Enabled = editable;
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
            //CodeDisplay_TextBox.Enabled = editable;
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
            //Price_TextBox.Enabled = editable;
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

        private void SetDefaultData()
        {
            NameProductValue_Label.Text = products.First().NameProduct;
            string serials = "";
            for (int index = 0; index < products.Count; index++)
            {
                serials += products[index].Serial + '\n';
            }
            //Serials_TextBox.Text = serials;

            Weight_TextBox.Text = products.First().Weight.ToString();
            X_Dimension_TextBox.Text = products.First().SizeProduct[0].ToString();
            Y_Dimension_TextBox.Text = products.First().SizeProduct[1].ToString();
            Z_Dimension_TextBox.Text = products.First().SizeProduct[2].ToString();
            Brightness_TextBox.Text = products.First().Brightness.ToString();
            //Touchscreen_ToggleButton.Checked = products.First().CanTouchPanel ?? false;
            HasCodeDisplay_CheckBox.Checked = false;
            //CodeDisplay_TextBox.Text = products.First().IdPanel;
            ColorDialog.Color = products.First().ColorModel.ColorCode;
            ColorPicker_Button.FillColor = ColorDialog.Color;
            NameColor_TextBox.Text = products.First().ColorModel.ColorName;
            BatteryCapacity_TextBox.Text = products.First().BatteryCapacity.ToString();
            //Price_TextBox.Text = products.First().Price.ToString();

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

            //Price_TextBox.Text = products.First().Price.ToString();

            SetDefaultComboBox(Lineup_ComboBox, products.First().LineUp);
            SetDefaultComboBox(Manufacturer_ComboBox, products.First().Manufacturer);
            SetDefaultComboBox(Country_ComboBox, products.First().Country);
            SetDefaultComboBox(CPU_ComboBox, products.First().CPU);
            SetDefaultComboBox(Capacity_RAM_ComboBox, products.First().InfoRAM.CapacityRAM.ToString());
            SetDefaultComboBox(TypeRAM_ComboBox, products.First().InfoRAM.TypeRAM.ToString());
            SetDefaultComboBox(BusRAM_ComboBox, products.First().InfoRAM.BusRAM.ToString());
            SetDefaultComboBox(iGPU_ComboBox, products.First().iGPU);
            SetDefaultComboBox(GPU_ComboBox, products.First().GPUString);
            SetDefaultComboBox(Material_ComboBox, products.First().CaseMaterial);
            SetDefaultComboBox(Webcam_ComboBox, products.First().Webcam);
            SetDefaultComboBox(OS_ComboBox, products.First().OS);
            SetDefaultComboBox(X_Pixel_ComboBox, products.First().Resolution[0].ToString());
            SetDefaultComboBox(Y_Pixel_ComboBox, products.First().Resolution[1].ToString());
            SetDefaultComboBox(TypePanel_ComboBox, products.First().TypePanel);
            SetDefaultComboBox(RefreshRate_ComboBox, products.First().RefreshRate.ToString());
            SetDefaultComboBox(SizePanel_ComboBox, products.First().SizePanel.ToString());
            SetDefaultComboBox(X_Ratio_ComboBox, products.First().RatioPanel[0].ToString());
            SetDefaultComboBox(Y_Ratio_ComboBox, products.First().RatioPanel[1].ToString());
            SetDefaultComboBox(TypeScreen_ComboBox, products.First().TypeScreen);
            SetDefaultComboBox(TypeStorage_ComboBox, products.First().TypeStorage);
            SetDefaultComboBox(StorageCapacity_ComboBox, products.First().StorageCapacity.ToString());
            SetDefaultComboBox(WifiStandard_ComboBox, products.First().Wifi);
            SetDefaultComboBox(BluetoothStandard_ComboBox, products.First().Bluetooth);
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
            //string[] serials = Serials_TextBox.Text.Split('\n');
            checkModel.LineUp = Lineup_ComboBox.SelectedItem?.ToString();
            checkModel.Manufacturer = Manufacturer_ComboBox.SelectedItem?.ToString();
            checkModel.Country = Country_ComboBox.SelectedItem?.ToString();
            checkModel.CPU = CPU_ComboBox.SelectedItem?.ToString();
            checkModel.RAMString = string.Format("{0}GB {1} {2}", 
                Capacity_RAM_ComboBox.SelectedItem?.ToString(), 
                TypeRAM_ComboBox.SelectedItem?.ToString(), 
                BusRAM_ComboBox.SelectedItem?.ToString());
            checkModel.iGPU = iGPU_ComboBox.SelectedItem?.ToString();
            checkModel.GPUString = GPU_ComboBox.SelectedItem?.ToString();
            checkModel.Weight = double.Parse(Weight_TextBox.Text);
            checkModel.SizeProductString = string.Format("{0}x{1}x{2}", 
                X_Dimension_TextBox.Text, 
                Y_Dimension_TextBox.Text, 
                Z_Dimension_TextBox.Text);
            checkModel.CaseMaterial = Material_ComboBox.SelectedItem?.ToString();
            checkModel.Webcam = Webcam_ComboBox.SelectedItem?.ToString();
            checkModel.ResolutionString = string.Format("{0}x{1}", 
                X_Pixel_ComboBox.SelectedItem?.ToString(), 
                Y_Pixel_ComboBox.SelectedItem?.ToString());
            checkModel.TypePanel = TypePanel_ComboBox.SelectedItem?.ToString();
            checkModel.RefreshRate = int.Parse(RefreshRate_ComboBox.SelectedItem?.ToString());
            checkModel.Brightness = int.Parse(Brightness_TextBox.Text);
            checkModel.SizePanel = double.Parse(SizePanel_ComboBox.SelectedItem?.ToString());
            checkModel.RatioPanelString = string.Format("{0}:{1}", 
                X_Ratio_ComboBox.SelectedItem?.ToString(), 
                Y_Ratio_ComboBox.SelectedItem?.ToString());
            //checkModel.CanTouchPanel = Touchscreen_ToggleButton.Checked;
            checkModel.TypeScreen = TypeScreen_ComboBox.SelectedItem?.ToString();
            //checkModel.IdPanel = CodeDisplay_TextBox.Text;
            checkModel.TypeStorage = TypeStorage_ComboBox.SelectedItem?.ToString();
            checkModel.StorageCapacity = int.Parse(StorageCapacity_ComboBox.SelectedItem?.ToString());
            checkModel.Wifi = WifiStandard_ComboBox.SelectedItem?.ToString();
            checkModel.Bluetooth = BluetoothStandard_ComboBox.SelectedItem?.ToString();
            checkModel.ColorName = NameColor_TextBox.Text;
            //checkModel.Price = double.Parse(Price_TextBox.Text);
            checkModel.BatteryCapacity = double.Parse(BatteryCapacity_TextBox.Text);
            checkModel.OS = OS_ComboBox.SelectedItem?.ToString();

            List<string> spaceColor = new List<string>();
            if (!string.IsNullOrEmpty(ColorSpace_sRGB_TextBox.Text))
            {
                spaceColor.Add(string.Format("{0}:{1}%", "sRGB color space", ColorSpace_sRGB_TextBox.Text));
            }
            if (!string.IsNullOrEmpty(ColorSpace_AdobeRGB_TextBox.Text))
            {
                spaceColor.Add(string.Format("{0}:{1}%", "Adobe RGB profile", ColorSpace_AdobeRGB_TextBox.Text));
            }
            if (!string.IsNullOrEmpty(ColorSpace_DCIP3_TextBox.Text))
            {
                spaceColor.Add(string.Format("{0}:{1}%", "DCI-P3 color gamut", ColorSpace_DCIP3_TextBox.Text));
            }

            checkModel.SpaceColorString = string.Join("_", spaceColor);

            checkModel.ColorCode = "#" + string.Format("{0:X8}", ColorTranslator.ToWin32(ColorDialog.Color)).Substring(2);

            List<string> ports = new List<string>();

            for (int index = 0; index < Ports_DataGridView.RowCount - 1; index++)
            {
                string portProtocol = Ports_DataGridView.Rows[index].Cells["PortProtocol_Column"].Value.ToString();
                string portPhysic = Ports_DataGridView.Rows[index].Cells["PortPhysic_Column"].Value.ToString();
                string portQuantity = Ports_DataGridView.Rows[index].Cells["PortQuantity_Column"].Value.ToString();

                if (portProtocol.CompareTo(portPhysic) == 0)
                {
                    ports.Add(string.Format("{0}:{1}", portPhysic, portQuantity));
                }
                else
                {
                    ports.Add(string.Format("{0}:{1}x {2}", portPhysic, portQuantity, portProtocol));
                }
            }

            checkModel.PortString = string.Join("_", ports);

            foreach(ModelProduct model in products)
            {
                checkModel.ReleaseDate = model.ReleaseDate;
                if (!model.CompareSpecs(checkModel))
                {
                    MessageBox.Show("!");
                }
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
            //CodeDisplay_TextBox.ReadOnly = !control.Checked;
        }

        private async void DetailSpecsProduct_Form_Load(object sender, EventArgs e)
        {
            Edit_Button.Visible = this.editable;
            SetEditable(this.editable);
            await LoadingData();
            SetDefaultData();
        }

        private void Touchscreen_ToggleButton_CheckedChanged(object sender, EventArgs e)
        {
            Guna2ToggleSwitch control = (sender as Guna2ToggleSwitch);
            if (!editable && control.Checked != products.First().CanTouchPanel)
            {
                control.Checked = products.First().CanTouchPanel ?? false;
            }
        }
    }
}
