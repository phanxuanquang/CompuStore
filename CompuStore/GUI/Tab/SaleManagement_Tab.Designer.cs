namespace CompuStore
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
        private void InitializeComponent()
        {
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
            this.SearchBox.PlaceholderText = "Tìm kiếm sản phẩm theo mã hoặc tên";
            this.SearchBox.ShadowDecoration.Parent = this.SearchBox;
            this.SearchBox.Size = new System.Drawing.Size(767, 37);
            // 
            // ViewDetail_Button
            // 
            this.ViewDetail_Button.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.ViewDetail_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.ViewDetail_Button.CheckedState.Parent = this.ViewDetail_Button;
            this.ViewDetail_Button.CustomImages.Parent = this.ViewDetail_Button;
            this.ViewDetail_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ViewDetail_Button.HoverState.Parent = this.ViewDetail_Button;
            this.ViewDetail_Button.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ViewDetail_Button.Location = new System.Drawing.Point(1007, 19);
            this.ViewDetail_Button.ShadowDecoration.Parent = this.ViewDetail_Button;
            this.ViewDetail_Button.Text = "Xem cấu hình";
            this.ViewDetail_Button.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ViewDetail_Button.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            this.ViewDetail_Button.Click += new System.EventHandler(this.ViewDetail_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.Delete_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Delete_Button.CheckedState.Parent = this.Delete_Button;
            this.Delete_Button.CustomImages.Parent = this.Delete_Button;
            this.Delete_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Delete_Button.HoverState.Parent = this.Delete_Button;
            this.Delete_Button.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Delete_Button.ShadowDecoration.Parent = this.Delete_Button;
            this.Delete_Button.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Delete_Button.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            this.Delete_Button.Visible = false;
            // 
            // AddNew_Buttom
            // 
            this.AddNew_Buttom.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.AddNew_Buttom.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.AddNew_Buttom.CheckedState.Parent = this.AddNew_Buttom;
            this.AddNew_Buttom.CustomImages.Parent = this.AddNew_Buttom;
            this.AddNew_Buttom.DialogResult = System.Windows.Forms.DialogResult.None;
            this.AddNew_Buttom.HoverState.Parent = this.AddNew_Buttom;
            this.AddNew_Buttom.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AddNew_Buttom.Location = new System.Drawing.Point(798, 19);
            this.AddNew_Buttom.ShadowDecoration.Parent = this.AddNew_Buttom;
            this.AddNew_Buttom.Text = "Tạo đơn hàng";
            this.AddNew_Buttom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AddNew_Buttom.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            this.AddNew_Buttom.Click += new System.EventHandler(this.AddNew_Buttom_Click);
            // 
            // SaleManagement_Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "SaleManagement_Tab";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
