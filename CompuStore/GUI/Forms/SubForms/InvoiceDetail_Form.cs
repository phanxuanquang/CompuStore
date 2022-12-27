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
       
        CUSTOMER customer;
        List<string> addedProduct = new List<string>();
        List<PRODUCT> productList = new List<PRODUCT>();
        STAFF currentStaff;
        DataTable adjustmentTable;
        INVOICE invoice;
        string id;

        public InvoiceDetail_Form(string id)
        {
            this.id = id;
            InitializeComponent();
            this.Load += AddInvoice_Form_Load;
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
            CUSTOMER customer = Database.DataProvider.Instance.Database.CUSTOMERs.Where(item => item.ID == invoice.ID_CUSTOMER).FirstOrDefault();
            Identity_Box.Text = customer.INFOR.IDENTITY_CODE;
            Name_Box.Text = customer.INFOR.NAME;
            PhoneNumber_Box.Text = customer.INFOR.PHONE_NUMBER;
            Email_Box.Text = customer.INFOR.EMAIL;
            Address_Box.Text = customer.INFOR.ADDRESS;
            Name_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = Address_Box.ReadOnly = true;
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
            ItemTable.CellDoubleClick += ItemTable_CellDoubleClick;
        }

        private void ItemTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ItemTable.Rows.RemoveAt(e.RowIndex);
                addedProduct.RemoveAt(e.RowIndex);
            }    
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
