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
        public static string nameIdCommonSpecs;
        public static Dictionary<COMMON_SPECS, int> listProduct = new Dictionary<COMMON_SPECS, int>();
        public SaleManagement_Tab()
        {
            
            InitializeComponent();
            this.Load += SaleManagement_Tab_Load;
        }


        private void SaleManagement_Tab_Load(object sender, EventArgs e)
        {
            ViewProduct();
            this.Button_3.Click -= ImportWarehouse_Click;
            this.DataTable.CellDoubleClick -= DataTable_CellDoubleClick;
            this.DataTable.CellDoubleClick += DataTable_CellDoubleClick1;
        }

        private void DataTable_CellDoubleClick1(object sender, DataGridViewCellEventArgs e)
        {
            nameIdCommonSpecs = DataTable.CurrentRow.Cells[0].Value.ToString();
            COMMON_SPECS commonSpecs = Database.Services.CommonSpecsServices.Instance.GetCommonSpecsByNameID(nameIdCommonSpecs);
            if (commonSpecs != null)
            {
                if (listProduct.ContainsKey(commonSpecs))
                {
                    listProduct[commonSpecs]++;
                }
                else
                {
                    listProduct.Add(commonSpecs, 1);
                }    
            }
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
            /*BaseDetailSpecsProduct_Form detailSpecsProduct_Form = new BaseDetailSpecsProduct_Form(*//*DataTable.CurrentRow.Cells[0].Value.ToString()*//*);
            detailSpecsProduct_Form.ShowDialog();*/
            nameIdCommonSpecs = DataTable.CurrentRow.Cells[0].Value.ToString();
            COMMON_SPECS commonSpecs = Database.Services.CommonSpecsServices.Instance.GetCommonSpecsByNameID(nameIdCommonSpecs);
            if (commonSpecs != null)
            {
                BaseDetailInvoiceImportWarehouse_Form form = new EditDetailInvoiceImportWarehouse_Form();
                form.ShowDialog(this, null, commonSpecs);
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm");
            }    
        }

        private void AddNew_Buttom_Click(object sender, EventArgs e)
        {
            ViewProduct();
            AddInvoice_Form addInvoice_Form = new AddInvoice_Form(listProduct);
            addInvoice_Form.ShowDialog();
        }

        private void ViewInvoice_Click(object sender, EventArgs e)
        {
            InvoiceList_Form invoiceList_Form = new InvoiceList_Form();
            invoiceList_Form.ShowDialog();
        }
    }
}
