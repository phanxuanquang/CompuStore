using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database
{
    using Models;
    internal class StaffServices
    {
        private static StaffServices instance;
        public static StaffServices Instance => instance ?? (instance = new StaffServices());

        private StaffServices() { }


        public STAFF GetStaffById(string id)
        {
            return DataProvider.Instance.Database.STAFFs.Where(Staff => Staff.NAME_ID.ToString() == id).FirstOrDefault();
        }

        public List<STAFF> GetStaffs()
        {
            return DataProvider.Instance.Database.STAFFs.Select(Staff => Staff).ToList();
        }

        public STAFF GetFirstStaff()
        {
            return DataProvider.Instance.Database.STAFFs.FirstOrDefault();
        }

        public STAFF GetStaffByUsername(string userName)
        {
            COMMON_USER user = UserServices.Instance.GetUserByUserName(userName);
            return user.STAFF;
        }
        public bool ChangeStaffRole(STAFF staff, STAFFROLE role)
        {
            if (staff == null) return false;
            staff.STAFFROLE = role;
            return true;
        }

        public bool ChangeStaffRole(STAFF staff, string role)
        {
            if (staff == null) return false;
            if (StaffRoleServices.Instance.GetStaffRole(role) == null) return false;
            staff.STAFFROLE = StaffRoleServices.Instance.GetStaffRole(role);
            return true;
        }

        public bool RemoveStaff(STAFF staff)
        {
            if (staff == null) return false;
            staff.WORKING_STATUS = 0;
            staff.COMMON_USER.ToList().ForEach(c => c.HAS_AUTHORITY = false);
            return true;
        }
    }
}
