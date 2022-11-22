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
    public partial class ReturnDetail_Form : Form
    {
        public ReturnDetail_Form()
        {
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditAndSave_Button_Click(object sender, EventArgs e)
        {
            if (EditAndSave_Button.Text == "SỬA HÓA ĐƠN")
            {
                OldItemSerial_Box.Width = 406;
                OldItemSerial_Box.ReadOnly = NewItemSerial_Box.ReadOnly = Identity_Box.ReadOnly = Name_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = ReturnReason.ReadOnly = false;
                EditAndSave_Button.Text = "LƯU THÔNG TIN";
            }
            else
            {
                // lưu lại thông tin
                OldItemSerial_Box.Width = 548;
                OldItemSerial_Box.ReadOnly = NewItemSerial_Box.ReadOnly = Identity_Box.ReadOnly = Name_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = ReturnReason.ReadOnly = true;
                EditAndSave_Button.Text = "SỬA HÓA ĐƠN";
            }
        }
    }
}
