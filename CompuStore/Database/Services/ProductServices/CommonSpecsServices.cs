using CompuStore.Database.Models;
using CompuStore.Database.Services.ProductServices;
using CompuStore.ImportData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    internal class CommonSpecsServices
    {
        private static CommonSpecsServices instance;

        public static CommonSpecsServices Instance => instance ?? (instance = new CommonSpecsServices());

        private CommonSpecsServices() { }

        public COMMON_SPECS GetCommonSpecsByNameID(string nameId)
        {
            return DataProvider.Instance.Database.COMMON_SPECS.FirstOrDefault(item => item.NAME_ID.CompareTo(nameId) == 0);
        }

        public async Task<COMMON_SPECS> GetCommonSpecs(ModelProduct product, LINE_UP lineup)
        {
            if (product == null || lineup == null) return null;

            COMMON_SPECS model = MappingModelProduct.Instance.CreateCommonSpecsByModelProduct(product);
            model.ID_LINE_UP = lineup.ID;

            return await Controller.Instance.GetData(DataProvider.Instance.Database.COMMON_SPECS,
                item =>
                item.ID_LINE_UP == model.ID_LINE_UP &&
                item.NAME == model.NAME && 
                item.RELEASED_YEAR == model.RELEASED_YEAR &&
                item.CASE_MATERIAL == model.CASE_MATERIAL &&
                item.PORT == model.PORT && 
                item.WEBCAM == model.WEBCAM &&
                item.DIMENSIONS == model.DIMENSIONS && 
                item.OS == model.OS &&
                item.WIFI == model.WIFI &&
                item.BLUETOOTH == model.BLUETOOTH,
                model
                );
        }

        public COMMON_SPECS GetCommonSpecsBySerial(string serialID)
        {
            return DataProvider.Instance.Database.PRODUCTs.FirstOrDefault(item => item.SERIAL_ID == serialID)?.DETAIL_SPECS.COMMON_SPECS;
        }

        public Task<int> UpdateCommonSpecs(COMMON_SPECS target)
        {
            if (target == null) return null;
            return DataProvider.Instance.Database.SaveChangesAsync();
        }
    }
}
