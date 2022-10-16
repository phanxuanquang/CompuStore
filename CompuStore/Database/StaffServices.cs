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
        public bool SaveStaffToDB(string phone_number, string email, bool sex, string identity_code, string addtress, int id_staffRole)
        {
            INFOR infor = new INFOR()
            {
                PHONE_NUMBER = phone_number,
                EMAIL = email,
                SEX = sex,
                IDENTITY_CODE = identity_code,
                ADDRESS = addtress
                
            };
            STAFF staff = new STAFF()
            {
                ID_STAFFROLE = DataProvider.Instance.Database.STAFFROLEs.FirstOrDefault(item => item.ID == id_staffRole).ID,
                WORKING_STATUS = 1,
                STAFFDATE = DateTime.Now
            };
            staff.ID_INFOR = infor.ID;
            DataProvider.Instance.Database.INFORs.Add(infor);
            DataProvider.Instance.Database.STAFFs.Add(staff);
            try
            {
                DataProvider.Instance.Database.SaveChanges();
            }
            catch
            {
                // thông báo thêm nhân viên không thành công
                return false;
            }
            if(!Database.UserServices.Instance.CreateNewStaffAccount(staff))
            {
                // thông báo tạo tài khoản không thành công
                return false;
            }    
            return true;
        }
        
    }
}
