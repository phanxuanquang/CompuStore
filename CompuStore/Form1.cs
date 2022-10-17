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
    using CompuStore.ImportData;
    using System.Threading;
    using Database;
    using CompuStore.Database.Services;

    public partial class Form1 : Form
    {
        Task task = null;
        CancellationTokenSource cancellationTokenSource = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tab-seperator values | *.tsv";
            if(openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.CheckFileExists)
            {
                ModelProduct[] products = ModelProduct.GetTSV(openFileDialog.FileName);

                if (task == null || task.IsCompleted)
                {
                    cancellationTokenSource = new CancellationTokenSource();
                    CancellationToken token = cancellationTokenSource.Token;

                    task = Task.Factory.StartNew(() =>
                    {
                        for (int index = 0; index < products.Length && !token.IsCancellationRequested; index++)
                        {
                            try
                            {
                                if (label1.InvokeRequired)
                                    label1.Invoke(new Action(() => label1.Text = string.Format("Completed {0}/{1}", index, products.Length)));
                                else
                                    label1.Text = string.Format("Completed {0}/{1}", index, products.Length);

                                ProductServices.InstanceImport.Import(products[index]).Wait();
                            }
                            catch (AggregateException ex)
                            {
                                MessageBox.Show(string.Format("Product serial: {0} already exists in the system", products[index].Serial));
                            }
                        }
                    }, token);

                    task.GetAwaiter().OnCompleted(() =>
                    {
                        if (token.IsCancellationRequested)
                        {
                            if (label1.InvokeRequired)
                                label1.Invoke(new Action(() => label1.Text = "Canceled"));
                            else
                                label1.Text = "Canceled";
                        }
                        else
                        {
                            if (label1.InvokeRequired)
                                label1.Invoke(new Action(() => label1.Text = "Insert completed"));
                            else
                                label1.Text = "Insert completed";
                        }
                        cancellationTokenSource.Dispose();
                        cancellationTokenSource = null;
                    });
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database.Services.StaffServices.Instance.SaveStaffToDB("0909123123", "123@gmail.com", true, "0808123456", "ấp 1, xã Ba", 1);
        }
    }
}
