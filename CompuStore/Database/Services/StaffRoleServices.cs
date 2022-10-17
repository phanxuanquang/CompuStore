using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    internal class StaffRoleServices
    {
        private static StaffRoleServices _instance;
        public static StaffRoleServices Instance => _instance ?? (_instance = new StaffRoleServices());

        public STAFFROLE GetStaffRole(string role)
        {
            return DataProvider.Instance.Database.STAFFROLEs.SingleOrDefault(c => c.ROLE == role);
        }
    }
}
