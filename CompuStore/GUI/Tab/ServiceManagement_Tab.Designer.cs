﻿namespace CompuStore
{
    partial class ServiceManagement_Tab
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
            this.components = new System.ComponentModel.Container();
            this.warrantyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.warrantyBindingSource)).BeginInit();
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
            this.SearchBox.PlaceholderText = "Tìm kiếm phiếu bảo hành theo số điện thoại ";
            this.SearchBox.ShadowDecoration.Parent = this.SearchBox;
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
            this.Button_2.ShadowDecoration.Parent = this.Button_2;
            this.Button_2.Text = "Thêm phiếu đổi trả";
            this.Button_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_2.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            this.Button_2.Click += new System.EventHandler(this.Button_2_Click);
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
            this.Bottom_1.ShadowDecoration.Parent = this.Bottom_1;
            this.Bottom_1.Text = "Thêm phiếu bảo hành";
            this.Bottom_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Bottom_1.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            this.Bottom_1.Click += new System.EventHandler(this.Bottom_1_Click);
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
            this.Button_3.ShadowDecoration.Parent = this.Button_3;
            this.Button_3.Text = "Danh sách đổi trả";
            this.Button_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_3.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            this.Button_3.Click += new System.EventHandler(this.Button_3_Click);
            // 
            // warrantyBindingSource
            // 
            this.warrantyBindingSource.DataSource = typeof(CompuStore.Database.Models.RECEIVE_WARRANTY);
            // 
            // ServiceManagement_Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ServiceManagement_Tab";
            ((System.ComponentModel.ISupportInitialize)(this.warrantyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource warrantyBindingSource;
    }
}
