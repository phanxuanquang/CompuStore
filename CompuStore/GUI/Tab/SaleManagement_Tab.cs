using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.GUI;
using CompuStore.GUI.Forms;
using CompuStore.GUI.Forms.SubForms.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.Tab
{
    public partial class SaleManagement_Tab : Warehouse_UC
    {
        public SaleManagement_Tab()
        {
            
            InitializeComponent();
            this.Load += SaleManagement_Tab_Load;
        }


        private void SaleManagement_Tab_Load(object sender, EventArgs e)
        {
            ViewProduct();
            this.Button_3.Click -= ImportWarehouse_Click;
        }

        #region Binding
        private void ViewProduct()
        {
            seeWhat = SEE_WHAT.COMMON_SPECS;
            AddBindingToDataGridView(commonSpecsBinding);
        }
        #endregion

        private void ViewDetail_Button_Click(object sender, EventArgs e)
        {
            DetailSpecsProduct_Form detailSpecsProduct_Form = new DetailSpecsProduct_Form(/*DataTable.CurrentRow.Cells[0].Value.ToString()*/);
            detailSpecsProduct_Form.ShowDialog();
        }

        private void AddNew_Buttom_Click(object sender, EventArgs e)
        {
            AddInvoice_Form addInvoice_Form = new AddInvoice_Form();
            addInvoice_Form.ShowDialog(); 
        }

        private void ViewInvoice_Click(object sender, EventArgs e)
        {
            InvoiceList_Form invoiceList_Form = new InvoiceList_Form();
            invoiceList_Form.ShowDialog();
        }
    }
}
