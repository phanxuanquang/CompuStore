﻿using System;
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

namespace CompuStore
{
    public partial class AddInvoice_Form : Form
    {
        CUSTOMER customer;
        public Dictionary<COMMON_SPECS, int> listProduct = new Dictionary<COMMON_SPECS, int>();
        List<PRODUCT> productList = new List<PRODUCT>();
        STAFF currentStaff;
        public AddInvoice_Form(Dictionary<COMMON_SPECS, int> listProduct)
        {
            InitializeComponent();
            LoadLabel();
            this.listProduct = listProduct;
            LoadData();
        }

        private void LoadLabel()
        {
            currentStaff = LoginServices.Instance.CurrentStaff;
            lbStaffName.Text += " " + currentStaff.INFOR.NAME;
            lbDate.Text += " " + DateTime.Now.ToLongDateString();
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

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool isValidCustomer(CUSTOMER customer)
        {
            if (customer == null)
            {
                return false;
            }    
            return true;
        }

        private void LoadData()
        {
            ItemTable.Rows.Clear();
            int count = 1;
            double temp = 0;
            List<double> prices = new List<double>();
            foreach (var item in listProduct)
            {
                var detail = Database.DataProvider.Instance.Database.DETAIL_SPECS.Where(x => x.ID_COMMON_SPECS == item.Key.ID).FirstOrDefault();
                if (detail.PRICE != null)
                {
                    prices.Add((double)detail.PRICE);
                }
                else
                {
                    prices.Add(100000);
                }    
            }    
            foreach (var item in listProduct)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(ItemTable);
                newRow.Cells[0].Value = count;
                newRow.Cells[1].Value = item.Key.NAME;
                newRow.Cells[2].Value = item.Value;
                temp = prices[count - 1];
                newRow.Cells[3].Value = temp;
                newRow.Cells[4].Value = temp * item.Value;
                count++;
                ItemTable.Rows.Add(newRow);
            }    
 
        }

        private void Identity_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                customer = CustomerServices.Instance.GetCustomerByIDCode(Identity_Box.Text);
                if (!isValidCustomer(customer))
                {
                    DialogResult dialogResult = MessageBox.Show("CMND/CCCD của khách hàng này không tồn tại.\nBạn có muốn thêm khách hàng mới?", "CMND/CCCD không tồn tại", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Name_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = Address_Box.ReadOnly = false;
                        Identity_Box.Text = String.Empty;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            foreach (var item in listProduct)
            {
                productList.Add(Database.DataProvider.Instance.Database.PRODUCTs.Where(prod => prod.DETAIL_SPECS.ID_COMMON_SPECS == item.Key.ID).FirstOrDefault());
            }    

            if (customer == null)
            {
                customer = CustomerServices.Instance.SaveCustomerToDB(Name_Box.Text, PhoneNumber_Box.Text, Email_Box.Text, Identity_Box.Text, Address_Box.Text);
            }
            Exception res = InvoiceServices.Instance.SaveInvoiceToDB(productList, customer.ID, currentStaff.ID, DateTime.Now, 10);
            if (res.Message == "done")
            {
                MessageBox.Show("Lưu thành công");
            }
            else
            {
                MessageBox.Show(res.Message);
            }
            this.Close();
        }

        private void AddInvoice_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompuStore.Tab.SaleManagement_Tab.listProduct.Clear();
            CompuStore.Tab.SaleManagement_Tab.nameIdCommonSpecs = null;
        }
    }
}
