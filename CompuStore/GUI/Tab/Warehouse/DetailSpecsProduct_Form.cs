﻿using CompuStore.ImportData;
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
    public partial class DetailSpecsProduct_Form : Form
    {
        public DetailSpecsProduct_Form(string id = "")
        {
            InitializeComponent();
        }

        public ModelProduct[] ShowDialog(IWin32Window owner, params ModelProduct[] preModels)
        {
            if (preModels != null)
            {
                NameProductValue_Label.Text = preModels[0].NameProduct;
                string serials = "";
                for (int index = 0; index < preModels.Length; index++)
                {
                    serials += preModels[index].Serial + '\n';
                }
                Serials_TextBox.Text = serials;
                Lineup_ComboBox.DataSource = new string[] { preModels[0].LineUp };
                Manufacturer_ComboBox.DataSource = new string[] { preModels[0].Manufacturer };
                Country_ComboBox.DataSource = new string[] { preModels[0].Country };
                CPU_ComboBox.DataSource = new string[] { preModels[0].CPU };
                Capacity_RAM_ComboBox.DataSource = new int[] { preModels[0].InfoRAM == null ? 0 : preModels[0].InfoRAM.CapacityRAM };
                Unit_RAM_ComboBox.DataSource = new string[] { "GB", "TB", "PB" };
                Type_Bus_RAM_ComboBox.DataSource = new string[] { "DDR5 5600MHz", "DDR4 2666MHz" };
                iGPU_ComboBox.DataSource = preModels.Select(x => x.iGPU).Distinct().ToList();
                GPU_ComboBox.DataSource = preModels.Select(x => x.GPUString).Distinct().ToList();
                Weight_TextBox.Text = preModels[0].Weight.ToString();
                X_Dimension_TextBox.Text = preModels[0].SizeProduct[0].ToString();
                Y_Dimension_TextBox.Text = preModels[0].SizeProduct[1].ToString();
                Z_Dimension_TextBox.Text = preModels[0].SizeProduct[2].ToString();
                Material_ComboBox.DataSource = new string[] { preModels[0].CaseMaterial };
                Webcam_ComboBox.DataSource = preModels.Select(x => x.Webcam).Distinct().ToList();
                OS_ComboBox.DataSource = preModels.Select(x => x.OS).Distinct().ToList();
                X_Pixel_ComboBox.DataSource = preModels.Select(x => x.Resolution[0]).Distinct().ToList();
                Y_Pixel_ComboBox.DataSource = preModels.Select(x => x.Resolution[1]).Distinct().ToList();
                TypePanel_ComboBox.DataSource = preModels.Select(x => x.TypePanel).Distinct().ToList();
                RefreshRate_ComboBox.DataSource = preModels.Select(x => x.RefreshRate).Distinct().ToList();
                Brightness_TextBox.Text = preModels[0].Brightness.ToString();
                SizePanel_ComboBox.DataSource = preModels.Select(x => x.SizePanel).Distinct().ToList();
                X_Ratio_ComboBox.DataSource = preModels[0].RatioPanel[0];
                Y_Ratio_ComboBox.DataSource = preModels[0].RatioPanel[1];
                Touchscreen_ToggleButton.Checked = preModels[0].CanTouchPanel ?? false;
                TypeScreen_ComboBox.DataSource = new string[] { preModels[0].TypeScreen };
                if (preModels[0].SpaceColor != null)
                {
                    if (preModels[0].SpaceColor.TryGetValue(ModelProduct.ENUM_SPACE_COLOR.sRGB, out double sRGB))
                    {
                        ColorSpace_sRGB_TextBox.Text = sRGB.ToString();
                    }
                    if (preModels[0].SpaceColor.TryGetValue(ModelProduct.ENUM_SPACE_COLOR.DCI_P3, out double dcip3))
                    {
                        ColorSpace_DCIP3_TextBox.Text = dcip3.ToString();
                    }
                    if (preModels[0].SpaceColor.TryGetValue(ModelProduct.ENUM_SPACE_COLOR.AdobeRGBProfile, out double adobe))
                    {
                        ColorSpace_AdobeRGB_TextBox.Text = adobe.ToString();
                    }
                }
                HasCodeDisplay_CheckBox.Checked = false;
                CodeDisplay_TextBox.Text = preModels[0].IdPanel;
                TypeStorage_ComboBox.DataSource = preModels.Select(x => x.TypeDrive).Distinct().ToList();
                StorageCapacity_ComboBox.DataSource = preModels.Select(x => x.DriveCapacity).Distinct().ToList();
                UnitStorage_ComboBox.DataSource = new string[] { "GB", "TB", "PB" };
                WifiStandard_ComboBox.DataSource = preModels.Select(x => x.Wifi).Distinct().ToList();
                BluetoothStandard_ComboBox.DataSource = preModels.Select(x => x.Bluetooth).Distinct().ToList();
                ColorDialog.Color = preModels[0].ColorModel.ColorCode;
                ColorPicker_Button.FillColor = ColorDialog.Color;
                NameColor_TextBox.Text = preModels[0].ColorModel.ColorName;

                for (int index = 0; index < preModels[0].Ports.Length; index++)
                {
                    Ports_DataGridView.Rows.Add(preModels[0].Ports[index].PortProtocol, preModels[0].Ports[index].PortPhysic, preModels[0].Ports[index].Quantity);
                }

                Price_TextBox.Text = preModels[0].Price.ToString();
            }
            base.ShowDialog();
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
    }
}
