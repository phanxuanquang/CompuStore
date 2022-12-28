using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static CompuStore.Database.Services.ProductServices.ProductServices;

namespace CompuStore.Database.Services.ProductServices
{
    internal class Controller
    {
        private static Controller instance;

        public static Controller Instance => instance ?? (instance = new Controller());

        private Controller() { }

        public async Task<TEntity> GetData<TEntity>(DbSet<TEntity> tableTarget,
            Expression<Func<TEntity, bool>> whereQuery, TEntity entity) where TEntity : class
        {
            TEntity find = tableTarget.Where(whereQuery).FirstOrDefault();
            List<TEntity> get = tableTarget.ToList();

            if (find == null)
            {
                tableTarget.Add(entity);
                await DataProvider.Instance.Database.SaveChangesAsync();

                find = entity;
            }

            return find;
        }
    }
}
