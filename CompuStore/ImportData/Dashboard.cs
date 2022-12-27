using CompuStore.Database.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompuStore.ImportData

{
    public struct RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
    internal class Dashboard
    {
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;
        public int NumCustomers { get; private set; }
        public int NumSuppliers { get; private set; }
        public int NumProducts { get; private set; }
        public List<KeyValuePair<string, int>> TopProductsList { get; private set; }
        public List<KeyValuePair<string, int>> UnderstockList { get; private set; }

        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public int NumOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }
        //Constructor
        public Dashboard()
        {
        }
        private void GetNumberItems()
        {
            NumCustomers = Database.DataProvider.Instance.Database.CUSTOMERs.Count();
            NumSuppliers = Database.DataProvider.Instance.Database.DISTRIBUTORs.Count();
            NumProducts = Database.DataProvider.Instance.Database.PRODUCTs.Count();
            NumOrders = Database.DataProvider.Instance.Database.INVOICEs.Where(item => item.INVOICE_DATE >= startDate && item.INVOICE_DATE <= endDate).Count();
        }

        private void GetProductAnalisys()
        {
            TopProductsList = new List<KeyValuePair<string, int>>();
            UnderstockList = new List<KeyValuePair<string, int>>();

            //Get Top 5 products
            var list = Database.DataProvider.Instance.Database.DETAIL_INVOICE.Where(item => item.INVOICE.INVOICE_DATE >= startDate && item.INVOICE.INVOICE_DATE <= endDate).GroupBy(product => product.PRODUCT.DETAIL_SPECS.COMMON_SPECS.NAME).Select(g => new
            {
                PRODUCT_NAME = g.Key,
                Quanlity = g.Count()
            }).OrderBy(t => t.Quanlity).Take(5);
            foreach (var item in list)
            {
                TopProductsList.Add(
                            new KeyValuePair<string, int>(item.PRODUCT_NAME.ToString(), item.Quanlity));
             
            }
            //Get Understock

        }
            private void GetOrderAnalisys()
        {
            GrossRevenueList = new List<RevenueByDate>();
            TotalProfit = 0;
            TotalRevenue = 0;

            var list = Database.DataProvider.Instance.Database.INVOICEs.Where(item => item.INVOICE_DATE >= startDate && item.INVOICE_DATE <= endDate).GroupBy(p => p.INVOICE_DATE).Select(g => new
            {
                INVOICE_DATE = g.Key,
                TotalAmount = g.Sum(gg => gg.TOTAL)
              
            });
            var listd = Database.DataProvider.Instance.Database.DETAIL_INVOICE.Where(item => item.INVOICE.INVOICE_DATE >= startDate && item.INVOICE.INVOICE_DATE <= endDate);
            foreach (var item in listd)
            {
                TotalProfit +=  (decimal)item.PRICE_PER_UNIT * (decimal)item.PRODUCT.DETAIL_SPECS.COMMON_SPECS.LINE_UP.PROFIT_RATIO;
            }
            var resultTable = new List<KeyValuePair<DateTime, decimal>>();
            foreach (var item in list)
            {
                resultTable.Add(
                           new KeyValuePair<DateTime, decimal>((DateTime)item.INVOICE_DATE, (decimal)item.TotalAmount)
                           );
                TotalRevenue += (decimal)item.TotalAmount;
                
            }
            
            //Group by Hours
            if (numberDays <= 1)
            {
                GrossRevenueList = (from orderList in resultTable
                                    group orderList by orderList.Key.ToString("hh tt")
                                   into order
                                    select new RevenueByDate
                                    {
                                        Date = order.Key,
                                        TotalAmount = order.Sum(amount => amount.Value)
                                    }).ToList();
            }
            //Group by Days
            else if (numberDays <= 30)
            {
                GrossRevenueList = (from orderList in resultTable
                                    group orderList by orderList.Key.ToString("dd MMM")
                                   into order
                                    select new RevenueByDate
                                    {
                                        Date = order.Key,
                                        TotalAmount = order.Sum(amount => amount.Value)
                                    }).ToList();
            }
            //Group by Weeks
            else if (numberDays <= 92)
            {
                GrossRevenueList = (from orderList in resultTable
                                    group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                        orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                   into order
                                    select new RevenueByDate
                                    {
                                        Date = "Week " + order.Key.ToString(),
                                        TotalAmount = order.Sum(amount => amount.Value)
                                    }).ToList();
            }
            //Group by Months
            else if (numberDays <= (365 * 2))
            {
                bool isYear = numberDays <= 365 ? true : false;
                GrossRevenueList = (from orderList in resultTable
                                    group orderList by orderList.Key.ToString("MMM yyyy")
                                   into order
                                    select new RevenueByDate
                                    {
                                        Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                        TotalAmount = order.Sum(amount => amount.Value)
                                    }).ToList();
            }
            //Group by Years
            else
            {
                GrossRevenueList = (from orderList in resultTable
                                    group orderList by orderList.Key.ToString("yyyy")
                                   into order
                                    select new RevenueByDate
                                    {
                                        Date = order.Key,
                                        TotalAmount = order.Sum(amount => amount.Value)
                                    }).ToList();
            }
        }
        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                endDate.Hour, endDate.Minute, 59);
            if (startDate == this.startDate && endDate == this.endDate)
                return false;
            this.startDate = startDate;
            this.endDate = endDate;
            this.numberDays = (endDate - startDate).Days;
            GetNumberItems();
            GetProductAnalisys();
            GetOrderAnalisys();
            return true;
        }
    }   
}
