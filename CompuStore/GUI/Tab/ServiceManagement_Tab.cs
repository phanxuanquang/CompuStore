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
    public partial class ServiceManagement_Tab : Tab.BaseTab
    {
        public ServiceManagement_Tab()
        {
            InitializeComponent();
        }

        private void Button_3_Click(object sender, EventArgs e)
        {
            if(Button_3.Text == "Danh sách đổi trả")
            {
                Button_3.Text = "Danh sách bảo hành";
                SearchBox.PlaceholderText = "Tìm kiếm phiếu đổi trả theo số điện thoại";
                // reload DataTable thành table đổi trả
            }
            else
            {
                Button_3.Text = "Danh sách đổi trả";
                SearchBox.PlaceholderText = "Tìm kiếm phiếu bảo hành theo số điện thoại";
                // reload DataTable thành table bảo hành
            }
        }

        private void Bottom_1_Click(object sender, EventArgs e)
        {
            AddWarranty_Form addWarranty_Form = new AddWarranty_Form();
            addWarranty_Form.ShowDialog();
        }

        private void Button_2_Click(object sender, EventArgs e)
        {
            AddReturn_Form addReturn_Form = new AddReturn_Form();
            addReturn_Form.ShowDialog();
        }
    }
}
