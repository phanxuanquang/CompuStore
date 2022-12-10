using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.Database.Services.ProductServices;
using CompuStore.GUI;
using CompuStore.GUI.Forms;
using CompuStore.GUI.Forms.SubForms.Warehouse;
using CompuStore.GUI.Forms.SubForms.Warehouse.DetailSpecsProduct;
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
        BindingList<ModelSale> productList;
        public static Dictionary<COMMON_SPECS, int> listProduct = new Dictionary<COMMON_SPECS, int>();
        protected Dictionary<string, string> listItemViews = new Dictionary<string, string>()
        {
           { "Name", "Tên sản phẩm" },
           { "Price", "Giá bán" },
            {"Color", "Màu sắc" },
            {"Size", "Kích thước" },
            {"Resolution", "Độ phân giải" },
            { "CPU", "CPU" },
           { "RAMString", "RAM" },
           { "GPU", "GPU" },
           { "StorageCapacity", "Ổ cứng" },
        };

        public class ModelSale
        {
            public string serialID { get; set; }
            public string name { get; set; }
            public double price{ get; set; }

            public string resolution{ get; set; }

            public double sizePanel{ get; set; }

            public string cpu{ get; set; }

            public string memory{ get; set; }

            public string gpu{ get; set; }

           public string color{ get; set; }

            public int storagecap{ get; set; }
        }

        public SaleManagement_Tab()
        {
            InitializeComponent();
            this.GridDataTable.AutoGenerateColumns = false;
            this.GridDataTable.DataSource = bindingSource1;
            this.GridDataTable.CellDoubleClick += DataTable_CellDoubleClick;
            this.GridDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Load += SaleManagement_Tab_Load;
            this.GridDataTable.Height = 690;
            this.GridDataTable.Dock = DockStyle.Bottom;
            PriceLimit_TrackBar.Value = PriceLimit_TrackBar.Maximum;
            PriceLimit_Label.Text = PriceLimit_TrackBar.Value.ToString() + "0.000.000";
        }

        private void DataTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string serialID = productList[e.RowIndex].serialID;
                PRODUCT pro = ProductServices.Instance.GetProductBySerial(serialID);
                ModelProduct model = ModelProduct.DatabaseToModel(pro, Database.DataProvider.Instance.Database.DETAIL_IMPORT_WAREHOUSE.FirstOrDefault(item => item.PRODUCT_ID == pro.PRODUCT_ID), pro.DETAIL_SPECS.COMMON_SPECS.LINE_UP, pro.DETAIL_SPECS.UNIQUE_SPECS.DISPLAY_SPECS, pro.DETAIL_SPECS.UNIQUE_SPECS, pro.DETAIL_SPECS.COMMON_SPECS, pro.DETAIL_SPECS.COLOR);
                BaseDetailSpecsProduct detailSpecs = null;
                detailSpecs = new OverviewDetailSpecsProduct_Form();
                detailSpecs.ShowDialog(this, model.ToList());
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

        private void View(BindingList<ModelSale> productList)
        {
            bindingSource1.ResetBindings(true);
            bindingSource1.DataSource = productList;
            foreach (DataGridViewRow row in GridDataTable.Rows)
            {
                ModelSale selected = row.DataBoundItem as ModelSale;
                if (selected != null)
                {
                    row.Cells["Name"].Value = selected.name;
                    row.Cells["Price"].Value = selected.price;
                    row.Cells["Size"].Value = selected.sizePanel + " inch";
                    row.Cells["Resolution"].Value = selected.resolution;
                    row.Cells["CPU"].Value = selected.cpu;
                    row.Cells["RAMString"].Value = selected.memory.ToString().Substring(0, 4);
                    row.Cells["GPU"].Value = selected.gpu;
                    row.Cells["StorageCapacity"].Value = selected.storagecap + " GB";
                    row.Cells["Color"].Value = selected.color;
                  
                }
            }
        }

        public void Run(BindingList<ModelSale> productList)
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

        private BindingList<ModelSale> GetListView()
        {
            productList = new BindingList<ModelSale>();
            //List<DETAIL_SPECS> detailSpecs = Database.DataProvider.Instance.Database.DETAIL_SPECS.Select(item => item).ToList();
            //foreach (DETAIL_SPECS detail in detailSpecs)
            //{
            //    UNIQUE_SPECS uniqueSpecs = detail.UNIQUE_SPECS;
            //    DISPLAY_SPECS display = uniqueSpecs.DISPLAY_SPECS;
            //    COLOR color = detail.COLOR;
            //    COMMON_SPECS commonSpecs = detail.COMMON_SPECS;
            //    LINE_UP lineup = commonSpecs.LINE_UP;
            //    ICollection<PRODUCT> products = detail.PRODUCTs;

            //    foreach (PRODUCT product in products)
            //    {
            //        DETAIL_IMPORT_WAREHOUSE detailImport = product.DETAIL_IMPORT_WAREHOUSE.First(item => item.PRODUCT_ID == product.PRODUCT_ID);
            //        ModelProduct productMD = ModelProduct.DatabaseToModel(product, detailImport, lineup, display, uniqueSpecs, commonSpecs, color);
            //        productMD.Price = detail.PRICE;
            //        productList.Add(productMD);
            //    }
            //}
            IList<PRODUCT> products = Database.DataProvider.Instance.Database.PRODUCTs.ToList();
            foreach (var product in products)
            {
                productList.Add(new ModelSale()
                {
                    serialID = product.SERIAL_ID,
                    name = product.DETAIL_SPECS.COMMON_SPECS.NAME,
                    price = product.DETAIL_SPECS.PRICE ?? 0.0d,
                    sizePanel = product.DETAIL_SPECS.UNIQUE_SPECS.DISPLAY_SPECS.SIZE.Value,
                    cpu = product.DETAIL_SPECS.UNIQUE_SPECS.CPU,
                    gpu = product.DETAIL_SPECS.UNIQUE_SPECS.GPU,
                    memory = product.DETAIL_SPECS.UNIQUE_SPECS.RAM,
                    resolution = product.DETAIL_SPECS.UNIQUE_SPECS.DISPLAY_SPECS.RESOLUTION,
                    storagecap = product.DETAIL_SPECS.UNIQUE_SPECS.STORAGE_CAPACITY.Value,
                    color = product.DETAIL_SPECS.COLOR.COLOR_NAME

                });

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

        void Search()
        {
            string size = Size_ComboBox.SelectedIndex == 0 ? size = string.Empty : Size_ComboBox.Text.ToLower();
            string resolution = Resolution_ComboBox.SelectedIndex == 0 ? resolution = string.Empty : Resolution_ComboBox.Text;
            string cpu = CPU_ComboBox.SelectedIndex == 0 ? cpu = string.Empty : CPU_ComboBox.Text;
            string vga = VGA_ComboBox.SelectedIndex == 0 ? vga = string.Empty : VGA_ComboBox.Text;
            string ram = RAM_ComboBox.SelectedIndex == 0 ? ram = string.Empty : RAM_ComboBox.Text;
            string storage = Storage_ComboBox.SelectedIndex == 0 ? storage = string.Empty : Storage_ComboBox.Text;
            int priceLimit = PriceLimit_TrackBar.Value * 10000000;
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[GridDataTable.DataSource];
                cm.SuspendBinding();

                foreach (DataGridViewRow row in GridDataTable.Rows)
                {
                    if (row.Cells["Name"].Value.ToString().ToLower().Contains(SearchBox.Text.ToLower()) &&
                        row.Cells["Color"].Value.ToString().ToLower().Contains(ColorSearch_Box.Text.ToLower()) &&
                        row.Cells["Size"].Value.ToString().Contains(size) &&
                        row.Cells["Resolution"].Value.ToString().Contains(resolution) &&
                        row.Cells["CPU"].Value.ToString().Contains(cpu) &&
                        row.Cells["RAMString"].Value.ToString().Trim().Contains(ram) &&
                        row.Cells["StorageCapacity"].Value.ToString().Contains(storage)
                    // && int.Parse(row.Cells["Price"].Value.ToString().Trim()) <= (PriceLimit_TrackBar.Value * 10000000);
                    // && (row.Cells["GPU"].Value.ToString().Contains(vga) && row.Cells["GPU"].Value != null)
                    )
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
                cm.ResumeBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Size_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void CPU_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void VGA_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void RAM_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Storage_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Resolution_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void ColorSearch_Box_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void PriceLimit_TrackBar_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}

