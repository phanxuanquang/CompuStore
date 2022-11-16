using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.GUI;
using CompuStore.GUI.Forms;
using CompuStore.GUI.Forms.SubForms.Warehouse;
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

namespace CompuStore.Tab
{
    public partial class SaleManagement_Tab : BaseTab
    {
        public static string nameIdCommonSpecs;
        BindingList<ModelProduct> productList;
        public static Dictionary<COMMON_SPECS, int> listProduct = new Dictionary<COMMON_SPECS, int>();
        protected Dictionary<string, string> listItemViews = new Dictionary<string, string>()
        {
           { "Name", "Tên sản phẩm" },
           { "Price", "Giá bán" },
            {"Size", "Kích thước màn hình" },
            {"Resolution", "Độ phân giải" },
            { "CPU", "CPU" },
           { "RAMString", "RAM" },
           { "GPU", "GPU" },
           { "StorageCapacity", "Dung lượng ổ cứng|Đơn vị: GB" },
        };
        public SaleManagement_Tab()
        {
            InitializeComponent();
            this.GridDataTable.AutoGenerateColumns = false;
            this.GridDataTable.DataSource = bindingSource1;
            this.GridDataTable.CellDoubleClick += DataTable_CellDoubleClick;
            //this.Load += SaleManagement_Tab_Load;
            this.GridDataTable.Height = 690;
        }

        private void DataTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ModelProduct model = productList[e.RowIndex];
                BaseDetailSpecsProduct_Form detailSpecs = null;
                detailSpecs = new OverviewDetailSpecsProduct_Form();
                IList<ModelProduct> models = productList.Where(item => item.CompareSpecs(model)).ToList();
                detailSpecs.ShowDialog(this, models);
            }
        }

        private void SaleManagement_Tab_Load(object sender, EventArgs e)
        {
            LoadView(listItemViews);
            Progress<bool> progress = new Progress<bool>();
            Waiting_Form waiting = new Waiting_Form();
            Task runLoading = LoadDB(progress);

            const bool stopWaitingCoutner = true;

            runLoading.GetAwaiter().OnCompleted(() => waiting.Close());

            progress.ProgressChanged += (owner, value) =>
            {
                if (value == stopWaitingCoutner && !waiting.IsDisposed && waiting.shown)
                {
                    waiting.Close();
                }
            };

            waiting.ShowDialog(this);
        }

        public Task LoadDB(IProgress<bool> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                Run(GetListView());
                progress.Report(true);
            });

        }

        private void View(BindingList<ModelProduct> productList)
        {
            bindingSource1.ResetBindings(true);
            bindingSource1.DataSource = productList;
            foreach (DataGridViewRow row in GridDataTable.Rows)
            {
                ModelProduct selected = row.DataBoundItem as ModelProduct;
                if (selected != null)
                {
                    row.Cells["Name"].Value = selected.NameProduct;
                    row.Cells["Price"].Value = selected.Price;
                    row.Cells["Size"].Value = selected.SizePanel;
                    row.Cells["Resolution"].Value = selected.ResolutionString;
                    row.Cells["CPU"].Value = selected.CPU;
                    row.Cells["RAMString"].Value = selected.InfoRAM.CapacityRAM;
                    row.Cells["GPU"].Value = selected.GPUString;
                    row.Cells["StorageCapacity"].Value = selected.StorageCapacity;
                  
                }
            }
        }

        public void Run(BindingList<ModelProduct> productList)
        {
            if (GridDataTable.InvokeRequired)
            {
                GridDataTable.Invoke(new Action(() => View(productList)));
            }
            else
            {
                View(productList);
            }

        }
        private void LoadView(Dictionary<string, string> listItemViews)
        {

            foreach (var item in listItemViews)
            {
                DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
                dataGridViewTextBoxColumn.Name = item.Key;
                dataGridViewTextBoxColumn.HeaderText = item.Value;
                GridDataTable.Columns.Add(dataGridViewTextBoxColumn);
            }
        }

        private BindingList<ModelProduct> GetListView()
        {
             productList = new BindingList<ModelProduct>();
            List<DETAIL_SPECS> detailSpecs = Database.DataProvider.Instance.Database.DETAIL_SPECS.Select(item => item).ToList();
            foreach (DETAIL_SPECS detail in detailSpecs)
            {
                UNIQUE_SPECS uniqueSpecs = detail.UNIQUE_SPECS;
                DISPLAY_SPECS display = uniqueSpecs.DISPLAY_SPECS;
                COLOR color = detail.COLOR;
                COMMON_SPECS commonSpecs = detail.COMMON_SPECS;
                LINE_UP lineup = commonSpecs.LINE_UP;
                ICollection<PRODUCT> products = detail.PRODUCTs;

                foreach (PRODUCT product in products)
                {
                    DETAIL_IMPORT_WAREHOUSE detailImport = product.DETAIL_IMPORT_WAREHOUSE.First(item => item.PRODUCT_ID == product.PRODUCT_ID);
                    ModelProduct productMD = ModelProduct.DatabaseToModel(product, detailImport, lineup, display, uniqueSpecs, commonSpecs, color);
                    //productMD.Price = detail.PRICE;
                    productList.Add(productMD);
                }
            }
            return productList;
        }



        #region Binding
        private void ViewProduct()
        {

        }
        #endregion

        private void ViewDetail_Button_Click(object sender, EventArgs e)
        {
            /*BaseDetailSpecsProduct_Form detailSpecsProduct_Form = new BaseDetailSpecsProduct_Form(*//*DataTable.CurrentRow.Cells[0].Value.ToString()*//*);
            detailSpecsProduct_Form.ShowDialog();*/
            nameIdCommonSpecs = GridDataTable.CurrentRow.Cells[0].Value.ToString();
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

