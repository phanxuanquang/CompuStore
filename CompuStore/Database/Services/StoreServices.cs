using CompuStore.Database.Models;
using CompuStore.Database.Services.ProductServices;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    internal class StoreServices
    {
        private static StoreServices instance;

        public static StoreServices Instance => instance ?? (instance = new StoreServices());

        private StoreServices() { }

        public STORE GetStoreByID(int ID)
        {
            return DataProvider.Instance.Database.STOREs.FirstOrDefault(item => item.ID == ID);
        }

        public async Task<STORE> GetStore(STORE store)
        {
            if (store == null) return null;

            return await Controller.Instance.GetData(DataProvider.Instance.Database.STOREs,
                item =>
                /*item.ADDRESS == store.ADDRESS &&*/
                item.NAME == store.NAME,
                store
                );
        }
    }
}
