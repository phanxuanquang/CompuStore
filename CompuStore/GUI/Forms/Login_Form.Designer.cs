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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            this.Login_Button = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.RememberAccount_CheckBox = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.CheckBox_Panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.Password_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Username_Box = new Guna.UI2.WinForms.Guna2TextBox();
            this.Background = new System.Windows.Forms.Panel();
            this.Welcome_Label = new System.Windows.Forms.Label();
            this.Exit_Button = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.ServerDatabase_ComboBox = new CompuStore.Control.ComboBoxCustom();
            this.CheckBox_Panel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login_Button
            // 
            this.Login_Button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Login_Button.Animated = true;
            this.Login_Button.AutoRoundedCorners = true;
            this.Login_Button.BorderRadius = 23;
            this.Login_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Login_Button.CheckedState.Parent = this.Login_Button;
            this.Login_Button.CustomImages.Parent = this.Login_Button;
            this.Login_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(204)))));
            this.Login_Button.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Login_Button.ForeColor = System.Drawing.Color.White;
            this.Login_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.Login_Button.HoverState.Parent = this.Login_Button;
            this.Login_Button.Location = new System.Drawing.Point(105, 246);
            this.Login_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.PressedDepth = 10;
            this.Login_Button.ShadowDecoration.Parent = this.Login_Button;
            this.Login_Button.Size = new System.Drawing.Size(390, 49);
            this.Login_Button.TabIndex = 4;
            this.Login_Button.Text = "ĐĂNG NHẬP";
            this.Login_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.Login_Button.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 11;
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
            this.RememberAccount_CheckBox.Location = new System.Drawing.Point(8, 7);
            this.RememberAccount_CheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.RememberAccount_CheckBox.Name = "RememberAccount_CheckBox";
            this.RememberAccount_CheckBox.ShadowDecoration.Parent = this.RememberAccount_CheckBox;
            this.RememberAccount_CheckBox.Size = new System.Drawing.Size(15, 15);
            this.RememberAccount_CheckBox.TabIndex = 8;
            this.RememberAccount_CheckBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.RememberAccount_CheckBox.UncheckedState.BorderRadius = 5;
            this.RememberAccount_CheckBox.UncheckedState.BorderThickness = 0;
            this.RememberAccount_CheckBox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.RememberAccount_CheckBox.UncheckedState.Parent = this.RememberAccount_CheckBox;
            // 
            // CheckBox_Panel
            // 
            this.CheckBox_Panel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CheckBox_Panel.BackColor = System.Drawing.Color.Transparent;
            this.CheckBox_Panel.Controls.Add(this.label1);
            this.CheckBox_Panel.Controls.Add(this.RememberAccount_CheckBox);
            this.CheckBox_Panel.Location = new System.Drawing.Point(105, 192);
            this.CheckBox_Panel.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBox_Panel.Name = "CheckBox_Panel";
            this.CheckBox_Panel.Size = new System.Drawing.Size(134, 30);
            this.CheckBox_Panel.TabIndex = 9;
            this.CheckBox_Panel.Click += new System.EventHandler(this.CheckBox_Panel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ghi nhớ mật khẩu";
            this.label1.Click += new System.EventHandler(this.CheckBox_Panel_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.Exit_Button);
            this.MainPanel.Controls.Add(this.Welcome_Label);
            this.MainPanel.Controls.Add(this.Login_Button);
            this.MainPanel.Controls.Add(this.ServerDatabase_ComboBox);
            this.MainPanel.Controls.Add(this.CheckBox_Panel);
            this.MainPanel.Controls.Add(this.Password_Box);
            this.MainPanel.Controls.Add(this.Username_Box);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainPanel.Location = new System.Drawing.Point(0, 415);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(600, 412);
            this.MainPanel.TabIndex = 10;
            // 
            // Password_Box
            // 
            this.Password_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Password_Box.Animated = true;
            this.Password_Box.BackColor = System.Drawing.Color.Transparent;
            this.Password_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Password_Box.BorderRadius = 6;
            this.Password_Box.BorderThickness = 0;
            this.Password_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Password_Box.DefaultText = "";
            this.Password_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Password_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.Password_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Password_Box.DisabledState.Parent = this.Password_Box;
            this.Password_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Password_Box.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(204)))));
            this.Password_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Password_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.Password_Box.FocusedState.ForeColor = System.Drawing.Color.White;
            this.Password_Box.FocusedState.Parent = this.Password_Box;
            this.Password_Box.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Password_Box.ForeColor = System.Drawing.Color.White;
            this.Password_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Password_Box.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.Password_Box.HoverState.Parent = this.Password_Box;
            this.Password_Box.IconLeft = global::CompuStore.Properties.Resources.Password;
            this.Password_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Password_Box.Location = new System.Drawing.Point(105, 152);
            this.Password_Box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Password_Box.Name = "Password_Box";
            this.Password_Box.PasswordChar = '\0';
            this.Password_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Password_Box.PlaceholderText = "Mật khẩu";
            this.Password_Box.SelectedText = "";
            this.Password_Box.ShadowDecoration.Parent = this.Password_Box;
            this.Password_Box.Size = new System.Drawing.Size(390, 40);
            this.Password_Box.TabIndex = 6;
            this.Password_Box.TextOffset = new System.Drawing.Point(10, 0);
            this.Password_Box.UseSystemPasswordChar = true;
            // 
            // Username_Box
            // 
            this.Username_Box.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Username_Box.Animated = true;
            this.Username_Box.BackColor = System.Drawing.Color.Transparent;
            this.Username_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Username_Box.BorderRadius = 6;
            this.Username_Box.BorderThickness = 0;
            this.Username_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Username_Box.DefaultText = "";
            this.Username_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Username_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.Username_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Username_Box.DisabledState.Parent = this.Username_Box;
            this.Username_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Username_Box.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(204)))));
            this.Username_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Username_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.Username_Box.FocusedState.ForeColor = System.Drawing.Color.White;
            this.Username_Box.FocusedState.Parent = this.Username_Box;
            this.Username_Box.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Username_Box.ForeColor = System.Drawing.Color.White;
            this.Username_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.Username_Box.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.Username_Box.HoverState.Parent = this.Username_Box;
            this.Username_Box.IconLeft = global::CompuStore.Properties.Resources.Username;
            this.Username_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.Username_Box.Location = new System.Drawing.Point(105, 92);
            this.Username_Box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.PasswordChar = '\0';
            this.Username_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Username_Box.PlaceholderText = "Tên đăng nhập";
            this.Username_Box.SelectedText = "";
            this.Username_Box.ShadowDecoration.Parent = this.Username_Box;
            this.Username_Box.Size = new System.Drawing.Size(390, 40);
            this.Username_Box.TabIndex = 2;
            this.Username_Box.TextOffset = new System.Drawing.Point(10, 0);
            // 
            // Background
            // 
            this.Background.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Background.BackgroundImage")));
            this.Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(600, 415);
            this.Background.TabIndex = 11;
            // 
            // Welcome_Label
            // 
            this.Welcome_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.Welcome_Label.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Welcome_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(79)))), ((int)(((byte)(180)))));
            this.Welcome_Label.Location = new System.Drawing.Point(0, 0);
            this.Welcome_Label.Name = "Welcome_Label";
            this.Welcome_Label.Size = new System.Drawing.Size(600, 89);
            this.Welcome_Label.TabIndex = 10;
            this.Welcome_Label.Text = "CHÀO MỪNG";
            this.Welcome_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Exit_Button
            // 
            this.Exit_Button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Exit_Button.Animated = true;
            this.Exit_Button.AutoRoundedCorners = true;
            this.Exit_Button.BorderRadius = 23;
            this.Exit_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Exit_Button.CheckedState.Parent = this.Exit_Button;
            this.Exit_Button.CustomImages.Parent = this.Exit_Button;
            this.Exit_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(204)))));
            this.Exit_Button.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Exit_Button.ForeColor = System.Drawing.Color.White;
            this.Exit_Button.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.Exit_Button.HoverState.Parent = this.Exit_Button;
            this.Exit_Button.Location = new System.Drawing.Point(105, 304);
            this.Exit_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.PressedDepth = 10;
            this.Exit_Button.ShadowDecoration.Parent = this.Exit_Button;
            this.Exit_Button.Size = new System.Drawing.Size(390, 49);
            this.Exit_Button.TabIndex = 11;
            this.Exit_Button.Text = "THOÁT";
            this.Exit_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.Exit_Button.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click_1);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.Background;
            // 
            // ServerDatabase_ComboBox
            // 
            this.ServerDatabase_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ServerDatabase_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ServerDatabase_ComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ServerDatabase_ComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ServerDatabase_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerDatabase_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServerDatabase_ComboBox.FormattingEnabled = true;
            this.ServerDatabase_ComboBox.Location = new System.Drawing.Point(0, 389);
            this.ServerDatabase_ComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.ServerDatabase_ComboBox.Name = "ServerDatabase_ComboBox";
            this.ServerDatabase_ComboBox.Size = new System.Drawing.Size(600, 23);
            this.ServerDatabase_ComboBox.TabIndex = 7;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 827);
            this.Controls.Add(this.Background);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.CheckBox_Panel.ResumeLayout(false);
            this.CheckBox_Panel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox Username_Box;
        private Guna.UI2.WinForms.Guna2Button Login_Button;
        private Guna.UI2.WinForms.Guna2TextBox Password_Box;
        private CompuStore.Control.ComboBoxCustom ServerDatabase_ComboBox;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel CheckBox_Panel;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CustomCheckBox RememberAccount_CheckBox;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel Background;
        private Guna.UI2.WinForms.Guna2Button Exit_Button;
        private System.Windows.Forms.Label Welcome_Label;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}