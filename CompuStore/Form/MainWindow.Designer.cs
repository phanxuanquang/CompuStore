﻿namespace CompuStore
{
    partial class MainWindow
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
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.ServiceManage_Button = new Guna.UI2.WinForms.Guna2TileButton();
            this.SaleManage_Button = new Guna.UI2.WinForms.Guna2TileButton();
            this.StaffManage_Button = new Guna.UI2.WinForms.Guna2TileButton();
            this.StorageManage_Button = new Guna.UI2.WinForms.Guna2TileButton();
            this.Header = new System.Windows.Forms.Label();
            this.Exit_Button = new Guna.UI2.WinForms.Guna2ImageButton();
            this.HeaderIcon = new System.Windows.Forms.PictureBox();
            this.DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.MenuPanel.Controls.Add(this.ServiceManage_Button);
            this.MenuPanel.Controls.Add(this.SaleManage_Button);
            this.MenuPanel.Controls.Add(this.StaffManage_Button);
            this.MenuPanel.Controls.Add(this.StorageManage_Button);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MenuPanel.Location = new System.Drawing.Point(0, 715);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(1226, 120);
            this.MenuPanel.TabIndex = 3;
            // 
            // ServiceManage_Button
            // 
            this.ServiceManage_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ServiceManage_Button.Animated = true;
            this.ServiceManage_Button.CheckedState.FillColor = System.Drawing.Color.White;
            this.ServiceManage_Button.CheckedState.Parent = this.ServiceManage_Button;
            this.ServiceManage_Button.CustomImages.Parent = this.ServiceManage_Button;
            this.ServiceManage_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ServiceManage_Button.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ServiceManage_Button.ForeColor = System.Drawing.Color.Black;
            this.ServiceManage_Button.HoverState.FillColor = System.Drawing.Color.White;
            this.ServiceManage_Button.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.ServiceManage_Button.HoverState.Parent = this.ServiceManage_Button;
            this.ServiceManage_Button.Image = global::CompuStore.Properties.Resources.Exit;
            this.ServiceManage_Button.ImageSize = new System.Drawing.Size(30, 30);
            this.ServiceManage_Button.Location = new System.Drawing.Point(617, 0);
            this.ServiceManage_Button.Margin = new System.Windows.Forms.Padding(0);
            this.ServiceManage_Button.Name = "ServiceManage_Button";
            this.ServiceManage_Button.ShadowDecoration.Parent = this.ServiceManage_Button;
            this.ServiceManage_Button.Size = new System.Drawing.Size(300, 119);
            this.ServiceManage_Button.TabIndex = 6;
            this.ServiceManage_Button.Text = "CHĂM SÓC KHÁCH HÀNG";
            this.ServiceManage_Button.Click += new System.EventHandler(this.ServiceManage_Button_Click);
            // 
            // SaleManage_Button
            // 
            this.SaleManage_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.SaleManage_Button.Animated = true;
            this.SaleManage_Button.CheckedState.FillColor = System.Drawing.Color.White;
            this.SaleManage_Button.CheckedState.Parent = this.SaleManage_Button;
            this.SaleManage_Button.CustomImages.Parent = this.SaleManage_Button;
            this.SaleManage_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.SaleManage_Button.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.SaleManage_Button.ForeColor = System.Drawing.Color.Black;
            this.SaleManage_Button.HoverState.FillColor = System.Drawing.Color.White;
            this.SaleManage_Button.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.SaleManage_Button.HoverState.Parent = this.SaleManage_Button;
            this.SaleManage_Button.Image = global::CompuStore.Properties.Resources.Exit;
            this.SaleManage_Button.ImageSize = new System.Drawing.Size(30, 30);
            this.SaleManage_Button.Location = new System.Drawing.Point(310, 0);
            this.SaleManage_Button.Margin = new System.Windows.Forms.Padding(0);
            this.SaleManage_Button.Name = "SaleManage_Button";
            this.SaleManage_Button.ShadowDecoration.Parent = this.SaleManage_Button;
            this.SaleManage_Button.Size = new System.Drawing.Size(300, 119);
            this.SaleManage_Button.TabIndex = 5;
            this.SaleManage_Button.Text = "BÁN HÀNG";
            this.SaleManage_Button.Click += new System.EventHandler(this.SaleManage_Button_Click);
            // 
            // StaffManage_Button
            // 
            this.StaffManage_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.StaffManage_Button.Animated = true;
            this.StaffManage_Button.CheckedState.FillColor = System.Drawing.Color.White;
            this.StaffManage_Button.CheckedState.Parent = this.StaffManage_Button;
            this.StaffManage_Button.CustomImages.Parent = this.StaffManage_Button;
            this.StaffManage_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.StaffManage_Button.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.StaffManage_Button.ForeColor = System.Drawing.Color.Black;
            this.StaffManage_Button.HoverState.FillColor = System.Drawing.Color.White;
            this.StaffManage_Button.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.StaffManage_Button.HoverState.Parent = this.StaffManage_Button;
            this.StaffManage_Button.Image = global::CompuStore.Properties.Resources.Exit;
            this.StaffManage_Button.ImageSize = new System.Drawing.Size(30, 30);
            this.StaffManage_Button.Location = new System.Drawing.Point(3, 0);
            this.StaffManage_Button.Margin = new System.Windows.Forms.Padding(0);
            this.StaffManage_Button.Name = "StaffManage_Button";
            this.StaffManage_Button.ShadowDecoration.Parent = this.StaffManage_Button;
            this.StaffManage_Button.Size = new System.Drawing.Size(300, 119);
            this.StaffManage_Button.TabIndex = 4;
            this.StaffManage_Button.Text = "NHÂN SỰ";
            this.StaffManage_Button.Click += new System.EventHandler(this.StaffManage_Button_Click);
            // 
            // StorageManage_Button
            // 
            this.StorageManage_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.StorageManage_Button.Animated = true;
            this.StorageManage_Button.CheckedState.FillColor = System.Drawing.Color.White;
            this.StorageManage_Button.CheckedState.Parent = this.StorageManage_Button;
            this.StorageManage_Button.CustomImages.Parent = this.StorageManage_Button;
            this.StorageManage_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.StorageManage_Button.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.StorageManage_Button.ForeColor = System.Drawing.Color.Black;
            this.StorageManage_Button.HoverState.FillColor = System.Drawing.Color.White;
            this.StorageManage_Button.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.StorageManage_Button.HoverState.Parent = this.StorageManage_Button;
            this.StorageManage_Button.Image = global::CompuStore.Properties.Resources.Exit;
            this.StorageManage_Button.ImageSize = new System.Drawing.Size(30, 30);
            this.StorageManage_Button.Location = new System.Drawing.Point(924, 0);
            this.StorageManage_Button.Margin = new System.Windows.Forms.Padding(0);
            this.StorageManage_Button.Name = "StorageManage_Button";
            this.StorageManage_Button.ShadowDecoration.Parent = this.StorageManage_Button;
            this.StorageManage_Button.Size = new System.Drawing.Size(300, 119);
            this.StorageManage_Button.TabIndex = 3;
            this.StorageManage_Button.Text = "KHO VẬN";
            this.StorageManage_Button.Click += new System.EventHandler(this.StorageManage_Button_Click);
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
            this.Header.Size = new System.Drawing.Size(1226, 40);
            this.Header.TabIndex = 4;
            this.Header.Text = "Tab name";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.Exit_Button.Location = new System.Drawing.Point(1186, 0);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.PressedState.Parent = this.Exit_Button;
            this.Exit_Button.Size = new System.Drawing.Size(40, 40);
            this.Exit_Button.TabIndex = 5;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // HeaderIcon
            // 
            this.HeaderIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.HeaderIcon.BackgroundImage = global::CompuStore.Properties.Resources.Exit;
            this.HeaderIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HeaderIcon.Location = new System.Drawing.Point(7, 8);
            this.HeaderIcon.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderIcon.Name = "HeaderIcon";
            this.HeaderIcon.Size = new System.Drawing.Size(25, 25);
            this.HeaderIcon.TabIndex = 6;
            this.HeaderIcon.TabStop = false;
            // 
            // DragControl
            // 
            this.DragControl.TargetControl = this.Header;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 40);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(1226, 675);
            this.ContainerPanel.TabIndex = 7;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1226, 835);
            this.Controls.Add(this.ContainerPanel);
            this.Controls.Add(this.HeaderIcon);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.MenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.MenuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MenuPanel;
        private Guna.UI2.WinForms.Guna2TileButton ServiceManage_Button;
        private Guna.UI2.WinForms.Guna2TileButton SaleManage_Button;
        private Guna.UI2.WinForms.Guna2TileButton StaffManage_Button;
        private Guna.UI2.WinForms.Guna2TileButton StorageManage_Button;
        private System.Windows.Forms.Label Header;
        private Guna.UI2.WinForms.Guna2ImageButton Exit_Button;
        private System.Windows.Forms.PictureBox HeaderIcon;
        private Guna.UI2.WinForms.Guna2DragControl DragControl;
        private System.Windows.Forms.Panel ContainerPanel;
    }
}