using Scriban;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Utilities.ExportPDF
{
    internal class ProductPDF : IExportPDF
    {
        public override string TemplatePath => "../../TemplatePDF/product/index.html";

        public class KeyValue
        {
            public string key { get; set; }
            public string value { get; set; }
        }

        public override dynamic DataModel()
        {
            IList<KeyValue> keyValue = new KeyValue[] {
                        new KeyValue() { key = "CPU", value = "Intel Core i9-12950H" },
                        new KeyValue() { key = "RAM", value = "16GB DDR5 5200MHz" }
                    };
            //Model for export
            return new
            {
                data = new
                {
                    name = "Dell Precision 7770",
                    price = "21.000.000",
                    properties = keyValue,
                }
            };
        }
    }
}
