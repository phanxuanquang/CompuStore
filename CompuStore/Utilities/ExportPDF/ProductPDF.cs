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
    internal class ProductPDF : IDataExport
    {
        public string TemplatePath => "../../TemplatePDF/product/index.html";
        public string ExportPath { get; set; }
        public dynamic DataBindingTemplate { get; set; }
    }
}
