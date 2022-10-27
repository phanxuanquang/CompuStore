using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.GUI;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public partial class BaseInvoiceImportWarehouse_Form : Form
    {
        protected interface CommonSpecsGroup<TModel> where TModel : class
        {
            double maxTotal { get;}
            double minTotal { get;}
            TModel Represent { get; }
            IList<TModel> detailSpecs { get; set; }
        }

        protected interface CommonSpecsCustom
        {
            int ID { get; set; }

            string NameID { get; set; }

            string NameCommonSpecs { get; set; }

            string LineUp { get; set; }

            string Manufacturer { get; set; }

            DateTime? ReleaseDate { get; set; }

            int Quantity { get; set; }

            string RangeTotal { get; set; }
        }

        protected class DistributorCustom
        {
            public int ID { get; set; }

            public string Name { get; set; }

            public static DistributorCustom Convert(DISTRIBUTOR model)
            {
                DistributorCustom result = null;
                if (model != null)
                {
                    result = new DistributorCustom();
                    result.ID = model.ID;
                    result.Name = model.NAME;
                }
                return result;
            }
        }

        protected class StoreCustom
        {
            public int ID { get; set; }

            public string Name { get; set; }

            public static StoreCustom Convert(STORE model)
            {
                StoreCustom result = null;
                if (model != null)
                {
                    result = new StoreCustom();
                    result.ID = model.ID;
                    result.Name = model.NAME;
                }
                return result;
            }
        }

        private static readonly Dictionary<string, string> translater = new Dictionary<string, string> {
            { "NameCommonSpecs", "Tên sản phẩm" },
            { "LineUp", "Dòng sản phẩm" },
            { "Manufacturer", "Nhà sản xuất" },
            { "ReleaseDate", "Năm ra mắt" },
            { "Quantity", "Số lượng|Số lượng sản phẩm nhập" },
            { "RangeTotal", "Giá tiền|Khoảng giá từ cấu hình thấp đến cao nhất" }};

        public BaseInvoiceImportWarehouse_Form()
        {
            InitializeComponent();
            TableData_DataGridView.DataSource = typeof(CommonSpecsCustom);
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TableData_DataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            grid.SuspendLayout();
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (translater.ContainsKey(column.Name))
                {
                    if (column.Name == "ReleaseDate")
                    {
                        column.DefaultCellStyle.Format = "yyyy";
                    }
                    string headerText = translater[column.Name];
                    string[] split = headerText.Split('|');
                    column.HeaderText = split[0];
                    if (split.Length > 1)
                    {
                        column.ToolTipText = split[1];
                    }
                }
                else
                {
                    column.Visible = false;
                }
            }
            grid.ResumeLayout(true);
        }
    }
}
