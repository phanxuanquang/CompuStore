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
    public partial class WarrantyDetail_Form : Form
    {
        public WarrantyDetail_Form()
        {
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditAndSave_Button_Click(object sender, EventArgs e)
        {
            if(EditAndSave_Button.Text == "SỬA HÓA ĐƠN")
            {
                ItemSerial_Box.Width = 406;
                ItemSerial_Box.ReadOnly = Identity_Box.ReadOnly = Name_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = WarrantyReason.ReadOnly = false;
                EditAndSave_Button.Text = "LƯU THÔNG TIN";
            }
            else
            {
                // lưu lại thông tin
                ItemSerial_Box.Width = 548;
                ItemSerial_Box.ReadOnly = Identity_Box.ReadOnly = Name_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = WarrantyReason.ReadOnly = true;
                EditAndSave_Button.Text = "SỬA HÓA ĐƠN";
            }
        }
    }
}
