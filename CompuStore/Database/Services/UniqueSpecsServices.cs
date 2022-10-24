using CompuStore.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Database.Services
{
    internal class UniqueSpecsServices
    {
        private static UniqueSpecsServices instance;

        public static UniqueSpecsServices Instance => instance ?? (instance = new UniqueSpecsServices());

        private UniqueSpecsServices() { }

        public UNIQUE_SPECS GetUniqueSpecsByx(string nameId)
        {
            return null;
        }
    }
}
