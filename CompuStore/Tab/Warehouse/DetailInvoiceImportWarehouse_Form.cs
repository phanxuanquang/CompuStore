using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.Tab.Warehouse
{
    public partial class DetailInvoiceImportWarehouse_Form : Form
    {
        public DetailInvoiceImportWarehouse_Form()
        {
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DateTimeImportWarehouse_Label_Click(object sender, EventArgs e)
        {
            DateTimeImportWarehouse_DateTimePicker.Visible = !DateTimeImportWarehouse_DateTimePicker.Visible;
            if (!DateTimeImportWarehouse_DateTimePicker.Visible)
            {
                DateTimeImportWarehouse_Label.Text = DateTimeImportWarehouse_DateTimePicker.Value.ToString("hh:mm:ss dd/MM/yyyy");
            }
        }

        private void AddProduct_Button_Click(object sender, EventArgs e)
        {
            TableData_DataGridView.Rows.Add("1");
        }
    }
}
