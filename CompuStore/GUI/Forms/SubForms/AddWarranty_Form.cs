using System;
using CompuStore.Database.Models;
using CompuStore.Database.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Security.Cryptography.X509Certificates;

namespace CompuStore
{
    using Database.Services.ProductServices;
    public partial class AddWarranty_Form : Form
    {
        DETAIL_INVOICE detail;
        CUSTOMER customer;
        STAFF currentStaff;
        public AddWarranty_Form()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            this.Icon = Properties.Resources.Icon;
            this.ShowInTaskbar = false;
            this.Load += AddWarranty_Form_Load;
            
        }

        private void AddWarranty_Form_Load(object sender, EventArgs e)
        {
            TurnOnAutocomplete();
            LoadLabel();
        }

        private void LoadLabel()
        {
            currentStaff = LoginServices.Instance.CurrentStaff;
            lbStaffName.Text += " " + currentStaff.INFOR.NAME;
            WarrantyDoneDate_Picker.Value = DateTime.Now.Date.AddDays(7);
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
        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (isValidSerialID(detail))
            {
                Exception res =  WarrantyServices.Instance.SaveWarrantyToDB(detail.ID_INVOICE, currentStaff.ID, Database.DataProvider.Instance.Database.PRODUCTs.FirstOrDefault(item => item.SERIAL_ID == ItemSerial_Box.Text).PRODUCT_ID, WarrantyReason.Text, CreateDate_Picker.Value, WarrantyDoneDate_Picker.Value, 0);
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
            AddAutoCompleteCource(ItemSerial_Box, arrayOfWowrds1.Where(pro => pro.PRODUCT.IN_WAREHOUSE == false).Select(item => item.PRODUCT.SERIAL_ID).ToArray());
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
            detail = InvoiceServices.Instance.GetDetailBySerialID((ItemSerial_Box.Text));
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
