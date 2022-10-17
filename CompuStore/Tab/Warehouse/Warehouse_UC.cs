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
    public partial class Warehouse_UC : UserControl
    {
        public Warehouse_UC()
        {
            InitializeComponent();
        }

        private void ImportWarehouse_Click(object sender, EventArgs e)
        {
            DetailInvoiceImportWarehouse detail = new DetailInvoiceImportWarehouse();
            detail.ShowDialog(this);
        }
    }
}
