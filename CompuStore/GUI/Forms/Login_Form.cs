using CompuStore.Database.Services;
using CompuStore.GUI;
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

namespace CompuStore.GUI
{
    public partial class Login_Form : Form
    {
        private class ServerComboBoxBinding
        {
            public int ID { get; set; }
            public string Value { get; set; }
            public string ConnectionString;
        }

        public Login_Form()
        {
            InitializeComponent();
            BindingList<ServerComboBoxBinding> binding = new BindingList<ServerComboBoxBinding>();
            binding.Add(new ServerComboBoxBinding { ID = 1, Value = "Server chính - kitaz.database.windows.net", ConnectionString = "CompuStoreDBEntities" });
            binding.Add(new ServerComboBoxBinding { ID = 2, Value = "Server backup - Local", ConnectionString = "CompuStoreDBEntities_Backup" });
            ServerDatabase_ComboBox.ValueMember = "ID";
            ServerDatabase_ComboBox.DisplayMember = "Value";
            ServerDatabase_ComboBox.DataSource = binding;
            ServerDatabase_ComboBox.SelectedIndexChanged += ServerDatabase_ComboBox_SelectedIndexChanged;
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

        private Task<(bool, string)> LoginVerification(string userName, string password)
        {
            return Task<(bool, string)>.Factory.StartNew(() =>
            {
                bool isValidAccount = false;
                string accountRole = String.Empty;
                isValidAccount = LoginServices.Instance.CheckAccount(userName, password);
                if (isValidAccount)
                {
                    LoginServices.Instance.Login(userName);
                    accountRole = LoginServices.Instance.CheckUserRole(userName);
                }
                return (isValidAccount, accountRole);
            });
        }

        private async void Login_Button_Click(object sender, EventArgs e)
        {
            Username_Box.Text = "20998983223";
            Password_Box.Text = "20998983223";
            if (Username_Box.Text == String.Empty || Password_Box.Text == String.Empty)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin đăng nhập.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (isInternetAvailable())
            {
                Waiting_Form waiting = new Waiting_Form();
                waiting.StartPosition = FormStartPosition.CenterScreen;

                waiting.Show();
                (bool, string) loginVerification = await LoginVerification(Username_Box.Text, Password_Box.Text);
                waiting.Close();
                waiting.Dispose();

                if (RememberAccount_CheckBox.Checked)
                {
                    LoginServices.Instance.RememberAccount(Username_Box.Text, Password_Box.Text);
                }

                if (loginVerification.Item1)
                {
                    this.Hide();
                    this.ShowIcon = this.ShowInTaskbar = false;

                    switch (loginVerification.Item2)
                    {

                    }

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.ShowDialog();
                }
                else
                {
                    Username_Box.Text = Password_Box.Text = String.Empty;
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.\nVui lòng điền lại thông tin đăng nhập.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (RememberAccount_CheckBox.Checked)
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
            }
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
                    RememberAccount_CheckBox.Checked = true;
                    Username_Box.Text = LoginServices.Instance.GetRememberAccount().Item1;
                    Password_Box.Text = LoginServices.Instance.GetRememberAccount().Item2;
                }
            }
        }

        private void ServerDatabase_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox control = sender as ComboBox;
            ServerComboBoxBinding binding = control.SelectedItem as ServerComboBoxBinding;
            Waiting_Form form = new Waiting_Form();
            Task<bool> task = Database.DataProvider.Instance.ChangeDatabase(binding.ConnectionString);
            task.GetAwaiter().OnCompleted(() =>
            {
                form.Close();
                MessageBox.Show(string.Format("Chuyển Server {0}", task.Result ? "thành công" : "thất bại"));
            });
            form.ShowDialog();
        }

        private void CheckBox_Panel_Click(object sender, EventArgs e)
        {
            RememberAccount_CheckBox.Checked = !RememberAccount_CheckBox.Checked;
        }
    }
}
