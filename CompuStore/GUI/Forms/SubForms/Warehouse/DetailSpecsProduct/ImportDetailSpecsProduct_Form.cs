using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public class ImportDetailSpecsProduct_Form : BaseDetailSpecsProduct_Form
    {
        #region Variable
        private System.Windows.Forms.Panel ImportPanel;
        private System.Windows.Forms.TextBox Serial_TextBox, Price_TextBox;
        private System.Windows.Forms.Label Serial_Label, UnitPrice_Label, Price_Label;
        #endregion

        #region Private Component
        protected override void AddInitializeComponent()
        {
            this.ImportPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Serial_TextBox = new System.Windows.Forms.TextBox();
            this.Serial_Label = new System.Windows.Forms.Label();
            this.UnitPrice_Label = new System.Windows.Forms.Label();
            this.Price_Label = new System.Windows.Forms.Label();
            this.Price_TextBox = new System.Windows.Forms.TextBox();
            this.ImportPanel.SuspendLayout();
            this.MainFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImportPanel
            // 
            this.ImportPanel.Controls.Add(this.Serial_Label);
            this.ImportPanel.Controls.Add(this.Serial_TextBox);
            this.ImportPanel.Controls.Add(this.Price_Label);
            this.ImportPanel.Controls.Add(this.Price_TextBox);
            this.ImportPanel.Controls.Add(this.UnitPrice_Label);
            this.ImportPanel.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ImportPanel.Name = "ImportPanel";
            this.ImportPanel.Size = new System.Drawing.Size(this.Size.Width, 70);
            this.ImportPanel.TabIndex = 134;
            // 
            // Serial_TextBox
            // 
            this.Serial_TextBox.Enabled = false;
            this.Serial_TextBox.Margin = new System.Windows.Forms.Padding(5 * DeviceDpi / 96);
            this.Serial_TextBox.Name = "Serial_TextBox";
            this.Serial_TextBox.Size = new System.Drawing.Size(232 * DeviceDpi / 96, 39);
            this.Serial_TextBox.TabIndex = 133;
            // 
            // Serial_Label
            // 
            this.Serial_Label.AutoSize = true;
            this.Serial_Label.Margin = new System.Windows.Forms.Padding(150 * DeviceDpi / 96, 3 * DeviceDpi / 96, 10 * DeviceDpi / 96, 3 * DeviceDpi / 96);
            this.Serial_Label.Padding = new Padding(5 * DeviceDpi / 96);
            this.Serial_Label.Name = "Serial_Label";
            this.Serial_Label.Size = new System.Drawing.Size(124 * DeviceDpi / 96, 32);
            this.Serial_Label.TabIndex = 134;
            this.Serial_Label.Text = "Serial máy";
            // 
            // UnitPrice_Label
            // 
            this.UnitPrice_Label.AutoSize = true;
            this.UnitPrice_Label.ForeColor = System.Drawing.Color.Black;
            this.UnitPrice_Label.Margin = new System.Windows.Forms.Padding(0, 3 * DeviceDpi / 96, 0, 3 * DeviceDpi / 96);
            this.UnitPrice_Label.Padding = new Padding(5 * DeviceDpi / 96);
            this.UnitPrice_Label.Name = "UnitPrice_Label";
            this.UnitPrice_Label.Size = new System.Drawing.Size(64 * DeviceDpi / 96, 32);
            this.UnitPrice_Label.TabIndex = 134;
            this.UnitPrice_Label.Text = "VNĐ";
            // 
            // Price_Label
            // 
            this.Price_Label.AutoSize = true;
            this.Price_Label.ForeColor = System.Drawing.Color.Black;
            this.Price_Label.Margin = new System.Windows.Forms.Padding(450 * DeviceDpi / 96, 3 * DeviceDpi / 96, 10 * DeviceDpi / 96, 3 * DeviceDpi / 96);
            this.Price_Label.Padding = new Padding(5 * DeviceDpi / 96);
            this.Price_Label.Name = "Price_Label";
            this.Price_Label.Size = new System.Drawing.Size(96 * DeviceDpi / 96, 32);
            this.Price_Label.TabIndex = 133;
            this.Price_Label.Text = "Giá tiền";
            // 
            // Price_TextBox
            // 
            this.Price_TextBox.Enabled = false;
            this.Price_TextBox.ForeColor = System.Drawing.Color.Black;
            this.Price_TextBox.Margin = new System.Windows.Forms.Padding(5 * DeviceDpi / 96);
            this.Price_TextBox.Name = "Price_TextBox";
            this.Price_TextBox.Size = new System.Drawing.Size(259 * DeviceDpi / 96, 39);
            this.Price_TextBox.TabIndex = 132;
            this.Price_TextBox.Enter += Price_TextBox_Enter;
            this.Price_TextBox.Leave += Price_TextBox_Leave;
            this.MainFlowLayoutPanel.Controls.Clear();
            this.MainFlowLayoutPanel.Controls.Add(ImportPanel);
            this.MainFlowLayoutPanel.Controls.Add(SpecsPanel);
            this.Size = new Size(this.Size.Width, this.Size.Height + 70);
            this.MainFlowLayoutPanel.Size = new Size(this.MainFlowLayoutPanel.Size.Width, this.MainFlowLayoutPanel.Size.Height + 70);
            this.ImportPanel.ResumeLayout(false);
            this.ImportPanel.PerformLayout();
            this.MainFlowLayoutPanel.ResumeLayout(false);
            this.MainFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        #region Set Editable
        protected override void SetEditable(bool editable)
        {
            base.SetEditable(editable);
            Serial_TextBox.Enabled = editable;
            Price_TextBox.Enabled = editable;
        }
        #endregion

        #region Set default if View | Edit;
        protected override void SetDefaultData()
        {
            base.SetDefaultData();
            Serial_TextBox.Text = product.Serial;
            Price_TextBox.Text = product.Price.ToString();
        }
        #endregion

        #region Show handle
        public override ResultDetailSpecsProduct ShowDialog(IWin32Window owner, IList<ModelProduct> payload, bool editable = true)
        {
            return base.ShowDialog(owner, payload, editable);
        }
        #endregion

        #region Event
        private void Price_TextBox_Leave(object sender, EventArgs e)
        {
            TextBox control = sender as TextBox;
            if (control != null && !string.IsNullOrEmpty(control.Text) && double.TryParse(control.Text, out double value))
            {
                control.Text = string.Format("{0:n3}", value);
            }
            else
            {
                MessageBox.Show("Tiền tệ yêu cầu số thực");
            }
        }

        private void Price_TextBox_Enter(object sender, EventArgs e)
        {
            TextBox control = sender as TextBox;
            if (control != null && !string.IsNullOrEmpty(control.Text) && double.TryParse(control.Text, out double value))
            {
                control.Text = value.ToString();
            }
            else
            {
                MessageBox.Show("Tiền tệ yêu cầu số thực");
            }
        }
        #endregion

        #region Validation
        protected override void CheckChange()
        {
            ModelProduct checkModel = new ModelProduct();
            checkModel.NameProduct = NameProductValue_Label.Text;
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
            checkModel.CanTouchPanel = TouchScreen_CheckBox.Checked;
            checkModel.TypeScreen = TypeScreen_ComboBox.SelectedItem?.ToString();
            if (HasCodeDisplay_CheckBox.Checked)
            {
                checkModel.IdPanel = CodeDisplay_ComboBox.Text;
            }
            else
            {
                checkModel.IdPanel = CodeDisplay_ComboBox.SelectedItem?.ToString();
            }
            checkModel.TypeStorage = TypeStorage_ComboBox.SelectedItem?.ToString();
            checkModel.StorageCapacity = int.Parse(StorageCapacity_ComboBox.SelectedItem?.ToString());
            checkModel.Wifi = WifiStandard_ComboBox.SelectedItem?.ToString();
            checkModel.Bluetooth = BluetoothStandard_ComboBox.SelectedItem?.ToString();
            checkModel.ColorName = NameColor_TextBox.Text;
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

            checkModel.ColorCode = string.Format("#{0:X2}{1:X2}{2:X2}", ColorDialog.Color.R, ColorDialog.Color.G, ColorDialog.Color.B);

            List<string> ports = new List<string>();

            foreach (ModelProduct.Port port in bindingPorts)
            {
                if (string.IsNullOrEmpty(port.PortProtocol) || string.IsNullOrEmpty(port.PortPhysic) || port.Quantity == null)
                {
                    continue;
                }
                else
                {
                    if (port.PortProtocol.CompareTo(port.PortPhysic) == 0)
                    {
                        ports.Add(string.Format("{0}:{1}", port.PortPhysic, port.Quantity));
                    }
                    else
                    {
                        ports.Add(string.Format("{0}:{1}x {2}", port.PortPhysic, port.Quantity, port.PortProtocol));
                    }
                }
            }
            checkModel.PortString = string.Join("_", ports);
            checkModel.Serial = Serial_TextBox.Text;
            checkModel.Price = double.Parse(Price_TextBox.Text);
            checkModel.ReleaseDate = product.ReleaseDate;

            if (string.IsNullOrEmpty(product.Serial))
            {
                resultChanged.typeReturn = ResultDetailSpecsProduct.TypeReturn.NewProduct;
                resultChanged.sendPayload = null;
                resultChanged.receivePayload = checkModel;
            }
            else
            {
                if (product.Serial == checkModel.Serial)
                {
                    if (product.StrictCompareSpecs(checkModel))
                    {
                        resultChanged.typeReturn = ResultDetailSpecsProduct.TypeReturn.NoChanged;
                    }
                    else
                    {
                        resultChanged.typeReturn = ResultDetailSpecsProduct.TypeReturn.SpecsChanged;
                    }
                }
                else
                {
                    if (product.TypeProduct == ModelProduct.TypeModel.New)
                    {
                        resultChanged.typeReturn = ResultDetailSpecsProduct.TypeReturn.ProductChanged;
                    }
                    else
                    {
                        resultChanged.typeReturn = ResultDetailSpecsProduct.TypeReturn.SpecsChanged;
                    }
                }

                resultChanged.sendPayload = product;
                resultChanged.receivePayload = checkModel;
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        }

        protected override List<string> ValidationDetailSpecs()
        {
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(Serial_TextBox.Text))
                result.Add("Chưa nhập Serial máy");
            if (string.IsNullOrEmpty(Price_TextBox.Text) || !double.TryParse(Price_TextBox.Text, out double price))
                result.Add("Chưa nhập giá máy");
            result.AddRange(base.ValidationDetailSpecs());
            return result;
        }
        #endregion

        #region IO handle
        protected override void Exit_Clicked(object sender, EventArgs e)
        {
            List<string> checkValidation = ValidationDetailSpecs();
            if (checkValidation?.Count > 0)
            {
                if (MessageBox.Show(string.Join("\n", checkValidation) + "\n\n" + "Quay trở lại(Yes) hay hủy thay đổi(No)?", "Thiếu thông tin", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    base.Exit_Clicked(sender, e);
                }
            }
            else
            {
                CheckChange();
                base.Exit_Clicked(sender, e);
            }
        }
        #endregion
    }
}
