using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore
{
    public partial class InvoiceList_Form : Form
    {
        protected Dictionary<string, string> listItemViews = new Dictionary<string, string>()
        {
            { "Id", "Mã đơn hàng" },
            { "CusName", "Họ và tên" },
            { "PhoneNum", "Số điện thoại" },
            { "Date", "Ngày lập" },
            { "TPrice", "Đơn giá"}
        };
        public InvoiceList_Form()
        {
            
            InitializeComponent();
            this.Icon = Properties.Resources.Icon;
            this.ShowInTaskbar = false;
            guna2ShadowForm1.SetShadowForm(this);
            this.DataTable.AutoGenerateColumns = false;
            this.DataTable.DataSource = iNVOICEBindingSource;
            this.Load += InvoiceList_Form_Load;
        }

        private void InvoiceList_Form_Load(object sender, EventArgs e)
        {
            LoadView(listItemViews);
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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        public Task LoadDB(IProgress<bool> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                Run(GetListView());
                progress.Report(true);
            });

        }
        private void LoadView(Dictionary<string, string> listItemViews)
        {
            
            foreach (var item in listItemViews)
            {
                DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
                dataGridViewTextBoxColumn.Name = item.Key;
                dataGridViewTextBoxColumn.HeaderText = item.Value;
                DataTable.Columns.Add(dataGridViewTextBoxColumn);
            }
        }
        private void View(List<INVOICE> iNVOICEs)
        {
            iNVOICEBindingSource.ResetBindings(true);
            iNVOICEBindingSource.DataSource = iNVOICEs;
            foreach (DataGridViewRow row in DataTable.Rows)
            {
                INVOICE selected = row.DataBoundItem as INVOICE;
                if (selected != null)
                {
                    row.Cells["Id"].Value = selected.NAME_ID;
                    row.Cells["CusName"].Value = selected.CUSTOMER.INFOR.NAME;
                    row.Cells["PhoneNum"].Value = selected.CUSTOMER.INFOR.PHONE_NUMBER;
                    row.Cells["Date"].Value = selected.INVOICE_DATE;
                    row.Cells["TPrice"].Value = selected.TOTAL;
                }
            }
        }
        public void Run(List<INVOICE> iNVOICEs)
        {
            if (DataTable.InvokeRequired)
            {
                DataTable.Invoke(new Action(() => View(iNVOICEs)));
            }
            else
            {
                View(iNVOICEs);
            }

        }
        private List<INVOICE> GetListView()
        {
            List<INVOICE> invoiceList = InvoiceServices.Instance.GetINVOICEs();

            return invoiceList;
        }
        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewDetail_Button_Click(object sender, EventArgs e)
        {
            if (DataTable.SelectedRows.Count > 0)
            {
                string id = DataTable.SelectedRows[0].Cells["Id"].Value.ToString();
                InvoiceDetail_Form invoiceDetail = new InvoiceDetail_Form(id);
                invoiceDetail.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[DataTable.DataSource];
                cm.SuspendBinding();

                foreach (DataGridViewRow row in DataTable.Rows)
                {
                    if (row.Cells["PhoneNum"].Value.ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
                cm.ResumeBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
