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
    public partial class AddInvoice_Form : Form
    {
        CUSTOMER customer;
        List<PRODUCT> listProduct;
        STAFF currentStaff;
        public AddInvoice_Form()
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

        bool isValidCustomer(CUSTOMER customer)
        {
            if (customer == null)
            {
                return false;
            }    
            return true;
        }

        private void Identity_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                customer = CustomerServices.Instance.GetCustomerByIDCode(Identity_Box.Text);
                if (!isValidCustomer(customer))
                {
                    DialogResult dialogResult = MessageBox.Show("CMND/CCCD của khách hàng này không tồn tại.\nBạn có muốn thêm khách hàng mới?", "CMND/CCCD không tồn tại", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Name_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = Address_Box.ReadOnly = false;
                        Identity_Box.Text = String.Empty;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (customer == null)
            {
                customer = CustomerServices.Instance.SaveCustomerToDB(Name_Box.Text, PhoneNumber_Box.Text, Email_Box.Text, Identity_Box.Text, Address_Box.Text);
            }
            InvoiceServices.Instance.SaveInvoiceToDB(listProduct, customer.ID, currentStaff.ID, DateTime.Now, 10);
        }
    }
}
