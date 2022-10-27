﻿namespace CompuStore
{
    partial class StaffManagement_Tab
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
            this.sTAFFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sTAFFBindingSource)).BeginInit();
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
            this.SearchBox.PlaceholderText = "Tìm kiếm nhân viên theo mã, họ và tên hoặc số điện thoại";
            this.SearchBox.ShadowDecoration.Parent = this.SearchBox;
            // 
            // ViewDetail_Button
            // 
            this.Button2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.Button2.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Button2.CheckedState.Parent = this.Button2;
            this.Button2.CustomImages.Parent = this.Button2;
            this.Button2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Button2.HoverState.Parent = this.Button2;
            this.Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button2.ShadowDecoration.Parent = this.Button2;
            this.Button2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button2.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            this.Button2.Click += new System.EventHandler(this.ViewDetail_Button_Click);
            // 
            // Delete_Button
            // 
            this.Button3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.Button3.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Button3.CheckedState.Parent = this.Button3;
            this.Button3.CustomImages.Parent = this.Button3;
            this.Button3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Button3.HoverState.Parent = this.Button3;
            this.Button3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button3.ShadowDecoration.Parent = this.Button3;
            this.Button3.Text = "Thu hồi quyền";
            this.Button3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button3.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            // 
            // AddNew_Buttom
            // 
            this.Button1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.Button1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Button1.CheckedState.Parent = this.Button1;
            this.Button1.CustomImages.Parent = this.Button1;
            this.Button1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Button1.HoverState.Parent = this.Button1;
            this.Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button1.ShadowDecoration.Parent = this.Button1;
            this.Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button1.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            this.Button1.Click += new System.EventHandler(this.AddNew_Buttom_Click);
            // 
            // sTAFFBindingSource
            // 
            this.sTAFFBindingSource.DataSource = typeof(CompuStore.Database.Models.STAFF);
            // 
            // StaffManagement_Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "StaffManagement_Tab";
            ((System.ComponentModel.ISupportInitialize)(this.sTAFFBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource sTAFFBindingSource;
    }
}
