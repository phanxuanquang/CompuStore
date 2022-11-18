namespace CompuStore.Tab
{
    partial class BaseTab
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
        protected void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridDataTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.SearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.Bottom_1 = new Guna.UI2.WinForms.Guna2Button();
            this.Button_2 = new Guna.UI2.WinForms.Guna2Button();
            this.Button_3 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // GridDataTable
            // 
            this.GridDataTable.AllowUserToAddRows = false;
            this.GridDataTable.AllowUserToDeleteRows = false;
            this.GridDataTable.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.GridDataTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridDataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridDataTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.GridDataTable.BackgroundColor = System.Drawing.Color.White;
            this.GridDataTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridDataTable.CausesValidation = false;
            this.GridDataTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridDataTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(151)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDataTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridDataTable.ColumnHeadersHeight = 38;
            this.GridDataTable.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridDataTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridDataTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GridDataTable.EnableHeadersVisualStyles = false;
            this.GridDataTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridDataTable.Location = new System.Drawing.Point(0, 78);
            this.GridDataTable.MultiSelect = false;
            this.GridDataTable.Name = "GridDataTable";
            this.GridDataTable.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridDataTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridDataTable.RowHeadersVisible = false;
            this.GridDataTable.RowHeadersWidth = 82;
            this.GridDataTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GridDataTable.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.GridDataTable.RowTemplate.ReadOnly = true;
            this.GridDataTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GridDataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridDataTable.Size = new System.Drawing.Size(1440, 722);
            this.GridDataTable.TabIndex = 1;
            this.GridDataTable.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.GridDataTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GridDataTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.GridDataTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.GridDataTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.GridDataTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.GridDataTable.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.GridDataTable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridDataTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.GridDataTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GridDataTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.GridDataTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GridDataTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GridDataTable.ThemeStyle.HeaderStyle.Height = 38;
            this.GridDataTable.ThemeStyle.ReadOnly = true;
            this.GridDataTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GridDataTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridDataTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.GridDataTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GridDataTable.ThemeStyle.RowsStyle.Height = 22;
            this.GridDataTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.GridDataTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBox.Animated = true;
            this.SearchBox.BorderRadius = 5;
            this.SearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchBox.DefaultText = "";
            this.SearchBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SearchBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SearchBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchBox.DisabledState.Parent = this.SearchBox;
            this.SearchBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SearchBox.FocusedState.Parent = this.SearchBox;
            this.SearchBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SearchBox.HoverState.Parent = this.SearchBox;
            this.SearchBox.IconLeft = global::CompuStore.Properties.Resources.Exit;
            this.SearchBox.Location = new System.Drawing.Point(25, 19);
            this.SearchBox.Margin = new System.Windows.Forms.Padding(6);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.PasswordChar = '\0';
            this.SearchBox.PlaceholderText = "Tìm kiếm ";
            this.SearchBox.SelectedText = "";
            this.SearchBox.ShadowDecoration.Parent = this.SearchBox;
            this.SearchBox.Size = new System.Drawing.Size(764, 37);
            this.SearchBox.TabIndex = 14;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // Bottom_1
            // 
            this.Bottom_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bottom_1.Animated = true;
            this.Bottom_1.BorderRadius = 5;
            this.Bottom_1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Bottom_1.CheckedState.Parent = this.Bottom_1;
            this.Bottom_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bottom_1.CustomImages.Parent = this.Bottom_1;
            this.Bottom_1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Bottom_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Bottom_1.ForeColor = System.Drawing.Color.White;
            this.Bottom_1.HoverState.Parent = this.Bottom_1;
            this.Bottom_1.Location = new System.Drawing.Point(795, 19);
            this.Bottom_1.Name = "Bottom_1";
            this.Bottom_1.PressedDepth = 5;
            this.Bottom_1.ShadowDecoration.Parent = this.Bottom_1;
            this.Bottom_1.Size = new System.Drawing.Size(203, 37);
            this.Bottom_1.TabIndex = 11;
            this.Bottom_1.Text = "Add New";
            this.Bottom_1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // Button_2
            // 
            this.Button_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_2.Animated = true;
            this.Button_2.BorderRadius = 5;
            this.Button_2.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Button_2.CheckedState.Parent = this.Button_2;
            this.Button_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_2.CustomImages.Parent = this.Button_2;
            this.Button_2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Button_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Button_2.ForeColor = System.Drawing.Color.White;
            this.Button_2.HoverState.Parent = this.Button_2;
            this.Button_2.Location = new System.Drawing.Point(1004, 19);
            this.Button_2.Name = "Button_2";
            this.Button_2.PressedDepth = 5;
            this.Button_2.ShadowDecoration.Parent = this.Button_2;
            this.Button_2.Size = new System.Drawing.Size(203, 37);
            this.Button_2.TabIndex = 13;
            this.Button_2.Text = "View Detail";
            this.Button_2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // Button_3
            // 
            this.Button_3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_3.Animated = true;
            this.Button_3.BorderRadius = 5;
            this.Button_3.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Button_3.CheckedState.Parent = this.Button_3;
            this.Button_3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_3.CustomImages.Parent = this.Button_3;
            this.Button_3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Button_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Button_3.ForeColor = System.Drawing.Color.White;
            this.Button_3.HoverState.Parent = this.Button_3;
            this.Button_3.Location = new System.Drawing.Point(1213, 19);
            this.Button_3.Name = "Button_3";
            this.Button_3.PressedDepth = 5;
            this.Button_3.ShadowDecoration.Parent = this.Button_3;
            this.Button_3.Size = new System.Drawing.Size(203, 37);
            this.Button_3.TabIndex = 12;
            this.Button_3.Text = "Delete";
            this.Button_3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            // 
            // BaseTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.Bottom_1);
            this.Controls.Add(this.Button_2);
            this.Controls.Add(this.Button_3);
            this.Controls.Add(this.GridDataTable);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BaseTab";
            this.Size = new System.Drawing.Size(1440, 800);
            ((System.ComponentModel.ISupportInitialize)(this.GridDataTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected Guna.UI2.WinForms.Guna2TextBox SearchBox;
        protected Guna.UI2.WinForms.Guna2Button Button_2;
        protected Guna.UI2.WinForms.Guna2Button Bottom_1;
        protected Guna.UI2.WinForms.Guna2Button Button_3;
        public Guna.UI2.WinForms.Guna2DataGridView GridDataTable;
    }
}
