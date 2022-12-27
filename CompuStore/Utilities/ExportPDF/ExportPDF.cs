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
    internal class ExportPDF
    {
        public virtual async Task<bool> RunExport(IDataExport data)
        {
            if (data == null || !File.Exists(data.TemplatePath) || data.DataBindingTemplate == null)
                throw new ArgumentNullException();
            try
            {
                string templateContent = File.ReadAllText(data.TemplatePath);
                Template template = Template.Parse(templateContent);
                dynamic templateData = data.DataBindingTemplate;
                string pageContent = await template.RenderAsync(templateData);
                File.WriteAllText(data.ExportPath, pageContent);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
