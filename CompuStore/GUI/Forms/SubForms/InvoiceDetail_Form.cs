using System;
using CompuStore.Database.Models;
using CompuStore.Database.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using CompuStore.Database.Services.ProductServices;
using CompuStore.ImportData;
using CompuStore.Utilities.ExportPDF;
using System.IO;
using System.Globalization;

namespace CompuStore
{
    public partial class InvoiceDetail_Form : Form
    {
       
        CUSTOMER customer = new CUSTOMER();
        List<string> addedProduct = new List<string>();
        List<PRODUCT> productList = new List<PRODUCT>();
        DataTable adjustmentTable;
        INVOICE invoice;
        string id;
        CultureInfo ci = new CultureInfo("vi-vn");
        int stt = 0;
        long sumM = 0;

        public InvoiceDetail_Form(string id)
        {
            this.id = id;
            InitializeComponent();
            this.Icon = Properties.Resources.Icon;
            this.ShowInTaskbar = false;
            guna2ShadowForm1.SetShadowForm(this);
            this.Load += AddInvoice_Form_Load;
            this.Identity_Box.KeyPress += Identity_Box_KeyPress;
        }

        private void AddInvoice_Form_Load(object sender, EventArgs e)
        {
            InitDGV();
            invoice = Database.DataProvider.Instance.Database.INVOICEs.Where(x => x.NAME_ID == id).FirstOrDefault();
            LoadLabel();
            LoadData();
            LoadCustomer();
        }

        private void LoadLabel()
        {
            lbDate.Text += " " + invoice.INVOICE_DATE.ToString();
            lbStaffName.Text += " " + invoice.STAFF.INFOR.NAME.ToString();
        }

        private void LoadData()
        {
            ItemTable.DataSource = GetAdjustmentTable();
        }

        private DataTable GetAdjustmentTable()
        {
            List<DETAIL_INVOICE> listInvoice = Database.DataProvider.Instance.Database.DETAIL_INVOICE.Where(item => item.ID_INVOICE == invoice.ID).ToList();
            foreach (DETAIL_INVOICE item in listInvoice)
            {
                DataRow dataRow = adjustmentTable.NewRow();
                dataRow[0] = ++stt;
                dataRow[1] = item.PRODUCT.SERIAL_ID;
                dataRow[2] = item.PRODUCT.DETAIL_SPECS.COMMON_SPECS.NAME;
                if (item.PRODUCT.DETAIL_SPECS.PRICE != null)
                {
                    dataRow[3] = item.PRODUCT.DETAIL_SPECS.PRICE;
                }
                else
                {
                    dataRow[3] = 10000000;
                }
                sumM += long.Parse(dataRow[3].ToString());
                int insertPosition = adjustmentTable.Rows.Count;
                adjustmentTable.Rows.InsertAt(dataRow, insertPosition);
            }
            this.label2.Text = sumM.ToString("N03", ci) + " VNĐ";
            return adjustmentTable;
        }

        private void LoadCustomer()
        {
            customer = Database.DataProvider.Instance.Database.CUSTOMERs.Where(item => item.ID == invoice.ID_CUSTOMER).FirstOrDefault();
            Identity_Box.Text = customer.INFOR.IDENTITY_CODE;
            Name_Box.Text = customer.INFOR.NAME;
            PhoneNumber_Box.Text = customer.INFOR.PHONE_NUMBER;
            Email_Box.Text = customer.INFOR.EMAIL;
            Address_Box.Text = customer.INFOR.ADDRESS;
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

        private void InitDGV()
        {
            adjustmentTable = new DataTable();
            DataColumn dataColumn = new DataColumn();
            dataColumn = new DataColumn("Số thứ tự", typeof(int));
            adjustmentTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Số se-ri", typeof(string));
            adjustmentTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Tên sản phẩm", typeof(string));
            adjustmentTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Giá tiền (VNĐ)", typeof(double));
            adjustmentTable.Columns.Add(dataColumn);
            ItemTable.DataSource = adjustmentTable;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Print_Button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            ExportPDF export = new ExportPDF();
            IDataExport data = new InvoicePDF
            {
                ExportPath = Path.Combine(dialog.SelectedPath, "export.html"),
                DataBindingTemplate = new
                {
                    data = new
                    {
                        id_invoice = invoice.NAME_ID,
                        date = invoice.INVOICE_DATE,
                        customer_name = invoice.CUSTOMER.INFOR.NAME,
                        phone_customer = invoice.CUSTOMER.INFOR.PHONE_NUMBER,
                        company = "XL COMPANY",
                        address = "123 KTX KHU A",
                        phone_company = "382765235",
                        total = invoice.TOTAL,
                        products = invoice.DETAIL_INVOICE.Select(item => new { name = item.PRODUCT.DETAIL_SPECS.COMMON_SPECS.NAME, price = item.PRICE_PER_UNIT })
                    }
                }
            };
            bool result = await export.RunExport(data);
            MessageBox.Show(result ? "Xuất thành công" : "Xuất thất bại");
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            customer.INFOR.IDENTITY_CODE = Identity_Box.Text;
            customer.INFOR.NAME = Name_Box.Text;
            customer.INFOR.PHONE_NUMBER = PhoneNumber_Box.Text;
            customer.INFOR.EMAIL = Email_Box.Text;
            customer.INFOR.ADDRESS = Address_Box.Text;
            invoice.ID_CUSTOMER = customer.ID;
            try
            {
                Database.DataProvider.Instance.Database.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Lưu thông tin hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Identity_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (customer.INFOR.IDENTITY_CODE != Identity_Box.Text)
            {
                CUSTOMER cus = CustomerServices.Instance.GetCustomerByIDCode(Identity_Box.Text);
                if (cus != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Khách hàng có số CMND/CCCD này đã tồn tại trong hệ thống.\nBạn có muốn cập nhật sang khách hàng đó?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        customer = cus;
                        Name_Box.Text = cus.INFOR.NAME;
                        PhoneNumber_Box.Text = cus.INFOR.PHONE_NUMBER;
                        Email_Box.Text = cus.INFOR.EMAIL;
                        Address_Box.Text = cus.INFOR.ADDRESS;
                    }
                }
            }
        }
    }
}
