﻿namespace CompuStore.Tab.Warehouse
{
    partial class DetailInvoiceImportWarehouse_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Header = new System.Windows.Forms.Label();
            this.Exit_Button = new Guna.UI2.WinForms.Guna2ImageButton();
            this.DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Distributor = new System.Windows.Forms.Label();
            this.DateTimeImportWarehouse = new System.Windows.Forms.Label();
            this.ImportToStore = new System.Windows.Forms.Label();
            this.TotalImportWarehouse = new System.Windows.Forms.Label();
            this.Distributor_Combobox = new System.Windows.Forms.ComboBox();
            this.DateTimeImportWarehouse_Label = new System.Windows.Forms.Label();
            this.StoreImportWarehouse_Combobox = new System.Windows.Forms.ComboBox();
            this.TotalImportWarehouse_Label = new System.Windows.Forms.Label();
            this.DateTimeImportWarehouse_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AddProduct_Button = new Guna.UI2.WinForms.Guna2Button();
            this.DeleteProduct_Button = new Guna.UI2.WinForms.Guna2Button();
            this.AddProductByExcel_Button = new Guna.UI2.WinForms.Guna2Button();
            this.TableData_DataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.No_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPU_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPU_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAM_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizePanelDisplay_Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DisplayResolution_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QualityPanel_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StorageType_Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StorageCapacity_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatteryCapacity_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensions_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Confirm_Button = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.TableData_DataGridView)).BeginInit();
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
            this.Header.Size = new System.Drawing.Size(1269, 40);
            this.Header.TabIndex = 5;
            this.Header.Text = "Chi tiết nhập hàng";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.Exit_Button.Location = new System.Drawing.Point(1485, 0);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.PressedState.Parent = this.Exit_Button;
            this.Exit_Button.Size = new System.Drawing.Size(40, 40);
            this.Exit_Button.TabIndex = 6;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // DragControl
            // 
            this.DragControl.TargetControl = this.Header;
            // 
            // Distributor
            // 
            this.Distributor.AutoSize = true;
            this.Distributor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Distributor.Location = new System.Drawing.Point(68, 53);
            this.Distributor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Distributor.Name = "Distributor";
            this.Distributor.Size = new System.Drawing.Size(81, 15);
            this.Distributor.TabIndex = 7;
            this.Distributor.Text = "Nhà cung cấp";
            // 
            // DateTimeImportWarehouse
            // 
            this.DateTimeImportWarehouse.AutoSize = true;
            this.DateTimeImportWarehouse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeImportWarehouse.Location = new System.Drawing.Point(68, 83);
            this.DateTimeImportWarehouse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DateTimeImportWarehouse.Name = "DateTimeImportWarehouse";
            this.DateTimeImportWarehouse.Size = new System.Drawing.Size(95, 15);
            this.DateTimeImportWarehouse.TabIndex = 8;
            this.DateTimeImportWarehouse.Text = "Ngày nhập hàng";
            // 
            // ImportToStore
            // 
            this.ImportToStore.AutoSize = true;
            this.ImportToStore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportToStore.Location = new System.Drawing.Point(68, 113);
            this.ImportToStore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ImportToStore.Name = "ImportToStore";
            this.ImportToStore.Size = new System.Drawing.Size(103, 15);
            this.ImportToStore.TabIndex = 9;
            this.ImportToStore.Text = "Nhập vào kho của";
            // 
            // TotalImportWarehouse
            // 
            this.TotalImportWarehouse.AutoSize = true;
            this.TotalImportWarehouse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalImportWarehouse.Location = new System.Drawing.Point(68, 143);
            this.TotalImportWarehouse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalImportWarehouse.Name = "TotalImportWarehouse";
            this.TotalImportWarehouse.Size = new System.Drawing.Size(67, 15);
            this.TotalImportWarehouse.TabIndex = 10;
            this.TotalImportWarehouse.Text = "Tổng giá trị";
            // 
            // Distributor_Combobox
            // 
            this.Distributor_Combobox.FormattingEnabled = true;
            this.Distributor_Combobox.Location = new System.Drawing.Point(206, 52);
            this.Distributor_Combobox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Distributor_Combobox.Name = "Distributor_Combobox";
            this.Distributor_Combobox.Size = new System.Drawing.Size(202, 21);
            this.Distributor_Combobox.TabIndex = 11;
            // 
            // DateTimeImportWarehouse_Label
            // 
            this.DateTimeImportWarehouse_Label.AutoSize = true;
            this.DateTimeImportWarehouse_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeImportWarehouse_Label.Location = new System.Drawing.Point(203, 83);
            this.DateTimeImportWarehouse_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DateTimeImportWarehouse_Label.Name = "DateTimeImportWarehouse_Label";
            this.DateTimeImportWarehouse_Label.Size = new System.Drawing.Size(108, 15);
            this.DateTimeImportWarehouse_Label.TabIndex = 13;
            this.DateTimeImportWarehouse_Label.Text = "9:36AM 22/10/2022";
            this.DateTimeImportWarehouse_Label.Click += new System.EventHandler(this.DateTimeImportWarehouse_Label_Click);
            // 
            // StoreImportWarehouse_Combobox
            // 
            this.StoreImportWarehouse_Combobox.FormattingEnabled = true;
            this.StoreImportWarehouse_Combobox.Location = new System.Drawing.Point(206, 112);
            this.StoreImportWarehouse_Combobox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StoreImportWarehouse_Combobox.Name = "StoreImportWarehouse_Combobox";
            this.StoreImportWarehouse_Combobox.Size = new System.Drawing.Size(202, 21);
            this.StoreImportWarehouse_Combobox.TabIndex = 14;
            // 
            // TotalImportWarehouse_Label
            // 
            this.TotalImportWarehouse_Label.AutoSize = true;
            this.TotalImportWarehouse_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalImportWarehouse_Label.Location = new System.Drawing.Point(203, 143);
            this.TotalImportWarehouse_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalImportWarehouse_Label.Name = "TotalImportWarehouse_Label";
            this.TotalImportWarehouse_Label.Size = new System.Drawing.Size(105, 15);
            this.TotalImportWarehouse_Label.TabIndex = 15;
            this.TotalImportWarehouse_Label.Text = "1000 củ khoai lang";
            // 
            // DateTimeImportWarehouse_DateTimePicker
            // 
            this.DateTimeImportWarehouse_DateTimePicker.CustomFormat = "hh:mm:ss dd/MM/yyyy";
            this.DateTimeImportWarehouse_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimeImportWarehouse_DateTimePicker.Location = new System.Drawing.Point(318, 83);
            this.DateTimeImportWarehouse_DateTimePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DateTimeImportWarehouse_DateTimePicker.Name = "DateTimeImportWarehouse_DateTimePicker";
            this.DateTimeImportWarehouse_DateTimePicker.Size = new System.Drawing.Size(152, 20);
            this.DateTimeImportWarehouse_DateTimePicker.TabIndex = 16;
            this.DateTimeImportWarehouse_DateTimePicker.Visible = false;
            // 
            // AddProduct_Button
            // 
            this.AddProduct_Button.Animated = true;
            this.AddProduct_Button.BorderRadius = 5;
            this.AddProduct_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.AddProduct_Button.CheckedState.Parent = this.AddProduct_Button;
            this.AddProduct_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddProduct_Button.CustomImages.Parent = this.AddProduct_Button;
            this.AddProduct_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.AddProduct_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.AddProduct_Button.ForeColor = System.Drawing.Color.White;
            this.AddProduct_Button.HoverState.Parent = this.AddProduct_Button;
            this.AddProduct_Button.Location = new System.Drawing.Point(589, 53);
            this.AddProduct_Button.Name = "AddProduct_Button";
            this.AddProduct_Button.PressedDepth = 5;
            this.AddProduct_Button.ShadowDecoration.Parent = this.AddProduct_Button;
            this.AddProduct_Button.Size = new System.Drawing.Size(203, 37);
            this.AddProduct_Button.TabIndex = 19;
            this.AddProduct_Button.Text = "Thêm";
            this.AddProduct_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.AddProduct_Button.Click += new System.EventHandler(this.AddProduct_Button_Click);
            // 
            // DeleteProduct_Button
            // 
            this.DeleteProduct_Button.Animated = true;
            this.DeleteProduct_Button.BorderRadius = 5;
            this.DeleteProduct_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.DeleteProduct_Button.CheckedState.Parent = this.DeleteProduct_Button;
            this.DeleteProduct_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteProduct_Button.CustomImages.Parent = this.DeleteProduct_Button;
            this.DeleteProduct_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.DeleteProduct_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.DeleteProduct_Button.ForeColor = System.Drawing.Color.White;
            this.DeleteProduct_Button.HoverState.Parent = this.DeleteProduct_Button;
            this.DeleteProduct_Button.Location = new System.Drawing.Point(800, 53);
            this.DeleteProduct_Button.Name = "DeleteProduct_Button";
            this.DeleteProduct_Button.PressedDepth = 5;
            this.DeleteProduct_Button.ShadowDecoration.Parent = this.DeleteProduct_Button;
            this.DeleteProduct_Button.Size = new System.Drawing.Size(203, 37);
            this.DeleteProduct_Button.TabIndex = 18;
            this.DeleteProduct_Button.Text = "Xóa";
            this.DeleteProduct_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // AddProductByExcel_Button
            // 
            this.AddProductByExcel_Button.Animated = true;
            this.AddProductByExcel_Button.BorderRadius = 5;
            this.AddProductByExcel_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.AddProductByExcel_Button.CheckedState.Parent = this.AddProductByExcel_Button;
            this.AddProductByExcel_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddProductByExcel_Button.CustomImages.Parent = this.AddProductByExcel_Button;
            this.AddProductByExcel_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.AddProductByExcel_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.AddProductByExcel_Button.ForeColor = System.Drawing.Color.White;
            this.AddProductByExcel_Button.HoverState.Parent = this.AddProductByExcel_Button;
            this.AddProductByExcel_Button.Location = new System.Drawing.Point(1011, 53);
            this.AddProductByExcel_Button.Name = "AddProductByExcel_Button";
            this.AddProductByExcel_Button.PressedDepth = 5;
            this.AddProductByExcel_Button.ShadowDecoration.Parent = this.AddProductByExcel_Button;
            this.AddProductByExcel_Button.Size = new System.Drawing.Size(203, 37);
            this.AddProductByExcel_Button.TabIndex = 17;
            this.AddProductByExcel_Button.Text = "Nhập bằng Excel";
            this.AddProductByExcel_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // TableData_DataGridView
            // 
            this.TableData_DataGridView.AllowUserToAddRows = false;
            this.TableData_DataGridView.AllowUserToDeleteRows = false;
            this.TableData_DataGridView.AllowUserToResizeColumns = false;
            this.TableData_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            this.TableData_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TableData_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableData_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.TableData_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.TableData_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableData_DataGridView.CausesValidation = false;
            this.TableData_DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TableData_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(151)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableData_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.TableData_DataGridView.ColumnHeadersHeight = 48;
            this.TableData_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No_Column,
            this.CPU_Column,
            this.GPU_Column,
            this.RAM_Column,
            this.SizePanelDisplay_Column,
            this.DisplayResolution_Column,
            this.QualityPanel_Column,
            this.StorageType_Column,
            this.StorageCapacity_Column,
            this.BatteryCapacity_Column,
            this.Weight,
            this.Dimensions_Column});
            this.TableData_DataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TableData_DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.TableData_DataGridView.EnableHeadersVisualStyles = false;
            this.TableData_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.TableData_DataGridView.Location = new System.Drawing.Point(0, 171);
            this.TableData_DataGridView.MultiSelect = false;
            this.TableData_DataGridView.Name = "TableData_DataGridView";
            this.TableData_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableData_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.TableData_DataGridView.RowHeadersVisible = false;
            this.TableData_DataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            this.TableData_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.TableData_DataGridView.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);
            this.TableData_DataGridView.RowTemplate.Height = 48;
            this.TableData_DataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TableData_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TableData_DataGridView.Size = new System.Drawing.Size(1525, 541);
            this.TableData_DataGridView.TabIndex = 20;
            this.TableData_DataGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.TableData_DataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.TableData_DataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.TableData_DataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.TableData_DataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.TableData_DataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.TableData_DataGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.TableData_DataGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.TableData_DataGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.TableData_DataGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TableData_DataGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TableData_DataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.TableData_DataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.TableData_DataGridView.ThemeStyle.HeaderStyle.Height = 48;
            this.TableData_DataGridView.ThemeStyle.ReadOnly = false;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TableData_DataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.Height = 48;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.TableData_DataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // No_Column
            // 
            this.No_Column.HeaderText = "STT";
            this.No_Column.MinimumWidth = 10;
            this.No_Column.Name = "No_Column";
            this.No_Column.Width = 72;
            // 
            // CPU_Column
            // 
            this.CPU_Column.HeaderText = "CPU";
            this.CPU_Column.MinimumWidth = 10;
            this.CPU_Column.Name = "CPU_Column";
            this.CPU_Column.Width = 76;
            // 
            // GPU_Column
            // 
            this.GPU_Column.HeaderText = "GPU";
            this.GPU_Column.MinimumWidth = 10;
            this.GPU_Column.Name = "GPU_Column";
            this.GPU_Column.Width = 77;
            // 
            // RAM_Column
            // 
            this.RAM_Column.HeaderText = "RAM";
            this.RAM_Column.MinimumWidth = 10;
            this.RAM_Column.Name = "RAM_Column";
            this.RAM_Column.Width = 77;
            // 
            // SizePanelDisplay_Column
            // 
            this.SizePanelDisplay_Column.HeaderText = "Kích thước màn hình";
            this.SizePanelDisplay_Column.MinimumWidth = 10;
            this.SizePanelDisplay_Column.Name = "SizePanelDisplay_Column";
            this.SizePanelDisplay_Column.Width = 131;
            // 
            // DisplayResolution_Column
            // 
            this.DisplayResolution_Column.HeaderText = "Độ phân giải màn hình";
            this.DisplayResolution_Column.MinimumWidth = 10;
            this.DisplayResolution_Column.Name = "DisplayResolution_Column";
            this.DisplayResolution_Column.Width = 162;
            // 
            // QualityPanel_Column
            // 
            this.QualityPanel_Column.HeaderText = "Chất lượng tấm nền";
            this.QualityPanel_Column.MinimumWidth = 10;
            this.QualityPanel_Column.Name = "QualityPanel_Column";
            this.QualityPanel_Column.Width = 147;
            // 
            // StorageType_Column
            // 
            this.StorageType_Column.HeaderText = "Loại ổ cứng";
            this.StorageType_Column.MinimumWidth = 10;
            this.StorageType_Column.Name = "StorageType_Column";
            // 
            // StorageCapacity_Column
            // 
            this.StorageCapacity_Column.HeaderText = "Dung lượng ổ cứng";
            this.StorageCapacity_Column.MinimumWidth = 10;
            this.StorageCapacity_Column.Name = "StorageCapacity_Column";
            this.StorageCapacity_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StorageCapacity_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StorageCapacity_Column.Width = 115;
            // 
            // BatteryCapacity_Column
            // 
            this.BatteryCapacity_Column.HeaderText = "Dung lượng pin";
            this.BatteryCapacity_Column.MinimumWidth = 10;
            this.BatteryCapacity_Column.Name = "BatteryCapacity_Column";
            this.BatteryCapacity_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BatteryCapacity_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BatteryCapacity_Column.Width = 102;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Cân nặng";
            this.Weight.MinimumWidth = 10;
            this.Weight.Name = "Weight";
            this.Weight.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Weight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Weight.Width = 85;
            // 
            // Dimensions_Column
            // 
            this.Dimensions_Column.HeaderText = "Kích thước máy";
            this.Dimensions_Column.MinimumWidth = 10;
            this.Dimensions_Column.Name = "Dimensions_Column";
            this.Dimensions_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Dimensions_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Dimensions_Column.Width = 125;
            // 
            // Confirm_Button
            // 
            this.Confirm_Button.Animated = true;
            this.Confirm_Button.BorderRadius = 5;
            this.Confirm_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Confirm_Button.CheckedState.Parent = this.Confirm_Button;
            this.Confirm_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Confirm_Button.CustomImages.Parent = this.Confirm_Button;
            this.Confirm_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Confirm_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Confirm_Button.ForeColor = System.Drawing.Color.White;
            this.Confirm_Button.HoverState.Parent = this.Confirm_Button;
            this.Confirm_Button.Location = new System.Drawing.Point(1011, 729);
            this.Confirm_Button.Name = "Confirm_Button";
            this.Confirm_Button.PressedDepth = 5;
            this.Confirm_Button.ShadowDecoration.Parent = this.Confirm_Button;
            this.Confirm_Button.Size = new System.Drawing.Size(203, 37);
            this.Confirm_Button.TabIndex = 21;
            this.Confirm_Button.Text = "Xác nhận";
            this.Confirm_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // DetailInvoiceImportWarehouse_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1269, 634);
            this.Controls.Add(this.Confirm_Button);
            this.Controls.Add(this.TableData_DataGridView);
            this.Controls.Add(this.AddProduct_Button);
            this.Controls.Add(this.DeleteProduct_Button);
            this.Controls.Add(this.AddProductByExcel_Button);
            this.Controls.Add(this.DateTimeImportWarehouse_DateTimePicker);
            this.Controls.Add(this.TotalImportWarehouse_Label);
            this.Controls.Add(this.StoreImportWarehouse_Combobox);
            this.Controls.Add(this.DateTimeImportWarehouse_Label);
            this.Controls.Add(this.Distributor_Combobox);
            this.Controls.Add(this.TotalImportWarehouse);
            this.Controls.Add(this.ImportToStore);
            this.Controls.Add(this.DateTimeImportWarehouse);
            this.Controls.Add(this.Distributor);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DetailInvoiceImportWarehouse_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DetailInvoiceImportWarehouse";
            ((System.ComponentModel.ISupportInitialize)(this.TableData_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Header;
        private Guna.UI2.WinForms.Guna2ImageButton Exit_Button;
        private Guna.UI2.WinForms.Guna2DragControl DragControl;
        private System.Windows.Forms.Label Distributor;
        private System.Windows.Forms.Label DateTimeImportWarehouse;
        private System.Windows.Forms.Label ImportToStore;
        private System.Windows.Forms.Label TotalImportWarehouse;
        private System.Windows.Forms.ComboBox Distributor_Combobox;
        private System.Windows.Forms.Label DateTimeImportWarehouse_Label;
        private System.Windows.Forms.ComboBox StoreImportWarehouse_Combobox;
        private System.Windows.Forms.Label TotalImportWarehouse_Label;
        private System.Windows.Forms.DateTimePicker DateTimeImportWarehouse_DateTimePicker;
        private Guna.UI2.WinForms.Guna2Button AddProduct_Button;
        private Guna.UI2.WinForms.Guna2Button DeleteProduct_Button;
        private Guna.UI2.WinForms.Guna2Button AddProductByExcel_Button;
        private Guna.UI2.WinForms.Guna2DataGridView TableData_DataGridView;
        private Guna.UI2.WinForms.Guna2Button Confirm_Button;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPU_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPU_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAM_Column;
        private System.Windows.Forms.DataGridViewComboBoxColumn SizePanelDisplay_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayResolution_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn QualityPanel_Column;
        private System.Windows.Forms.DataGridViewComboBoxColumn StorageType_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn StorageCapacity_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatteryCapacity_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimensions_Column;
    }
}