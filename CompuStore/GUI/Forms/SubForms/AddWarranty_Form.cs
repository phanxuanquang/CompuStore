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

namespace CompuStore
{
    public partial class AddWarranty_Form : Form
    {
        DETAIL_INVOICE detail;
        CUSTOMER customer;
        STAFF currentStaff;
        public AddWarranty_Form()
        {
            InitializeComponent();
            LoadLabel();
        }
        private void LoadLabel()
        {
            currentStaff = LoginServices.Instance.CurrentStaff;
            lbStaffName.Text += " " + currentStaff.INFOR.NAME;
            lbDate.Text += " " + DateTime.Now.ToLongDateString();
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
            if (!isValidSerialID(detail))
            {
                Exception res =  WarrantyServices.Instance.SaveWarrantyToDB(detail.ID_INVOICE, currentStaff.ID, ItemSerial_Box.Text, null, DateTime.Now, WarrantyDoneDate_Picker.Value, null);
                if (res.Message == "done")
                {
                    MessageBox.Show("Lưu thành công");
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

        private void ItemSerial_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                detail = InvoiceServices.Instance.GetDetailBySerialID(ItemSerial_Box.Text);
                if (!isValidSerialID(detail))
                {
                    MessageBox.Show("Không tìm thấy hóa đơn bán sản phẩm này");
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
        }
    }
}
