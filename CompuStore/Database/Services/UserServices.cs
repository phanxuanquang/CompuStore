using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    using Models;
    internal class UserServices
    {
        private static UserServices instance;

        public static UserServices Instance => instance ?? (instance = new UserServices());

        private UserServices() { }

        public COMMON_USER GetUserByUserName(string userName)
        {
            return DataProvider.Instance.Database.COMMON_USER.Where(item => item.USERNAME == userName).FirstOrDefault();
        }
        public bool CreateNewStaffAccount(STAFF staff)
        {
            COMMON_USER c_user = new COMMON_USER()
            {
                ID_USERROLE = 2,
                ID_STAFF = staff.ID,
                USERNAME = staff.INFOR.IDENTITY_CODE,
                PASSWORD = staff.INFOR.IDENTITY_CODE,
                DISPLAYNAME = staff.STAFFROLE == null ? "Nhân viên" : staff.STAFFROLE.ROLE,
                HAS_AUTHORITY = true,
            };
            DataProvider.Instance.Database.COMMON_USER.Add(c_user);
            try
            {
                DataProvider.Instance.Database.SaveChanges();
                return true;
            }
            catch
            { 
                return false; 
            }
        }
    }
}
