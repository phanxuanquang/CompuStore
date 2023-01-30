using System;
using CompuStore.Database.Models;
using CompuStore.Database.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using CompuStore.Database.Services.ProductServices;
using CompuStore.ImportData;
using CompuStore.Utilities.ExportPDF;
using System.IO;
using System.Globalization;

namespace CompuStore
{
    public partial class AddInvoice_Form : Form
    {
        private class BindingSerialModel
        {
            public string SERIAL { get; set; }
            public string NAME { get; set; }
        }

        private class BindingSerialModelComparer : IEqualityComparer<BindingSerialModel>
        {
            public bool Equals(BindingSerialModel x, BindingSerialModel y)
            {
                return x.NAME == y.NAME;
            }

            public int GetHashCode(BindingSerialModel obj)
            {
                return 0;
            }
        }
        CultureInfo ci = new CultureInfo("vi-vn");
        CUSTOMER customer;
        List<string> addedProduct = new List<string>();
        List<PRODUCT> productList = new List<PRODUCT>();
        STAFF currentStaff;
        DataTable adjustmentTable;
        INVOICE lastInvoice = null;
        int stt = 0;
        long sumM = 0;

        public AddInvoice_Form()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Icon;
            guna2ShadowForm1.SetShadowForm(this);
            this.Load += AddInvoice_Form_Load;
        }

        private void AddInvoice_Form_Load(object sender, EventArgs e)
        {
            this.dateTimePicker.Value = DateTime.Now;
            InitDGV();
            TurnOnAutocomplete();
            LoadLabel();
        }

