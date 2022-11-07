using CompuStore.Database.Models;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public class AddDetailInvoiceImportWarehouse_Form : BaseDetailInvoiceImportWarehouse_Form
    {
        #region Set editable
        private void SetEditable()
        {
            Finish_Button.Visible = true;
            AddProductByExcel_Button.Visible = true;
            AddProduct_Button.Visible = true;
            DeleteProduct_Button.Visible = true;
        }
        #endregion

        public AddDetailInvoiceImportWarehouse_Form()
        {
            Load += Custom_Load;
            TableData_DataGridView.CellDoubleClick += TableData_DataGridView_CellDoubleClick;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        #region Event
        private void SetDefaultComboBox(ComboBox control, string value)
        {
            if (control != null)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    BindingList<string> binding = control.DataSource as BindingList<string>;
                    if (binding != null)
                    {
                        if (!binding.Contains(value))
                            binding.Add(value);
                    }
                    else
                    {
                        binding = new BindingList<string>();
                        binding.Add(value);
                        control.DataSource = binding;
                    }
                    control.SelectedIndex = binding.IndexOf(value);
                }
                else
                {
                    control.SelectedIndex = -1;
                }
            }
        }

        protected override void Custom_Load(object sender, EventArgs e)
        {
            bindingTable.Clear();
            foreach (ModelProduct product in productList)
            {
                bindingTable.Add(product);
            }
            ModelProduct model = productList?.FirstOrDefault();
            SetDefaultComboBox(LineUp_ComboBox, model?.LineUp);
            SetDefaultComboBox(NameProduct_ComboBox, model?.NameProduct);
            SetDefaultComboBox(Manufacturer_ComboBox, model?.Manufacturer);
            if (model != null)
            {
                ReleaseDate_DateTimePicker.Value = model.ReleaseDate.Value;
            }
        }

        private void TableData_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ModelProduct model = productList[e.RowIndex];
                if (model != null)
                {
                    ModelProduct[] parameter = new ModelProduct[] { model };
                    BaseDetailSpecsProduct_Form detailSpecs = new ImportDetailSpecsProduct_Form();
                    BaseDetailSpecsProduct_Form.ResultDetailSpecsProduct afterEdit = detailSpecs.ShowDialog(this, parameter.ToList());
                    Thread.Sleep(1000);
                    bool reload = true;
                    switch (afterEdit.typeReturn)
                    {
                        case BaseDetailSpecsProduct_Form.ResultDetailSpecsProduct.TypeReturn.NewProduct:
                            productList.Add(afterEdit.receivePayload);
                            break;
                        case BaseDetailSpecsProduct_Form.ResultDetailSpecsProduct.TypeReturn.ProductChanged:
                            int index = bindingTable.IndexOf(afterEdit.sendPayload);
                            productList.Remove(afterEdit.sendPayload);
                            productList.Insert(index, afterEdit.receivePayload);
                            break;
                        case BaseDetailSpecsProduct_Form.ResultDetailSpecsProduct.TypeReturn.SpecsChanged:
                            afterEdit.sendPayload.OverrideData(afterEdit.receivePayload);
                            break;
                        default:
                            reload = false;
                            break;
                    }
                    if (reload)
                    {
                        Custom_Load(null, null);
                    }
                }
            }
        }
        #endregion

        /*protected override void CheckChange()
        {
            if (initProduct == null)
            {
                resultChanged.NoChanged = null;
                resultChanged.SpecsChanged = null;
                resultChanged.RemoveOrSerialChanged = null;
                resultChanged.NewProduct = productList.ToList();
            }
            else
            {
                resultChanged.NoChanged = initProduct.Where(item => productList.FirstOrDefault(item2 => item2.CompareProduct(item)) != null).ToList();
                resultChanged.NewProduct = productList.Where(item => initProduct.FirstOrDefault(item2 => item2.Serial == item.Serial) == null).ToList();
                resultChanged.RemoveOrSerialChanged = initProduct.Where(item => productList.FirstOrDefault(item2 => item2.Serial == item.Serial) == null).ToList();
                resultChanged.SpecsChanged = new Dictionary<ModelProduct, ModelProduct>();
                foreach (ModelProduct product in initProduct)
                {
                    ModelProduct after = productList.FirstOrDefault(item => item.Serial == product.Serial);
                    if (after != null && !product.StrictCompareSpecs(after))
                    {
                        resultChanged.SpecsChanged.Add(product, after);
                    }
                }
            }
        }*/

        #region IO Handle
        public override ResultDetailInvoiceImportWarehouse ShowDialog(IWin32Window owner, List<ModelProduct> products)
        {
            SetEditable();
            return base.ShowDialog(owner, products);
        }
        #endregion
    }
}
