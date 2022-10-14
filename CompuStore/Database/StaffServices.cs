using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database
{
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
    }
}
