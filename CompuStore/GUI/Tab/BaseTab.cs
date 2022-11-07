using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.GUI;
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
    public partial class BaseTab : UserControl
    {
        protected BackgroundWorker backgroundWorker = null;
        protected Dictionary<string, string> listItemViews = new Dictionary<string, string>();
        public BaseTab()
        {
            
            InitializeComponent();
        }



        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                /*CurrencyManager cm = (CurrencyManager)BindingContext[DataTable.DataSource];
                cm.SuspendBinding();*/

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

                /*cm.ResumeBinding();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
