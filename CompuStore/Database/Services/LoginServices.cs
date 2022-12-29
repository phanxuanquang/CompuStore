using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.Database.Services
{
    using Models;
    internal class LoginServices
    {
        private COMMON_USER currentUser;

        public COMMON_USER CurrentUser => currentUser;

        private STAFF currentStaff;

        public STAFF CurrentStaff => currentStaff;

        private static LoginServices instance;
        public static LoginServices Instance => instance ?? (instance = new LoginServices());

        private static string FilePathRememberAccount = Application.StartupPath + @"/Document/accRe.studMin";

        public bool CheckAccount(string username, string password)
        {
            try
            {
                string passhash = password;
                return DataProvider.Instance.Database.COMMON_USER.SingleOrDefault(user => user.USERNAME == username && user.PASSWORD == passhash && user.HAS_AUTHORITY == true) != null;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckUser(string username)
        {
            return DataProvider.Instance.Database.COMMON_USER.SingleOrDefault(user => user.USERNAME == username) != null;
        }

        public string CheckUserRole(string userName)
        {
            if (!CheckUser(userName))
                return null;
            else
            {
                var user = DataProvider.Instance.Database.COMMON_USER.SingleOrDefault((item) => item.USERNAME == userName);
                if (user.USERROLE.ROLE == "Nhân viên")
                {
                    var staff = user.STAFF;
                    return staff.STAFFROLE.ROLE;
                }
                return user.USERROLE.ROLE;
            }
        }

        public void Login(string userName)
        {
            currentUser = UserServices.Instance.GetUserByUserName(userName);

            currentStaff = null;

            switch (currentUser.USERROLE.ROLE)
            {
                case "Nhân viên":
                    //Chủ cửa hàng là role đăng biệt
                case "Chủ cửa hàng":
                    currentStaff = StaffServices.Instance.GetStaffByUsername(userName);
                    break;
            }

        }

        public string GetFilePathRememberAccount()
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(FilePathRememberAccount)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(FilePathRememberAccount));
                }
                if (!File.Exists(FilePathRememberAccount))
                {
                    File.Create(FilePathRememberAccount);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Lỗi truy cập , mã lỗi: {e}");
            }
            return FilePathRememberAccount;
        }

        public (string, string) GetRememberAccount()
        {
            string filePath = LoginServices.Instance.GetFilePathRememberAccount();
            if (File.Exists(filePath))
            {
                string fileContent = "";
                try
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        fileContent = sr.ReadToEnd();
                        string accountRow = fileContent.Split('\n')[0];
                        if (accountRow == "")
                            return (null, null);
                        string[] account = accountRow.Split('\t');
                        return (account[0], Hash.Decrypt(account[1].ToString()));
                    }
                }
                catch
                {
                    //Application.Exit();
                    //System.Diagnostics.Process.Start(Application.ExecutablePath);
                }
            }
            return (null, null);
        }

        public void RememberAccount(string userName, string passWord)
        {
            try
            {
                if (LoginServices.Instance.CheckAccount(userName, passWord))
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(LoginServices.Instance.GetFilePathRememberAccount()))
                        {
                            sw.Write(userName + '\t' + Hash.Encrypt(passWord));
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Đã có lỗi trong việc ghi nhớ tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
