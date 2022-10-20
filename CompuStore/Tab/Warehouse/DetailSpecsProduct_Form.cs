using CompuStore.ImportData;
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
    public partial class DetailSpecsProduct_Form : Form
    {
        public DetailSpecsProduct_Form()
        {
            InitializeComponent();
        }

        public ModelProduct ShowDialog(IWin32Window owner, ModelProduct preModel = null)
        {
            base.ShowDialog();
            return new ModelProduct();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Confirm_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
