﻿using CompuStore.Database.Services;
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
        public StaffEdit_Form(bool notReadOnly, string headerName)
        {
            InitializeComponent();
            ShadowForm.SetShadowForm(this);
            Name_Box.ReadOnly = Identity_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = Address_Box.ReadOnly = StaffDate_Box.ReadOnly = Edit_Button.Visible = !notReadOnly;
            
            Header.Text = headerName;
            if (headerName == "THÊM NHÂN VIÊN")
            {
                Edit_Button.Visible = StaffDate_Box.Visible = false;
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
            Name_Box.ReadOnly = Identity_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = Address_Box.ReadOnly = StaffDate_Box.Visible = Edit_Button.Visible = false;
            Header.Text = "CHỈNH SỬA THÔNG TIN";
            if (CheckEmptyInput())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private bool CheckEmptyInput()
        {
            return String.IsNullOrEmpty(Name_Box.Text) || String.IsNullOrEmpty(Identity_Box.Text) || String.IsNullOrEmpty(PhoneNumber_Box.Text) || String.IsNullOrEmpty(Email_Box.Text) || String.IsNullOrEmpty(PhoneNumber_Box.Text) || String.IsNullOrEmpty(Address_Box.Text);
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
            sTAFFROLEBindingSource.DataSource = StaffRoleServices.Instance.GetSTAFFROLEs();
            DateTimeImportWarehouse_DateTimePicker.Value = DateTime.Today;
        }
    }
}
