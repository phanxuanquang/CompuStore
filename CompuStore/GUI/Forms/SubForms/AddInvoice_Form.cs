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

        CUSTOMER customer;
        List<string> addedProduct = new List<string>();
        List<PRODUCT> productList = new List<PRODUCT>();
        STAFF currentStaff;
        DataTable adjustmentTable;

        public AddInvoice_Form()
        {
            InitializeComponent();
            this.Load += AddInvoice_Form_Load;
        }

        private void AddInvoice_Form_Load(object sender, EventArgs e)
        {
            InitDGV();
            TurnOnAutocomplete();
            LoadLabel();
        }

        private void LoadLabel()
        {
            currentStaff = LoginServices.Instance.CurrentStaff;
            lbStaffName.Text += " " + currentStaff.INFOR.NAME;
            lbDate.Text += " " + DateTime.Now.ToLongDateString();
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
            dataColumn = new DataColumn("Số se-ri", typeof(string));
            adjustmentTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Tên sản phẩm", typeof(string));
            adjustmentTable.Columns.Add(dataColumn);
            dataColumn = new DataColumn("Giá tiền", typeof(double));
            adjustmentTable.Columns.Add(dataColumn);
            ItemTable.DataSource = adjustmentTable;
            ItemTable.CellDoubleClick += ItemTable_CellDoubleClick;
        }

        private void ItemTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ItemTable.Rows.RemoveAt(e.RowIndex);
                addedProduct.RemoveAt(e.RowIndex);
            }    
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
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
        }

        private DataTable GetAdjustmentTable()
        {
            string serial = Serial_ComboBox.SelectedValue.ToString();
            if (!addedProduct.Contains(serial))
            {
                addedProduct.Add(serial);
                DataRow dataRow = adjustmentTable.NewRow();
                dataRow[0] = serial;
                BindingSerialModel selectedItem = NameProduct_ComboBox.SelectedItem as BindingSerialModel;
                dataRow[1] = selectedItem.NAME;
                PRODUCT product = Database.DataProvider.Instance.Database.PRODUCTs.Where(item => item.SERIAL_ID == serial).FirstOrDefault();
                if (product.DETAIL_SPECS.PRICE != null)
                {
                    dataRow[2] = product.DETAIL_SPECS.PRICE;
                }
                else
                {
                    dataRow[2] = 10000000;
                }
                int insertPosition = adjustmentTable.Rows.Count;
                adjustmentTable.Rows.InsertAt(dataRow, insertPosition);
            }
            else
            {
                MessageBox.Show("Sản phẩm đã được thêm");
            }    
            return adjustmentTable;
        }

        private void Identity_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
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

        private void Save_Button_Click(object sender, EventArgs e)
        {
            foreach (var item in addedProduct)
            {
                productList.Add(Database.DataProvider.Instance.Database.PRODUCTs.Where(prod => prod.SERIAL_ID == item).FirstOrDefault());
            }    

            if (customer == null)
            {
                customer = CustomerServices.Instance.SaveCustomerToDB(Name_Box.Text, PhoneNumber_Box.Text, Email_Box.Text, Identity_Box.Text, Address_Box.Text);
            }
            Exception res = InvoiceServices.Instance.SaveInvoiceToDB(productList, customer.ID, currentStaff.ID, DateTime.Now, 10);
            if (res.Message == "done")
            {
                MessageBox.Show("Lưu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res.Message);
            }
            this.Close();
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

        private void Print_Button_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Không tim thấy máy in. Vui lòng thử lại sau.", "Không tìm thấy máy in", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            foreach (var item in addedProduct)
            {
                productList.Add(Database.DataProvider.Instance.Database.PRODUCTs.Where(prod => prod.SERIAL_ID == item).FirstOrDefault());
            }

            if (customer == null)
            {
                customer = CustomerServices.Instance.SaveCustomerToDB(Name_Box.Text, PhoneNumber_Box.Text, Email_Box.Text, Identity_Box.Text, Address_Box.Text);
            }
            Exception res = InvoiceServices.Instance.SaveInvoiceToDB(productList, customer.ID, currentStaff.ID, DateTime.Now, 10);
            if (res.Message == "done")
            {
                MessageBox.Show("Lưu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(res.Message);
            }
            this.Close();
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
    }
}
