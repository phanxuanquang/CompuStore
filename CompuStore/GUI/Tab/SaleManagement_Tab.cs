using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.GUI;
using CompuStore.GUI.Forms;
using CompuStore.GUI.Forms.Warehouse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.Tab
{
    public partial class SaleManagement_Tab : BaseTab
    {
        public SaleManagement_Tab()
        {
            this.DataTable.AutoGenerateColumns = false;
            InitializeComponent();
            this.DataTable.DataSource = invoiceBindingSource;
            this.Load += SaleManagement_Tab_Load;
        }


        private void SaleManagement_Tab_Load(object sender, EventArgs e)
        {
            LoadView();
            Progress<bool> progress = new Progress<bool>();
            Waiting_Form waiting = new Waiting_Form();
            Task runLoading = LoadDB(progress);

            const bool stopWaitingCoutner = true;

            runLoading.GetAwaiter().OnCompleted(() => waiting.Close());

            progress.ProgressChanged += (owner, value) =>
            {
                if (value == stopWaitingCoutner && !waiting.IsDisposed && waiting.shown)
                {
                    waiting.Close();
                }
            };

            waiting.ShowDialog(this);
        }

        #region Binding

        public Task LoadDB(IProgress<bool> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                Run(GetListView());
                progress.Report(true);
            });

        }
        private void LoadView()
        {
            listItemViews.Add("Id", "Mã nhân viên");
            listItemViews.Add("StaffName", "Họ và tên");
            listItemViews.Add("PhoneNum", "Số điện thoại");
            listItemViews.Add("Role", "Chức vụ");
            listItemViews.Add("Status", "Trình trạng");
            foreach (var item in listItemViews)
            {
                DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
                dataGridViewTextBoxColumn.Name = item.Key;
                dataGridViewTextBoxColumn.HeaderText = item.Value;
                DataTable.Columns.Add(dataGridViewTextBoxColumn);
            }
        }
        private void View(List<INVOICE> invoices)
        {
            invoiceBindingSource.ResetBindings(true);
            invoiceBindingSource.DataSource = invoices;
            foreach (DataGridViewRow row in DataTable.Rows)
            {
                STAFF selected = row.DataBoundItem as STAFF;
                if (selected != null)
                {
                    row.Cells["Id"].Value = selected.NAME_ID;
                    row.Cells["StaffName"].Value = selected.INFOR.NAME;
                    row.Cells["PhoneNum"].Value = selected.INFOR.PHONE_NUMBER;
                    row.Cells["Role"].Value = selected.STAFFROLE.ROLE;
                    row.Cells["Status"].Value = selected.WORKING_STATUS == 0 ? "Đã nghỉ việc" : "Đang làm việc";
                }
            }
        }
        public void Run(List<INVOICE> invoices)
        {
            if (DataTable.InvokeRequired)
            {
                DataTable.Invoke(new Action(() => View(invoices)));
            }
            else
            {
                View(invoices);
            }

        }
        private List<INVOICE> GetListView()
        {
            List<INVOICE> invoiceList = InvoiceServices.Instance.GetINVOICEs();

            return invoiceList;
        }


        #endregion

        private void ViewDetail_Button_Click(object sender, EventArgs e)
        {
            DetailSpecsProduct_Form detailSpecsProduct_Form = new DetailSpecsProduct_Form(/*DataTable.CurrentRow.Cells[0].Value.ToString()*/);
            detailSpecsProduct_Form.ShowDialog();
        }

        private void AddNew_Buttom_Click(object sender, EventArgs e)
        {
            AddInvoice_Form addInvoice_Form = new AddInvoice_Form();
            addInvoice_Form.ShowDialog(); 
        }
    }
}
