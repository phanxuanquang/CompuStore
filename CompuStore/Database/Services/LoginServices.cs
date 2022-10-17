using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    internal class LoginServices
    {
        private COMMON_USER currentUser;

        public COMMON_USER CurrentUser => currentUser;

        private STAFF currentStaff;

        public STAFF CurrentStaff => currentStaff;

        private static LoginServices instance;
        public static LoginServices Instance => instance ?? (instance = new LoginServices());

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
                    currentStaff = StaffServices.Instance.GetStaffByUsername(userName);
                    break;
            }

        }
    }
}
