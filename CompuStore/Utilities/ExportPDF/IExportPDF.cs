using Scriban;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CompuStore.Utilities.ExportPDF
{
    /// <summary>
    /// source: https://laptrinhvb.net/bai-viet/chuyen-de-csharp/---Csharp----Huong-dan-in-hoa-don-Invoice-tu-Template-HTML-va-xuat-ra-file-PDF/054857c0ef7d0100.html
    /// Đang lỗi không xuất PDF được do lỗi chưa cài Chromium cho Microsoft.Playwright
    /// </summary>
    internal abstract class IExportPDF
    {
        public abstract string TemplatePath { get; }

        public abstract dynamic DataModel();

        public virtual async Task<bool> RunExport(string exportPath)
        {
            if (string.IsNullOrEmpty(exportPath))
                throw new ArgumentNullException(nameof(exportPath));
            try
            {
                string templateContent = File.ReadAllText(TemplatePath);
                Template template = Template.Parse(templateContent);
                dynamic templateData = DataModel();
                string pageContent = await template.RenderAsync(templateData);
                File.WriteAllText(exportPath, pageContent);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
