using CompuStore.Tab.Warehouse;
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
    public partial class SaleManagement_Tab : BaseTab
    {
        public SaleManagement_Tab()
        {
            InitializeComponent();
        }

        private void ViewDetail_Button_Click(object sender, EventArgs e)
        {
            DetailSpecsProduct_Form detailSpecsProduct_Form = new DetailSpecsProduct_Form(DataTable.CurrentRow.Cells[0].Value.ToString());
            detailSpecsProduct_Form.ShowDialog();
        }
    }
}
