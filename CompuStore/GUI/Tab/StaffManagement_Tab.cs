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
    using CompuStore.Database.Services;
    using CompuStore.GUI;
    using CompuStore.GUI.Forms;
    using CompuStore.ImportData;
    using Database.Models;
    using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
    using System.Threading;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;

    public partial class StaffManagement_Tab : BaseTab
    {
        
        public StaffManagement_Tab()
        {
            this.GridDataTable.AutoGenerateColumns = false;
            InitializeComponent();
            this.GridDataTable.DataSource = sTAFFBindingSource;
            this.Load += StaffManagement_Tab_Load;


        }

        private void StaffManagement_Tab_Load(object sender, EventArgs e)
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
                GridDataTable.Columns.Add(dataGridViewTextBoxColumn);
            }
        }
        private void View(List<STAFF> sTAFFs)
        {
            sTAFFBindingSource.ResetBindings(true);
            sTAFFBindingSource.DataSource = sTAFFs;
            foreach (DataGridViewRow row in GridDataTable.Rows)
            {
                STAFF selected = row.DataBoundItem as STAFF;
                if (selected != null)
                {
                    row.Cells["Id"].Value = selected.NAME_ID;
                    row.Cells["Id"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    row.Cells["StaffName"].Value = selected.INFOR.NAME;
                    row.Cells["StaffName"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    row.Cells["PhoneNum"].Value = selected.INFOR.PHONE_NUMBER;
                    row.Cells["PhoneNum"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    row.Cells["Role"].Value = selected.STAFFROLE.ROLE;
                    row.Cells["Role"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    row.Cells["Status"].Value = selected.WORKING_STATUS == 0 ? "Đã nghỉ việc" : "Đang làm việc";
                    row.Cells["Status"].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }
        public void Run(List<STAFF> sTAFFs)
        {
            if (GridDataTable.InvokeRequired)
            {
                GridDataTable.Invoke(new Action(() => View(sTAFFs)));
            }
            else
            {
                View(sTAFFs);
            }

        }
        private List<STAFF> GetListView()
        {
            List<STAFF> staffList = StaffServices.Instance.GetStaffs();

            return staffList;
        }


        #endregion

        #region Buttons
        private void AddNew_Buttom_Click(object sender, EventArgs e)
        {
            StaffEdit_Form staffEdit_Form = new StaffEdit_Form(true, "THÊM NHÂN VIÊN", null);
            staffEdit_Form.ShowDialog();
            Run(GetListView());
        }
        private void ViewDetail_Button_Click(object sender, EventArgs e)
        {
            StaffEdit_Form staffEdit_Form = new StaffEdit_Form(false, "THÔNG TIN NHÂN VIÊN", sTAFFBindingSource.Current);
            staffEdit_Form.ShowDialog();
            Run(GetListView());
        }
        #endregion

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[GridDataTable.DataSource];
            currencyManager1.SuspendBinding();
            foreach (DataGridViewRow row in GridDataTable.Rows)
            {
                STAFF selected = row.DataBoundItem as STAFF;
                if (selected != null)
                {
                    if (!(selected.NAME_ID.ToLower().Contains(SearchBox.Text) || selected.INFOR.NAME.Contains(SearchBox.Text) || selected.INFOR.PHONE_NUMBER.Contains(SearchBox.Text)))
                    {
                        
                        row.Visible = false;
                        
                    }
                    else
                    {
                        row.Visible = true;
                    }
                }
            }
            currencyManager1.ResumeBinding();
        }

        protected void GridDataTable_DataSourceChanged(object sender, EventArgs e)
        {
            
        }
    }
}
