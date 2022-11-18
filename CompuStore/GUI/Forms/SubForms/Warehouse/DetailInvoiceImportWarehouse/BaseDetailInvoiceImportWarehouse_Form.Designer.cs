using CompuStore.Control;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    partial class BaseDetailInvoiceImportWarehouse_Form
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
            this.Manufacturer = new System.Windows.Forms.Label();
            this.ReleaseDate_Label = new System.Windows.Forms.Label();
            this.NameProduct = new System.Windows.Forms.Label();
            this.TotalImportWarehouse = new System.Windows.Forms.Label();
            this.TotalImportWarehouse_Label = new System.Windows.Forms.Label();
            this.AddProduct_Button = new Guna.UI2.WinForms.Guna2Button();
            this.DeleteProduct_Button = new Guna.UI2.WinForms.Guna2Button();
            this.AddProductByExcel_Button = new Guna.UI2.WinForms.Guna2Button();
            this.TableData_DataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Confirm_Button = new Guna.UI2.WinForms.Guna2Button();
            this.IDImportWarehouse_Value = new System.Windows.Forms.Label();
            this.IDImportWarehouse_Label = new System.Windows.Forms.Label();
            this.Finish_Button = new Guna.UI2.WinForms.Guna2Button();
            this.LineUp = new System.Windows.Forms.Label();
            this.ReleaseDate_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Filter_FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LineUp_ComboBox = new CompuStore.Control.ComboBoxCustom();
            this.NameProduct_ComboBox = new CompuStore.Control.ComboBoxCustom();
            this.Manufacturer_ComboBox = new CompuStore.Control.ComboBoxCustom();
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
            this.Header.Padding = new System.Windows.Forms.Padding(76, 0, 0, 0);
            this.Header.Size = new System.Drawing.Size(2468, 75);
            this.Header.TabIndex = 5;
            this.Header.Text = "Chi tiết nhập sản phẩm";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.Exit_Button.Location = new System.Drawing.Point(2393, 0);
            this.Exit_Button.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.PressedState.Parent = this.Exit_Button;
            this.Exit_Button.Size = new System.Drawing.Size(75, 75);
            this.Exit_Button.TabIndex = 6;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Clicked);
            // 
            // DragControl
            // 
            this.DragControl.TargetControl = this.Header;
            // 
            // Manufacturer
            // 
            this.Manufacturer.AutoSize = true;
            this.Manufacturer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Manufacturer.Location = new System.Drawing.Point(84, 206);
            this.Manufacturer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Manufacturer.Name = "Manufacturer";
            this.Manufacturer.Size = new System.Drawing.Size(153, 32);
            this.Manufacturer.TabIndex = 7;
            this.Manufacturer.Text = "Nhà sản xuất";
            // 
            // ReleaseDate_Label
            // 
            this.ReleaseDate_Label.AutoSize = true;
            this.ReleaseDate_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReleaseDate_Label.Location = new System.Drawing.Point(84, 303);
            this.ReleaseDate_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ReleaseDate_Label.Name = "ReleaseDate_Label";
            this.ReleaseDate_Label.Size = new System.Drawing.Size(145, 32);
            this.ReleaseDate_Label.TabIndex = 8;
            this.ReleaseDate_Label.Text = "Ngày ra mắt";
            // 
            // NameProduct
            // 
            this.NameProduct.AutoSize = true;
            this.NameProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameProduct.Location = new System.Drawing.Point(84, 158);
            this.NameProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameProduct.Name = "NameProduct";
            this.NameProduct.Size = new System.Drawing.Size(163, 32);
            this.NameProduct.TabIndex = 9;
            this.NameProduct.Text = "Tên sản phẩm";
            // 
            // TotalImportWarehouse
            // 
            this.TotalImportWarehouse.AutoSize = true;
            this.TotalImportWarehouse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalImportWarehouse.Location = new System.Drawing.Point(84, 352);
            this.TotalImportWarehouse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TotalImportWarehouse.Name = "TotalImportWarehouse";
            this.TotalImportWarehouse.Size = new System.Drawing.Size(137, 32);
            this.TotalImportWarehouse.TabIndex = 10;
            this.TotalImportWarehouse.Text = "Tổng giá trị";
            // 
            // TotalImportWarehouse_Label
            // 
            this.TotalImportWarehouse_Label.AutoSize = true;
            this.TotalImportWarehouse_Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalImportWarehouse_Label.Location = new System.Drawing.Point(408, 352);
            this.TotalImportWarehouse_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TotalImportWarehouse_Label.Name = "TotalImportWarehouse_Label";
            this.TotalImportWarehouse_Label.Size = new System.Drawing.Size(216, 32);
            this.TotalImportWarehouse_Label.TabIndex = 15;
            this.TotalImportWarehouse_Label.Text = "1000 củ khoai lang";
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
            this.AddProduct_Button.Location = new System.Drawing.Point(1909, 253);
            this.AddProduct_Button.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.AddProduct_Button.Name = "AddProduct_Button";
            this.AddProduct_Button.PressedDepth = 5;
            this.AddProduct_Button.ShadowDecoration.Parent = this.AddProduct_Button;
            this.AddProduct_Button.Size = new System.Drawing.Size(150, 100);
            this.AddProduct_Button.TabIndex = 19;
            this.AddProduct_Button.Text = "Thêm";
            this.AddProduct_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.AddProduct_Button.Visible = false;
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
            this.DeleteProduct_Button.Location = new System.Drawing.Point(2069, 253);
            this.DeleteProduct_Button.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.DeleteProduct_Button.Name = "DeleteProduct_Button";
            this.DeleteProduct_Button.PressedDepth = 5;
            this.DeleteProduct_Button.ShadowDecoration.Parent = this.DeleteProduct_Button;
            this.DeleteProduct_Button.Size = new System.Drawing.Size(150, 100);
            this.DeleteProduct_Button.TabIndex = 18;
            this.DeleteProduct_Button.Text = "Xóa";
            this.DeleteProduct_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.DeleteProduct_Button.Visible = false;
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
            this.AddProductByExcel_Button.Location = new System.Drawing.Point(1909, 141);
            this.AddProductByExcel_Button.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.AddProductByExcel_Button.Name = "AddProductByExcel_Button";
            this.AddProductByExcel_Button.PressedDepth = 5;
            this.AddProductByExcel_Button.ShadowDecoration.Parent = this.AddProductByExcel_Button;
            this.AddProductByExcel_Button.Size = new System.Drawing.Size(310, 100);
            this.AddProductByExcel_Button.TabIndex = 17;
            this.AddProductByExcel_Button.Text = "Nhập bằng Excel";
            this.AddProductByExcel_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.AddProductByExcel_Button.Visible = false;
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
            this.TableData_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.TableData_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.TableData_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TableData_DataGridView.CausesValidation = false;
            this.TableData_DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TableData_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(151)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.TableData_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.TableData_DataGridView.ColumnHeadersHeight = 48;
            this.TableData_DataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TableData_DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.TableData_DataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TableData_DataGridView.EnableHeadersVisualStyles = false;
            this.TableData_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.TableData_DataGridView.Location = new System.Drawing.Point(0, 476);
            this.TableData_DataGridView.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.TableData_DataGridView.MultiSelect = false;
            this.TableData_DataGridView.Name = "TableData_DataGridView";
            this.TableData_DataGridView.ReadOnly = true;
            this.TableData_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.TableData_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TableData_DataGridView.Size = new System.Drawing.Size(2468, 871);
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
            this.TableData_DataGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableData_DataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.TableData_DataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.TableData_DataGridView.ThemeStyle.HeaderStyle.Height = 48;
            this.TableData_DataGridView.ThemeStyle.ReadOnly = true;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TableData_DataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.Height = 48;
            this.TableData_DataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.TableData_DataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.TableData_DataGridView.VirtualMode = true;
            this.TableData_DataGridView.DataSourceChanged += new System.EventHandler(this.TableData_DataGridView_DataSourceChanged);
            this.TableData_DataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.TableData_DataGridView_RowsAdded);
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
            this.Confirm_Button.Location = new System.Drawing.Point(2190, 1795);
            this.Confirm_Button.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Confirm_Button.Name = "Confirm_Button";
            this.Confirm_Button.PressedDepth = 5;
            this.Confirm_Button.ShadowDecoration.Parent = this.Confirm_Button;
            this.Confirm_Button.Size = new System.Drawing.Size(440, 91);
            this.Confirm_Button.TabIndex = 21;
            this.Confirm_Button.Text = "Xác nhận";
            this.Confirm_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // IDImportWarehouse_Value
            // 
            this.IDImportWarehouse_Value.AutoSize = true;
            this.IDImportWarehouse_Value.Font = new System.Drawing.Font("Segoe UI Semibold", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDImportWarehouse_Value.Location = new System.Drawing.Point(407, 96);
            this.IDImportWarehouse_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IDImportWarehouse_Value.Name = "IDImportWarehouse_Value";
            this.IDImportWarehouse_Value.Size = new System.Drawing.Size(235, 40);
            this.IDImportWarehouse_Value.TabIndex = 25;
            this.IDImportWarehouse_Value.Text = "IMPORT_SV0823";
            // 
            // IDImportWarehouse_Label
            // 
            this.IDImportWarehouse_Label.AutoSize = true;
            this.IDImportWarehouse_Label.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDImportWarehouse_Label.Location = new System.Drawing.Point(81, 88);
            this.IDImportWarehouse_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IDImportWarehouse_Label.Name = "IDImportWarehouse_Label";
            this.IDImportWarehouse_Label.Size = new System.Drawing.Size(271, 50);
            this.IDImportWarehouse_Label.TabIndex = 24;
            this.IDImportWarehouse_Label.Text = "Mã nhập hàng";
            // 
            // Finish_Button
            // 
            this.Finish_Button.Animated = true;
            this.Finish_Button.BorderRadius = 5;
            this.Finish_Button.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Finish_Button.CheckedState.Parent = this.Finish_Button;
            this.Finish_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Finish_Button.CustomImages.Parent = this.Finish_Button;
            this.Finish_Button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Finish_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Finish_Button.ForeColor = System.Drawing.Color.White;
            this.Finish_Button.HoverState.Parent = this.Finish_Button;
            this.Finish_Button.Location = new System.Drawing.Point(2230, 141);
            this.Finish_Button.Margin = new System.Windows.Forms.Padding(6);
            this.Finish_Button.Name = "Finish_Button";
            this.Finish_Button.PressedDepth = 5;
            this.Finish_Button.ShadowDecoration.Parent = this.Finish_Button;
            this.Finish_Button.Size = new System.Drawing.Size(166, 212);
            this.Finish_Button.TabIndex = 27;
            this.Finish_Button.Text = "Hoàn tất";
            this.Finish_Button.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.Finish_Button.Visible = false;
            this.Finish_Button.Click += new System.EventHandler(this.Exit_Clicked);
            // 
            // LineUp
            // 
            this.LineUp.AutoSize = true;
            this.LineUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineUp.Location = new System.Drawing.Point(84, 254);
            this.LineUp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LineUp.Name = "LineUp";
            this.LineUp.Size = new System.Drawing.Size(184, 32);
            this.LineUp.TabIndex = 28;
            this.LineUp.Text = "Dòng sản phẩm";
            // 
            // ReleaseDate_DateTimePicker
            // 
            this.ReleaseDate_DateTimePicker.CustomFormat = "h:mm tt dd/MM/yyyy";
            this.ReleaseDate_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ReleaseDate_DateTimePicker.Location = new System.Drawing.Point(414, 300);
            this.ReleaseDate_DateTimePicker.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.ReleaseDate_DateTimePicker.Name = "ReleaseDate_DateTimePicker";
            this.ReleaseDate_DateTimePicker.Size = new System.Drawing.Size(433, 39);
            this.ReleaseDate_DateTimePicker.TabIndex = 30;
            this.ReleaseDate_DateTimePicker.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // Filter_FlowLayoutPanel
            // 
            this.Filter_FlowLayoutPanel.AutoScroll = true;
            this.Filter_FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Filter_FlowLayoutPanel.Location = new System.Drawing.Point(0, 400);
            this.Filter_FlowLayoutPanel.Name = "Filter_FlowLayoutPanel";
            this.Filter_FlowLayoutPanel.Size = new System.Drawing.Size(2468, 75);
            this.Filter_FlowLayoutPanel.TabIndex = 31;
            // 
            // LineUp_ComboBox
            // 
            this.LineUp_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.LineUp_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.LineUp_ComboBox.FormattingEnabled = true;
            this.LineUp_ComboBox.Location = new System.Drawing.Point(414, 251);
            this.LineUp_ComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LineUp_ComboBox.Name = "LineUp_ComboBox";
            this.LineUp_ComboBox.Size = new System.Drawing.Size(433, 40);
            this.LineUp_ComboBox.TabIndex = 29;
            this.LineUp_ComboBox.InsertKeyPressed += new CompuStore.Control.ComboBoxCustom.InsertKeyEvent(this.NameProduct_ComboBox_InsertKeyPressed);
            this.LineUp_ComboBox.Leave += new System.EventHandler(this.NameProduct_ComboBox_Leave);
            // 
            // NameProduct_ComboBox
            // 
            this.NameProduct_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.NameProduct_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.NameProduct_ComboBox.FormattingEnabled = true;
            this.NameProduct_ComboBox.Location = new System.Drawing.Point(414, 155);
            this.NameProduct_ComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NameProduct_ComboBox.Name = "NameProduct_ComboBox";
            this.NameProduct_ComboBox.Size = new System.Drawing.Size(433, 40);
            this.NameProduct_ComboBox.TabIndex = 14;
            this.NameProduct_ComboBox.InsertKeyPressed += new CompuStore.Control.ComboBoxCustom.InsertKeyEvent(this.NameProduct_ComboBox_InsertKeyPressed);
            this.NameProduct_ComboBox.Leave += new System.EventHandler(this.NameProduct_ComboBox_Leave);
            // 
            // Manufacturer_ComboBox
            // 
            this.Manufacturer_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Manufacturer_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Manufacturer_ComboBox.FormattingEnabled = true;
            this.Manufacturer_ComboBox.Location = new System.Drawing.Point(414, 203);
            this.Manufacturer_ComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Manufacturer_ComboBox.Name = "Manufacturer_ComboBox";
            this.Manufacturer_ComboBox.Size = new System.Drawing.Size(433, 40);
            this.Manufacturer_ComboBox.TabIndex = 11;
            this.Manufacturer_ComboBox.InsertKeyPressed += new CompuStore.Control.ComboBoxCustom.InsertKeyEvent(this.NameProduct_ComboBox_InsertKeyPressed);
            this.Manufacturer_ComboBox.Leave += new System.EventHandler(this.NameProduct_ComboBox_Leave);
            // 
            // BaseDetailInvoiceImportWarehouse_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2468, 1347);
            this.Controls.Add(this.Filter_FlowLayoutPanel);
            this.Controls.Add(this.ReleaseDate_DateTimePicker);
            this.Controls.Add(this.LineUp_ComboBox);
            this.Controls.Add(this.LineUp);
            this.Controls.Add(this.Finish_Button);
            this.Controls.Add(this.IDImportWarehouse_Value);
            this.Controls.Add(this.IDImportWarehouse_Label);
            this.Controls.Add(this.Confirm_Button);
            this.Controls.Add(this.TableData_DataGridView);
            this.Controls.Add(this.AddProduct_Button);
            this.Controls.Add(this.DeleteProduct_Button);
            this.Controls.Add(this.AddProductByExcel_Button);
            this.Controls.Add(this.TotalImportWarehouse_Label);
            this.Controls.Add(this.NameProduct_ComboBox);
            this.Controls.Add(this.Manufacturer_ComboBox);
            this.Controls.Add(this.TotalImportWarehouse);
            this.Controls.Add(this.NameProduct);
            this.Controls.Add(this.ReleaseDate_Label);
            this.Controls.Add(this.Manufacturer);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Header);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BaseDetailInvoiceImportWarehouse_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DetailInvoiceImportWarehouse";
            this.Load += new System.EventHandler(this.DetailInvoiceImportWarehouse_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TableData_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Header;
        private Guna.UI2.WinForms.Guna2ImageButton Exit_Button;
        private Guna.UI2.WinForms.Guna2DragControl DragControl;
        private System.Windows.Forms.Label Manufacturer;
        private System.Windows.Forms.Label ReleaseDate_Label;
        private System.Windows.Forms.Label NameProduct;
        private System.Windows.Forms.Label TotalImportWarehouse;
        private Guna.UI2.WinForms.Guna2Button Confirm_Button;
        protected System.Windows.Forms.Label IDImportWarehouse_Value;
        private System.Windows.Forms.Label IDImportWarehouse_Label;
        protected Guna.UI2.WinForms.Guna2Button Finish_Button;
        private System.Windows.Forms.Label LineUp;
        protected ComboBoxCustom Manufacturer_ComboBox;
        protected ComboBoxCustom NameProduct_ComboBox;
        protected System.Windows.Forms.Label TotalImportWarehouse_Label;
        protected Guna.UI2.WinForms.Guna2Button AddProduct_Button;
        protected Guna.UI2.WinForms.Guna2Button DeleteProduct_Button;
        protected Guna.UI2.WinForms.Guna2Button AddProductByExcel_Button;
        protected Guna.UI2.WinForms.Guna2DataGridView TableData_DataGridView;
        protected ComboBoxCustom LineUp_ComboBox;
        protected System.Windows.Forms.DateTimePicker ReleaseDate_DateTimePicker;
        private System.Windows.Forms.FlowLayoutPanel Filter_FlowLayoutPanel;
    }
}