namespace CompuStore.Tab
{
    partial class SaleManagement_Tab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private new void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Size_ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.CPU_ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.VGA_ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.RAM_ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Storage_ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Resolution_ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ColorSearch_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.PriceLimit_TrackBar = new Guna.UI2.WinForms.Guna2TrackBar();
            this.PriceLimit_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchBox
            // 
            this.SearchBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SearchBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SearchBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchBox.DisabledState.Parent = this.SearchBox;
            this.SearchBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SearchBox.FocusedState.Parent = this.SearchBox;
            this.SearchBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SearchBox.HoverState.Parent = this.SearchBox;
            this.SearchBox.Location = new System.Drawing.Point(33, 19);
            this.SearchBox.PlaceholderText = "Tìm kiếm sản phẩm theo mã hoặc tên";
            this.SearchBox.ShadowDecoration.Parent = this.SearchBox;
            this.SearchBox.Size = new System.Drawing.Size(1004, 37);
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // Button_2
            // 
            this.Button_2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.Button_2.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Button_2.CheckedState.Parent = this.Button_2;
            this.Button_2.CustomImages.Parent = this.Button_2;
            this.Button_2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Button_2.HoverState.Parent = this.Button_2;
            this.Button_2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_2.Location = new System.Drawing.Point(1256, 19);
            this.Button_2.ShadowDecoration.Parent = this.Button_2;
            this.Button_2.Text = "Xem cấu hình";
            this.Button_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_2.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            this.Button_2.Click += new System.EventHandler(this.ViewDetail_Button_Click);
            // 
            // Bottom_1
            // 
            this.Bottom_1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.Bottom_1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Bottom_1.CheckedState.Parent = this.Bottom_1;
            this.Bottom_1.CustomImages.Parent = this.Bottom_1;
            this.Bottom_1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Bottom_1.HoverState.Parent = this.Bottom_1;
            this.Bottom_1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Bottom_1.Location = new System.Drawing.Point(1047, 19);
            this.Bottom_1.Margin = new System.Windows.Forms.Padding(4);
            this.Bottom_1.ShadowDecoration.Parent = this.Bottom_1;
            this.Bottom_1.Text = "Tạo đơn hàng";
            this.Bottom_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Bottom_1.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            this.Bottom_1.Click += new System.EventHandler(this.AddNew_Buttom_Click);
            // 
            // Button_3
            // 
            this.Button_3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.Button_3.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Button_3.CheckedState.Parent = this.Button_3;
            this.Button_3.CustomImages.Parent = this.Button_3;
            this.Button_3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Button_3.HoverState.Parent = this.Button_3;
            this.Button_3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_3.Location = new System.Drawing.Point(1465, 19);
            this.Button_3.ShadowDecoration.Parent = this.Button_3;
            this.Button_3.Text = "Danh sách đơn hàng";
            this.Button_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_3.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            this.Button_3.Click += new System.EventHandler(this.ViewInvoice_Click);
            // 
            // Size_ComboBox
            // 
            this.Size_ComboBox.Animated = true;
            this.Size_ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.Size_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Size_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Size_ComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.Size_ComboBox.FocusedState.Parent = this.Size_ComboBox;
            this.Size_ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Size_ComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Size_ComboBox.FormattingEnabled = true;
            this.Size_ComboBox.HoverState.Parent = this.Size_ComboBox;
            this.Size_ComboBox.ItemHeight = 30;
            this.Size_ComboBox.Items.AddRange(new object[] {
            "Kích thước",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17"});
            this.Size_ComboBox.ItemsAppearance.Parent = this.Size_ComboBox;
            this.Size_ComboBox.Location = new System.Drawing.Point(470, 63);
            this.Size_ComboBox.Name = "Size_ComboBox";
            this.Size_ComboBox.ShadowDecoration.Parent = this.Size_ComboBox;
            this.Size_ComboBox.Size = new System.Drawing.Size(152, 36);
            this.Size_ComboBox.StartIndex = 0;
            this.Size_ComboBox.TabIndex = 43;
            this.Size_ComboBox.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.Size_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Size_ComboBox_SelectedIndexChanged);
            // 
            // CPU_ComboBox
            // 
            this.CPU_ComboBox.Animated = true;
            this.CPU_ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.CPU_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CPU_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPU_ComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.CPU_ComboBox.FocusedState.Parent = this.CPU_ComboBox;
            this.CPU_ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CPU_ComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CPU_ComboBox.FormattingEnabled = true;
            this.CPU_ComboBox.HoverState.Parent = this.CPU_ComboBox;
            this.CPU_ComboBox.ItemHeight = 30;
            this.CPU_ComboBox.Items.AddRange(new object[] {
            "CPU",
            "Intel",
            "AMD",
            "Intel Core i3",
            "Intel Core i5",
            "Intel Core i7",
            "Intel Core i9",
            "Ryzen 3",
            "Ryzen 5",
            "Ryzen 7",
            "Ryzen 9"});
            this.CPU_ComboBox.ItemsAppearance.Parent = this.CPU_ComboBox;
            this.CPU_ComboBox.Location = new System.Drawing.Point(628, 63);
            this.CPU_ComboBox.Name = "CPU_ComboBox";
            this.CPU_ComboBox.ShadowDecoration.Parent = this.CPU_ComboBox;
            this.CPU_ComboBox.Size = new System.Drawing.Size(152, 36);
            this.CPU_ComboBox.StartIndex = 0;
            this.CPU_ComboBox.TabIndex = 44;
            this.CPU_ComboBox.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.CPU_ComboBox.SelectedIndexChanged += new System.EventHandler(this.CPU_ComboBox_SelectedIndexChanged);
            // 
            // VGA_ComboBox
            // 
            this.VGA_ComboBox.Animated = true;
            this.VGA_ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.VGA_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.VGA_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VGA_ComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.VGA_ComboBox.FocusedState.Parent = this.VGA_ComboBox;
            this.VGA_ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.VGA_ComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.VGA_ComboBox.FormattingEnabled = true;
            this.VGA_ComboBox.HoverState.Parent = this.VGA_ComboBox;
            this.VGA_ComboBox.ItemHeight = 30;
            this.VGA_ComboBox.Items.AddRange(new object[] {
            "VGA",
            "NVIDIA",
            "AMD",
            "Intel",
            "RTX",
            "GTX"});
            this.VGA_ComboBox.ItemsAppearance.Parent = this.VGA_ComboBox;
            this.VGA_ComboBox.Location = new System.Drawing.Point(786, 63);
            this.VGA_ComboBox.Name = "VGA_ComboBox";
            this.VGA_ComboBox.ShadowDecoration.Parent = this.VGA_ComboBox;
            this.VGA_ComboBox.Size = new System.Drawing.Size(152, 36);
            this.VGA_ComboBox.StartIndex = 0;
            this.VGA_ComboBox.TabIndex = 45;
            this.VGA_ComboBox.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.VGA_ComboBox.SelectedIndexChanged += new System.EventHandler(this.VGA_ComboBox_SelectedIndexChanged);
            // 
            // RAM_ComboBox
            // 
            this.RAM_ComboBox.Animated = true;
            this.RAM_ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.RAM_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.RAM_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RAM_ComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.RAM_ComboBox.FocusedState.Parent = this.RAM_ComboBox;
            this.RAM_ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.RAM_ComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.RAM_ComboBox.FormattingEnabled = true;
            this.RAM_ComboBox.HoverState.Parent = this.RAM_ComboBox;
            this.RAM_ComboBox.ItemHeight = 30;
            this.RAM_ComboBox.Items.AddRange(new object[] {
            "RAM",
            "4GB",
            "8GB",
            "16GB",
            "32GB"});
            this.RAM_ComboBox.ItemsAppearance.Parent = this.RAM_ComboBox;
            this.RAM_ComboBox.Location = new System.Drawing.Point(944, 63);
            this.RAM_ComboBox.Name = "RAM_ComboBox";
            this.RAM_ComboBox.ShadowDecoration.Parent = this.RAM_ComboBox;
            this.RAM_ComboBox.Size = new System.Drawing.Size(152, 36);
            this.RAM_ComboBox.StartIndex = 0;
            this.RAM_ComboBox.TabIndex = 46;
            this.RAM_ComboBox.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.RAM_ComboBox.SelectedIndexChanged += new System.EventHandler(this.RAM_ComboBox_SelectedIndexChanged);
            // 
            // Storage_ComboBox
            // 
            this.Storage_ComboBox.Animated = true;
            this.Storage_ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.Storage_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Storage_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Storage_ComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.Storage_ComboBox.FocusedState.Parent = this.Storage_ComboBox;
            this.Storage_ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Storage_ComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Storage_ComboBox.FormattingEnabled = true;
            this.Storage_ComboBox.HoverState.Parent = this.Storage_ComboBox;
            this.Storage_ComboBox.ItemHeight = 30;
            this.Storage_ComboBox.Items.AddRange(new object[] {
            "Ổ cứng",
            "128",
            "256",
            "512",
            "1024",
            "2048"});
            this.Storage_ComboBox.ItemsAppearance.Parent = this.Storage_ComboBox;
            this.Storage_ComboBox.Location = new System.Drawing.Point(1102, 63);
            this.Storage_ComboBox.Name = "Storage_ComboBox";
            this.Storage_ComboBox.ShadowDecoration.Parent = this.Storage_ComboBox;
            this.Storage_ComboBox.Size = new System.Drawing.Size(152, 36);
            this.Storage_ComboBox.StartIndex = 0;
            this.Storage_ComboBox.TabIndex = 47;
            this.Storage_ComboBox.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.Storage_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Storage_ComboBox_SelectedIndexChanged);
            // 
            // Resolution_ComboBox
            // 
            this.Resolution_ComboBox.Animated = true;
            this.Resolution_ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.Resolution_ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Resolution_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Resolution_ComboBox.FocusedColor = System.Drawing.Color.Empty;
            this.Resolution_ComboBox.FocusedState.Parent = this.Resolution_ComboBox;
            this.Resolution_ComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Resolution_ComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.Resolution_ComboBox.FormattingEnabled = true;
            this.Resolution_ComboBox.HoverState.Parent = this.Resolution_ComboBox;
            this.Resolution_ComboBox.ItemHeight = 30;
            this.Resolution_ComboBox.Items.AddRange(new object[] {
            "Độ phân giải",
            "1280",
            "1920",
            "2560"});
            this.Resolution_ComboBox.ItemsAppearance.Parent = this.Resolution_ComboBox;
            this.Resolution_ComboBox.Location = new System.Drawing.Point(1260, 63);
            this.Resolution_ComboBox.Name = "Resolution_ComboBox";
            this.Resolution_ComboBox.ShadowDecoration.Parent = this.Resolution_ComboBox;
            this.Resolution_ComboBox.Size = new System.Drawing.Size(152, 36);
            this.Resolution_ComboBox.StartIndex = 0;
            this.Resolution_ComboBox.TabIndex = 48;
            this.Resolution_ComboBox.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.Resolution_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Resolution_ComboBox_SelectedIndexChanged);
            // 
            // ColorSearch_Box
            // 
            this.ColorSearch_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorSearch_Box.Animated = true;
            this.ColorSearch_Box.BorderRadius = 5;
            this.ColorSearch_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ColorSearch_Box.DefaultText = "";
            this.ColorSearch_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ColorSearch_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ColorSearch_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ColorSearch_Box.DisabledState.Parent = this.ColorSearch_Box;
            this.ColorSearch_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ColorSearch_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ColorSearch_Box.FocusedState.Parent = this.ColorSearch_Box;
            this.ColorSearch_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ColorSearch_Box.HoverState.Parent = this.ColorSearch_Box;
            this.ColorSearch_Box.Location = new System.Drawing.Point(305, 63);
            this.ColorSearch_Box.Margin = new System.Windows.Forms.Padding(6);
            this.ColorSearch_Box.Name = "ColorSearch_Box";
            this.ColorSearch_Box.PasswordChar = '\0';
            this.ColorSearch_Box.PlaceholderText = "Màu sắc";
            this.ColorSearch_Box.SelectedText = "";
            this.ColorSearch_Box.ShadowDecoration.Parent = this.ColorSearch_Box;
            this.ColorSearch_Box.Size = new System.Drawing.Size(156, 37);
            this.ColorSearch_Box.TabIndex = 49;
            this.ColorSearch_Box.TextChanged += new System.EventHandler(this.ColorSearch_Box_TextChanged);
            // 
            // PriceLimit_TrackBar
            // 
            this.PriceLimit_TrackBar.BackColor = System.Drawing.Color.Transparent;
            this.PriceLimit_TrackBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.PriceLimit_TrackBar.HoverState.Parent = this.PriceLimit_TrackBar;
            this.PriceLimit_TrackBar.Location = new System.Drawing.Point(25, 65);
            this.PriceLimit_TrackBar.Maximum = 20;
            this.PriceLimit_TrackBar.Minimum = 1;
            this.PriceLimit_TrackBar.MouseWheelBarPartitions = 1;
            this.PriceLimit_TrackBar.Name = "PriceLimit_TrackBar";
            this.PriceLimit_TrackBar.Size = new System.Drawing.Size(182, 34);
            this.PriceLimit_TrackBar.TabIndex = 5;
            this.PriceLimit_TrackBar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.PriceLimit_TrackBar.Value = 10;
            this.PriceLimit_TrackBar.ValueChanged += new System.EventHandler(this.PriceLimit_TrackBar_ValueChanged);
            // 
            // PriceLimit_Label
            // 
            this.PriceLimit_Label.Enabled = false;
            this.PriceLimit_Label.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PriceLimit_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.PriceLimit_Label.Location = new System.Drawing.Point(213, 65);
            this.PriceLimit_Label.Name = "PriceLimit_Label";
            this.PriceLimit_Label.Size = new System.Drawing.Size(83, 34);
            this.PriceLimit_Label.TabIndex = 50;
            this.PriceLimit_Label.Text = "200.000.000";
            this.PriceLimit_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SaleManagement_Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PriceLimit_TrackBar);
            this.Controls.Add(this.PriceLimit_Label);
            this.Controls.Add(this.Resolution_ComboBox);
            this.Controls.Add(this.Storage_ComboBox);
            this.Controls.Add(this.RAM_ComboBox);
            this.Controls.Add(this.VGA_ComboBox);
            this.Controls.Add(this.CPU_ComboBox);
            this.Controls.Add(this.Size_ComboBox);
            this.Controls.Add(this.ColorSearch_Box);
            this.Name = "SaleManagement_Tab";
            this.Controls.SetChildIndex(this.Button_3, 0);
            this.Controls.SetChildIndex(this.Button_2, 0);
            this.Controls.SetChildIndex(this.Bottom_1, 0);
            this.Controls.SetChildIndex(this.SearchBox, 0);
            this.Controls.SetChildIndex(this.ColorSearch_Box, 0);
            this.Controls.SetChildIndex(this.Size_ComboBox, 0);
            this.Controls.SetChildIndex(this.CPU_ComboBox, 0);
            this.Controls.SetChildIndex(this.VGA_ComboBox, 0);
            this.Controls.SetChildIndex(this.RAM_ComboBox, 0);
            this.Controls.SetChildIndex(this.Storage_ComboBox, 0);
            this.Controls.SetChildIndex(this.Resolution_ComboBox, 0);
            this.Controls.SetChildIndex(this.PriceLimit_Label, 0);
            this.Controls.SetChildIndex(this.PriceLimit_TrackBar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private Guna.UI2.WinForms.Guna2ComboBox Size_ComboBox;
        private Guna.UI2.WinForms.Guna2ComboBox CPU_ComboBox;
        private Guna.UI2.WinForms.Guna2ComboBox VGA_ComboBox;
        private Guna.UI2.WinForms.Guna2ComboBox RAM_ComboBox;
        private Guna.UI2.WinForms.Guna2ComboBox Storage_ComboBox;
        private Guna.UI2.WinForms.Guna2ComboBox Resolution_ComboBox;
        protected Guna.UI2.WinForms.Guna2TextBox ColorSearch_Box;
        private Guna.UI2.WinForms.Guna2TrackBar PriceLimit_TrackBar;
        private System.Windows.Forms.Label PriceLimit_Label;
    }
}
