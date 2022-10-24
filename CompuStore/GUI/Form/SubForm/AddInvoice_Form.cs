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
    public partial class AddInvoice_Form : Form
    {
        public AddInvoice_Form()
        {
            InitializeComponent();
        }


        private void Edit_Button_Click(object sender, EventArgs e)
        {
            Name_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = Address_Box.ReadOnly = false;
        }

        private void AddCustomer_Button_Click(object sender, EventArgs e)
        {
            AddCustomer_Form addCustomer_Form = new AddCustomer_Form();
            addCustomer_Form.ShowDialog();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
