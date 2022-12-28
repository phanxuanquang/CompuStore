using CompuStore.Database.Models;
using CompuStore.Database.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    internal class DistributorServices
    {
        private static DistributorServices instance;

        public static DistributorServices Instance => instance ?? (instance = new DistributorServices());

        private DistributorServices() { }

        public DISTRIBUTOR GetDistributorByID(int ID)
        {
            return DataProvider.Instance.Database.DISTRIBUTORs.FirstOrDefault(item => item.ID == ID);
        }

        public async Task<DISTRIBUTOR> GetDistributor(DISTRIBUTOR distributor)
        {
            if (distributor == null) return null;

            return await Controller.Instance.GetData(DataProvider.Instance.Database.DISTRIBUTORs,
                item =>
                /*item.ADDRESS == distributor.ADDRESS &&*/
                item.NAME == distributor.NAME/* &&
                item.PHONE_NUMBER == distributor.PHONE_NUMBER*/,
                distributor
                );
        }
    }
}
