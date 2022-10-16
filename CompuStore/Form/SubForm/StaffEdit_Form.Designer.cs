﻿namespace CompuStore
{
    partial class StaffEdit_Form
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
            this.HeaderIcon = new System.Windows.Forms.PictureBox();
            this.Exit_Button = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Header = new System.Windows.Forms.Label();
            this.PhoneNumber_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Identity_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Email_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Address_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.StaffDate_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Complete_Button = new Guna.UI2.WinForms.Guna2Button();
            this.DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Name_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.ID_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.ShadowForm = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.Apartment_ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Edit_Button = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderIcon
            // 
            this.HeaderIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.HeaderIcon.BackgroundImage = global::CompuStore.Properties.Resources.Exit;
            this.HeaderIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HeaderIcon.Location = new System.Drawing.Point(9, 7);
            this.HeaderIcon.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderIcon.Name = "HeaderIcon";
            this.HeaderIcon.Size = new System.Drawing.Size(25, 25);
            this.HeaderIcon.TabIndex = 9;
            this.HeaderIcon.TabStop = false;
            // 
            // Exit_Button
            // 
            this.Exit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit_Button.CheckedState.ImageSize = new System.Drawing.Size(25, 25);
            this.Exit_Button.CheckedState.Parent = this.Exit_Button;
            this.Exit_Button.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.Exit_Button.HoverState.Parent = this.Exit_Button;
            this.Exit_Button.Image = global::CompuStore.Properties.Resources.Exit;
            this.Exit_Button.ImageSize = new System.Drawing.Size(27, 27);
            this.Exit_Button.Location = new System.Drawing.Point(485, 0);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.PressedState.Parent = this.Exit_Button;
            this.Exit_Button.Size = new System.Drawing.Size(40, 40);
            this.Exit_Button.TabIndex = 8;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Header.ForeColor = System.Drawing.Color.White;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.Header.Size = new System.Drawing.Size(525, 40);
            this.Header.TabIndex = 7;
            this.Header.Text = "Chỉnh sửa thông tin";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PhoneNumber_Box
            // 
            this.PhoneNumber_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PhoneNumber_Box.Animated = true;
            this.PhoneNumber_Box.BackColor = System.Drawing.Color.Transparent;
            this.PhoneNumber_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.PhoneNumber_Box.BorderRadius = 8;
            this.PhoneNumber_Box.BorderThickness = 2;
            this.PhoneNumber_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
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
            this.PhoneNumber_Box.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PhoneNumber_Box.ForeColor = System.Drawing.Color.Black;
            this.PhoneNumber_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.PhoneNumber_Box.HoverState.Parent = this.PhoneNumber_Box;
            this.PhoneNumber_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.PhoneNumber_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.PhoneNumber_Box.Location = new System.Drawing.Point(265, 153);
            this.PhoneNumber_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PhoneNumber_Box.Name = "PhoneNumber_Box";
            this.PhoneNumber_Box.PasswordChar = '\0';
            this.PhoneNumber_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.PhoneNumber_Box.PlaceholderText = "Số điện thoại";
            this.PhoneNumber_Box.SelectedText = "";
            this.PhoneNumber_Box.ShadowDecoration.Parent = this.PhoneNumber_Box;
            this.PhoneNumber_Box.Size = new System.Drawing.Size(217, 37);
            this.PhoneNumber_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.PhoneNumber_Box.TabIndex = 11;
            this.PhoneNumber_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // Identity_Box
            // 
            this.Identity_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Identity_Box.Animated = true;
            this.Identity_Box.BackColor = System.Drawing.Color.Transparent;
            this.Identity_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Identity_Box.BorderRadius = 8;
            this.Identity_Box.BorderThickness = 2;
            this.Identity_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
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
            this.Identity_Box.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Identity_Box.ForeColor = System.Drawing.Color.Black;
            this.Identity_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Identity_Box.HoverState.Parent = this.Identity_Box;
            this.Identity_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Identity_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Identity_Box.Location = new System.Drawing.Point(42, 153);
            this.Identity_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Identity_Box.Name = "Identity_Box";
            this.Identity_Box.PasswordChar = '\0';
            this.Identity_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Identity_Box.PlaceholderText = "CCCD/CMND";
            this.Identity_Box.SelectedText = "";
            this.Identity_Box.ShadowDecoration.Parent = this.Identity_Box;
            this.Identity_Box.Size = new System.Drawing.Size(217, 37);
            this.Identity_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Identity_Box.TabIndex = 12;
            this.Identity_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // Email_Box
            // 
            this.Email_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Email_Box.Animated = true;
            this.Email_Box.BackColor = System.Drawing.Color.Transparent;
            this.Email_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Email_Box.BorderRadius = 8;
            this.Email_Box.BorderThickness = 2;
            this.Email_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
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
            this.Email_Box.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Email_Box.ForeColor = System.Drawing.Color.Black;
            this.Email_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Email_Box.HoverState.Parent = this.Email_Box;
            this.Email_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Email_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Email_Box.Location = new System.Drawing.Point(42, 196);
            this.Email_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Email_Box.Name = "Email_Box";
            this.Email_Box.PasswordChar = '\0';
            this.Email_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Email_Box.PlaceholderText = "E-mail";
            this.Email_Box.SelectedText = "";
            this.Email_Box.ShadowDecoration.Parent = this.Email_Box;
            this.Email_Box.Size = new System.Drawing.Size(217, 37);
            this.Email_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Email_Box.TabIndex = 13;
            this.Email_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // Address_Box
            // 
            this.Address_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Address_Box.Animated = true;
            this.Address_Box.BackColor = System.Drawing.Color.Transparent;
            this.Address_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Address_Box.BorderRadius = 8;
            this.Address_Box.BorderThickness = 2;
            this.Address_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Address_Box.DefaultText = "";
            this.Address_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Address_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Address_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Address_Box.DisabledState.Parent = this.Address_Box;
            this.Address_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Address_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Address_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Address_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.Address_Box.FocusedState.Parent = this.Address_Box;
            this.Address_Box.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Address_Box.ForeColor = System.Drawing.Color.Black;
            this.Address_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Address_Box.HoverState.Parent = this.Address_Box;
            this.Address_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Address_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Address_Box.Location = new System.Drawing.Point(42, 239);
            this.Address_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Address_Box.Name = "Address_Box";
            this.Address_Box.PasswordChar = '\0';
            this.Address_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Address_Box.PlaceholderText = "Địa chỉ";
            this.Address_Box.SelectedText = "";
            this.Address_Box.ShadowDecoration.Parent = this.Address_Box;
            this.Address_Box.Size = new System.Drawing.Size(440, 37);
            this.Address_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Address_Box.TabIndex = 14;
            this.Address_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // StaffDate_Box
            // 
            this.StaffDate_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StaffDate_Box.Animated = true;
            this.StaffDate_Box.BackColor = System.Drawing.Color.Transparent;
            this.StaffDate_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.StaffDate_Box.BorderRadius = 8;
            this.StaffDate_Box.BorderThickness = 2;
            this.StaffDate_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.StaffDate_Box.DefaultText = "";
            this.StaffDate_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.StaffDate_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.StaffDate_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.StaffDate_Box.DisabledState.Parent = this.StaffDate_Box;
            this.StaffDate_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.StaffDate_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.StaffDate_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.StaffDate_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.StaffDate_Box.FocusedState.Parent = this.StaffDate_Box;
            this.StaffDate_Box.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.StaffDate_Box.ForeColor = System.Drawing.Color.Black;
            this.StaffDate_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.StaffDate_Box.HoverState.Parent = this.StaffDate_Box;
            this.StaffDate_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.StaffDate_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.StaffDate_Box.Location = new System.Drawing.Point(265, 196);
            this.StaffDate_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StaffDate_Box.Name = "StaffDate_Box";
            this.StaffDate_Box.PasswordChar = '\0';
            this.StaffDate_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.StaffDate_Box.PlaceholderText = "Ngày vào làm";
            this.StaffDate_Box.SelectedText = "";
            this.StaffDate_Box.ShadowDecoration.Parent = this.StaffDate_Box;
            this.StaffDate_Box.Size = new System.Drawing.Size(217, 37);
            this.StaffDate_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.StaffDate_Box.TabIndex = 15;
            this.StaffDate_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // Complete_Button
            // 
            this.Complete_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Complete_Button.Animated = true;
            this.Complete_Button.BorderRadius = 8;
            this.Complete_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Complete_Button.CheckedState.Parent = this.Complete_Button;
            this.Complete_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Complete_Button.CustomImages.Parent = this.Complete_Button;
            this.Complete_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Complete_Button.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Complete_Button.ForeColor = System.Drawing.Color.White;
            this.Complete_Button.HoverState.Parent = this.Complete_Button;
            this.Complete_Button.Location = new System.Drawing.Point(42, 354);
            this.Complete_Button.Name = "Complete_Button";
            this.Complete_Button.PressedDepth = 5;
            this.Complete_Button.ShadowDecoration.Parent = this.Complete_Button;
            this.Complete_Button.Size = new System.Drawing.Size(440, 59);
            this.Complete_Button.TabIndex = 16;
            this.Complete_Button.Text = "XONG";
            // 
            // DragControl
            // 
            this.DragControl.TargetControl = this.Header;
            // 
            // Name_Box
            // 
            this.Name_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Name_Box.Animated = true;
            this.Name_Box.BackColor = System.Drawing.Color.Transparent;
            this.Name_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Name_Box.BorderRadius = 8;
            this.Name_Box.BorderThickness = 2;
            this.Name_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
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
            this.Name_Box.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name_Box.ForeColor = System.Drawing.Color.Black;
            this.Name_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Name_Box.HoverState.Parent = this.Name_Box;
            this.Name_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Name_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Name_Box.Location = new System.Drawing.Point(42, 110);
            this.Name_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name_Box.Name = "Name_Box";
            this.Name_Box.PasswordChar = '\0';
            this.Name_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Name_Box.PlaceholderText = "Họ và tên";
            this.Name_Box.SelectedText = "";
            this.Name_Box.ShadowDecoration.Parent = this.Name_Box;
            this.Name_Box.Size = new System.Drawing.Size(440, 37);
            this.Name_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Name_Box.TabIndex = 17;
            this.Name_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // ID_Box
            // 
            this.ID_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ID_Box.Animated = true;
            this.ID_Box.BackColor = System.Drawing.Color.Transparent;
            this.ID_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.ID_Box.BorderRadius = 8;
            this.ID_Box.BorderThickness = 2;
            this.ID_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_Box.DefaultText = "";
            this.ID_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ID_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ID_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ID_Box.DisabledState.Parent = this.ID_Box;
            this.ID_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ID_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.ID_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.ID_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.ID_Box.FocusedState.Parent = this.ID_Box;
            this.ID_Box.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ID_Box.ForeColor = System.Drawing.Color.Black;
            this.ID_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.ID_Box.HoverState.Parent = this.ID_Box;
            this.ID_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.ID_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.ID_Box.Location = new System.Drawing.Point(42, 67);
            this.ID_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ID_Box.Name = "ID_Box";
            this.ID_Box.PasswordChar = '\0';
            this.ID_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.ID_Box.PlaceholderText = "Mã nhân viên";
            this.ID_Box.ReadOnly = true;
            this.ID_Box.SelectedText = "";
            this.ID_Box.ShadowDecoration.Parent = this.ID_Box;
            this.ID_Box.Size = new System.Drawing.Size(440, 37);
            this.ID_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.ID_Box.TabIndex = 18;
            this.ID_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // Apartment_ComboBox
            // 
            this.Apartment_ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Apartment_ComboBox.Animated = true;
            this.Apartment_ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.Apartment_ComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Apartment_ComboBox.BorderRadius = 4;
            this.Apartment_ComboBox.BorderThickness = 2;
            this.Apartment_ComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Apartment_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Apartment_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Apartment_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Apartment_ComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Apartment_ComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Apartment_ComboBox.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Apartment_ComboBox.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.Apartment_ComboBox.FocusedState.Parent = this.Apartment_ComboBox;
            this.Apartment_ComboBox.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Apartment_ComboBox.ForeColor = System.Drawing.Color.Black;
            this.Apartment_ComboBox.FormattingEnabled = true;
            this.Apartment_ComboBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Apartment_ComboBox.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Apartment_ComboBox.HoverState.ForeColor = System.Drawing.Color.Black;
            this.Apartment_ComboBox.HoverState.Parent = this.Apartment_ComboBox;
            this.Apartment_ComboBox.ItemHeight = 32;
            this.Apartment_ComboBox.Items.AddRange(new object[] {
            "Bộ phận phụ trách",
            "Bán hàng",
            "Chăm sóc khách hàng",
            "Kho vận"});
            this.Apartment_ComboBox.ItemsAppearance.Parent = this.Apartment_ComboBox;
            this.Apartment_ComboBox.Location = new System.Drawing.Point(42, 285);
            this.Apartment_ComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.Apartment_ComboBox.Name = "Apartment_ComboBox";
            this.Apartment_ComboBox.ShadowDecoration.Parent = this.Apartment_ComboBox;
            this.Apartment_ComboBox.Size = new System.Drawing.Size(440, 38);
            this.Apartment_ComboBox.StartIndex = 0;
            this.Apartment_ComboBox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Apartment_ComboBox.TabIndex = 19;
            this.Apartment_ComboBox.TextOffset = new System.Drawing.Point(5, 0);
            this.Apartment_ComboBox.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // Edit_Button
            // 
            this.Edit_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Edit_Button.Animated = true;
            this.Edit_Button.BorderRadius = 8;
            this.Edit_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Edit_Button.CheckedState.Parent = this.Edit_Button;
            this.Edit_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Edit_Button.CustomImages.Parent = this.Edit_Button;
            this.Edit_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Edit_Button.Font = new System.Drawing.Font("Open Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Edit_Button.ForeColor = System.Drawing.Color.White;
            this.Edit_Button.HoverState.Parent = this.Edit_Button;
            this.Edit_Button.Location = new System.Drawing.Point(42, 354);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.PressedDepth = 5;
            this.Edit_Button.ShadowDecoration.Parent = this.Edit_Button;
            this.Edit_Button.Size = new System.Drawing.Size(440, 59);
            this.Edit_Button.TabIndex = 20;
            this.Edit_Button.Text = "CHỈNH SỬA";
            this.Edit_Button.Visible = false;
            this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
            // 
            // StaffEdit_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(525, 442);
            this.Controls.Add(this.Edit_Button);
            this.Controls.Add(this.Apartment_ComboBox);
            this.Controls.Add(this.ID_Box);
            this.Controls.Add(this.Name_Box);
            this.Controls.Add(this.Complete_Button);
            this.Controls.Add(this.StaffDate_Box);
            this.Controls.Add(this.Address_Box);
            this.Controls.Add(this.Email_Box);
            this.Controls.Add(this.Identity_Box);
            this.Controls.Add(this.PhoneNumber_Box);
            this.Controls.Add(this.HeaderIcon);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StaffEdit_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm nhân viên mới";
            ((System.ComponentModel.ISupportInitialize)(this.HeaderIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox HeaderIcon;
        private Guna.UI2.WinForms.Guna2ImageButton Exit_Button;
        private System.Windows.Forms.Label Header;
        private Guna.UI2.WinForms.Guna2TextBox PhoneNumber_Box;
        private Guna.UI2.WinForms.Guna2TextBox Identity_Box;
        private Guna.UI2.WinForms.Guna2TextBox Email_Box;
        private Guna.UI2.WinForms.Guna2TextBox Address_Box;
        private Guna.UI2.WinForms.Guna2TextBox StaffDate_Box;
        private Guna.UI2.WinForms.Guna2Button Complete_Button;
        private Guna.UI2.WinForms.Guna2DragControl DragControl;
        private Guna.UI2.WinForms.Guna2TextBox Name_Box;
        private Guna.UI2.WinForms.Guna2TextBox ID_Box;
        private Guna.UI2.WinForms.Guna2ShadowForm ShadowForm;
        private Guna.UI2.WinForms.Guna2ComboBox Apartment_ComboBox;
        private Guna.UI2.WinForms.Guna2Button Edit_Button;
    }
}