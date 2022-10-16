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
    public partial class StaffManage_Tab : UserControl
    {
        public StaffManage_Tab()
        {
            InitializeComponent();
        }

        private void EditStaff_Button_Click(object sender, EventArgs e)
        {
            StaffEdit_Form staffEdit_Form = new StaffEdit_Form(true, "CHỈNH SỬA THÔNG TIN");
            staffEdit_Form.ShowDialog();
        }

        private void InfoStaff_Button_Click(object sender, EventArgs e)
        {
            StaffEdit_Form staffEdit_Form = new StaffEdit_Form(false, "THÔNG TIN NHÂN VIÊN");
            staffEdit_Form.ShowDialog();
        }

        private void AddStaff_Button_Click(object sender, EventArgs e)
        {
            StaffEdit_Form staffEdit_Form = new StaffEdit_Form(false, "THÊM NHÂN VIÊN");
            staffEdit_Form.ShowDialog();
        }
    }
}
