using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    using Models;
    internal class CustomerServices
    {
        private static CustomerServices instance;
        public static CustomerServices Instance => instance ?? (instance = new CustomerServices());

        private CustomerServices() { }

        public CUSTOMER GetCustomerByIDCode(string idCode)
        {
            return Database.DataProvider.Instance.Database.CUSTOMERs.Where(customer => customer.INFOR.IDENTITY_CODE == idCode).FirstOrDefault();
        }

        public CUSTOMER SaveCustomerToDB(string name, string phone_number, string email, string identity_code, string addtress, int purchased = 0, bool sex = true)
        {
            INFOR infor = new INFOR()
            {
                NAME = name,
                PHONE_NUMBER = phone_number,
                EMAIL = email,
                SEX = sex,
                IDENTITY_CODE = identity_code,
                ADDRESS = addtress
            };
            CUSTOMER customer = new CUSTOMER() 
            {
                ID_INFOR = infor.ID,
                ID_RANK = null,
                PURCHASED_QUANTITY = purchased
            };
            DataProvider.Instance.Database.INFORs.Add(infor);
            DataProvider.Instance.Database.CUSTOMERs.Add(customer);
            try
            {
                DataProvider.Instance.Database.SaveChanges();
            }
            catch
            {
                // thông báo thêm hoa không thành công
                return null;
            }
            return customer;
        }
    }
}
