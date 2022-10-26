namespace CompuStore.Tab.Warehouse
{
    partial class InvoiceImportWarehouse_Form
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
            this.DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Distributor_Label = new System.Windows.Forms.Label();
            this.DateTimeImportWarehouse_Label = new System.Windows.Forms.Label();
            this.ImportToStore_Label = new System.Windows.Forms.Label();
            this.TotalImportWarehouse_Label = new System.Windows.Forms.Label();
            this.Distributor_Combobox = new System.Windows.Forms.ComboBox();
            this.ImportToStore_Combobox = new System.Windows.Forms.ComboBox();
            this.TotalImportWarehouse_Value = new System.Windows.Forms.Label();
            this.DateTimeImportWarehouse_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AddProduct_Button = new Guna.UI2.WinForms.Guna2Button();
            this.DeleteProduct_Button = new Guna.UI2.WinForms.Guna2Button();
            this.AddProductByExcel_Button = new Guna.UI2.WinForms.Guna2Button();
            this.Confirm_Button = new Guna.UI2.WinForms.Guna2Button();
            this.Exit_Button = new Guna.UI2.WinForms.Guna2ImageButton();
            this.TableData_DataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Staffimport_Label = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.StaffImport_Value = new System.Windows.Forms.Label();
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
            this.Header.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Header.Name = "Header";
            this.Header.Padding = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.Header.Size = new System.Drawing.Size(2468, 77);
            this.Header.TabIndex = 5;
            this.Header.Text = "Chi tiết nhập hàng";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DragControl
            // 
            this.DragControl.TargetControl = this.Header;
            // 
            // Distributor_Label
            // 
            this.Distributor_Label.AutoSize = true;
            this.Distributor_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Distributor_Label.Location = new System.Drawing.Point(77, 176);
            this.Distributor_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Distributor_Label.Name = "Distributor_Label";
            this.Distributor_Label.Size = new System.Drawing.Size(162, 32);
            this.Distributor_Label.TabIndex = 7;
            this.Distributor_Label.Text = "Nhà cung cấp";
            // 
            // DateTimeImportWarehouse_Label
            // 
            this.DateTimeImportWarehouse_Label.AutoSize = true;
            this.DateTimeImportWarehouse_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeImportWarehouse_Label.Location = new System.Drawing.Point(77, 234);
            this.DateTimeImportWarehouse_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DateTimeImportWarehouse_Label.Name = "DateTimeImportWarehouse_Label";
            this.DateTimeImportWarehouse_Label.Size = new System.Drawing.Size(192, 32);
            this.DateTimeImportWarehouse_Label.TabIndex = 8;
            this.DateTimeImportWarehouse_Label.Text = "Ngày nhập hàng";
            // 
            // ImportToStore_Label
            // 
            this.ImportToStore_Label.AutoSize = true;
            this.ImportToStore_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportToStore_Label.Location = new System.Drawing.Point(77, 291);
            this.ImportToStore_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ImportToStore_Label.Name = "ImportToStore_Label";
            this.ImportToStore_Label.Size = new System.Drawing.Size(208, 32);
            this.ImportToStore_Label.TabIndex = 9;
            this.ImportToStore_Label.Text = "Nhập vào kho của";
            // 
            // TotalImportWarehouse_Label
            // 
            this.TotalImportWarehouse_Label.AutoSize = true;
            this.TotalImportWarehouse_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalImportWarehouse_Label.Location = new System.Drawing.Point(77, 349);
            this.TotalImportWarehouse_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TotalImportWarehouse_Label.Name = "TotalImportWarehouse_Label";
            this.TotalImportWarehouse_Label.Size = new System.Drawing.Size(137, 32);
            this.TotalImportWarehouse_Label.TabIndex = 10;
            this.TotalImportWarehouse_Label.Text = "Tổng giá trị";
            // 
            // Distributor_Combobox
            // 
            this.Distributor_Combobox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Distributor_Combobox.FormattingEnabled = true;
            this.Distributor_Combobox.Location = new System.Drawing.Point(353, 173);
            this.Distributor_Combobox.Margin = new System.Windows.Forms.Padding(4);
            this.Distributor_Combobox.Name = "Distributor_Combobox";
            this.Distributor_Combobox.Size = new System.Drawing.Size(400, 40);
            this.Distributor_Combobox.TabIndex = 11;
            // 
            // ImportToStore_Combobox
            // 
            this.ImportToStore_Combobox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportToStore_Combobox.FormattingEnabled = true;
            this.ImportToStore_Combobox.Location = new System.Drawing.Point(353, 288);
            this.ImportToStore_Combobox.Margin = new System.Windows.Forms.Padding(4);
            this.ImportToStore_Combobox.Name = "ImportToStore_Combobox";
            this.ImportToStore_Combobox.Size = new System.Drawing.Size(400, 40);
            this.ImportToStore_Combobox.TabIndex = 14;
            // 
            // TotalImportWarehouse_Value
            // 
            this.TotalImportWarehouse_Value.AutoSize = true;
            this.TotalImportWarehouse_Value.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalImportWarehouse_Value.Location = new System.Drawing.Point(347, 349);
            this.TotalImportWarehouse_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TotalImportWarehouse_Value.Name = "TotalImportWarehouse_Value";
            this.TotalImportWarehouse_Value.Size = new System.Drawing.Size(216, 32);
            this.TotalImportWarehouse_Value.TabIndex = 15;
            this.TotalImportWarehouse_Value.Text = "1000 củ khoai lang";
            // 
            // DateTimeImportWarehouse_DateTimePicker
            // 
            this.DateTimeImportWarehouse_DateTimePicker.CustomFormat = "h:mm tt dd/MM/yyyy";
            this.DateTimeImportWarehouse_DateTimePicker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimeImportWarehouse_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimeImportWarehouse_DateTimePicker.Location = new System.Drawing.Point(353, 234);
            this.DateTimeImportWarehouse_DateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.DateTimeImportWarehouse_DateTimePicker.Name = "DateTimeImportWarehouse_DateTimePicker";
            this.DateTimeImportWarehouse_DateTimePicker.Size = new System.Drawing.Size(400, 39);
            this.DateTimeImportWarehouse_DateTimePicker.TabIndex = 16;
            this.DateTimeImportWarehouse_DateTimePicker.Value = new System.DateTime(2022, 10, 26, 19, 38, 7, 0);
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
            this.AddProduct_Button.Location = new System.Drawing.Point(1952, 218);
            this.AddProduct_Button.Margin = new System.Windows.Forms.Padding(6);
            this.AddProduct_Button.Name = "AddProduct_Button";
            this.AddProduct_Button.PressedDepth = 5;
            this.AddProduct_Button.ShadowDecoration.Parent = this.AddProduct_Button;
            this.AddProduct_Button.Size = new System.Drawing.Size(150, 100);
            this.AddProduct_Button.TabIndex = 19;
            this.AddProduct_Button.Text = "Thêm";
            this.AddProduct_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
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
            this.DeleteProduct_Button.Location = new System.Drawing.Point(2114, 218);
            this.DeleteProduct_Button.Margin = new System.Windows.Forms.Padding(6);
            this.DeleteProduct_Button.Name = "DeleteProduct_Button";
            this.DeleteProduct_Button.PressedDepth = 5;
            this.DeleteProduct_Button.ShadowDecoration.Parent = this.DeleteProduct_Button;
            this.DeleteProduct_Button.Size = new System.Drawing.Size(150, 100);
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
            this.AddProductByExcel_Button.Location = new System.Drawing.Point(1954, 106);
            this.AddProductByExcel_Button.Margin = new System.Windows.Forms.Padding(6);
            this.AddProductByExcel_Button.Name = "AddProductByExcel_Button";
            this.AddProductByExcel_Button.PressedDepth = 5;
            this.AddProductByExcel_Button.ShadowDecoration.Parent = this.AddProductByExcel_Button;
            this.AddProductByExcel_Button.Size = new System.Drawing.Size(310, 100);
            this.AddProductByExcel_Button.TabIndex = 17;
            this.AddProductByExcel_Button.Text = "Nhập bằng Excel";
            this.AddProductByExcel_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
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
            this.Confirm_Button.Location = new System.Drawing.Point(2022, 1402);
            this.Confirm_Button.Margin = new System.Windows.Forms.Padding(6);
            this.Confirm_Button.Name = "Confirm_Button";
            this.Confirm_Button.PressedDepth = 5;
            this.Confirm_Button.ShadowDecoration.Parent = this.Confirm_Button;
            this.Confirm_Button.Size = new System.Drawing.Size(406, 71);
            this.Confirm_Button.TabIndex = 21;
            this.Confirm_Button.Text = "Xác nhận";
            this.Confirm_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // Exit_Button
            // 
            this.Exit_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Exit_Button.CheckedState.ImageSize = new System.Drawing.Size(25, 25);
            this.Exit_Button.CheckedState.Parent = this.Exit_Button;
            this.Exit_Button.HoverState.ImageSize = new System.Drawing.Size(25, 25);
            this.Exit_Button.HoverState.Parent = this.Exit_Button;
            this.Exit_Button.Image = global::CompuStore.Properties.Resources.Close;
            this.Exit_Button.ImageSize = new System.Drawing.Size(27, 27);
            this.Exit_Button.Location = new System.Drawing.Point(2388, 0);
            this.Exit_Button.Margin = new System.Windows.Forms.Padding(6);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.PressedState.Parent = this.Exit_Button;
            this.Exit_Button.Size = new System.Drawing.Size(80, 77);
            this.Exit_Button.TabIndex = 6;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
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
            this.TableData_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.TableData_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.TableData_DataGridView.ColumnHeadersHeight = 48;
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
            this.TableData_DataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TableData_DataGridView.EnableHeadersVisualStyles = false;
            this.TableData_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.TableData_DataGridView.Location = new System.Drawing.Point(0, 402);
            this.TableData_DataGridView.Margin = new System.Windows.Forms.Padding(6);
            this.TableData_DataGridView.MultiSelect = false;
            this.TableData_DataGridView.Name = "TableData_DataGridView";
            this.TableData_DataGridView.ReadOnly = true;
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
            this.TableData_DataGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TableData_DataGridView.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);
            this.TableData_DataGridView.RowTemplate.Height = 48;
            this.TableData_DataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TableData_DataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TableData_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TableData_DataGridView.Size = new System.Drawing.Size(2468, 933);
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
            this.TableData_DataGridView.ThemeStyle.ReadOnly = true;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TableData_DataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.Height = 48;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.TableData_DataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.TableData_DataGridView.VirtualMode = true;
            this.TableData_DataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableData_DataGridView_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 50);
            this.label1.TabIndex = 22;
            this.label1.Text = "Mã nhập hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 40);
            this.label2.TabIndex = 23;
            this.label2.Text = "IMPORT_SV0823";
            // 
            // Staffimport_Label
            // 
            this.Staffimport_Label.AutoSize = true;
            this.Staffimport_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Staffimport_Label.Location = new System.Drawing.Point(923, 176);
            this.Staffimport_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Staffimport_Label.Name = "Staffimport_Label";
            this.Staffimport_Label.Size = new System.Drawing.Size(202, 32);
            this.Staffimport_Label.TabIndex = 24;
            this.Staffimport_Label.Text = "Người nhập hàng";
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.guna2Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(2276, 106);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(6);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedDepth = 5;
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(166, 212);
            this.guna2Button1.TabIndex = 26;
            this.guna2Button1.Text = "Hoàn tất";
            this.guna2Button1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // StaffImport_Value
            // 
            this.StaffImport_Value.AutoSize = true;
            this.StaffImport_Value.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StaffImport_Value.Location = new System.Drawing.Point(1213, 176);
            this.StaffImport_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StaffImport_Value.Name = "StaffImport_Value";
            this.StaffImport_Value.Size = new System.Drawing.Size(264, 32);
            this.StaffImport_Value.TabIndex = 27;
            this.StaffImport_Value.Text = "Nguyễn Văn A | SF4652";
            // 
            // InvoiceImportWarehouse_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2468, 1335);
            this.Controls.Add(this.StaffImport_Value);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.Staffimport_Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Confirm_Button);
            this.Controls.Add(this.TableData_DataGridView);
            this.Controls.Add(this.AddProduct_Button);
            this.Controls.Add(this.DeleteProduct_Button);
            this.Controls.Add(this.AddProductByExcel_Button);
            this.Controls.Add(this.DateTimeImportWarehouse_DateTimePicker);
            this.Controls.Add(this.TotalImportWarehouse_Value);
            this.Controls.Add(this.ImportToStore_Combobox);
            this.Controls.Add(this.Distributor_Combobox);
            this.Controls.Add(this.TotalImportWarehouse_Label);
            this.Controls.Add(this.ImportToStore_Label);
            this.Controls.Add(this.DateTimeImportWarehouse_Label);
            this.Controls.Add(this.Distributor_Label);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InvoiceImportWarehouse_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DetailInvoiceImportWarehouse";
            this.Load += new System.EventHandler(this.InvoiceImportWarehouse_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TableData_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Header;
        private Guna.UI2.WinForms.Guna2ImageButton Exit_Button;
        private Guna.UI2.WinForms.Guna2DragControl DragControl;
        private System.Windows.Forms.Label Distributor_Label;
        private System.Windows.Forms.Label DateTimeImportWarehouse_Label;
        private System.Windows.Forms.Label ImportToStore_Label;
        private System.Windows.Forms.Label TotalImportWarehouse_Label;
        private System.Windows.Forms.ComboBox Distributor_Combobox;
        private System.Windows.Forms.ComboBox ImportToStore_Combobox;
        private System.Windows.Forms.Label TotalImportWarehouse_Value;
        private System.Windows.Forms.DateTimePicker DateTimeImportWarehouse_DateTimePicker;
        private Guna.UI2.WinForms.Guna2Button AddProduct_Button;
        private Guna.UI2.WinForms.Guna2Button DeleteProduct_Button;
        private Guna.UI2.WinForms.Guna2Button AddProductByExcel_Button;
        private Guna.UI2.WinForms.Guna2Button Confirm_Button;
        private Guna.UI2.WinForms.Guna2DataGridView TableData_DataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Staffimport_Label;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label StaffImport_Value;
    }
}