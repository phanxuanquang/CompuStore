using CompuStore.Database.Models;
using CompuStore.Database.Services;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore
{
    public partial class AddReturn_Form : Form
    {
        DETAIL_INVOICE detail;
        CUSTOMER customer;
        STAFF currentStaff;

        private class BindingSerialModel
        {
            public string SERIAL { get; set; }
            public string NAME { get; set; }
        }

        private class BindingSerialModelComparer : IEqualityComparer<BindingSerialModel>
        {
            public bool Equals(BindingSerialModel x, BindingSerialModel y)
            {
                return x.NAME == y.NAME;
            }

            public int GetHashCode(BindingSerialModel obj)
            {
                return 0;
            }
        }

        public AddReturn_Form()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Icon;
            this.ShowInTaskbar = false;
            guna2ShadowForm1.SetShadowForm(this);
            this.Load += AddReturn_Form_Load;
            this.Serial_ComboBox.DrawItem += Serial_ComboBox_DrawItem;
        }

        private void AddReturn_Form_Load(object sender, EventArgs e)
        {
            TurnOnAutocomplete();
            LoadLabel();
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

        private void TurnOnAutocompleteCB()
        {
            PRODUCT pro = Database.Services.ProductServices.ProductServices.Instance.GetProductBySerial(OldItemSerial_Box.Text);
            IList<BindingSerialModel> arrayOfWowrds1 = null;
            try
            {
                arrayOfWowrds1 = Database.DataProvider.Instance.Database.PRODUCTs
                    .Where(item => item.IN_WAREHOUSE == true && item.DETAIL_SPECS.COMMON_SPECS.NAME == pro.DETAIL_SPECS.COMMON_SPECS.NAME)
                    .Select(item => new BindingSerialModel { NAME = item.DETAIL_SPECS.COMMON_SPECS.NAME, SERIAL = item.SERIAL_ID })
                    .ToList();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            IEqualityComparer<BindingSerialModel> comparer = new BindingSerialModelComparer();
            IEnumerable<BindingSerialModel> nameProducts = arrayOfWowrds1.Distinct(comparer);
            BindingList<BindingSerialModel> bindingSerial = new BindingList<BindingSerialModel>(arrayOfWowrds1);
            BindingList<BindingSerialModel> bindingNameProduct = new BindingList<BindingSerialModel>(nameProducts.ToList());
            Serial_ComboBox.DataSource = bindingSerial;
            NameProduct_ComboBox.DataSource = bindingNameProduct;

            Serial_ComboBox.ValueMember = "SERIAL";
            Serial_ComboBox.DisplayMember = "SERIAL";

            NameProduct_ComboBox.ValueMember = "SERIAL";
            NameProduct_ComboBox.DisplayMember = "NAME";
        }

        private void NameProduct_ComboBox_Leave(object sender, EventArgs e)
        {
            if (sender is ComboBox control)
            {
                string currentText = control.Text;
                BindingList<BindingSerialModel> binding = control.DataSource as BindingList<BindingSerialModel>;
                if (control.DisplayMember == "NAME" && binding.FirstOrDefault(item => item.NAME == currentText) == null
                    || control.DisplayMember == "SERIAL" && binding.FirstOrDefault(item => item.SERIAL == currentText) == null)
                {
                    MessageBox.Show("Thông tin sản phẩm không hợp lệ.\nVui lòng nhập lại.");
                    control.Focus();
                }
            }
        }

        private void Serial_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            BindingSerialModel selectedItem = NameProduct_ComboBox.SelectedItem as BindingSerialModel;
            if (selectedItem != null && sender is ComboBox control)
            {
                int index = e.Index >= 0 ? e.Index : 0;
                BindingSerialModel item = control.Items[index] as BindingSerialModel;

                Brush backColor = null;
                Brush foreColor = null;
                if (item.NAME == selectedItem.NAME)
                {
                    backColor = Brushes.DarkBlue;
                    foreColor = Brushes.White;
                }
                else
                {
                    backColor = Brushes.WhiteSmoke;
                    foreColor = Brushes.Black;
                }
                e.DrawBackground();
                e.Graphics.FillRectangle(backColor, e.Bounds);
                e.Graphics.DrawString(item.SERIAL, e.Font, foreColor, e.Bounds, StringFormat.GenericDefault);
            }
            e.DrawFocusRectangle();
        }

        private void Serial_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox control)
            {
                BindingSerialModel selectedItem = control.SelectedItem as BindingSerialModel;
                BindingList<BindingSerialModel> binding = NameProduct_ComboBox.DataSource as BindingList<BindingSerialModel>;
                if (selectedItem == null || binding == null) return;
                BindingSerialModel found = binding.FirstOrDefault(item => item.NAME == selectedItem.NAME);
                if (found != null)
                    NameProduct_ComboBox.SelectedItem = found;
            }
        }

        private void NameProduct_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox control)
            {
                BindingSerialModel selectedItem = control.SelectedItem as BindingSerialModel;
                BindingList<BindingSerialModel> binding = Serial_ComboBox.DataSource as BindingList<BindingSerialModel>;
                if (selectedItem == null || binding == null) return;
                BindingSerialModel found = binding.FirstOrDefault(item => item.NAME == selectedItem.NAME);
                if (found != null)
                    Serial_ComboBox.SelectedItem = found;
            }
        }


        private void LoadLabel()
        {
            currentStaff = LoginServices.Instance.CurrentStaff;
            lbStaffName.Text += " " + currentStaff.INFOR.NAME;
        }
        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (isValidSerialID(detail))
            {
                if (Database.DataProvider.Instance.Database.PRODUCTs.FirstOrDefault(item => item.SERIAL_ID == Serial_ComboBox.SelectedValue.ToString()) == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm mới trong kho.", "Không tìm thấy sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Exception res = ChangeOrRefundProductServices.Instance.SaveCOrreFundToDB(detail.ID_INVOICE, currentStaff.ID, Database.DataProvider.Instance.Database.PRODUCTs.FirstOrDefault(item => item.SERIAL_ID == OldItemSerial_Box.Text).PRODUCT_ID, Database.DataProvider.Instance.Database.PRODUCTs.FirstOrDefault(item => item.SERIAL_ID == Serial_ComboBox.SelectedValue.ToString()).PRODUCT_ID, ReturnReason.Text, CreateDate_Picker.Value);
                if (res.Message == "done")
                {
                    MessageBox.Show("Lưu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res.Message);
                }
            }
        }

        private bool isValidSerialID(DETAIL_INVOICE detail)
        {
            if (detail == null)
            {
                return false;
            }
            return true;
        }

        private void TurnOnAutocomplete()
        {
            List<DETAIL_INVOICE> arrayOfWowrds1 = new List<DETAIL_INVOICE>();
            try
            {
                //Read in data Autocomplete list to a string[]
                arrayOfWowrds1 = DetailInvoiceServices.Instance.GetDETAIL_INVOICEs();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            AddAutoCompleteCource(OldItemSerial_Box, arrayOfWowrds1.Where(pro => pro.PRODUCT.IN_WAREHOUSE == false).Select(item => item.PRODUCT.SERIAL_ID).ToArray());
        }

        public void AddAutoCompleteCource(Guna2TextBox textBox, string[] strings)
        {
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(strings);
            textBox.AutoCompleteCustomSource = collection;
        }

        private void AddInfor_Button_Click(object sender, EventArgs e)
        {
            detail = InvoiceServices.Instance.GetDetailBySerialID((OldItemSerial_Box.Text));
            if (!isValidSerialID(detail))
            {
                MessageBox.Show("Không tìm thấy hóa đơn bán sản phẩm này.", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                customer = detail.INVOICE.CUSTOMER;
                Identity_Box.Text = customer.INFOR.IDENTITY_CODE;
                Name_Box.Text = customer.INFOR.NAME;
                PhoneNumber_Box.Text = customer.INFOR.PHONE_NUMBER;
                Email_Box.Text = customer.INFOR.EMAIL;

                TurnOnAutocompleteCB();
            }

        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không tim thấy máy in. Vui lòng thử lại sau.", "Không tìm thấy máy in", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Identity_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!Program.isValidInformation("IDcard", Identity_Box.Text))
                {
                    PhoneNumber_Box.Text = String.Empty;
                    MessageBox.Show("Định dạng CCCD/CMND không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void PhoneNumber_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!Program.isValidInformation("phoneNum", PhoneNumber_Box.Text))
                {
                    PhoneNumber_Box.Text = String.Empty;
                    MessageBox.Show("Định dạng số điện thoại không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Email_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!Program.isValidInformation("email", Email_Box.Text))
                {
                    PhoneNumber_Box.Text = String.Empty;
                    MessageBox.Show("Định dạng email không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
