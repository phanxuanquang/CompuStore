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
    public partial class StaffEdit_Form : Form
    {
        public StaffEdit_Form(bool notReadOnly, string headerName)
        {
            InitializeComponent();
            ShadowForm.SetShadowForm(this);
            ID_Box.ReadOnly = Name_Box.ReadOnly = Identity_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = Address_Box.ReadOnly = StaffDate_Box.ReadOnly = Edit_Button.Visible = !notReadOnly;
            Header.Text = headerName;
            if (headerName == "THÊM NHÂN VIÊN")
            {
                Edit_Button.Visible = false;
            }
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            ID_Box.ReadOnly = Name_Box.ReadOnly = Identity_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = Address_Box.ReadOnly = StaffDate_Box.ReadOnly = Edit_Button.Visible = false;
            Header.Text = "CHỈNH SỬA THÔNG TIN";
        }
    }
}
