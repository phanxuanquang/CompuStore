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
    public partial class ReturnDetail_Form : Form
    {
        RECEIVE_WARRANTY warrantyCurrent;
        DETAIL_INVOICE detail;
        CUSTOMER customer;
        public ReturnDetail_Form(object warrantyD)
        {
            if (warrantyD != null)
            {
                warrantyCurrent = warrantyD as RECEIVE_WARRANTY;
            }
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            OldItemSerial_Box.ReadOnly = Identity_Box.ReadOnly = Name_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = NewItemSerial_Box.ReadOnly= ReturnReason.ReadOnly = NewItemSerial_Box.ReadOnly = true;
         
            this.Load += WarrantyDetail_Form_Load;
        }

        private void WarrantyDetail_Form_Load(object sender, EventArgs e)
        {
            if (warrantyCurrent != null)
            {
                cHANGEORREFUNDPRODUCTBindingSource.DataSource = warrantyCurrent;
                iNFORBindingSource.DataSource = warrantyCurrent.INVOICE.CUSTOMER.INFOR;
                pRODUCTBindingSource.DataSource = warrantyCurrent.PRODUCT;
                lbStaffName.Text += " " + warrantyCurrent.STAFF.INFOR.NAME;
                lbDate.Text += " " + warrantyCurrent.RECEIVE_DATE.ToString();
            }
           
            TurnOnAutocomplete();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditAndSave_Button_Click(object sender, EventArgs e)
        {
            if (EditAndSave_Button.Text == "SỬA HÓA ĐƠN")
            {
                OldItemSerial_Box.Width = 406;
                ReturnReason.ReadOnly = false;
      
                EditAndSave_Button.Text = "LƯU THÔNG TIN";
            }
            else
            {


                try
                {
                   
                    Database.DataProvider.Instance.Database.SaveChanges();
                    MessageBox.Show("Chỉnh sửa thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();

                OldItemSerial_Box.Width = 548;
                OldItemSerial_Box.ReadOnly = Identity_Box.ReadOnly = Name_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = ReturnReason.ReadOnly = true;
                EditAndSave_Button.Text = "SỬA HÓA ĐƠN";
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
                MessageBox.Show("Không tìm thấy hóa đơn bán sản phẩm này.", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Print_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không tim thấy máy in. Vui lòng thử lại sau.", "Không tìm thấy máy in", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

       
    }
}
