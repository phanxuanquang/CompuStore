using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.GUI;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public partial class BaseDetailInvoiceImportWarehouse_Form : Form
    {
        #region Interface
        protected class ModelProductGroup
        {
            public List<ModelProduct> productsTheSame;

            public ModelProduct product
            {
                get
                {
                    return productsTheSame?.First() ?? null;
                }
                set
                {
                    if (value != null)
                    {
                        if (productsTheSame == null)
                            productsTheSame = new List<ModelProduct>();
                        productsTheSame.Add(value);
                    }
                }
            }

            public bool IsTheSameGroup(ModelProduct _product)
            {
                ModelProduct template = product;
                if (template == null) return true;
                return template.CompareSpecs(_product);
            }
        }

        private class LineUpCustom
        {
            public int ID { get; set; }
            public string LineUp { get; set; }
            public string Manufacturer { get; set; }

            public static LineUpCustom Convert(LINE_UP model)
            {
                LineUpCustom result = null;
                if (model != null)
                {
                    result = new LineUpCustom();
                    result.ID = model.ID;
                    result.LineUp = model.NAME;
                    result.Manufacturer = model.MANUFACTURER;
                }
                return result;
            }
        }

        private class NameProductCustom
        {
            public int IDCommonSpecs { get; set; }
            public string NameProduct { get; set; }

            public static NameProductCustom Convert(COMMON_SPECS model)
            {
                NameProductCustom result = null;
                if (model != null)
                {
                    result = new NameProductCustom();
                    result.IDCommonSpecs = model.ID;
                    result.NameProduct = model.NAME;
                }
                return result;
            }
        }
        #endregion

        private static readonly Dictionary<string, string> translater = new Dictionary<string, string> {
            { "LineUp", "Dòng sản phẩm" },
            { "Country", "Nơi sản xuất" },
            { "Manufacturer", "Nhà sản xuất" },
            { "SizePanel", "Kích thước màn hình|Đơn vị: inch" },
            { "Brightness", "Độ sáng|Đơn vị: nit" },
            { "TypePanel", "Tấm nền" },
            { "SpaceColorString", "Độ phủ màu|Độ chính xác màu hiện thị trên màn hình so với khi in ấn" },
            { "RefreshRate", "Tốc độ làm tươi|Đơn vị: Hz" },
            { "CanTouchPanel", "Cảm ứng" },
            { "RatioPanelString", "Tỉ lệ màn hình" },
            { "CPU", "CPU" },
            { "GPU", "GPU" },
            { "RAMString", "RAM" },
            { "iGPU", "iGPU" },
            { "TypeStorage", "Chuẩn ổ cứng" },
            { "StorageCapacity", "Dung lượng ổ cứng|Đơn vị: GB" },
            { "GPUString", "Card đồ hoại rời" },
            { "Weight", "Khối lượng|Đơn vị: Kg" },
            { "NameProduct", "Tên sản phẩm" },
            { "ReleaseDate", "Năm ra mắt|Năm hãng ra mắt đến công chúng" },
            { "CaseMaterial", "Vật liệu vỏ" },
            { "PortString", "Cổng kết nối" },
            { "Webcam", "Webcam" },
            { "SizeProductString", "Kích thước máy|Đơn vị: mm" },
            { "OS", "Hệ điều hành" },
            { "Wifi", "Chuẩn Wifi" },
            { "Bluetooth", "Chuẩn Bluetooth" },
            { "ColorCode", "Màu sắc" }};

        BindingList<ModelProduct> bindingTable = null;
        BindingList<NameProductCustom> bindingNameProduct = null;
        BindingList<LineUpCustom> bindingLineUp = null;

        public BaseDetailInvoiceImportWarehouse_Form()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Task LoadingData(IProgress<bool> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                IQueryable<LINE_UP> lineupQueryable = Database.DataProvider.Instance.Database.LINE_UP;
                foreach (LINE_UP lineup in lineupQueryable)
                {
                    if (bindingLineUp != null)
                    {
                        bindingLineUp.Add(LineUpCustom.Convert(lineup));
                    }
                }

                IQueryable<COMMON_SPECS> commonSpecsQueryable = Database.DataProvider.Instance.Database.COMMON_SPECS;
                foreach (COMMON_SPECS commonSpecs in commonSpecsQueryable)
                {
                    if (bindingNameProduct != null)
                    {
                        bindingNameProduct.Add(NameProductCustom.Convert(commonSpecs));
                    }
                }

                progress.Report(true);
            });
        }

        private void DetailInvoiceImportWarehouse_Form_Load(object sender, EventArgs e)
        {
            bindingTable = new BindingList<ModelProduct>();
            bindingNameProduct = new BindingList<NameProductCustom>();
            bindingLineUp = new BindingList<LineUpCustom>();
            TableData_DataGridView.DataSource = bindingTable;
            Progress<bool> progress = new Progress<bool>();
            Waiting_Form waiting = new Waiting_Form();
            waiting.FormClosing += (owner, ev) =>
            {
                LineUp_ComboBox.DataSource = bindingLineUp;
                LineUp_ComboBox.ValueMember = "ID";
                LineUp_ComboBox.DisplayMember = "LineUp";

                NameProduct_ComboBox.DataSource = bindingNameProduct;
                NameProduct_ComboBox.ValueMember = "IDCommonSpecs";
                NameProduct_ComboBox.DisplayMember = "NameProduct";

                Manufacturer_ComboBox.DataSource = bindingLineUp;
                Manufacturer_ComboBox.ValueMember = "ID";
                Manufacturer_ComboBox.DisplayMember = "Manufacturer";
            };

            Task runLoading = LoadingData(progress);

            runLoading.GetAwaiter().OnCompleted(() => waiting.Close());

            progress.ProgressChanged += (owner, value) =>
            {
                if(value && !waiting.IsDisposed && waiting.shown)
                {
                    waiting.Close();
                }
            };

            waiting.ShowDialog(this);
        }

        private void TableData_DataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            grid.SuspendLayout();
            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (translater.ContainsKey(column.Name))
                {
                    if (column.Name == "ReleaseDate")
                    {
                        column.DefaultCellStyle.Format = "yyyy";
                    }
                    string headerText = translater[column.Name];
                    string[] split = headerText.Split('|');
                    column.HeaderText = split[0];
                    if (split.Length > 1)
                    {
                        column.ToolTipText = split[1];
                    }
                }
                else
                {
                    column.Visible = false;
                }
            }
            grid.ResumeLayout(true);
        }

        private void TableData_DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowCount > 0)
            {
                DataGridView grid = sender as DataGridView;

                DataGridViewColumn colorModelCol = grid.Columns["ColorModel"];
                DataGridViewColumn colorCodeCol = grid.Columns["ColorCode"];
                DataGridViewColumn colorNameCol = grid.Columns["ColorName"];
                DataGridViewCell toolTipColor = grid.Rows[e.RowIndex].Cells[colorNameCol.Index];
                DataGridViewCell color = grid.Rows[e.RowIndex].Cells[colorModelCol.Index];
                DataGridViewCell cell = grid.Rows[e.RowIndex].Cells[colorCodeCol.Index];
                DataGridViewCellStyle style = cell.Style;
                cell.ToolTipText = toolTipColor.Value.ToString();
                style.ForeColor = style.SelectionForeColor = style.BackColor = style.SelectionBackColor = (color.Value as ImportData.ModelProduct.Color).ColorCode;
            }
        }
    }
}
