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
    using Database.Models;
    using System.Security.Cryptography.Pkcs;

    public partial class ServiceManagement_Tab : Tab.BaseTab
    {
        public ServiceManagement_Tab()
        {
            InitializeComponent();
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
            listItemViews.Add("CusName", "Họ và tên");
            listItemViews.Add("PhoneNum", "Số điện thoại");
            listItemViews.Add("Product", "Tên sản phẩm");
            listItemViews.Add("Date", "Ngày lập");
            listItemViews.Add("DateRe", "Ngày hẹn trả");
            listItemViews.Add("Status", "Trạng thái");
            foreach (var item in listItemViews)
            {
                DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
                dataGridViewTextBoxColumn.Name = item.Key;
                dataGridViewTextBoxColumn.HeaderText = item.Value;
                DataTable.Columns.Add(dataGridViewTextBoxColumn);
            }
        }
        private void View(List<RECEIVE_WARRANTY> wARRANTies)
        {
            warrantyBindingSource.ResetBindings(true);
            warrantyBindingSource.DataSource = wARRANTies;
            foreach (DataGridViewRow row in DataTable.Rows)
            {
                RECEIVE_WARRANTY selected = row.DataBoundItem as RECEIVE_WARRANTY;
                if (selected != null)
                {
                    row.Cells["Id"].Value = selected.NAME_ID;
                    row.Cells["CusName"].Value = selected.INVOICE.CUSTOMER.INFOR.NAME;
                    row.Cells["PhoneNum"].Value = selected.INVOICE.CUSTOMER.INFOR.PHONE_NUMBER;
                    row.Cells["Product"].Value = selected.PRODUCT.DETAIL_SPECS.COMMON_SPECS.NAME;
                    row.Cells["Date"].Value = selected.RECEIVE_DATE;
                    row.Cells["DateRe"].Value = selected.RETURN_DATE;
                    row.Cells["Status"].Value = selected.STATUS_WARRANTY;
                }
            }
        }
        public void Run(List<RECEIVE_WARRANTY> wARRANTies)
        {
            if (DataTable.InvokeRequired)
            {
                DataTable.Invoke(new Action(() => View(wARRANTies)));
            }
            else
            {
                View(wARRANTies);
            }

        }
        private List<RECEIVE_WARRANTY> GetListView()
        {
            List<RECEIVE_WARRANTY> warrantyList = WarrantyServices.Instance.GetWarrantys();

            return warrantyList;
        }

        private void Button_3_Click(object sender, EventArgs e)
        {
            if(Button_3.Text == "Danh sách đổi trả")
            {
                Button_3.Text = "Danh sách bảo hành";
                SearchBox.PlaceholderText = "Tìm kiếm phiếu đổi trả theo số điện thoại";
                // reload DataTable thành table đổi trả
            }
            else
            {
                Button_3.Text = "Danh sách đổi trả";
                SearchBox.PlaceholderText = "Tìm kiếm phiếu bảo hành theo số điện thoại";
                // reload DataTable thành table bảo hành
            }
        }

        private void Bottom_1_Click(object sender, EventArgs e)
        {
            AddWarranty_Form addWarranty_Form = new AddWarranty_Form();
            addWarranty_Form.ShowDialog();
        }

        private void Button_2_Click(object sender, EventArgs e)
        {
            AddReturn_Form addReturn_Form = new AddReturn_Form();
            addReturn_Form.ShowDialog();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DataTable.Rows)
            {
                RECEIVE_WARRANTY selected = row.DataBoundItem as RECEIVE_WARRANTY;
                if (selected != null)
                {
                    if (!(selected.NAME_ID.ToString().Contains(SearchBox.Text) || selected.INVOICE.CUSTOMER.INFOR.PHONE_NUMBER.Contains(SearchBox.Text)))
                    {
                        DataTable.CurrentCell = null;
                    }
                }
            }
        }
    }
}
