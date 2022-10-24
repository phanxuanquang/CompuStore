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
    public partial class SalesManage_Tab : UserControl
    {
        private BackgroundWorker backgroundWorker = null;
        public SalesManage_Tab()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        private void AddNew_Button_Click(object sender, EventArgs e)
        {

        }

        private void ViewDetail_Button_Click(object sender, EventArgs e)
        {
            
            DetailSpecsProduct_Form detailSpecsProduct_Form = new DetailSpecsProduct_Form(DataTable.CurrentRow.Cells[0].Value.ToString());
            detailSpecsProduct_Form.ShowDialog();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[DataTable.DataSource];
                cm.SuspendBinding();

                for (int i = 0; i < DataTable.RowCount; i++)
                {
                    if (DataTable.Rows[i].Cells[0].Value != null &&
                        DataTable.Rows[i].Cells[1].Value != null)
                    {
                        if (DataTable.Rows[i].Cells[0].Value.ToString().ToLower().StartsWith(SearchBox.Text.ToLower()) ||
                            DataTable.Rows[i].Cells[1].Value.ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                        {
                            DataTable.Rows[i].Visible = true;
                        }
                        else
                        {
                            DataTable.Rows[i].Visible = false;
                        }
                    }
                }

                cm.ResumeBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
