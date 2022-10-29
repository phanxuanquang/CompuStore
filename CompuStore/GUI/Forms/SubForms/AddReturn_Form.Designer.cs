namespace CompuStore
{
    partial class AddReturn_Form
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
            this.Header = new System.Windows.Forms.Label();
            this.HeaderIcon = new System.Windows.Forms.PictureBox();
            this.Exit_Button = new Guna.UI2.WinForms.Guna2ImageButton();
            this.NewItemSerial_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.OldItemSerial_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Print_Button = new Guna.UI2.WinForms.Guna2Button();
            this.Email_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Name_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbStaffName = new System.Windows.Forms.Label();
            this.PhoneNumber_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Identity_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Save_Button = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderIcon)).BeginInit();
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
            this.Header.Size = new System.Drawing.Size(607, 40);
            this.Header.TabIndex = 90;
            this.Header.Text = "Tạo phiếu đổi trả sản phẩm";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Header.UseCompatibleTextRendering = true;
            // 
            // HeaderIcon
            // 
            this.HeaderIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.HeaderIcon.BackgroundImage = global::CompuStore.Properties.Resources.Staff___Header;
            this.HeaderIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HeaderIcon.Location = new System.Drawing.Point(6, 7);
            this.HeaderIcon.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderIcon.Name = "HeaderIcon";
            this.HeaderIcon.Size = new System.Drawing.Size(25, 25);
            this.HeaderIcon.TabIndex = 92;
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
            this.Exit_Button.Location = new System.Drawing.Point(567, 0);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.PressedState.Parent = this.Exit_Button;
            this.Exit_Button.Size = new System.Drawing.Size(40, 40);
            this.Exit_Button.TabIndex = 91;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // NewItemSerial_Box
            // 
            this.NewItemSerial_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NewItemSerial_Box.Animated = true;
            this.NewItemSerial_Box.BackColor = System.Drawing.Color.Transparent;
            this.NewItemSerial_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.NewItemSerial_Box.BorderRadius = 8;
            this.NewItemSerial_Box.BorderThickness = 2;
            this.NewItemSerial_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NewItemSerial_Box.DefaultText = "";
            this.NewItemSerial_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NewItemSerial_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NewItemSerial_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NewItemSerial_Box.DisabledState.Parent = this.NewItemSerial_Box;
            this.NewItemSerial_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NewItemSerial_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.NewItemSerial_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.NewItemSerial_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.NewItemSerial_Box.FocusedState.Parent = this.NewItemSerial_Box;
            this.NewItemSerial_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NewItemSerial_Box.ForeColor = System.Drawing.Color.Black;
            this.NewItemSerial_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.NewItemSerial_Box.HoverState.Parent = this.NewItemSerial_Box;
            this.NewItemSerial_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.NewItemSerial_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.NewItemSerial_Box.Location = new System.Drawing.Point(30, 232);
            this.NewItemSerial_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewItemSerial_Box.Name = "NewItemSerial_Box";
            this.NewItemSerial_Box.PasswordChar = '\0';
            this.NewItemSerial_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.NewItemSerial_Box.PlaceholderText = "Mã se-ri sản phẩm đổi mới";
            this.NewItemSerial_Box.ReadOnly = true;
            this.NewItemSerial_Box.SelectedText = "";
            this.NewItemSerial_Box.ShadowDecoration.Parent = this.NewItemSerial_Box;
            this.NewItemSerial_Box.Size = new System.Drawing.Size(550, 37);
            this.NewItemSerial_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.NewItemSerial_Box.TabIndex = 135;
            this.NewItemSerial_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // OldItemSerial_Box
            // 
            this.OldItemSerial_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OldItemSerial_Box.Animated = true;
            this.OldItemSerial_Box.BackColor = System.Drawing.Color.Transparent;
            this.OldItemSerial_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.OldItemSerial_Box.BorderRadius = 8;
            this.OldItemSerial_Box.BorderThickness = 2;
            this.OldItemSerial_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OldItemSerial_Box.DefaultText = "";
            this.OldItemSerial_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.OldItemSerial_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.OldItemSerial_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.OldItemSerial_Box.DisabledState.Parent = this.OldItemSerial_Box;
            this.OldItemSerial_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.OldItemSerial_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.OldItemSerial_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.OldItemSerial_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.OldItemSerial_Box.FocusedState.Parent = this.OldItemSerial_Box;
            this.OldItemSerial_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.OldItemSerial_Box.ForeColor = System.Drawing.Color.Black;
            this.OldItemSerial_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.OldItemSerial_Box.HoverState.Parent = this.OldItemSerial_Box;
            this.OldItemSerial_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.OldItemSerial_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.OldItemSerial_Box.Location = new System.Drawing.Point(30, 189);
            this.OldItemSerial_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OldItemSerial_Box.Name = "OldItemSerial_Box";
            this.OldItemSerial_Box.PasswordChar = '\0';
            this.OldItemSerial_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.OldItemSerial_Box.PlaceholderText = "Mã se-ri sản phẩm trả lại";
            this.OldItemSerial_Box.ReadOnly = true;
            this.OldItemSerial_Box.SelectedText = "";
            this.OldItemSerial_Box.ShadowDecoration.Parent = this.OldItemSerial_Box;
            this.OldItemSerial_Box.Size = new System.Drawing.Size(550, 37);
            this.OldItemSerial_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.OldItemSerial_Box.TabIndex = 134;
            this.OldItemSerial_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(26, 313);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 133;
            this.label2.Text = "Ngày lập:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.Print_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Print_Button.ForeColor = System.Drawing.Color.White;
            this.Print_Button.HoverState.Parent = this.Print_Button;
            this.Print_Button.Location = new System.Drawing.Point(30, 345);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.PressedDepth = 5;
            this.Print_Button.ShadowDecoration.Parent = this.Print_Button;
            this.Print_Button.Size = new System.Drawing.Size(550, 57);
            this.Print_Button.TabIndex = 131;
            this.Print_Button.Text = "IN HÓA ĐƠN";
            this.Print_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
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
            this.Email_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Email_Box.ForeColor = System.Drawing.Color.Black;
            this.Email_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Email_Box.HoverState.Parent = this.Email_Box;
            this.Email_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Email_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Email_Box.Location = new System.Drawing.Point(30, 148);
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
            this.Email_Box.TabIndex = 128;
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
            this.Name_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name_Box.ForeColor = System.Drawing.Color.Black;
            this.Name_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Name_Box.HoverState.Parent = this.Name_Box;
            this.Name_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Name_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Name_Box.Location = new System.Drawing.Point(30, 105);
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
            this.Name_Box.TabIndex = 127;
            this.Name_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // lbStaffName
            // 
            this.lbStaffName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbStaffName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbStaffName.Location = new System.Drawing.Point(26, 280);
            this.lbStaffName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStaffName.Name = "lbStaffName";
            this.lbStaffName.Size = new System.Drawing.Size(106, 24);
            this.lbStaffName.TabIndex = 132;
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
            this.PhoneNumber_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PhoneNumber_Box.ForeColor = System.Drawing.Color.Black;
            this.PhoneNumber_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.PhoneNumber_Box.HoverState.Parent = this.PhoneNumber_Box;
            this.PhoneNumber_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.PhoneNumber_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.PhoneNumber_Box.Location = new System.Drawing.Point(348, 105);
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
            this.PhoneNumber_Box.TabIndex = 126;
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
            this.Identity_Box.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Identity_Box.ForeColor = System.Drawing.Color.Black;
            this.Identity_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Identity_Box.HoverState.Parent = this.Identity_Box;
            this.Identity_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Identity_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Identity_Box.Location = new System.Drawing.Point(30, 62);
            this.Identity_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Identity_Box.Name = "Identity_Box";
            this.Identity_Box.PasswordChar = '\0';
            this.Identity_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Identity_Box.PlaceholderText = "CMND/CCCD của khách hàng";
            this.Identity_Box.SelectedText = "";
            this.Identity_Box.ShadowDecoration.Parent = this.Identity_Box;
            this.Identity_Box.Size = new System.Drawing.Size(550, 37);
            this.Identity_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Identity_Box.TabIndex = 129;
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
            this.Save_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Save_Button.ForeColor = System.Drawing.Color.White;
            this.Save_Button.HoverState.Parent = this.Save_Button;
            this.Save_Button.Location = new System.Drawing.Point(30, 415);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.PressedDepth = 5;
            this.Save_Button.ShadowDecoration.Parent = this.Save_Button;
            this.Save_Button.Size = new System.Drawing.Size(550, 53);
            this.Save_Button.TabIndex = 130;
            this.Save_Button.Text = "LƯU";
            this.Save_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // AddReturn_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 498);
            this.Controls.Add(this.NewItemSerial_Box);
            this.Controls.Add(this.OldItemSerial_Box);
            this.Controls.Add(this.label2);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddReturn_Form";
            this.Text = "AddReturn_Form";
            ((System.ComponentModel.ISupportInitialize)(this.HeaderIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox HeaderIcon;
        private Guna.UI2.WinForms.Guna2ImageButton Exit_Button;
        private System.Windows.Forms.Label Header;
        private Guna.UI2.WinForms.Guna2TextBox NewItemSerial_Box;
        private Guna.UI2.WinForms.Guna2TextBox OldItemSerial_Box;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button Print_Button;
        private Guna.UI2.WinForms.Guna2TextBox Email_Box;
        private Guna.UI2.WinForms.Guna2TextBox Name_Box;
        private System.Windows.Forms.Label lbStaffName;
        private Guna.UI2.WinForms.Guna2TextBox PhoneNumber_Box;
        private Guna.UI2.WinForms.Guna2TextBox Identity_Box;
        private Guna.UI2.WinForms.Guna2Button Save_Button;
    }
}