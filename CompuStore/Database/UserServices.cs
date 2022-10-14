using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database
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

    }
}
