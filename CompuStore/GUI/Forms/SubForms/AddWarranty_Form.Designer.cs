namespace CompuStore
{
    partial class AddWarranty_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.WarrantyDoneDate_Picker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.ItemSerial_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbDate = new System.Windows.Forms.Label();
            this.Print_Button = new Guna.UI2.WinForms.Guna2Button();
            this.Email_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Name_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbStaffName = new System.Windows.Forms.Label();
            this.PhoneNumber_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Identity_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Save_Button = new Guna.UI2.WinForms.Guna2Button();
            this.WarrantyReason = new Guna.UI2.WinForms.Guna2TextBox();
            this.AddInfor_Button = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderIcon)).BeginInit();
            this.SuspendLayout();
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
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Header.ForeColor = System.Drawing.Color.White;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.Header.Size = new System.Drawing.Size(623, 40);
            this.Header.TabIndex = 41;
            this.Header.Text = "Tạo phiếu gửi bảo hành";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Header.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 278);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 24);
            this.label1.TabIndex = 89;
            this.label1.Text = "Ngày hẹn trả bảo hành:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WarrantyDoneDate_Picker
            // 
            this.WarrantyDoneDate_Picker.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.WarrantyDoneDate_Picker.Animated = true;
            this.WarrantyDoneDate_Picker.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.WarrantyDoneDate_Picker.CheckedState.Parent = this.WarrantyDoneDate_Picker;
            this.WarrantyDoneDate_Picker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WarrantyDoneDate_Picker.CustomFormat = " dd/MM/yyyy";
            this.WarrantyDoneDate_Picker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.WarrantyDoneDate_Picker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarrantyDoneDate_Picker.ForeColor = System.Drawing.Color.Black;
            this.WarrantyDoneDate_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.WarrantyDoneDate_Picker.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.WarrantyDoneDate_Picker.HoverState.Parent = this.WarrantyDoneDate_Picker;
            this.WarrantyDoneDate_Picker.Location = new System.Drawing.Point(266, 281);
            this.WarrantyDoneDate_Picker.Margin = new System.Windows.Forms.Padding(0);
            this.WarrantyDoneDate_Picker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.WarrantyDoneDate_Picker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.WarrantyDoneDate_Picker.Name = "WarrantyDoneDate_Picker";
            this.WarrantyDoneDate_Picker.ShadowDecoration.Parent = this.WarrantyDoneDate_Picker;
            this.WarrantyDoneDate_Picker.Size = new System.Drawing.Size(323, 24);
            this.WarrantyDoneDate_Picker.TabIndex = 88;
            this.WarrantyDoneDate_Picker.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.WarrantyDoneDate_Picker.Value = new System.DateTime(2022, 10, 18, 0, 0, 0, 0);
            // 
            // ItemSerial_Box
            // 
            this.ItemSerial_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemSerial_Box.Animated = true;
            this.ItemSerial_Box.BackColor = System.Drawing.Color.Transparent;
            this.ItemSerial_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.ItemSerial_Box.BorderRadius = 8;
            this.ItemSerial_Box.BorderThickness = 2;
            this.ItemSerial_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
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
            this.ItemSerial_Box.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemSerial_Box.ForeColor = System.Drawing.Color.Black;
            this.ItemSerial_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.ItemSerial_Box.HoverState.Parent = this.ItemSerial_Box;
            this.ItemSerial_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.ItemSerial_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.ItemSerial_Box.Location = new System.Drawing.Point(39, 74);
            this.ItemSerial_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ItemSerial_Box.Name = "ItemSerial_Box";
            this.ItemSerial_Box.PasswordChar = '\0';
            this.ItemSerial_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.ItemSerial_Box.PlaceholderText = "Mã se-ri sản phẩm bảo hành";
            this.ItemSerial_Box.SelectedText = "";
            this.ItemSerial_Box.ShadowDecoration.Parent = this.ItemSerial_Box;
            this.ItemSerial_Box.Size = new System.Drawing.Size(407, 37);
            this.ItemSerial_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.ItemSerial_Box.TabIndex = 87;
            this.ItemSerial_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // lbDate
            // 
            this.lbDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(34, 347);
            this.lbDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(75, 20);
            this.lbDate.TabIndex = 86;
            this.lbDate.Text = "Ngày lập:";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Print_Button
            // 
            this.Print_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Print_Button.Animated = true;
            this.Print_Button.BorderRadius = 3;
            this.Print_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Print_Button.CheckedState.Parent = this.Print_Button;
            this.Print_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Print_Button.CustomImages.Parent = this.Print_Button;
            this.Print_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Print_Button.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print_Button.ForeColor = System.Drawing.Color.White;
            this.Print_Button.HoverState.Parent = this.Print_Button;
            this.Print_Button.Location = new System.Drawing.Point(38, 389);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.PressedDepth = 5;
            this.Print_Button.ShadowDecoration.Parent = this.Print_Button;
            this.Print_Button.Size = new System.Drawing.Size(550, 57);
            this.Print_Button.TabIndex = 84;
            this.Print_Button.Text = "IN HÓA ĐƠN";
            this.Print_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // Email_Box
            // 
            this.Email_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
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
            this.Email_Box.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_Box.ForeColor = System.Drawing.Color.Black;
            this.Email_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Email_Box.HoverState.Parent = this.Email_Box;
            this.Email_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Email_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Email_Box.Location = new System.Drawing.Point(39, 197);
            this.Email_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Email_Box.Name = "Email_Box";
            this.Email_Box.PasswordChar = '\0';
            this.Email_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Email_Box.PlaceholderText = "E-mail";
            this.Email_Box.ReadOnly = true;
            this.Email_Box.SelectedText = "";
            this.Email_Box.ShadowDecoration.Parent = this.Email_Box;
            this.Email_Box.Size = new System.Drawing.Size(550, 37);
            this.Email_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Email_Box.TabIndex = 81;
            this.Email_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // Name_Box
            // 
            this.Name_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
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
            this.Name_Box.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_Box.ForeColor = System.Drawing.Color.Black;
            this.Name_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Name_Box.HoverState.Parent = this.Name_Box;
            this.Name_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Name_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Name_Box.Location = new System.Drawing.Point(39, 156);
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
            // 
            // lbStaffName
            // 
            this.lbStaffName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbStaffName.AutoSize = true;
            this.lbStaffName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStaffName.Location = new System.Drawing.Point(34, 315);
            this.lbStaffName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStaffName.Name = "lbStaffName";
            this.lbStaffName.Size = new System.Drawing.Size(82, 20);
            this.lbStaffName.TabIndex = 85;
            this.lbStaffName.Text = "Người lập:";
            this.lbStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PhoneNumber_Box
            // 
            this.PhoneNumber_Box.Anchor = System.Windows.Forms.AnchorStyles.Right;
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
            this.PhoneNumber_Box.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNumber_Box.ForeColor = System.Drawing.Color.Black;
            this.PhoneNumber_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.PhoneNumber_Box.HoverState.Parent = this.PhoneNumber_Box;
            this.PhoneNumber_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.PhoneNumber_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.PhoneNumber_Box.Location = new System.Drawing.Point(356, 156);
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
            // 
            // Identity_Box
            // 
            this.Identity_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
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
            this.Identity_Box.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Identity_Box.ForeColor = System.Drawing.Color.Black;
            this.Identity_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Identity_Box.HoverState.Parent = this.Identity_Box;
            this.Identity_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Identity_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Identity_Box.Location = new System.Drawing.Point(38, 115);
            this.Identity_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Identity_Box.Name = "Identity_Box";
            this.Identity_Box.PasswordChar = '\0';
            this.Identity_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Identity_Box.PlaceholderText = "CMND/CCCD của khách hàng";
            this.Identity_Box.ReadOnly = true;
            this.Identity_Box.SelectedText = "";
            this.Identity_Box.ShadowDecoration.Parent = this.Identity_Box;
            this.Identity_Box.Size = new System.Drawing.Size(550, 37);
            this.Identity_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Identity_Box.TabIndex = 82;
            this.Identity_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Save_Button.Animated = true;
            this.Save_Button.BorderRadius = 3;
            this.Save_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Save_Button.CheckedState.Parent = this.Save_Button;
            this.Save_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save_Button.CustomImages.Parent = this.Save_Button;
            this.Save_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Save_Button.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_Button.ForeColor = System.Drawing.Color.White;
            this.Save_Button.HoverState.Parent = this.Save_Button;
            this.Save_Button.Location = new System.Drawing.Point(39, 452);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.PressedDepth = 5;
            this.Save_Button.ShadowDecoration.Parent = this.Save_Button;
            this.Save_Button.Size = new System.Drawing.Size(550, 53);
            this.Save_Button.TabIndex = 83;
            this.Save_Button.Text = "LƯU";
            this.Save_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // WarrantyReason
            // 
            this.WarrantyReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.WarrantyReason.Animated = true;
            this.WarrantyReason.BackColor = System.Drawing.Color.Transparent;
            this.WarrantyReason.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.WarrantyReason.BorderRadius = 8;
            this.WarrantyReason.BorderThickness = 2;
            this.WarrantyReason.Cursor = System.Windows.Forms.Cursors.IBeam;
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
            this.WarrantyReason.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarrantyReason.ForeColor = System.Drawing.Color.Black;
            this.WarrantyReason.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.WarrantyReason.HoverState.Parent = this.WarrantyReason;
            this.WarrantyReason.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.WarrantyReason.IconLeftSize = new System.Drawing.Size(30, 30);
            this.WarrantyReason.Location = new System.Drawing.Point(38, 238);
            this.WarrantyReason.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WarrantyReason.Name = "WarrantyReason";
            this.WarrantyReason.PasswordChar = '\0';
            this.WarrantyReason.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.WarrantyReason.PlaceholderText = "Lý do bảo hành";
            this.WarrantyReason.SelectedText = "";
            this.WarrantyReason.ShadowDecoration.Parent = this.WarrantyReason;
            this.WarrantyReason.Size = new System.Drawing.Size(550, 37);
            this.WarrantyReason.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.WarrantyReason.TabIndex = 90;
            this.WarrantyReason.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // AddInfor_Button
            // 
            this.AddInfor_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddInfor_Button.Animated = true;
            this.AddInfor_Button.BorderRadius = 3;
            this.AddInfor_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.AddInfor_Button.CheckedState.Parent = this.AddInfor_Button;
            this.AddInfor_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddInfor_Button.CustomImages.Parent = this.AddInfor_Button;
            this.AddInfor_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.AddInfor_Button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.AddInfor_Button.ForeColor = System.Drawing.Color.White;
            this.AddInfor_Button.HoverState.Parent = this.AddInfor_Button;
            this.AddInfor_Button.Location = new System.Drawing.Point(452, 74);
            this.AddInfor_Button.Name = "AddInfor_Button";
            this.AddInfor_Button.PressedDepth = 5;
            this.AddInfor_Button.ShadowDecoration.Parent = this.AddInfor_Button;
            this.AddInfor_Button.Size = new System.Drawing.Size(136, 36);
            this.AddInfor_Button.TabIndex = 91;
            this.AddInfor_Button.Text = "THÊM";
            this.AddInfor_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.AddInfor_Button.Click += new System.EventHandler(this.AddInfor_Button_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.Header;
            // 
            // AddWarranty_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 537);
            this.Controls.Add(this.AddInfor_Button);
            this.Controls.Add(this.WarrantyReason);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WarrantyDoneDate_Picker);
            this.Controls.Add(this.ItemSerial_Box);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.Print_Button);
            this.Controls.Add(this.Email_Box);
            this.Controls.Add(this.Name_Box);
            this.Controls.Add(this.lbStaffName);
            this.Controls.Add(this.PhoneNumber_Box);
            this.Controls.Add(this.Identity_Box);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.HeaderIcon);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Header);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddWarranty_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddWarranty_Form";
            ((System.ComponentModel.ISupportInitialize)(this.HeaderIcon)).EndInit();
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
        private Guna.UI2.WinForms.Guna2Button Print_Button;
        private Guna.UI2.WinForms.Guna2TextBox Email_Box;
        private Guna.UI2.WinForms.Guna2TextBox Name_Box;
        private System.Windows.Forms.Label lbStaffName;
        private Guna.UI2.WinForms.Guna2TextBox PhoneNumber_Box;
        private Guna.UI2.WinForms.Guna2TextBox Identity_Box;
        private Guna.UI2.WinForms.Guna2Button Save_Button;
        private Guna.UI2.WinForms.Guna2TextBox WarrantyReason;
        private Guna.UI2.WinForms.Guna2Button AddInfor_Button;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
    }
}