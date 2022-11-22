namespace CompuStore.GUI
{
    partial class Login_Form
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
            this.Login_Button = new Guna.UI2.WinForms.Guna2Button();
            this.Password_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Username_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Exit_Button = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ServerDatabase_ComboBox = new CompuStore.Control.ComboBoxCustom();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.RememberAccount_CheckBox = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.CheckBox_Panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckBox_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login_Button
            // 
            this.Login_Button.Animated = true;
            this.Login_Button.BorderRadius = 10;
            this.Login_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Login_Button.CheckedState.Parent = this.Login_Button;
            this.Login_Button.CustomImages.Parent = this.Login_Button;
            this.Login_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(151)))), ((int)(((byte)(232)))));
            this.Login_Button.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Login_Button.ForeColor = System.Drawing.Color.White;
            this.Login_Button.HoverState.Parent = this.Login_Button;
            this.Login_Button.Location = new System.Drawing.Point(54, 533);
            this.Login_Button.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.PressedDepth = 10;
            this.Login_Button.ShadowDecoration.Parent = this.Login_Button;
            this.Login_Button.Size = new System.Drawing.Size(750, 100);
            this.Login_Button.TabIndex = 4;
            this.Login_Button.Text = "ĐĂNG NHẬP";
            this.Login_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.Login_Button.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // Password_Box
            // 
            this.Password_Box.Animated = true;
            this.Password_Box.BackColor = System.Drawing.Color.Transparent;
            this.Password_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Password_Box.BorderRadius = 10;
            this.Password_Box.BorderThickness = 2;
            this.Password_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Password_Box.DefaultText = "";
            this.Password_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Password_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Password_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Password_Box.DisabledState.Parent = this.Password_Box;
            this.Password_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Password_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Password_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Password_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.Password_Box.FocusedState.Parent = this.Password_Box;
            this.Password_Box.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Password_Box.ForeColor = System.Drawing.Color.Black;
            this.Password_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Password_Box.HoverState.Parent = this.Password_Box;
            this.Password_Box.IconLeft = global::CompuStore.Properties.Resources.Exit;
            this.Password_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Password_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Password_Box.Location = new System.Drawing.Point(54, 278);
            this.Password_Box.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Password_Box.Name = "Password_Box";
            this.Password_Box.PasswordChar = '\0';
            this.Password_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Password_Box.PlaceholderText = "Mật khẩu";
            this.Password_Box.SelectedText = "";
            this.Password_Box.ShadowDecoration.Parent = this.Password_Box;
            this.Password_Box.Size = new System.Drawing.Size(750, 125);
            this.Password_Box.TabIndex = 6;
            this.Password_Box.TextOffset = new System.Drawing.Point(2, 0);
            this.Password_Box.UseSystemPasswordChar = true;
            // 
            // Username_Box
            // 
            this.Username_Box.Animated = true;
            this.Username_Box.BackColor = System.Drawing.Color.Transparent;
            this.Username_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Username_Box.BorderRadius = 10;
            this.Username_Box.BorderThickness = 2;
            this.Username_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Username_Box.DefaultText = "";
            this.Username_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Username_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Username_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Username_Box.DisabledState.Parent = this.Username_Box;
            this.Username_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Username_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Username_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Username_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.Username_Box.FocusedState.Parent = this.Username_Box;
            this.Username_Box.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Username_Box.ForeColor = System.Drawing.Color.Black;
            this.Username_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Username_Box.HoverState.Parent = this.Username_Box;
            this.Username_Box.IconLeft = global::CompuStore.Properties.Resources.Exit;
            this.Username_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Username_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.Username_Box.Location = new System.Drawing.Point(54, 107);
            this.Username_Box.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.PasswordChar = '\0';
            this.Username_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Username_Box.PlaceholderText = "Tên đăng nhập";
            this.Username_Box.SelectedText = "";
            this.Username_Box.ShadowDecoration.Parent = this.Username_Box;
            this.Username_Box.Size = new System.Drawing.Size(750, 125);
            this.Username_Box.TabIndex = 2;
            this.Username_Box.TextOffset = new System.Drawing.Point(2, 0);
            // 
            // Exit_Button
            // 
            this.Exit_Button.CheckedState.ImageSize = new System.Drawing.Size(25, 25);
            this.Exit_Button.CheckedState.Parent = this.Exit_Button;
            this.Exit_Button.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.Exit_Button.HoverState.Parent = this.Exit_Button;
            this.Exit_Button.Image = global::CompuStore.Properties.Resources.Exit;
            this.Exit_Button.ImageSize = new System.Drawing.Size(27, 27);
            this.Exit_Button.Location = new System.Drawing.Point(783, 0);
            this.Exit_Button.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.PressedState.Parent = this.Exit_Button;
            this.Exit_Button.Size = new System.Drawing.Size(75, 75);
            this.Exit_Button.TabIndex = 1;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // ServerDatabase_ComboBox
            // 
            this.ServerDatabase_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ServerDatabase_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ServerDatabase_ComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ServerDatabase_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerDatabase_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServerDatabase_ComboBox.FormattingEnabled = true;
            this.ServerDatabase_ComboBox.Location = new System.Drawing.Point(336, 688);
            this.ServerDatabase_ComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ServerDatabase_ComboBox.Name = "ServerDatabase_ComboBox";
            this.ServerDatabase_ComboBox.Size = new System.Drawing.Size(513, 40);
            this.ServerDatabase_ComboBox.TabIndex = 7;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            // 
            // RememberAccount_CheckBox
            // 
            this.RememberAccount_CheckBox.Animated = true;
            this.RememberAccount_CheckBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RememberAccount_CheckBox.CheckedState.BorderRadius = 5;
            this.RememberAccount_CheckBox.CheckedState.BorderThickness = 0;
            this.RememberAccount_CheckBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RememberAccount_CheckBox.CheckedState.Parent = this.RememberAccount_CheckBox;
            this.RememberAccount_CheckBox.Location = new System.Drawing.Point(16, 20);
            this.RememberAccount_CheckBox.Name = "RememberAccount_CheckBox";
            this.RememberAccount_CheckBox.ShadowDecoration.Parent = this.RememberAccount_CheckBox;
            this.RememberAccount_CheckBox.Size = new System.Drawing.Size(25, 25);
            this.RememberAccount_CheckBox.TabIndex = 8;
            this.RememberAccount_CheckBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.RememberAccount_CheckBox.UncheckedState.BorderRadius = 5;
            this.RememberAccount_CheckBox.UncheckedState.BorderThickness = 0;
            this.RememberAccount_CheckBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.RememberAccount_CheckBox.UncheckedState.Parent = this.RememberAccount_CheckBox;
            // 
            // CheckBox_Panel
            // 
            this.CheckBox_Panel.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Panel.Controls.Add(this.label1);
            this.CheckBox_Panel.Controls.Add(this.RememberAccount_CheckBox);
            this.CheckBox_Panel.Location = new System.Drawing.Point(54, 437);
            this.CheckBox_Panel.Name = "CheckBox_Panel";
            this.CheckBox_Panel.Size = new System.Drawing.Size(269, 61);
            this.CheckBox_Panel.TabIndex = 9;
            this.CheckBox_Panel.Click += new System.EventHandler(this.CheckBox_Panel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ghi nhớ mật khẩu";
            this.label1.Click += new System.EventHandler(this.CheckBox_Panel_Click);
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(861, 741);
            this.Controls.Add(this.CheckBox_Panel);
            this.Controls.Add(this.ServerDatabase_ComboBox);
            this.Controls.Add(this.Password_Box);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.Username_Box);
            this.Controls.Add(this.Exit_Button);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.CheckBox_Panel.ResumeLayout(false);
            this.CheckBox_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ImageButton Exit_Button;
        private Guna.UI2.WinForms.Guna2TextBox Username_Box;
        private Guna.UI2.WinForms.Guna2Button Login_Button;
        private Guna.UI2.WinForms.Guna2TextBox Password_Box;
        private CompuStore.Control.ComboBoxCustom ServerDatabase_ComboBox;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel CheckBox_Panel;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CustomCheckBox RememberAccount_CheckBox;
    }
}