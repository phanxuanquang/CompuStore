﻿using CompuStore.Database.Models;
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
            this.GridDataTable.AutoGenerateColumns = false;
            InitializeComponent();
            this.GridDataTable.DataSource = warrantyBindingSource;
            this.Load += ServiceManagement_Tab_Load;
        }

        private void ServiceManagement_Tab_Load(object sender, EventArgs e)
        {
            LoadWarranty();
        }

        public void LoadWarranty()
        {
            LoadViewWarranty();
            Progress<bool> progress = new Progress<bool>();
            Waiting_Form waiting = new Waiting_Form();
            Task runLoading = LoadDBWarranty(progress);

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

        public void LoadCOrRefund()
        {
            LoadViewCOrRefund();
            Progress<bool> progress = new Progress<bool>();
            Waiting_Form waiting = new Waiting_Form();
            Task runLoading = LoadDBCOrRefund(progress);

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


        public Task LoadDBWarranty(IProgress<bool> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                RunWarranty(GetListViewWarranty());
                progress.Report(true);
            });

        }

        public Task LoadDBCOrRefund(IProgress<bool> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                RunCOrRefund(GetListViewCOrRefund());
                progress.Report(true);
            });

        }
        private void LoadViewWarranty()
        {
            listItemViews.Clear();
            GridDataTable.Columns.Clear();
            listItemViews.Add("CusName", "Họ và tên");
            listItemViews.Add("PhoneNum", "Số điện thoại");
            listItemViews.Add("Product", "Tên sản phẩm");
            listItemViews.Add("ProductSerial", "Mã sản phẩm");
            listItemViews.Add("Date", "Ngày lập");
            listItemViews.Add("DateRe", "Ngày hẹn trả");
            listItemViews.Add("Id", "Mã nhân viên phụ trách");
            listItemViews.Add("Status", "Trạng thái");
            foreach (var item in listItemViews)
            {
                DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
                dataGridViewTextBoxColumn.Name = item.Key;
                dataGridViewTextBoxColumn.HeaderText = item.Value;
                GridDataTable.Columns.Add(dataGridViewTextBoxColumn);
            }
        }

        private void LoadViewCOrRefund()
        {
            listItemViews.Clear();
            GridDataTable.Columns.Clear();
            listItemViews.Add("CusName", "Họ và tên");
            listItemViews.Add("PhoneNum", "Số điện thoại");
            listItemViews.Add("Product", "Tên sản phẩm");
            listItemViews.Add("ProductSerial", "Mã sản phẩm hoàn trả");
            listItemViews.Add("ProductRe", "Tên sản phẩm");
            listItemViews.Add("ProductSerialRe", "Mã sản phẩm đổi");
            listItemViews.Add("DateRe", "Ngày hẹn trả");
            listItemViews.Add("Id", "Mã nhân viên phụ trách");
            
            foreach (var item in listItemViews)
            {
                DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
                dataGridViewTextBoxColumn.Name = item.Key;
                dataGridViewTextBoxColumn.HeaderText = item.Value;
                GridDataTable.Columns.Add(dataGridViewTextBoxColumn);
            }
        }
        private void ViewWarranty(List<RECEIVE_WARRANTY> wARRANTies)
        {
            warrantyBindingSource.ResetBindings(true);
            warrantyBindingSource.DataSource = wARRANTies;
            foreach (DataGridViewRow row in GridDataTable.Rows)
            {
                RECEIVE_WARRANTY selected = row.DataBoundItem as RECEIVE_WARRANTY;
                if (selected != null)
                {

                    row.Cells["CusName"].Value = selected.INVOICE.CUSTOMER.INFOR.NAME;
                    row.Cells["PhoneNum"].Value = selected.INVOICE.CUSTOMER.INFOR.PHONE_NUMBER;
                    row.Cells["Product"].Value = selected.PRODUCT.DETAIL_SPECS.COMMON_SPECS.NAME;
                    row.Cells["ProductSerial"].Value = selected.PRODUCT.SERIAL_ID;
                    row.Cells["Date"].Value = selected.RECEIVE_DATE;
                    row.Cells["DateRe"].Value = selected.RETURN_DATE;
                    row.Cells["Id"].Value = selected.STAFF.NAME_ID;
                    row.Cells["Status"].Value = selected.STATUS_WARRANTY == 0 ? "Đang xử lý" : "Đã xử lý";
                }
            }
        }

        private void ViewCOrRefund(List<CHANGE_OR_REFUND_PRODUCT> cHANGE_OR_REFUND_PRODUCTs)
        {
            warrantyBindingSource.ResetBindings(true);
            warrantyBindingSource.DataSource = cHANGE_OR_REFUND_PRODUCTs;
            foreach (DataGridViewRow row in GridDataTable.Rows)
            {
                CHANGE_OR_REFUND_PRODUCT selected = row.DataBoundItem as CHANGE_OR_REFUND_PRODUCT;
                if (selected != null)
                {
                    row.Cells["CusName"].Value = selected.INVOICE.CUSTOMER.INFOR.NAME;
                    row.Cells["PhoneNum"].Value = selected.INVOICE.CUSTOMER.INFOR.PHONE_NUMBER;
                    row.Cells["Product"].Value = selected.PRODUCT.DETAIL_SPECS.COMMON_SPECS.NAME;
                    row.Cells["ProductSerial"].Value = selected.PRODUCT.SERIAL_ID;
                    row.Cells["ProductRe"].Value = selected.PRODUCT1.DETAIL_SPECS.COMMON_SPECS.NAME;
                    row.Cells["ProductSerialRe"].Value = selected.PRODUCT1.SERIAL_ID;
                    row.Cells["DateRe"].Value = selected.RETURN_DATE;
                    row.Cells["Id"].Value = selected.STAFF.NAME_ID;
                }
            }
        }
        public void RunWarranty(List<RECEIVE_WARRANTY> wARRANTies)
        {
            if (GridDataTable.InvokeRequired)
            {
                GridDataTable.Invoke(new Action(() => ViewWarranty(wARRANTies)));
            }
            else
            {
                ViewWarranty(wARRANTies);
            }

        }

        public void RunCOrRefund(List<CHANGE_OR_REFUND_PRODUCT> cHANGE_OR_REFUND_PRODUCTs)
        {
            if (GridDataTable.InvokeRequired)
            {
                GridDataTable.Invoke(new Action(() => ViewCOrRefund(cHANGE_OR_REFUND_PRODUCTs)));
            }
            else
            {
                ViewCOrRefund(cHANGE_OR_REFUND_PRODUCTs);
            }

        }
        private List<RECEIVE_WARRANTY> GetListViewWarranty()
        {
            List<RECEIVE_WARRANTY> warrantyList = WarrantyServices.Instance.GetWarrantys();

            return warrantyList;
        }

        private List<CHANGE_OR_REFUND_PRODUCT> GetListViewCOrRefund()
        {
            List<CHANGE_OR_REFUND_PRODUCT> warrantyList = ChangeOrRefundProductServices.Instance.GetCHANGE_OR_REFUND_PRODUCTs();

            return warrantyList;
        }

        private void Button_3_Click(object sender, EventArgs e)
        {
            if(Button_3.Text == "Danh sách đổi trả")
            {
                Button_3.Text = "Danh sách bảo hành";
                SearchBox.PlaceholderText = "Tìm kiếm phiếu đổi trả theo số điện thoại";
                LoadCOrRefund();
            }
            else
            {
                Button_3.Text = "Danh sách đổi trả";
                SearchBox.PlaceholderText = "Tìm kiếm phiếu bảo hành theo số điện thoại";
                LoadWarranty();
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

            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[GridDataTable.DataSource];
            currencyManager1.SuspendBinding();
            if (Button_3.Text == "Danh sách đổi trả")
            {
                foreach (DataGridViewRow row in GridDataTable.Rows)
                {
                    CHANGE_OR_REFUND_PRODUCT selected = row.DataBoundItem as CHANGE_OR_REFUND_PRODUCT;
                    if (selected != null)
                    {
                        if (!(selected.PRODUCT.SERIAL_ID.Contains(SearchBox.Text) || selected.INVOICE.CUSTOMER.INFOR.PHONE_NUMBER.Contains(SearchBox.Text)))
                        {
                            row.Visible = false;
                        }
                        else
                        {
                            row.Visible = true;
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in GridDataTable.Rows)
                {
                    RECEIVE_WARRANTY selected = row.DataBoundItem as RECEIVE_WARRANTY;
                    if (selected != null)
                    {
                        if (!(selected.PRODUCT.SERIAL_ID.Contains(SearchBox.Text) || selected.INVOICE.CUSTOMER.INFOR.PHONE_NUMBER.Contains(SearchBox.Text)))
                        {
                            row.Visible = false;
                        }
                        else
                        {
                            row.Visible = true;
                        }
                    }
                }
            }

            currencyManager1.ResumeBinding();
        }
    }
}
