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
        BindingList<CommonSpecsCustom> bindingTable = null;
        BindingList<DistributorCustom> bindingDistributor = null;
        BindingList<StoreCustom> bindingStore = null;
        List<CommonSpecsGroup<ModelProduct>> commonSpecsGroups = null;

        private class AddInvoiceCommonSpecsGroup : CommonSpecsGroup<ModelProduct>
        {
            List<ModelProduct> _detailSpecs;

            double CommonSpecsGroup<ModelProduct>.maxTotal
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
            double CommonSpecsGroup<ModelProduct>.minTotal
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
            ModelProduct CommonSpecsGroup<ModelProduct>.Represent
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

        private class AddInvoiceCommonSpecs : CommonSpecsCustom
        {
            private int? _ID;
            private string _NameID;
            private string _NameCommonSpecs;
            private string _LineUp;
            private string _Manufacturer;
            private DateTime? _ReleaseDate;
            private int? _Quantity;
            private string _RangeTotal;

            int CommonSpecsCustom.ID { get => _ID.Value; set => _ID = value; }
            string CommonSpecsCustom.NameID { get => _NameID; set => _NameID = value; }
            string CommonSpecsCustom.NameCommonSpecs { get => _NameCommonSpecs; set => _NameCommonSpecs = value; }
            string CommonSpecsCustom.LineUp { get => _LineUp; set => _LineUp = value; }
            string CommonSpecsCustom.Manufacturer { get => _Manufacturer; set => _Manufacturer = value; }
            DateTime? CommonSpecsCustom.ReleaseDate { get => _ReleaseDate; set => _ReleaseDate = value; }
            int CommonSpecsCustom.Quantity { get => _Quantity.Value; set => _Quantity = value; }
            string CommonSpecsCustom.RangeTotal { get => _RangeTotal; set => _RangeTotal = value; }

            public AddInvoiceCommonSpecs(CommonSpecsGroup<ModelProduct> group)
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

        public AddInvoiceImportWarehouse_Form()
        {
            AddProductByExcel_Button.Click += AddProductByExcel_Button_Click;
            Load += InvoiceImportWarehouse_Form_Load;
            TableData_DataGridView.CellDoubleClick += TableData_DataGridView_CellDoubleClick;
        }

        private Task LoadingData(IProgress<int> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                IQueryable<DISTRIBUTOR> distributorQueryable = Database.DataProvider.Instance.Database.DISTRIBUTORs;
                foreach (DISTRIBUTOR distributor in distributorQueryable)
                {
                    if (bindingDistributor != null)
                    {
                        bindingDistributor.Add(DistributorCustom.Convert(distributor));
                    }
                }

                IQueryable<STORE> storeQueryable = Database.DataProvider.Instance.Database.STOREs;
                foreach (STORE store in storeQueryable)
                {
                    if (bindingStore != null)
                    {
                        bindingStore.Add(StoreCustom.Convert(store));
                    }
                }

                progress.Report(0);
            });
        }

        private void InvoiceImportWarehouse_Form_Load(object sender, EventArgs e)
        {
            bindingTable = new BindingList<CommonSpecsCustom>();
            bindingStore = new BindingList<StoreCustom>();
            bindingDistributor = new BindingList<DistributorCustom>();
            commonSpecsGroups = new List<CommonSpecsGroup<ModelProduct>>();
            TableData_DataGridView.DataSource = bindingTable;

            Progress<int> progress = new Progress<int>();
            Waiting_Form waiting = new Waiting_Form();
            Task runLoading = LoadingData(progress);

            const int stopWaitingCoutner = 1;

            waiting.FormClosed += (owner, ev) =>
            {
                Distributor_Combobox.DataSource = bindingDistributor;
                Distributor_Combobox.ValueMember = "ID";
                Distributor_Combobox.DisplayMember = "Name";

                ImportToStore_Combobox.DataSource = bindingStore;
                ImportToStore_Combobox.ValueMember = "ID";
                ImportToStore_Combobox.DisplayMember = "Name";

                StaffImport_Value.Text = string.Format("{0} | {1}", LoginServices.Instance.CurrentStaff.INFOR.NAME, LoginServices.Instance.CurrentStaff.NAME_ID);
            };

            runLoading.GetAwaiter().OnCompleted(() => waiting.Close());

            progress.ProgressChanged += (owner, value) =>
            {
                if (value >= stopWaitingCoutner && !waiting.IsDisposed && waiting.shown)
                {
                    waiting.Close();
                }
            };

            waiting.ShowDialog(this);
        }

        private void TableData_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nameIdCommonSpecs = (sender as DataGridView).Rows[e.RowIndex].Cells["NameID"].Value as string;
            CommonSpecsGroup<ModelProduct> commonSpecs = commonSpecsGroups.FirstOrDefault(item => item.Represent.Serial == nameIdCommonSpecs);
            if (commonSpecs != null)
            {
                /*DetailInvoiceImportWarehouse_Form form = new DetailInvoiceImportWarehouse_Form(commonSpecs);
                form.ShowDialog();*/
            }
        }

        private void AddProductByExcel_Button_Click(object sender, EventArgs e)
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
                }).Select(item => new AddInvoiceCommonSpecsGroup(item.ToList())).ToList<CommonSpecsGroup<ModelProduct>>();

                foreach(CommonSpecsGroup<ModelProduct> item in commonSpecsGroups)
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
                        InvoiceImportWarehouse_Form_Load(null, null);
                    }
                }*/
            }
        }
    }
}
