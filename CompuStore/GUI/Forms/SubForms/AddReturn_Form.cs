using CompuStore.Database.Models;
using CompuStore.Database.Services;
using Guna.UI2.WinForms;
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
    public partial class AddReturn_Form : Form
    {
        DETAIL_INVOICE detail;
        CUSTOMER customer;
        STAFF currentStaff;
        public AddReturn_Form()
        {
            InitializeComponent();
            this.Load += AddReturn_Form_Load;
        }

        private void AddReturn_Form_Load(object sender, EventArgs e)
        {
            TurnOnAutocomplete();
            LoadLabel();
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

        private void LoadLabel()
        {
            currentStaff = LoginServices.Instance.CurrentStaff;
            lbStaffName.Text += " " + currentStaff.INFOR.NAME;
            lbDate.Text += " " + DateTime.Now.Date;
        }
        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (isValidSerialID(detail))
            {
                if (Database.DataProvider.Instance.Database.PRODUCTs.FirstOrDefault(item => item.SERIAL_ID == NewItemSerial_Box.Text) == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm mới trong kho");
                    return;
                }
                Exception res = ChangeOrRefundProductServices.Instance.SaveCOrreFundToDB(detail.ID_INVOICE, currentStaff.ID, Database.DataProvider.Instance.Database.PRODUCTs.FirstOrDefault(item => item.SERIAL_ID == OldItemSerial_Box.Text).PRODUCT_ID, Database.DataProvider.Instance.Database.PRODUCTs.FirstOrDefault(item => item.SERIAL_ID == NewItemSerial_Box.Text).PRODUCT_ID, ReturnReason.Text, DateTime.Now);
                if (res.Message == "done")
                {
                    MessageBox.Show("Lưu thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res.Message);
                }
            }
        }

        private bool isValidSerialID(DETAIL_INVOICE detail)
        {
            if (detail == null)
            {
                return false;
            }
            return true;
        }

        private void TurnOnAutocomplete()
        {
            List<DETAIL_INVOICE> arrayOfWowrds1 = new List<DETAIL_INVOICE>();
            try
            {
                //Read in data Autocomplete list to a string[]
                arrayOfWowrds1 = DetailInvoiceServices.Instance.GetDETAIL_INVOICEs();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            AddAutoCompleteCource(OldItemSerial_Box, arrayOfWowrds1.Select(item => item.PRODUCT.SERIAL_ID).ToArray());
        }

        public void AddAutoCompleteCource(Guna2TextBox textBox, string[] strings)
        {
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(strings);
            textBox.AutoCompleteCustomSource = collection;
        }

        private void AddInfor_Button_Click(object sender, EventArgs e)
        {
            detail = InvoiceServices.Instance.GetDetailBySerialID((OldItemSerial_Box.Text));
            if (!isValidSerialID(detail))
            {
                MessageBox.Show("Không tìm thấy hóa đơn bán sản phẩm này");
            }
            else
            {
                customer = detail.INVOICE.CUSTOMER;
                Identity_Box.Text = customer.INFOR.IDENTITY_CODE;
                Name_Box.Text = customer.INFOR.NAME;
                PhoneNumber_Box.Text = customer.INFOR.PHONE_NUMBER;
                Email_Box.Text = customer.INFOR.EMAIL;
            }
        }
    }
}
