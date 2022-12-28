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
                dataRow[0] = item.PRODUCT.SERIAL_ID;
                dataRow[1] = item.PRODUCT.DETAIL_SPECS.COMMON_SPECS.NAME;
                if (item.PRODUCT.DETAIL_SPECS.PRICE != null)
                {
                    dataRow[2] = item.PRODUCT.DETAIL_SPECS.PRICE;
                }
                else
                {
                    dataRow[2] = 10000000;
                }
                int insertPosition = adjustmentTable.Rows.Count;
                adjustmentTable.Rows.InsertAt(dataRow, insertPosition);
            }
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
            dataColumn = new DataColumn("Số se-ri", typeof(string));
            adjustmentTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Tên sản phẩm", typeof(string));
            adjustmentTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Giá tiền", typeof(double));
            adjustmentTable.Columns.Add(dataColumn);
            ItemTable.DataSource = adjustmentTable;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Print_Button_Click(object sender, EventArgs e)
        {
            this.Close();
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
