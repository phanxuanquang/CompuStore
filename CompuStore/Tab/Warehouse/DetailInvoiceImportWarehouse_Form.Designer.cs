namespace CompuStore.Tab.Warehouse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Header = new System.Windows.Forms.Label();
            this.Exit_Button = new Guna.UI2.WinForms.Guna2ImageButton();
            this.DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Distributor = new System.Windows.Forms.Label();
            this.DateTimeImportWarehouse = new System.Windows.Forms.Label();
            this.ImportToStore = new System.Windows.Forms.Label();
            this.TotalImportWarehouse = new System.Windows.Forms.Label();
            this.DateTimeImportWarehouse_Label = new System.Windows.Forms.Label();
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
            this.StoreImportWarehouse_Combobox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.DateTimeImportWarehouse_DateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.Distributor_Combobox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.TotalImportWarehouse_Box = new Guna.UI2.WinForms.Guna2TextBox();
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
            this.Header.Size = new System.Drawing.Size(1506, 40);
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
            this.Exit_Button.Location = new System.Drawing.Point(1722, 0);
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
            this.Distributor.Location = new System.Drawing.Point(21, 53);
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
            this.DateTimeImportWarehouse.Location = new System.Drawing.Point(21, 83);
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
            this.ImportToStore.Location = new System.Drawing.Point(21, 113);
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
            this.TotalImportWarehouse.Location = new System.Drawing.Point(21, 143);
            this.TotalImportWarehouse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalImportWarehouse.Name = "TotalImportWarehouse";
            this.TotalImportWarehouse.Size = new System.Drawing.Size(67, 15);
            this.TotalImportWarehouse.TabIndex = 10;
            this.TotalImportWarehouse.Text = "Tổng giá trị";
            // 
            // DateTimeImportWarehouse_Label
            // 
            this.DateTimeImportWarehouse_Label.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DateTimeImportWarehouse_Label.Location = new System.Drawing.Point(200, 96);
            this.DateTimeImportWarehouse_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DateTimeImportWarehouse_Label.Name = "DateTimeImportWarehouse_Label";
            this.DateTimeImportWarehouse_Label.Size = new System.Drawing.Size(250, 32);
            this.DateTimeImportWarehouse_Label.TabIndex = 13;
            this.DateTimeImportWarehouse_Label.Text = "9:36AM 22/10/2022";
            this.DateTimeImportWarehouse_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DateTimeImportWarehouse_Label.Click += new System.EventHandler(this.DateTimeImportWarehouse_Label_Click);
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
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            this.TableData_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.TableData_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TableData_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TableData_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.TableData_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableData_DataGridView.CausesValidation = false;
            this.TableData_DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TableData_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(151)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableData_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TableData_DataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.TableData_DataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TableData_DataGridView.EnableHeadersVisualStyles = false;
            this.TableData_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.TableData_DataGridView.Location = new System.Drawing.Point(0, 214);
            this.TableData_DataGridView.MultiSelect = false;
            this.TableData_DataGridView.Name = "TableData_DataGridView";
            this.TableData_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableData_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.TableData_DataGridView.RowHeadersVisible = false;
            this.TableData_DataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(5);
            this.TableData_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.TableData_DataGridView.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);
            this.TableData_DataGridView.RowTemplate.Height = 48;
            this.TableData_DataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TableData_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TableData_DataGridView.Size = new System.Drawing.Size(1506, 420);
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
            // 
            // CPU_Column
            // 
            this.CPU_Column.HeaderText = "CPU";
            this.CPU_Column.MinimumWidth = 10;
            this.CPU_Column.Name = "CPU_Column";
            // 
            // GPU_Column
            // 
            this.GPU_Column.HeaderText = "GPU";
            this.GPU_Column.MinimumWidth = 10;
            this.GPU_Column.Name = "GPU_Column";
            // 
            // RAM_Column
            // 
            this.RAM_Column.HeaderText = "RAM";
            this.RAM_Column.MinimumWidth = 10;
            this.RAM_Column.Name = "RAM_Column";
            // 
            // SizePanelDisplay_Column
            // 
            this.SizePanelDisplay_Column.HeaderText = "Kích thước màn hình";
            this.SizePanelDisplay_Column.MinimumWidth = 10;
            this.SizePanelDisplay_Column.Name = "SizePanelDisplay_Column";
            // 
            // DisplayResolution_Column
            // 
            this.DisplayResolution_Column.HeaderText = "Độ phân giải màn hình";
            this.DisplayResolution_Column.MinimumWidth = 10;
            this.DisplayResolution_Column.Name = "DisplayResolution_Column";
            // 
            // QualityPanel_Column
            // 
            this.QualityPanel_Column.HeaderText = "Chất lượng tấm nền";
            this.QualityPanel_Column.MinimumWidth = 10;
            this.QualityPanel_Column.Name = "QualityPanel_Column";
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
            // 
            // BatteryCapacity_Column
            // 
            this.BatteryCapacity_Column.HeaderText = "Dung lượng pin";
            this.BatteryCapacity_Column.MinimumWidth = 10;
            this.BatteryCapacity_Column.Name = "BatteryCapacity_Column";
            this.BatteryCapacity_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BatteryCapacity_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Cân nặng";
            this.Weight.MinimumWidth = 10;
            this.Weight.Name = "Weight";
            this.Weight.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Weight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Dimensions_Column
            // 
            this.Dimensions_Column.HeaderText = "Kích thước máy";
            this.Dimensions_Column.MinimumWidth = 10;
            this.Dimensions_Column.Name = "Dimensions_Column";
            this.Dimensions_Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Dimensions_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // StoreImportWarehouse_Combobox
            // 
            this.StoreImportWarehouse_Combobox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StoreImportWarehouse_Combobox.Animated = true;
            this.StoreImportWarehouse_Combobox.BackColor = System.Drawing.Color.Transparent;
            this.StoreImportWarehouse_Combobox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.StoreImportWarehouse_Combobox.BorderRadius = 4;
            this.StoreImportWarehouse_Combobox.BorderThickness = 2;
            this.StoreImportWarehouse_Combobox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StoreImportWarehouse_Combobox.DisplayMember = "ROLE";
            this.StoreImportWarehouse_Combobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.StoreImportWarehouse_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StoreImportWarehouse_Combobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StoreImportWarehouse_Combobox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.StoreImportWarehouse_Combobox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.StoreImportWarehouse_Combobox.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.StoreImportWarehouse_Combobox.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.StoreImportWarehouse_Combobox.FocusedState.Parent = this.StoreImportWarehouse_Combobox;
            this.StoreImportWarehouse_Combobox.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.StoreImportWarehouse_Combobox.ForeColor = System.Drawing.Color.Black;
            this.StoreImportWarehouse_Combobox.FormattingEnabled = true;
            this.StoreImportWarehouse_Combobox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.StoreImportWarehouse_Combobox.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.StoreImportWarehouse_Combobox.HoverState.ForeColor = System.Drawing.Color.Black;
            this.StoreImportWarehouse_Combobox.HoverState.Parent = this.StoreImportWarehouse_Combobox;
            this.StoreImportWarehouse_Combobox.ItemHeight = 32;
            this.StoreImportWarehouse_Combobox.ItemsAppearance.Parent = this.StoreImportWarehouse_Combobox;
            this.StoreImportWarehouse_Combobox.Location = new System.Drawing.Point(203, 128);
            this.StoreImportWarehouse_Combobox.Margin = new System.Windows.Forms.Padding(0);
            this.StoreImportWarehouse_Combobox.Name = "StoreImportWarehouse_Combobox";
            this.StoreImportWarehouse_Combobox.ShadowDecoration.Parent = this.StoreImportWarehouse_Combobox;
            this.StoreImportWarehouse_Combobox.Size = new System.Drawing.Size(247, 38);
            this.StoreImportWarehouse_Combobox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.StoreImportWarehouse_Combobox.TabIndex = 22;
            this.StoreImportWarehouse_Combobox.TextOffset = new System.Drawing.Point(5, 0);
            this.StoreImportWarehouse_Combobox.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // DateTimeImportWarehouse_DateTimePicker
            // 
            this.DateTimeImportWarehouse_DateTimePicker.Animated = true;
            this.DateTimeImportWarehouse_DateTimePicker.BorderRadius = 4;
            this.DateTimeImportWarehouse_DateTimePicker.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.DateTimeImportWarehouse_DateTimePicker.CheckedState.Parent = this.DateTimeImportWarehouse_DateTimePicker;
            this.DateTimeImportWarehouse_DateTimePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DateTimeImportWarehouse_DateTimePicker.CustomFormat = " dd/MM/yyyy";
            this.DateTimeImportWarehouse_DateTimePicker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.DateTimeImportWarehouse_DateTimePicker.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DateTimeImportWarehouse_DateTimePicker.ForeColor = System.Drawing.Color.Black;
            this.DateTimeImportWarehouse_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DateTimeImportWarehouse_DateTimePicker.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.DateTimeImportWarehouse_DateTimePicker.HoverState.Parent = this.DateTimeImportWarehouse_DateTimePicker;
            this.DateTimeImportWarehouse_DateTimePicker.Location = new System.Drawing.Point(692, 115);
            this.DateTimeImportWarehouse_DateTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.DateTimeImportWarehouse_DateTimePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateTimeImportWarehouse_DateTimePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateTimeImportWarehouse_DateTimePicker.Name = "DateTimeImportWarehouse_DateTimePicker";
            this.DateTimeImportWarehouse_DateTimePicker.ShadowDecoration.Parent = this.DateTimeImportWarehouse_DateTimePicker;
            this.DateTimeImportWarehouse_DateTimePicker.Size = new System.Drawing.Size(244, 37);
            this.DateTimeImportWarehouse_DateTimePicker.TabIndex = 23;
            this.DateTimeImportWarehouse_DateTimePicker.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.DateTimeImportWarehouse_DateTimePicker.Value = new System.DateTime(2022, 10, 18, 0, 0, 0, 0);
            // 
            // Distributor_Combobox
            // 
            this.Distributor_Combobox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Distributor_Combobox.Animated = true;
            this.Distributor_Combobox.BackColor = System.Drawing.Color.Transparent;
            this.Distributor_Combobox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Distributor_Combobox.BorderRadius = 4;
            this.Distributor_Combobox.BorderThickness = 2;
            this.Distributor_Combobox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Distributor_Combobox.DisplayMember = "ROLE";
            this.Distributor_Combobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Distributor_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Distributor_Combobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Distributor_Combobox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Distributor_Combobox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Distributor_Combobox.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Distributor_Combobox.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.Distributor_Combobox.FocusedState.Parent = this.Distributor_Combobox;
            this.Distributor_Combobox.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Distributor_Combobox.ForeColor = System.Drawing.Color.Black;
            this.Distributor_Combobox.FormattingEnabled = true;
            this.Distributor_Combobox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Distributor_Combobox.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.Distributor_Combobox.HoverState.ForeColor = System.Drawing.Color.Black;
            this.Distributor_Combobox.HoverState.Parent = this.Distributor_Combobox;
            this.Distributor_Combobox.ItemHeight = 32;
            this.Distributor_Combobox.ItemsAppearance.Parent = this.Distributor_Combobox;
            this.Distributor_Combobox.Location = new System.Drawing.Point(203, 48);
            this.Distributor_Combobox.Margin = new System.Windows.Forms.Padding(0);
            this.Distributor_Combobox.Name = "Distributor_Combobox";
            this.Distributor_Combobox.ShadowDecoration.Parent = this.Distributor_Combobox;
            this.Distributor_Combobox.Size = new System.Drawing.Size(247, 38);
            this.Distributor_Combobox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Distributor_Combobox.TabIndex = 24;
            this.Distributor_Combobox.TextOffset = new System.Drawing.Point(5, 0);
            this.Distributor_Combobox.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // TotalImportWarehouse_Box
            // 
            this.TotalImportWarehouse_Box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TotalImportWarehouse_Box.Animated = true;
            this.TotalImportWarehouse_Box.BackColor = System.Drawing.Color.Transparent;
            this.TotalImportWarehouse_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(185)))), ((int)(((byte)(189)))));
            this.TotalImportWarehouse_Box.BorderRadius = 8;
            this.TotalImportWarehouse_Box.BorderThickness = 2;
            this.TotalImportWarehouse_Box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TotalImportWarehouse_Box.DefaultText = "ddđ";
            this.TotalImportWarehouse_Box.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TotalImportWarehouse_Box.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TotalImportWarehouse_Box.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TotalImportWarehouse_Box.DisabledState.Parent = this.TotalImportWarehouse_Box;
            this.TotalImportWarehouse_Box.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TotalImportWarehouse_Box.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.TotalImportWarehouse_Box.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.TotalImportWarehouse_Box.FocusedState.ForeColor = System.Drawing.Color.Black;
            this.TotalImportWarehouse_Box.FocusedState.Parent = this.TotalImportWarehouse_Box;
            this.TotalImportWarehouse_Box.Font = new System.Drawing.Font("Open Sans Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TotalImportWarehouse_Box.ForeColor = System.Drawing.Color.Black;
            this.TotalImportWarehouse_Box.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.TotalImportWarehouse_Box.HoverState.Parent = this.TotalImportWarehouse_Box;
            this.TotalImportWarehouse_Box.IconLeftOffset = new System.Drawing.Point(9, 0);
            this.TotalImportWarehouse_Box.IconLeftSize = new System.Drawing.Size(30, 30);
            this.TotalImportWarehouse_Box.Location = new System.Drawing.Point(203, 155);
            this.TotalImportWarehouse_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TotalImportWarehouse_Box.Name = "TotalImportWarehouse_Box";
            this.TotalImportWarehouse_Box.PasswordChar = '\0';
            this.TotalImportWarehouse_Box.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.TotalImportWarehouse_Box.PlaceholderText = "";
            this.TotalImportWarehouse_Box.ReadOnly = true;
            this.TotalImportWarehouse_Box.SelectedText = "";
            this.TotalImportWarehouse_Box.SelectionStart = 3;
            this.TotalImportWarehouse_Box.ShadowDecoration.Parent = this.TotalImportWarehouse_Box;
            this.TotalImportWarehouse_Box.Size = new System.Drawing.Size(247, 42);
            this.TotalImportWarehouse_Box.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.TotalImportWarehouse_Box.TabIndex = 25;
            this.TotalImportWarehouse_Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TotalImportWarehouse_Box.TextOffset = new System.Drawing.Point(5, 0);
            // 
            // DetailInvoiceImportWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1506, 634);
            this.Controls.Add(this.TotalImportWarehouse_Box);
            this.Controls.Add(this.Distributor_Combobox);
            this.Controls.Add(this.DateTimeImportWarehouse_DateTimePicker);
            this.Controls.Add(this.StoreImportWarehouse_Combobox);
            this.Controls.Add(this.Confirm_Button);
            this.Controls.Add(this.TableData_DataGridView);
            this.Controls.Add(this.AddProduct_Button);
            this.Controls.Add(this.DeleteProduct_Button);
            this.Controls.Add(this.AddProductByExcel_Button);
            this.Controls.Add(this.DateTimeImportWarehouse_Label);
            this.Controls.Add(this.TotalImportWarehouse);
            this.Controls.Add(this.ImportToStore);
            this.Controls.Add(this.DateTimeImportWarehouse);
            this.Controls.Add(this.Distributor);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DetailInvoiceImportWarehouse";
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
        private System.Windows.Forms.Label DateTimeImportWarehouse_Label;
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
        private Guna.UI2.WinForms.Guna2ComboBox StoreImportWarehouse_Combobox;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimeImportWarehouse_DateTimePicker;
        private Guna.UI2.WinForms.Guna2ComboBox Distributor_Combobox;
        private Guna.UI2.WinForms.Guna2TextBox TotalImportWarehouse_Box;
    }
}