﻿namespace CompuStore
{
    partial class WarrantyDetail_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Header = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WarrantyDoneDate_Picker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.ItemSerial_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbDate = new System.Windows.Forms.Label();
            this.Email_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Name_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbStaffName = new System.Windows.Forms.Label();
            this.PhoneNumber_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Identity_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.WarrantyReason = new Guna.UI2.WinForms.Guna2TextBox();
            this.EditAndSave_Button = new Guna.UI2.WinForms.Guna2Button();
            this.HeaderIcon = new System.Windows.Forms.PictureBox();
            this.Exit_Button = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Status_ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.warrantyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pRODUCTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iNFORBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warrantyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNFORBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Header.ForeColor = System.Drawing.Color.White;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.Header.Size = new System.Drawing.Size(623, 40);
            this.Header.TabIndex = 41;
            this.Header.Text = "Thông tin phiếu gửi bảo hành";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Header.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 242);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 24);
            this.label1.TabIndex = 89;
            this.label1.Text = "Ngày hẹn trả bảo hành:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WarrantyDoneDate_Picker
            // 
            this.WarrantyDoneDate_Picker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WarrantyDoneDate_Picker.Animated = true;
            this.WarrantyDoneDate_Picker.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.WarrantyDoneDate_Picker.CheckedState.Parent = this.WarrantyDoneDate_Picker;
            this.WarrantyDoneDate_Picker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WarrantyDoneDate_Picker.CustomFormat = " dd/MM/yyyy";
            this.WarrantyDoneDate_Picker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.warrantyBindingSource, "RETURN_DATE", true));
            this.WarrantyDoneDate_Picker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.WarrantyDoneDate_Picker.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarrantyDoneDate_Picker.ForeColor = System.Drawing.Color.Black;
            this.WarrantyDoneDate_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.WarrantyDoneDate_Picker.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.WarrantyDoneDate_Picker.HoverState.Parent = this.WarrantyDoneDate_Picker;
            this.WarrantyDoneDate_Picker.Location = new System.Drawing.Point(218, 237);
            this.WarrantyDoneDate_Picker.Margin = new System.Windows.Forms.Padding(0);
            this.WarrantyDoneDate_Picker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.WarrantyDoneDate_Picker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.WarrantyDoneDate_Picker.Name = "WarrantyDoneDate_Picker";
            this.WarrantyDoneDate_Picker.ShadowDecoration.Parent = this.WarrantyDoneDate_Picker;
            this.WarrantyDoneDate_Picker.Size = new System.Drawing.Size(167, 38);
            this.WarrantyDoneDate_Picker.TabIndex = 88;
            this.WarrantyDoneDate_Picker.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.WarrantyDoneDate_Picker.Value = new System.DateTime(2022, 10, 18, 0, 0, 0, 0);
            // 
            // ItemSerial_Box
            // 
            this.ItemSerial_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ItemSerial_Box.Animated = true;
            this.ItemSerial_Box.BackColor = System.Drawing.Color.Transparent;
            this.ItemSerial_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.ItemSerial_Box.BorderRadius = 8;
            this.ItemSerial_Box.BorderThickness = 2;
            this.ItemSerial_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ItemSerial_Box.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pRODUCTBindingSource, "SERIAL_ID", true));
            this.ItemSerial_Box.DefaultText = "";
            this.ItemSerial_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ItemSerial_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ItemSerial_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ItemSerial_Box.DisabledState.Parent = this.ItemSerial_Box;
            this.ItemSerial_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ItemSerial_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.ItemSerial_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.ItemSerial_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.ItemSerial_Box.FocusedState.Parent = this.ItemSerial_Box;
            this.ItemSerial_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ItemSerial_Box.ForeColor = System.Drawing.Color.Black;
            this.ItemSerial_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.ItemSerial_Box.HoverState.Parent = this.ItemSerial_Box;
            this.ItemSerial_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.ItemSerial_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.ItemSerial_Box.Location = new System.Drawing.Point(36, 67);
            this.ItemSerial_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ItemSerial_Box.Name = "ItemSerial_Box";
            this.ItemSerial_Box.PasswordChar = '\0';
            this.ItemSerial_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.ItemSerial_Box.PlaceholderText = "Mã se-ri sản phẩm bảo hành";
            this.ItemSerial_Box.ReadOnly = true;
            this.ItemSerial_Box.SelectedText = "";
            this.ItemSerial_Box.ShadowDecoration.Parent = this.ItemSerial_Box;
            this.ItemSerial_Box.Size = new System.Drawing.Size(551, 37);
            this.ItemSerial_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.ItemSerial_Box.TabIndex = 87;
            this.ItemSerial_Box.TextOffset = new System.Drawing.Point(5, 0);
            this.toolTip1.SetToolTip(this.ItemSerial_Box, "Mã se-ri sản phẩm bảo hành");
            // 
            // lbDate
            // 
            this.lbDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(34, 309);
            this.lbDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(75, 20);
            this.lbDate.TabIndex = 86;
            this.lbDate.Text = "Ngày lập:";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Email_Box
            // 
            this.Email_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Email_Box.Animated = true;
            this.Email_Box.BackColor = System.Drawing.Color.Transparent;
            this.Email_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Email_Box.BorderRadius = 8;
            this.Email_Box.BorderThickness = 2;
            this.Email_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Email_Box.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNFORBindingSource, "EMAIL", true));
            this.Email_Box.DefaultText = "";
            this.Email_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Email_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Email_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Email_Box.DisabledState.Parent = this.Email_Box;
            this.Email_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Email_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Email_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Email_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.Email_Box.FocusedState.Parent = this.Email_Box;
            this.Email_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Email_Box.ForeColor = System.Drawing.Color.Black;
            this.Email_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Email_Box.HoverState.Parent = this.Email_Box;
            this.Email_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Email_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Email_Box.Location = new System.Drawing.Point(357, 149);
            this.Email_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Email_Box.Name = "Email_Box";
            this.Email_Box.PasswordChar = '\0';
            this.Email_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Email_Box.PlaceholderText = "E-mail";
            this.Email_Box.ReadOnly = true;
            this.Email_Box.SelectedText = "";
            this.Email_Box.ShadowDecoration.Parent = this.Email_Box;
            this.Email_Box.Size = new System.Drawing.Size(230, 37);
            this.Email_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Email_Box.TabIndex = 81;
            this.Email_Box.TextOffset = new System.Drawing.Point(5, 0);
            this.toolTip1.SetToolTip(this.Email_Box, "E-mail");
            // 
            // Name_Box
            // 
            this.Name_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Name_Box.Animated = true;
            this.Name_Box.BackColor = System.Drawing.Color.Transparent;
            this.Name_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Name_Box.BorderRadius = 8;
            this.Name_Box.BorderThickness = 2;
            this.Name_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Name_Box.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNFORBindingSource, "NAME", true));
            this.Name_Box.DefaultText = "";
            this.Name_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Name_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Name_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Name_Box.DisabledState.Parent = this.Name_Box;
            this.Name_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Name_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Name_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Name_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.Name_Box.FocusedState.Parent = this.Name_Box;
            this.Name_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name_Box.ForeColor = System.Drawing.Color.Black;
            this.Name_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Name_Box.HoverState.Parent = this.Name_Box;
            this.Name_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Name_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Name_Box.Location = new System.Drawing.Point(36, 149);
            this.Name_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name_Box.Name = "Name_Box";
            this.Name_Box.PasswordChar = '\0';
            this.Name_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Name_Box.PlaceholderText = "Họ và tên khách hàng";
            this.Name_Box.ReadOnly = true;
            this.Name_Box.SelectedText = "";
            this.Name_Box.ShadowDecoration.Parent = this.Name_Box;
            this.Name_Box.Size = new System.Drawing.Size(312, 37);
            this.Name_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Name_Box.TabIndex = 80;
            this.Name_Box.TextOffset = new System.Drawing.Point(5, 0);
            this.toolTip1.SetToolTip(this.Name_Box, "Họ và tên khách hàng");
            // 
            // lbStaffName
            // 
            this.lbStaffName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbStaffName.AutoSize = true;
            this.lbStaffName.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStaffName.Location = new System.Drawing.Point(35, 275);
            this.lbStaffName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStaffName.Name = "lbStaffName";
            this.lbStaffName.Size = new System.Drawing.Size(81, 20);
            this.lbStaffName.TabIndex = 85;
            this.lbStaffName.Text = "Người lập:";
            this.lbStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PhoneNumber_Box
            // 
            this.PhoneNumber_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PhoneNumber_Box.Animated = true;
            this.PhoneNumber_Box.BackColor = System.Drawing.Color.Transparent;
            this.PhoneNumber_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.PhoneNumber_Box.BorderRadius = 8;
            this.PhoneNumber_Box.BorderThickness = 2;
            this.PhoneNumber_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PhoneNumber_Box.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNFORBindingSource, "PHONE_NUMBER", true));
            this.PhoneNumber_Box.DefaultText = "";
            this.PhoneNumber_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PhoneNumber_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PhoneNumber_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PhoneNumber_Box.DisabledState.Parent = this.PhoneNumber_Box;
            this.PhoneNumber_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PhoneNumber_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.PhoneNumber_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.PhoneNumber_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.PhoneNumber_Box.FocusedState.Parent = this.PhoneNumber_Box;
            this.PhoneNumber_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PhoneNumber_Box.ForeColor = System.Drawing.Color.Black;
            this.PhoneNumber_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.PhoneNumber_Box.HoverState.Parent = this.PhoneNumber_Box;
            this.PhoneNumber_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.PhoneNumber_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.PhoneNumber_Box.Location = new System.Drawing.Point(355, 108);
            this.PhoneNumber_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PhoneNumber_Box.Name = "PhoneNumber_Box";
            this.PhoneNumber_Box.PasswordChar = '\0';
            this.PhoneNumber_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.PhoneNumber_Box.PlaceholderText = "Số điện thoại";
            this.PhoneNumber_Box.ReadOnly = true;
            this.PhoneNumber_Box.SelectedText = "";
            this.PhoneNumber_Box.ShadowDecoration.Parent = this.PhoneNumber_Box;
            this.PhoneNumber_Box.Size = new System.Drawing.Size(232, 37);
            this.PhoneNumber_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.PhoneNumber_Box.TabIndex = 79;
            this.PhoneNumber_Box.TextOffset = new System.Drawing.Point(5, 0);
            this.toolTip1.SetToolTip(this.PhoneNumber_Box, "Số điện thoại");
            // 
            // Identity_Box
            // 
            this.Identity_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Identity_Box.Animated = true;
            this.Identity_Box.BackColor = System.Drawing.Color.Transparent;
            this.Identity_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Identity_Box.BorderRadius = 8;
            this.Identity_Box.BorderThickness = 2;
            this.Identity_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Identity_Box.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNFORBindingSource, "IDENTITY_CODE", true));
            this.Identity_Box.DefaultText = "";
            this.Identity_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Identity_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Identity_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Identity_Box.DisabledState.Parent = this.Identity_Box;
            this.Identity_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Identity_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Identity_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Identity_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.Identity_Box.FocusedState.Parent = this.Identity_Box;
            this.Identity_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Identity_Box.ForeColor = System.Drawing.Color.Black;
            this.Identity_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Identity_Box.HoverState.Parent = this.Identity_Box;
            this.Identity_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Identity_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Identity_Box.Location = new System.Drawing.Point(36, 108);
            this.Identity_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Identity_Box.Name = "Identity_Box";
            this.Identity_Box.PasswordChar = '\0';
            this.Identity_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Identity_Box.PlaceholderText = "CMND/CCCD của khách hàng";
            this.Identity_Box.ReadOnly = true;
            this.Identity_Box.SelectedText = "";
            this.Identity_Box.ShadowDecoration.Parent = this.Identity_Box;
            this.Identity_Box.Size = new System.Drawing.Size(313, 37);
            this.Identity_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Identity_Box.TabIndex = 82;
            this.Identity_Box.TextOffset = new System.Drawing.Point(5, 0);
            this.toolTip1.SetToolTip(this.Identity_Box, "CMND/CCCD của khách hàng");
            // 
            // WarrantyReason
            // 
            this.WarrantyReason.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WarrantyReason.Animated = true;
            this.WarrantyReason.BackColor = System.Drawing.Color.Transparent;
            this.WarrantyReason.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.WarrantyReason.BorderRadius = 8;
            this.WarrantyReason.BorderThickness = 2;
            this.WarrantyReason.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.WarrantyReason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.warrantyBindingSource, "REASON_WARRANTY", true));
            this.WarrantyReason.DefaultText = "";
            this.WarrantyReason.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.WarrantyReason.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.WarrantyReason.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.WarrantyReason.DisabledState.Parent = this.WarrantyReason;
            this.WarrantyReason.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.WarrantyReason.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.WarrantyReason.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.WarrantyReason.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.WarrantyReason.FocusedState.Parent = this.WarrantyReason;
            this.WarrantyReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.WarrantyReason.ForeColor = System.Drawing.Color.Black;
            this.WarrantyReason.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.WarrantyReason.HoverState.Parent = this.WarrantyReason;
            this.WarrantyReason.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.WarrantyReason.IconLeftSize = new System.Drawing.Size(30, 30);
            this.WarrantyReason.Location = new System.Drawing.Point(36, 190);
            this.WarrantyReason.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WarrantyReason.Name = "WarrantyReason";
            this.WarrantyReason.PasswordChar = '\0';
            this.WarrantyReason.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.WarrantyReason.PlaceholderText = "Lý do bảo hành";
            this.WarrantyReason.ReadOnly = true;
            this.WarrantyReason.SelectedText = "";
            this.WarrantyReason.ShadowDecoration.Parent = this.WarrantyReason;
            this.WarrantyReason.Size = new System.Drawing.Size(551, 37);
            this.WarrantyReason.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.WarrantyReason.TabIndex = 90;
            this.WarrantyReason.TextOffset = new System.Drawing.Point(5, 0);
            this.toolTip1.SetToolTip(this.WarrantyReason, "Lý do bảo hành");
            // 
            // EditAndSave_Button
            // 
            this.EditAndSave_Button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EditAndSave_Button.Animated = true;
            this.EditAndSave_Button.BorderRadius = 3;
            this.EditAndSave_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.EditAndSave_Button.CheckedState.Parent = this.EditAndSave_Button;
            this.EditAndSave_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditAndSave_Button.CustomImages.Parent = this.EditAndSave_Button;
            this.EditAndSave_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.EditAndSave_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.EditAndSave_Button.ForeColor = System.Drawing.Color.White;
            this.EditAndSave_Button.HoverState.Parent = this.EditAndSave_Button;
            this.EditAndSave_Button.Location = new System.Drawing.Point(39, 343);
            this.EditAndSave_Button.Name = "EditAndSave_Button";
            this.EditAndSave_Button.PressedDepth = 5;
            this.EditAndSave_Button.ShadowDecoration.Parent = this.EditAndSave_Button;
            this.EditAndSave_Button.Size = new System.Drawing.Size(548, 57);
            this.EditAndSave_Button.TabIndex = 91;
            this.EditAndSave_Button.Text = "SỬA HÓA ĐƠN";
            this.EditAndSave_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.EditAndSave_Button.Click += new System.EventHandler(this.EditAndSave_Button_Click);
            // 
            // HeaderIcon
            // 
            this.HeaderIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.HeaderIcon.BackgroundImage = global::CompuStore.Properties.Resources.Service___Header;
            this.HeaderIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HeaderIcon.Location = new System.Drawing.Point(7, 7);
            this.HeaderIcon.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderIcon.Name = "HeaderIcon";
            this.HeaderIcon.Size = new System.Drawing.Size(25, 25);
            this.HeaderIcon.TabIndex = 43;
            this.HeaderIcon.TabStop = false;
            // 
            // Exit_Button
            // 
            this.Exit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Exit_Button.CheckedState.ImageSize = new System.Drawing.Size(25, 25);
            this.Exit_Button.CheckedState.Parent = this.Exit_Button;
            this.Exit_Button.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.Exit_Button.HoverState.Parent = this.Exit_Button;
            this.Exit_Button.Image = global::CompuStore.Properties.Resources.Close;
            this.Exit_Button.ImageSize = new System.Drawing.Size(27, 27);
            this.Exit_Button.Location = new System.Drawing.Point(583, -1);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.PressedState.Parent = this.Exit_Button;
            this.Exit_Button.Size = new System.Drawing.Size(40, 40);
            this.Exit_Button.TabIndex = 42;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.Header;
            // 
            // Status_ComboBox
            // 
            this.Status_ComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Status_ComboBox.Animated = true;
            this.Status_ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.Status_ComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Status_ComboBox.BorderRadius = 4;
            this.Status_ComboBox.BorderThickness = 2;
            this.Status_ComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Status_ComboBox.DisplayMember = "ID";
            this.Status_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Status_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Status_ComboBox.Enabled = false;
            this.Status_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Status_ComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Status_ComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Status_ComboBox.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Status_ComboBox.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.Status_ComboBox.FocusedState.Parent = this.Status_ComboBox;
            this.Status_ComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status_ComboBox.ForeColor = System.Drawing.Color.Black;
            this.Status_ComboBox.FormattingEnabled = true;
            this.Status_ComboBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Status_ComboBox.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Status_ComboBox.HoverState.ForeColor = System.Drawing.Color.Black;
            this.Status_ComboBox.HoverState.Parent = this.Status_ComboBox;
            this.Status_ComboBox.ItemHeight = 32;
            this.Status_ComboBox.ItemsAppearance.Parent = this.Status_ComboBox;
            this.Status_ComboBox.Location = new System.Drawing.Point(394, 237);
            this.Status_ComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Status_ComboBox.Name = "Status_ComboBox";
            this.Status_ComboBox.ShadowDecoration.Parent = this.Status_ComboBox;
            this.Status_ComboBox.Size = new System.Drawing.Size(193, 38);
            this.Status_ComboBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Status_ComboBox.TabIndex = 139;
            this.Status_ComboBox.TextOffset = new System.Drawing.Point(5, 0);
            this.Status_ComboBox.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.Status_ComboBox.ValueMember = "ID";
            // 
            // warrantyBindingSource
            // 
            this.warrantyBindingSource.DataSource = typeof(CompuStore.Database.Models.RECEIVE_WARRANTY);
            // 
            // pRODUCTBindingSource
            // 
            this.pRODUCTBindingSource.DataSource = typeof(CompuStore.Database.Models.PRODUCT);
            // 
            // iNFORBindingSource
            // 
            this.iNFORBindingSource.DataSource = typeof(CompuStore.Database.Models.INFOR);
            // 
            // WarrantyDetail_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 430);
            this.Controls.Add(this.Status_ComboBox);
            this.Controls.Add(this.EditAndSave_Button);
            this.Controls.Add(this.WarrantyReason);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WarrantyDoneDate_Picker);
            this.Controls.Add(this.ItemSerial_Box);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.Email_Box);
            this.Controls.Add(this.Name_Box);
            this.Controls.Add(this.lbStaffName);
            this.Controls.Add(this.PhoneNumber_Box);
            this.Controls.Add(this.Identity_Box);
            this.Controls.Add(this.HeaderIcon);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Header);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WarrantyDetail_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddWarranty_Form";
            ((System.ComponentModel.ISupportInitialize)(this.HeaderIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warrantyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNFORBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox HeaderIcon;
        private Guna.UI2.WinForms.Guna2ImageButton Exit_Button;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker WarrantyDoneDate_Picker;
        private Guna.UI2.WinForms.Guna2TextBox ItemSerial_Box;
        private System.Windows.Forms.Label lbDate;
        private Guna.UI2.WinForms.Guna2TextBox Email_Box;
        private Guna.UI2.WinForms.Guna2TextBox Name_Box;
        private System.Windows.Forms.Label lbStaffName;
        private Guna.UI2.WinForms.Guna2TextBox PhoneNumber_Box;
        private Guna.UI2.WinForms.Guna2TextBox Identity_Box;
        private Guna.UI2.WinForms.Guna2TextBox WarrantyReason;
        private Guna.UI2.WinForms.Guna2Button EditAndSave_Button;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.BindingSource warrantyBindingSource;
        private System.Windows.Forms.BindingSource pRODUCTBindingSource;
        private System.Windows.Forms.BindingSource iNFORBindingSource;
        private Guna.UI2.WinForms.Guna2ComboBox Status_ComboBox;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}