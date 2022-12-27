using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuStore.Utilities.ExportPDF
{
    internal interface IDataExport
    {
        string TemplatePath { get; }
        string ExportPath { get; set; }
        dynamic DataBindingTemplate { get; set; }
    }
}
