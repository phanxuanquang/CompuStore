using CompuStore.Database.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore
{
    public partial class Login_Form : Form
    {

        
        public Login_Form()
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

        bool isInternetAvailable()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private async void Login_Button_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();

            /*if (Username_Box.Text == String.Empty || Password_Box.Text == String.Empty)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin đăng nhập.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (isInternetAvailable())
            {
                bool isValidAccount = false;
                string accountRole = String.Empty;

                *//*GUI.LoadingWindow loadingWindow = new GUI.LoadingWindow(this, "ĐANG TẢI");
                loadingWindow.Show();*//*
                this.Enabled = false;

                await System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    isValidAccount = LoginServices.Instance.CheckAccount(Username_Box.Text, Password_Box.Text);
                    if (isValidAccount)
                    {
                        LoginServices.Instance.Login(Username_Box.Text);
                        accountRole = LoginServices.Instance.CheckUserRole(Username_Box.Text);
                        if (Remember_CheckBox.Checked)
                        {
                            LoginServices.Instance.RememberAccount(Username_Box.Text, Password_Box.Text);
                        }
                    }
                });

                *//*loadingWindow.Close();
                loadingWindow.Dispose();*//*
                this.Enabled = true;

                if (isValidAccount)
                {
                    this.Hide();
                    this.ShowIcon = this.ShowInTaskbar = false;

                    switch (accountRole)
                    {
                        case "Nhân viên":
                            personRole = studMin.role.officeStaff;
                            break;
                        case "Chủ nhiệm":
                            personRole = studMin.role.classHead;
                            break;
                        case "Trưởng bộ môn":
                            personRole = studMin.role.subjectHead;
                            break;
                        case "Hiệu trưởng":
                            personRole = studMin.role.principal;
                            break;
                        case "Phó hiệu trưởng":
                            personRole = studMin.role.vicePrincipal;
                            break;
                        default:
                            personRole = studMin.role.normalTeacher;
                            break;
                    }

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.ShowDialog();
                }
                else
                {
                    Username_Box.Text = Password_Box.Text = String.Empty;
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.\nVui lòng điền lại thông tin đăng nhập.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (Remember_CheckBox.Checked)
                {
                    File.WriteAllText("rem.loginf", "1");
                }
                else
                {
                    File.WriteAllText("rem.loginf", "0");
                }
            }
            else
            {
                MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau.", "Lỗi kết nối mạng", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            if (!isInternetAvailable() && MessageBox.Show("Không có kết nối mạng, vui lòng thử lại sau.", "Lỗi kết nối mạng", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                string isRememberLogin = String.Empty;
                try
                {
                    isRememberLogin = File.ReadAllText("rem.loginf").Trim();
                }
                catch
                {
                    isRememberLogin = "0";
                }
                if (isRememberLogin == "1")
                {
                    Remember_CheckBox.Checked = true;
                    Username_Box.Text = LoginServices.Instance.GetRememberAccount().Item1;
                    Password_Box.Text = LoginServices.Instance.GetRememberAccount().Item2;
                }
            }
        }
    }
}
