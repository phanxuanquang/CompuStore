﻿using CompuStore.Database.Models;
using CompuStore.Database.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore
{
    public partial class StaffEdit_Form : Form
    {
        STAFF staffCurrent;
        public StaffEdit_Form(bool notReadOnly, string headerName, object staff)
        {

            if (staff != null)
            {
                staffCurrent = staff as STAFF;
            }
            InitializeComponent();
            ShadowForm.SetShadowForm(this);
            Name_Box.ReadOnly = Identity_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = Address_Box.ReadOnly = !notReadOnly;
            DateTimeImportWarehouse_DateTimePicker.Enabled = notReadOnly;
            Header.Text = headerName;
            if (headerName == "THÊM NHÂN VIÊN")
            {
               Edit_Button.Text = "LƯU";
            }
            else if (headerName == "XEM THÔNG TIN")
            {
                Edit_Button.Text = "CHỈNH SỬA";
            }
            else if(headerName == "CHỈNH SỬA THÔNG TIN")
            {
                Edit_Button.Text = "LƯU";
            }
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

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if(Edit_Button.Text == "LƯU")
            {
                SaveFromTextboxToDB();
                this.Close();
                return;
            }

            Name_Box.ReadOnly = Identity_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = Address_Box.ReadOnly =false;
            DateTimeImportWarehouse_DateTimePicker.Enabled = true;
            Header.Text = "CHỈNH SỬA THÔNG TIN";
            this.Close();
        }

        private void SaveFromTextboxToDB()
        {
            if (CheckEmptyInput())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!CheckEmail(Email_Box.Text))
            {
                MessageBox.Show("E-mail không hợp lệ. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = Name_Box.Text;
            string identity = Identity_Box.Text;
            string phoneNumber = PhoneNumber_Box.Text;
            string email = Email_Box.Text;
            string address = Address_Box.Text;
            DateTime staffDate = DateTimeImportWarehouse_DateTimePicker.Value;
            int idStaffRole = (sTAFFROLEBindingSource.Current as STAFFROLE).ID;

            if (StaffServices.Instance.SaveStaffToDB(name, phoneNumber, email, true, staffDate, identity, address, idStaffRole))
            {
                MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckEmptyInput()
        {
            return String.IsNullOrEmpty(Name_Box.Text) || String.IsNullOrEmpty(Identity_Box.Text) || String.IsNullOrEmpty(PhoneNumber_Box.Text) || String.IsNullOrEmpty(Email_Box.Text) || String.IsNullOrEmpty(Address_Box.Text);
        }

        public bool CheckEmail(string emailAddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void StaffEdit_Form_Load(object sender, EventArgs e)
        {
            if (staffCurrent != null)
            {
                iNFORBindingSource.DataSource = staffCurrent.INFOR;
                Apartment_ComboBox.DisplayMember = "ROLE";
                Apartment_ComboBox.SelectedValue = staffCurrent.STAFFROLE.ID;
            }
            else
            {
                DateTimeImportWarehouse_DateTimePicker.Value = DateTime.Today;
            }
            sTAFFROLEBindingSource.DataSource = StaffRoleServices.Instance.GetSTAFFROLEs();
        }
    }
}
