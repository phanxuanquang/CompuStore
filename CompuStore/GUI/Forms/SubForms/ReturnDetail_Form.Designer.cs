namespace CompuStore
{
    partial class ReturnDetail_Form
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
            this.Print_Button = new Guna.UI2.WinForms.Guna2Button();
            this.HeaderIcon = new System.Windows.Forms.PictureBox();
            this.Exit_Button = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ReturnReason = new Guna.UI2.WinForms.Guna2TextBox();
            this.cHANGEORREFUNDPRODUCTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NewItemSerial_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.pRODUCTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OldItemSerial_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbDate = new System.Windows.Forms.Label();
            this.Email_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.iNFORBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Name_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbStaffName = new System.Windows.Forms.Label();
            this.PhoneNumber_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Identity_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.AddInfor_Button = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHANGEORREFUNDPRODUCTBindingSource)).BeginInit();
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
            this.Header.Text = "Thông tin phiếu đổi trả";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Header.UseCompatibleTextRendering = true;
            // 
            // Print_Button
            // 
            this.Print_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.Print_Button.Location = new System.Drawing.Point(38, 419);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.PressedDepth = 5;
            this.Print_Button.ShadowDecoration.Parent = this.Print_Button;
            this.Print_Button.Size = new System.Drawing.Size(549, 57);
            this.Print_Button.TabIndex = 84;
            this.Print_Button.Text = "IN HÓA ĐƠN";
            this.Print_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
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
            // ReturnReason
            // 
            this.ReturnReason.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReturnReason.Animated = true;
            this.ReturnReason.BackColor = System.Drawing.Color.Transparent;
            this.ReturnReason.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.ReturnReason.BorderRadius = 8;
            this.ReturnReason.BorderThickness = 2;
            this.ReturnReason.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ReturnReason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cHANGEORREFUNDPRODUCTBindingSource, "REASON", true));
            this.ReturnReason.DefaultText = "";
            this.ReturnReason.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ReturnReason.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ReturnReason.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ReturnReason.DisabledState.Parent = this.ReturnReason;
            this.ReturnReason.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ReturnReason.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.ReturnReason.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.ReturnReason.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.ReturnReason.FocusedState.Parent = this.ReturnReason;
            this.ReturnReason.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ReturnReason.ForeColor = System.Drawing.Color.Black;
            this.ReturnReason.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.ReturnReason.HoverState.Parent = this.ReturnReason;
            this.ReturnReason.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.ReturnReason.IconLeftSize = new System.Drawing.Size(30, 30);
            this.ReturnReason.Location = new System.Drawing.Point(38, 285);
            this.ReturnReason.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReturnReason.Name = "ReturnReason";
            this.ReturnReason.PasswordChar = '\0';
            this.ReturnReason.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.ReturnReason.PlaceholderText = "Lý do đổi trả";
            this.ReturnReason.SelectedText = "";
            this.ReturnReason.ShadowDecoration.Parent = this.ReturnReason;
            this.ReturnReason.Size = new System.Drawing.Size(550, 37);
            this.ReturnReason.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.ReturnReason.TabIndex = 146;
            this.ReturnReason.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // cHANGEORREFUNDPRODUCTBindingSource
            // 
            this.cHANGEORREFUNDPRODUCTBindingSource.DataSource = typeof(CompuStore.Database.Models.CHANGE_OR_REFUND_PRODUCT);
            // 
            // NewItemSerial_Box
            // 
            this.NewItemSerial_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NewItemSerial_Box.Animated = true;
            this.NewItemSerial_Box.BackColor = System.Drawing.Color.Transparent;
            this.NewItemSerial_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.NewItemSerial_Box.BorderRadius = 8;
            this.NewItemSerial_Box.BorderThickness = 2;
            this.NewItemSerial_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NewItemSerial_Box.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pRODUCTBindingSource, "SERIAL_ID", true));
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
            this.NewItemSerial_Box.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NewItemSerial_Box.ForeColor = System.Drawing.Color.Black;
            this.NewItemSerial_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.NewItemSerial_Box.HoverState.Parent = this.NewItemSerial_Box;
            this.NewItemSerial_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.NewItemSerial_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.NewItemSerial_Box.Location = new System.Drawing.Point(38, 241);
            this.NewItemSerial_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewItemSerial_Box.Name = "NewItemSerial_Box";
            this.NewItemSerial_Box.PasswordChar = '\0';
            this.NewItemSerial_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.NewItemSerial_Box.PlaceholderText = "Mã se-ri sản phẩm đổi mới";
            this.NewItemSerial_Box.SelectedText = "";
            this.NewItemSerial_Box.ShadowDecoration.Parent = this.NewItemSerial_Box;
            this.NewItemSerial_Box.Size = new System.Drawing.Size(550, 37);
            this.NewItemSerial_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.NewItemSerial_Box.TabIndex = 145;
            this.NewItemSerial_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // pRODUCTBindingSource
            // 
            this.pRODUCTBindingSource.DataSource = typeof(CompuStore.Database.Models.PRODUCT);
            // 
            // OldItemSerial_Box
            // 
            this.OldItemSerial_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OldItemSerial_Box.Animated = true;
            this.OldItemSerial_Box.BackColor = System.Drawing.Color.Transparent;
            this.OldItemSerial_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.OldItemSerial_Box.BorderRadius = 8;
            this.OldItemSerial_Box.BorderThickness = 2;
            this.OldItemSerial_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OldItemSerial_Box.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pRODUCTBindingSource, "SERIAL_ID", true));
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
            this.OldItemSerial_Box.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.OldItemSerial_Box.ForeColor = System.Drawing.Color.Black;
            this.OldItemSerial_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.OldItemSerial_Box.HoverState.Parent = this.OldItemSerial_Box;
            this.OldItemSerial_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.OldItemSerial_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.OldItemSerial_Box.Location = new System.Drawing.Point(38, 65);
            this.OldItemSerial_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OldItemSerial_Box.Name = "OldItemSerial_Box";
            this.OldItemSerial_Box.PasswordChar = '\0';
            this.OldItemSerial_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.OldItemSerial_Box.PlaceholderText = "Mã se-ri sản phẩm trả lại";
            this.OldItemSerial_Box.SelectedText = "";
            this.OldItemSerial_Box.ShadowDecoration.Parent = this.OldItemSerial_Box;
            this.OldItemSerial_Box.Size = new System.Drawing.Size(549, 37);
            this.OldItemSerial_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.OldItemSerial_Box.TabIndex = 144;
            this.OldItemSerial_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // lbDate
            // 
            this.lbDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDate.Location = new System.Drawing.Point(34, 369);
            this.lbDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(83, 20);
            this.lbDate.TabIndex = 143;
            this.lbDate.Text = "Ngày lập:";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.Email_Box.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Email_Box.ForeColor = System.Drawing.Color.Black;
            this.Email_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Email_Box.HoverState.Parent = this.Email_Box;
            this.Email_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Email_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Email_Box.Location = new System.Drawing.Point(38, 197);
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
            this.Email_Box.TabIndex = 140;
            this.Email_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // iNFORBindingSource
            // 
            this.iNFORBindingSource.DataSource = typeof(CompuStore.Database.Models.INFOR);
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
            this.Name_Box.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name_Box.ForeColor = System.Drawing.Color.Black;
            this.Name_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Name_Box.HoverState.Parent = this.Name_Box;
            this.Name_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Name_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Name_Box.Location = new System.Drawing.Point(38, 153);
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
            this.Name_Box.TabIndex = 139;
            this.Name_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // lbStaffName
            // 
            this.lbStaffName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbStaffName.AutoSize = true;
            this.lbStaffName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbStaffName.Location = new System.Drawing.Point(34, 336);
            this.lbStaffName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStaffName.Name = "lbStaffName";
            this.lbStaffName.Size = new System.Drawing.Size(89, 20);
            this.lbStaffName.TabIndex = 142;
            this.lbStaffName.Text = "Người lập:";
            this.lbStaffName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.PhoneNumber_Box.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PhoneNumber_Box.ForeColor = System.Drawing.Color.Black;
            this.PhoneNumber_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.PhoneNumber_Box.HoverState.Parent = this.PhoneNumber_Box;
            this.PhoneNumber_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.PhoneNumber_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.PhoneNumber_Box.Location = new System.Drawing.Point(355, 153);
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
            this.PhoneNumber_Box.TabIndex = 138;
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
            this.Identity_Box.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Identity_Box.ForeColor = System.Drawing.Color.Black;
            this.Identity_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Identity_Box.HoverState.Parent = this.Identity_Box;
            this.Identity_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Identity_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Identity_Box.Location = new System.Drawing.Point(38, 109);
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
            this.Identity_Box.TabIndex = 141;
            this.Identity_Box.TextOffset = new System.Drawing.Point(5, 0);
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
            this.AddInfor_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.AddInfor_Button.ForeColor = System.Drawing.Color.White;
            this.AddInfor_Button.HoverState.Parent = this.AddInfor_Button;
            this.AddInfor_Button.Location = new System.Drawing.Point(451, 65);
            this.AddInfor_Button.Name = "AddInfor_Button";
            this.AddInfor_Button.PressedDepth = 5;
            this.AddInfor_Button.ShadowDecoration.Parent = this.AddInfor_Button;
            this.AddInfor_Button.Size = new System.Drawing.Size(136, 36);
            this.AddInfor_Button.TabIndex = 147;
            this.AddInfor_Button.Text = "Thêm thông tin";
            this.AddInfor_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.Header;
            // 
            // ReturnDetail_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 506);
            this.Controls.Add(this.ReturnReason);
            this.Controls.Add(this.NewItemSerial_Box);
            this.Controls.Add(this.OldItemSerial_Box);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.Email_Box);
            this.Controls.Add(this.Name_Box);
            this.Controls.Add(this.lbStaffName);
            this.Controls.Add(this.PhoneNumber_Box);
            this.Controls.Add(this.Identity_Box);
            this.Controls.Add(this.AddInfor_Button);
            this.Controls.Add(this.Print_Button);
            this.Controls.Add(this.HeaderIcon);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Header);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReturnDetail_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddWarranty_Form";
            ((System.ComponentModel.ISupportInitialize)(this.HeaderIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHANGEORREFUNDPRODUCTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNFORBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox HeaderIcon;
        private Guna.UI2.WinForms.Guna2ImageButton Exit_Button;
        private System.Windows.Forms.Label Header;
        private Guna.UI2.WinForms.Guna2Button Print_Button;
        private Guna.UI2.WinForms.Guna2TextBox ReturnReason;
        private Guna.UI2.WinForms.Guna2TextBox NewItemSerial_Box;
        private Guna.UI2.WinForms.Guna2TextBox OldItemSerial_Box;
        private System.Windows.Forms.Label lbDate;
        private Guna.UI2.WinForms.Guna2TextBox Email_Box;
        private Guna.UI2.WinForms.Guna2TextBox Name_Box;
        private System.Windows.Forms.Label lbStaffName;
        private Guna.UI2.WinForms.Guna2TextBox PhoneNumber_Box;
        private Guna.UI2.WinForms.Guna2TextBox Identity_Box;
        private Guna.UI2.WinForms.Guna2Button AddInfor_Button;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private System.Windows.Forms.BindingSource cHANGEORREFUNDPRODUCTBindingSource;
        private System.Windows.Forms.BindingSource pRODUCTBindingSource;
        private System.Windows.Forms.BindingSource iNFORBindingSource;
    }
}