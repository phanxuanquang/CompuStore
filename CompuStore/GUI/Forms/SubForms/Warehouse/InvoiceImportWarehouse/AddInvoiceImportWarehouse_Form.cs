using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.ImportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public class AddInvoiceImportWarehouse_Form : BaseInvoiceImportWarehouse_Form
    {
        #region Implement interface in base class
        private class AddInvoiceCommonSpecsGroup : ICommonSpecsGroup<ModelProduct>
        {
            List<ModelProduct> _detailSpecs;

            double ICommonSpecsGroup<ModelProduct>.maxTotal
            {
                get
                {
                    double? max = null;
                    foreach (ModelProduct detail in _detailSpecs)
                    {
                        if (detail.Price > max || max == null)
                        {
                            max = detail.Price;
                        }
                    }
                    return max == null ? 0.0 : max.Value;
                }
            }
            double ICommonSpecsGroup<ModelProduct>.minTotal
            {
                get
                {
                    double? min = null;
                    foreach (ModelProduct detail in _detailSpecs)
                    {
                        if (detail.Price < min || min == null)
                        {
                            min = detail.Price;
                        }
                    }
                    return min == null ? 0.0 : min.Value;
                }
            }
            ModelProduct ICommonSpecsGroup<ModelProduct>.Represent
            {
                get => _detailSpecs?.FirstOrDefault();
            }

            public IList<ModelProduct> detailSpecs
            {
                get => _detailSpecs;
                set
                {
                    if (value is List<ModelProduct>)
                    {
                        _detailSpecs = (List<ModelProduct>)value;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            public AddInvoiceCommonSpecsGroup(List<ModelProduct> detailSpecs)
            {
                if (detailSpecs != null)
                {
                    _detailSpecs = detailSpecs;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        private class AddInvoiceCommonSpecs : ICommonSpecsCustom
        {
            private int? _ID;
            private string _NameID;
            private string _NameCommonSpecs;
            private string _LineUp;
            private string _Manufacturer;
            private DateTime? _ReleaseDate;
            private int? _Quantity;
            private string _RangeTotal;

            int ICommonSpecsCustom.ID { get => _ID.Value; set => _ID = value; }
            string ICommonSpecsCustom.NameID { get => _NameID; set => _NameID = value; }
            string ICommonSpecsCustom.NameCommonSpecs { get => _NameCommonSpecs; set => _NameCommonSpecs = value; }
            string ICommonSpecsCustom.LineUp { get => _LineUp; set => _LineUp = value; }
            string ICommonSpecsCustom.Manufacturer { get => _Manufacturer; set => _Manufacturer = value; }
            DateTime? ICommonSpecsCustom.ReleaseDate { get => _ReleaseDate; set => _ReleaseDate = value; }
            int ICommonSpecsCustom.Quantity { get => _Quantity.Value; set => _Quantity = value; }
            string ICommonSpecsCustom.RangeTotal { get => _RangeTotal; set => _RangeTotal = value; }

            public AddInvoiceCommonSpecs(ICommonSpecsGroup<ModelProduct> group)
            {
                if (group != null)
                {
                    ModelProduct product = group.Represent;
                    if (product != null)
                    {
                        //set serial is represent of group in item
                        _ID = null;
                        _NameID = product.Serial;
                        _LineUp = product.LineUp;
                        _Manufacturer = product.Manufacturer;
                        _ReleaseDate = product.ReleaseDate;
                        _NameCommonSpecs = product.NameProduct;
                        _RangeTotal = string.Format("{0} - {1} {2}", group.minTotal, group.maxTotal, "VNĐ");
                        _Quantity = group.detailSpecs.Count;
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        #endregion

        BindingList<ICommonSpecsCustom> bindingTable = null;
        List<ICommonSpecsGroup<ModelProduct>> commonSpecsGroups = null;

        public AddInvoiceImportWarehouse_Form()
        {
            AddProductByExcel_Button.Click += AddProductByExcel_Button_Click;
            TableData_DataGridView.CellDoubleClick += TableData_DataGridView_CellDoubleClick;
            Load += AddInvoiceImportWarehouse_Form_Load;
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

        #region Add table binding
        private void AddInvoiceImportWarehouse_Form_Load(object sender, EventArgs e)
        {
            bindingTable = new BindingList<ICommonSpecsCustom>();
            TableData_DataGridView.DataSource = bindingTable;
        }
        #endregion

        private void TableData_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nameIdCommonSpecs = (sender as DataGridView).Rows[e.RowIndex].Cells["NameID"].Value as string;
            ICommonSpecsGroup<ModelProduct> commonSpecs = commonSpecsGroups.FirstOrDefault(item => item.Represent.Serial == nameIdCommonSpecs);
            if (commonSpecs != null)
            {
                BaseDetailInvoiceImportWarehouse_Form form = new AddDetailInvoiceImportWarehouse_Form(commonSpecs.detailSpecs.ToList());
                form.ShowDialog();
            }
        }

        private async void AddProductByExcel_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tab-seperator values | *.tsv";

            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.CheckFileExists)
            {
                ModelProduct[] products = ModelProduct.GetTSV(openFileDialog.FileName);

                //missing item.OS in groupBy

                commonSpecsGroups = products.GroupBy(item => new
                {
                    item.LineUp,
                    item.Manufacturer,
                    item.Country,
                    item.NameProduct,
                    item.ReleaseDate,
                    item.CaseMaterial,
                    item.PortString,
                    item.Webcam,
                    item.SizeProductString,
                    item.Wifi,
                    item.Bluetooth
                }).Select(item => new AddInvoiceCommonSpecsGroup(item.ToList())).ToList<ICommonSpecsGroup<ModelProduct>>();

                foreach (ICommonSpecsGroup<ModelProduct> item in commonSpecsGroups)
                {
                    bindingTable.Add(new AddInvoiceCommonSpecs(item));
                }

                /*int? storeIDSelected = ImportToStore_Combobox.SelectedValue as int?;
                int? distributorID = Distributor_Combobox.SelectedValue as int?;
                if (products != null && storeIDSelected != null && LoginServices.Instance.CurrentStaff != null && distributorID != null)
                {
                    STORE store = StoreServices.Instance.GetStoreByID(storeIDSelected.Value);
                    STAFF staff = LoginServices.Instance.CurrentStaff;
                    DISTRIBUTOR distributor = DistributorServices.Instance.GetDistributorByID(distributorID.Value);
                    if (store != null && distributor != null)
                    {
                        (IMPORT_WAREHOUSE, List<ModelProduct>) respone = await ImportServices.Instance.Import(products, store, staff, distributor);
                        MessageBox.Show(string.Format("Chấp nhận {0}/{1}", products.Length - respone.Item2.Count, products.Length));
                        AddInvoiceImportWarehouse_Form_Load(null, null);
                    }
                }*/
            }
        }
    }
}
