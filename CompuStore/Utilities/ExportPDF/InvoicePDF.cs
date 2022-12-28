using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Utilities.ExportPDF
{
    internal class InvoicePDF : IDataExport
    {
        public string TemplatePath => "../../TemplatePDF/invoice/index.html";

        public string ExportPath { get; set; }
        public dynamic DataBindingTemplate { get; set; }
    }
}
