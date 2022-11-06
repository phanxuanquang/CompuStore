using CompuStore.Database.Models;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services.ProductServices
{
    internal class LineUpServices
    {
        private static LineUpServices instance;

        public static LineUpServices Instance => instance ?? (instance = new LineUpServices());

        private LineUpServices() { }

        public async Task<LINE_UP> GetLineUp(ModelProduct product)
        {
            if (product == null) return null;

            LINE_UP model = MappingModelProduct.Instance.CreateLineUpByModelProduct(product);

            return await Controller.Instance.GetData(DataProvider.Instance.Database.LINE_UP,
                item =>
                item.NAME == model.NAME &&
                item.MANUFACTURER == model.MANUFACTURER &&
                item.COUNTRY == model.COUNTRY,
                model
                );
        }

        public Task<int> UpdateLineUp(LINE_UP target, string lineUp, string manufacturer, string country, double? profit)
        {
            if (target == null) return null;
            target.NAME = string.IsNullOrEmpty(lineUp) ? target.NAME : lineUp;
            target.MANUFACTURER = string.IsNullOrEmpty(manufacturer) ? target.MANUFACTURER : manufacturer;
            target.COUNTRY = string.IsNullOrEmpty(country) ? target.COUNTRY : country;
            target.PROFIT_RATIO = profit ?? target.PROFIT_RATIO;
            return DataProvider.Instance.Database.SaveChangesAsync();
        }
    }
}
