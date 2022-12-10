using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.Database.Services.ProductServices;
using CompuStore.GUI.Forms.SubForms.Warehouse.DetailSpecsProduct;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public class OverviewDetailSpecsProduct_Form : BaseDetailSpecsProduct
    {
        #region Class
        private class SerialBinding
        {
            public int STT { get; set; }
            public string Serial { get; set; }
            public string NameIDImportWarehouse { get; set; }
            public DateTime? ImportDate { get; set; }
            public double? Price { get; set; }
        }
        #endregion

        #region Variable
        private BindingList<SerialBinding> binding;
        private Guna.UI2.WinForms.Guna2DataGridView Serial_DataGridView;
        private System.Windows.Forms.TabPage tabPage6;
        private IList<ModelProduct> products;
        #endregion

        #region Translater
        protected static readonly Dictionary<string, string> serialTranslater = new Dictionary<string, string> {
            { "STT", "STT" },
            { "Serial", "Serial máy|Mỗi máy có một số định danh duy nhất được nhán ở đáy máy" },
            { "NameIDImportWarehouse", "Mã nhập hàng|Sản phẩm được nhập ở lần nhập có mã nhập hàng" },
            { "ImportDate", "Ngày nhập hàng" },
            { "Price", "Giá tiền" }
        };
        #endregion

        #region Private component
        protected override void AddInitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.Serial_DataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Serial_DataGridView)).BeginInit();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage6);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.Serial_DataGridView);
            this.tabPage6.Location = new System.Drawing.Point(8, 46);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1279, 908);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "Thông tin nhập kho";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Serial_DataGridView
            // 
            this.Serial_DataGridView.AllowUserToResizeColumns = false;
            this.Serial_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            this.Serial_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Serial_DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Serial_DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Serial_DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Serial_DataGridView.BackgroundColor = System.Drawing.Color.White;
            this.Serial_DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Serial_DataGridView.CausesValidation = false;
            this.Serial_DataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Serial_DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(151)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Serial_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.Serial_DataGridView.ColumnHeadersHeight = DeviceDpi > 96 ? 48 : 35;
            this.Serial_DataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Serial_DataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.Serial_DataGridView.EnableHeadersVisualStyles = false;
            this.Serial_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Serial_DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            /*this.Serial_DataGridView.Location = new System.Drawing.Point(0, 37);*/
            this.Serial_DataGridView.Location = new System.Drawing.Point(0, 0);
            this.Serial_DataGridView.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Serial_DataGridView.MultiSelect = false;
            this.Serial_DataGridView.Name = "Serial_DataGridView";
            this.Serial_DataGridView.ReadOnly = true;
            this.Serial_DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Serial_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.Serial_DataGridView.RowHeadersVisible = false;
            this.Serial_DataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(5);
            this.Serial_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.Serial_DataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.Serial_DataGridView.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);
            this.Serial_DataGridView.RowTemplate.Height = DeviceDpi > 96 ? 48 : 30;
            this.Serial_DataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Serial_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            /*this.Serial_DataGridView.Size = new System.Drawing.Size(this.Size.Width - 100, 100 * DeviceDpi / 96);*/
            this.Serial_DataGridView.Size = new System.Drawing.Size(1279, 908);
            this.Serial_DataGridView.TabIndex = 65;
            this.Serial_DataGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.Serial_DataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.Serial_DataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.Serial_DataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.Serial_DataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.Serial_DataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.Serial_DataGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.Serial_DataGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Serial_DataGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Serial_DataGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Serial_DataGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Serial_DataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Serial_DataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.Serial_DataGridView.ThemeStyle.HeaderStyle.Height = DeviceDpi > 96 ? 48 : 35;
            this.Serial_DataGridView.ThemeStyle.ReadOnly = true;
            this.Serial_DataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.Serial_DataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Serial_DataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Serial_DataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.Serial_DataGridView.ThemeStyle.RowsStyle.Height = DeviceDpi > 96 ? 48 : 30;
            this.Serial_DataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.Serial_DataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.Size = new Size(this.Size.Width, this.Size.Height + 150 * DeviceDpi / 96);
            ((System.ComponentModel.ISupportInitialize)(this.Serial_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        public OverviewDetailSpecsProduct_Form()
        {
            Load += OverviewDetailSpecsProduct_Form_Load;
            Serial_DataGridView.AllowUserToAddRows = false;
            Serial_DataGridView.AllowUserToDeleteRows = false;
            Ports_DataGridView.AllowUserToDeleteRows = false;
            Ports_DataGridView.AllowUserToAddRows = false;
            Serial_DataGridView.DataSourceChanged += Serial_DataGridView_DataSourceChanged;
        }

        #region Loading data
        private void Serial_DataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            grid.SuspendLayout();
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (serialTranslater.ContainsKey(column.Name))
                {
                    string headerText = serialTranslater[column.Name];
                    string[] split = headerText.Split('|');
                    column.HeaderText = split[0];
                    if (split.Length > 1)
                        column.ToolTipText = split[1];
                    if (column.Name == "STT")
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    else if (column.Name == "Price")
                        column.DefaultCellStyle.Format = "#,# VND";

                }
                else
                {
                    column.Visible = false;
                }
            }
            grid.ResumeLayout(false);
            grid.PerformLayout();
        }

        private Task LoadingData(IProgress<int> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                int counter = 0;
                if (products != null && binding != null)
                {
                    for (int index = 0; index < products.Count; index++)
                    {
                        DETAIL_IMPORT_WAREHOUSE detail = DetailImportWarehouseServices.Instance.GetDetailImportWarehouseByProduct(products[index].ID.Value);
                        if (detail != null)
                        {
                            IMPORT_WAREHOUSE import = detail.IMPORT_WAREHOUSE;
                            if (Serial_DataGridView.InvokeRequired)
                            {
                                Serial_DataGridView.Invoke(new Action(() =>
                                {
                                    binding.Add(new SerialBinding { STT = index + 1, Serial = products[index].Serial, Price = detail.PRICE_PER_UNIT, ImportDate = import.IMPORT_DATE, NameIDImportWarehouse = import.NAME_ID });
                                }));
                            }
                            else
                            {
                                binding.Add(new SerialBinding { STT = index + 1, Serial = products[index].Serial, Price = detail.PRICE_PER_UNIT, ImportDate = import.IMPORT_DATE, NameIDImportWarehouse = import.NAME_ID });
                            }
                            progress.Report(++counter);
                        }
                    }
                }
            });
        }
        #endregion

        #region Event
        private void OverviewDetailSpecsProduct_Form_Load(object sender, EventArgs e)
        {
            Waiting_Form waiting = new Waiting_Form();
            Progress<int> progress = new Progress<int>();
            binding = new BindingList<SerialBinding>();
            Serial_DataGridView.DataSource = binding;
            const int stopWaitingCounter = 10;
            progress.ProgressChanged += (owner, value) =>
            {
                if (value >= stopWaitingCounter && !waiting.IsDisposed && waiting.shown)
                {
                    waiting.Close();
                }
            };
            waiting.FormClosing += (owner, ev) =>
            {

            };
            Task task = LoadingData(progress);
            task.GetAwaiter().OnCompleted(() =>
            {
                waiting.Close();
            });
            waiting.ShowDialog(this);
        }
        #endregion

        #region Show handle
        public override ResultDetailSpecsProduct ShowDialog(IWin32Window owner, IList<ModelProduct> payload, bool editable = true)
        {
            products = payload;
            return base.ShowDialog(owner, payload, false);
        }
        #endregion
    }
}