        #region Biding
        private void LoadLabel()
        {
            currentStaff = LoginServices.Instance.CurrentStaff;
            lbStaffName.Text += "    " + currentStaff.INFOR.NAME;
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

        private void InitDGV()
        {
            adjustmentTable = new DataTable();
            DataColumn dataColumn = new DataColumn();
            dataColumn = new DataColumn("Số thứ tự", typeof(int));
            adjustmentTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Số se-ri", typeof(string));
            adjustmentTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Tên sản phẩm", typeof(string));
            adjustmentTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Giá tiền (VNĐ)", typeof(double));
            adjustmentTable.Columns.Add(dataColumn);
            ItemTable.DataSource = adjustmentTable;
            ItemTable.CellDoubleClick += ItemTable_CellDoubleClick;
        }



        bool isValidCustomer(CUSTOMER customer)
        {
            if (customer == null)
            {
                return false;
            }
            return true;
        }

        private void LoadData()
        {
            ItemTable.DataSource = GetAdjustmentTable();
            foreach (DataGridViewRow row in ItemTable.Rows)
            {
                row.Cells["Số thứ tự"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells["Số se-ri"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                row.Cells["Tên sản phẩm"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                row.Cells["Giá tiền (VNĐ)"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private DataTable GetAdjustmentTable()
        {
            string serial = Serial_ComboBox.SelectedValue.ToString();
            if (!addedProduct.Contains(serial))
            {
                addedProduct.Add(serial);
                DataRow dataRow = adjustmentTable.NewRow();
                dataRow[0] = ++stt;
                dataRow[1] = serial;
                BindingSerialModel selectedItem = NameProduct_ComboBox.SelectedItem as BindingSerialModel;
                dataRow[2] = selectedItem.NAME;
                PRODUCT product = Database.DataProvider.Instance.Database.PRODUCTs.Where(item => item.SERIAL_ID == serial).FirstOrDefault();
                if (product.DETAIL_SPECS.PRICE != null)
                {
                    dataRow[3] = product.DETAIL_SPECS.PRICE.ToString();
                }
                else
                {
                    dataRow[3] = 10000000;
                }
                sumM += long.Parse(dataRow[3].ToString());
                int insertPosition = adjustmentTable.Rows.Count;
                adjustmentTable.Rows.InsertAt(dataRow, insertPosition);
            }
            else
            {
                MessageBox.Show("Sản phẩm đã được thêm");
            }
            this.label2.Text = sumM.ToString("N03", ci) + " VNĐ";
            return adjustmentTable;
        }
        #endregion

        #region Event

        private void ItemTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                sumM -= long.Parse(ItemTable.Rows[e.RowIndex].Cells[3].Value.ToString());
                ItemTable.Rows.RemoveAt(e.RowIndex);
                addedProduct.RemoveAt(e.RowIndex);
                int length = adjustmentTable.Rows.Count;
                int stt2 = 0;
                foreach (DataRow data in adjustmentTable.Rows)
                {
                    if (stt2 < length)
                    {
                        data[0] = ++stt2;
                    }
                }
                ItemTable.DataSource = adjustmentTable;
                stt--;
                this.label2.Text = sumM.ToString("N03", ci) + " VNĐ";
            }
        }


        private void Identity_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                if (!Program.isValidInformation("IDcard", Identity_Box.Text))
                {
                    PhoneNumber_Box.Text = String.Empty;
                    MessageBox.Show("Định dạng CCCD/CMND không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                customer = CustomerServices.Instance.GetCustomerByIDCode(Identity_Box.Text);
                if (!isValidCustomer(customer))
                {
                    DialogResult dialogResult = MessageBox.Show("CMND/CCCD của khách hàng này không tồn tại.\nBạn có muốn thêm khách hàng mới?", "CMND/CCCD không tồn tại", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Name_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = Address_Box.ReadOnly = false;
                        Name_Box.Clear();
                        PhoneNumber_Box.Clear();
                        Email_Box.Clear();
                        Address_Box.Clear();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    Name_Box.Text = customer.INFOR.NAME;
                    PhoneNumber_Box.Text = customer.INFOR.PHONE_NUMBER;
                    Email_Box.Text = customer.INFOR.EMAIL;
                    Address_Box.Text = customer.INFOR.ADDRESS;
                    Name_Box.ReadOnly = PhoneNumber_Box.ReadOnly = Email_Box.ReadOnly = Address_Box.ReadOnly = true;
                }
            }
        }

        
        private void AddInvoice_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompuStore.Tab.SaleManagement_Tab.nameIdCommonSpecs = null;
        }

        private void TurnOnAutocomplete()
        {
            IList<BindingSerialModel> arrayOfWowrds1 = null;
            try
            {
                arrayOfWowrds1 = Database.DataProvider.Instance.Database.PRODUCTs
                    .Where(item => item.IN_WAREHOUSE == true)
                    .Select(item => new BindingSerialModel { NAME = item.DETAIL_SPECS.COMMON_SPECS.NAME, SERIAL = item.SERIAL_ID })
                    .ToList();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            IEqualityComparer<BindingSerialModel> comparer = new BindingSerialModelComparer();
            IEnumerable<BindingSerialModel> nameProducts = arrayOfWowrds1.Distinct(comparer);
            BindingList<BindingSerialModel> bindingSerial = new BindingList<BindingSerialModel>(arrayOfWowrds1);
            BindingList<BindingSerialModel> bindingNameProduct = new BindingList<BindingSerialModel>(nameProducts.ToList());
            Serial_ComboBox.DataSource = bindingSerial;
            NameProduct_ComboBox.DataSource = bindingNameProduct;

            Serial_ComboBox.ValueMember = "SERIAL";
            Serial_ComboBox.DisplayMember = "SERIAL";

            NameProduct_ComboBox.ValueMember = "SERIAL";            
            NameProduct_ComboBox.DisplayMember = "NAME";
        }

        

        private void NameProduct_ComboBox_Leave(object sender, EventArgs e)
        {
            if (sender is ComboBox control)
            {
                string currentText = control.Text;
                BindingList<BindingSerialModel> binding = control.DataSource as BindingList<BindingSerialModel>;
                if (control.DisplayMember == "NAME" && binding.FirstOrDefault(item => item.NAME == currentText) == null
                    || control.DisplayMember == "SERIAL" && binding.FirstOrDefault(item => item.SERIAL == currentText) == null)
                {
                    MessageBox.Show("Thông tin sản phẩm không hợp lệ.\nVui lòng nhập lại.");
                    control.Focus();
                }
            }
        }

        private void Serial_ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            BindingSerialModel selectedItem = NameProduct_ComboBox.SelectedItem as BindingSerialModel;
            if (selectedItem != null && sender is ComboBox control)
            {
                int index = e.Index >= 0 ? e.Index : 0;
                BindingSerialModel item = control.Items[index] as BindingSerialModel;

                Brush backColor = null;
                Brush foreColor = null;
                if (item.NAME == selectedItem.NAME)
                {
                    backColor = Brushes.DarkBlue;
                    foreColor = Brushes.White;
                }
                else
                {
                    backColor = Brushes.WhiteSmoke;
                    foreColor = Brushes.Black;
                }
                e.DrawBackground();
                e.Graphics.FillRectangle(backColor, e.Bounds);
                e.Graphics.DrawString(item.SERIAL, e.Font, foreColor, e.Bounds, StringFormat.GenericDefault);
            }
            e.DrawFocusRectangle();
        }

        private void Serial_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox control)
            {
                BindingSerialModel selectedItem = control.SelectedItem as BindingSerialModel;
                BindingList<BindingSerialModel> binding = NameProduct_ComboBox.DataSource as BindingList<BindingSerialModel>;
                if (selectedItem == null || binding == null) return;
                BindingSerialModel found = binding.FirstOrDefault(item => item.NAME == selectedItem.NAME);
                if (found != null)
                    NameProduct_ComboBox.SelectedItem = found;
            }
        }

        private void NameProduct_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox control)
            {
                BindingSerialModel selectedItem = control.SelectedItem as BindingSerialModel;
                BindingList<BindingSerialModel> binding = Serial_ComboBox.DataSource as BindingList<BindingSerialModel>;
                if (selectedItem == null || binding == null) return;
                BindingSerialModel found = binding.FirstOrDefault(item => item.NAME == selectedItem.NAME);
                if (found != null)
                    Serial_ComboBox.SelectedItem = found;
            }
        }

        private void AddItemToTable_Button_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Button
        private async void Save_Button_Click(object sender, EventArgs e)
        {
            foreach (var item in addedProduct)
            {
                productList.Add(Database.DataProvider.Instance.Database.PRODUCTs.Where(prod => prod.SERIAL_ID == item).FirstOrDefault());
            }

            if (customer == null)
            {
                customer = CustomerServices.Instance.SaveCustomerToDB(Name_Box.Text, PhoneNumber_Box.Text, Email_Box.Text, Identity_Box.Text, Address_Box.Text);
            }
            dynamic result = await InvoiceServices.Instance.SaveInvoiceToDB(productList, customer.ID, currentStaff.ID, new DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month, dateTimePicker.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), 10);
            if (result is Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            else
            {
                lastInvoice = result;
                MessageBox.Show("Lưu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            await Controller.Instance.Reload(lastInvoice);
            //this.Close();
        }

        private async void Print_Button_Click(object sender, EventArgs e)
        {
            if (lastInvoice == null)
                return;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            ExportPDF export = new ExportPDF();
            IDataExport data = new InvoicePDF
            {
                ExportPath = Path.Combine(dialog.SelectedPath, "export.html"),
                DataBindingTemplate = new
                {
                    data = new
                    {
                        id_invoice = lastInvoice.NAME_ID,
                        date = lastInvoice.INVOICE_DATE,
                        customer_name = lastInvoice.CUSTOMER.INFOR.NAME,
                        phone_customer = lastInvoice.CUSTOMER.INFOR.PHONE_NUMBER,
                        company = "XL COMPANY",
                        address = "123 KTX KHU A",
                        phone_company = "382765235",
                        total = lastInvoice.DETAIL_INVOICE.Select(item => item.PRICE_PER_UNIT).Sum(),
                        products = lastInvoice.DETAIL_INVOICE.Select(item => new { name = item.PRODUCT.DETAIL_SPECS.COMMON_SPECS.NAME, price = item.PRICE_PER_UNIT })
                    }
                }
            };
            bool result = await export.RunExport(data);
            MessageBox.Show(result ? "Xuất thành công" : "Xuất thất bại");
            //fake invoice
            /*await Task.Factory.StartNew(() =>
            {
                int[] id = { 7, 8, 9 };

                string message = string.Empty;
                DateTime now = new DateTime(2022, 12, 1);
                for (int index = 0; index < 10; index++)
                {
                    List<PRODUCT> items = Database.DataProvider.Instance.Database.PRODUCTs.Where(item => item.IN_WAREHOUSE == true && item.DETAIL_SPECS.COMMON_SPECS.NAME == "Apple MacBook Pro 15 (2018)").Take(1).ToList();
                    now = now.AddDays(1);
                    try
                    {
                        InvoiceServices.Instance.SaveInvoiceToDB(items, id[id.Length % 3], currentStaff.ID, now, 10);
                    }
                    catch (Exception ex)
                    {
                        message += ex;
                    }
                }
            });
            this.Close();*/
        }
        #endregion

        private void PhoneNumber_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if(!Program.isValidInformation("phoneNum", PhoneNumber_Box.Text))
                {
                    MessageBox.Show("Định dạng số điện thoại không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Email_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!Program.isValidInformation("email", Email_Box.Text))
                {
                    MessageBox.Show("Định dạng email không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
