using CompuStore.Database.Models;
using CompuStore.Database.Services;
using CompuStore.Database.Services.ProductServices;
using CompuStore.ImportData;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace CompuStore.GUI.Forms.SubForms.Warehouse
{
    public class AddInvoiceImportWarehouse_Form : BaseInvoiceImportWarehouse_Form
    {
        #region Implement interface in base class
        private class AddInvoiceCommonSpecsGroup : ICommonSpecsGroup<ModelProduct>
        {
            ModelProduct ICommonSpecsGroup<ModelProduct>.Represent
            {
                get => detailSpecs?.FirstOrDefault();
            }

            public IList<ModelProduct> detailSpecs { get; set; }

            public double? maxTotal
            {
                get
                {
                    double? max = null;
                    foreach (ModelProduct detail in detailSpecs)
                    {
                        if (detail.Price > max || max == null)
                        {
                            max = detail.Price;
                        }
                    }
                    return max == null ? 0.0 : max.Value;
                }
            }

            public double? minTotal
            {
                get
                {
                    double? min = null;
                    foreach (ModelProduct detail in detailSpecs)
                    {
                        if (detail.Price < min || min == null)
                        {
                            min = detail.Price;
                        }
                    }
                    return min == null ? 0.0 : min.Value;
                }
            }

            public AddInvoiceCommonSpecsGroup(List<ModelProduct> detailSpecs)
            {
                if (detailSpecs != null)
                {
                    this.detailSpecs = detailSpecs;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        private class AddInvoiceCommonSpecs : ICommonSpecsCustom
        {
            public int? ID { get; set; }
            public string NameID { get; set; }
            public string NameCommonSpecs { get; set; }
            public string LineUp { get; set; }
            public string Manufacturer { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public int? Quantity { get; set; }
            public string RangeTotal { get; set; }

            public AddInvoiceCommonSpecs(ICommonSpecsGroup<ModelProduct> group)
            {
                if (group != null)
                {
                    ModelProduct product = group.Represent;
                    if (product != null)
                    {
                        //set serial is represent of group in item
                        ID = null;
                        NameID = product.TypeProduct == ModelProduct.TypeModel.New ? product.Serial : product.ID.ToString();
                        LineUp = product.LineUp;
                        Manufacturer = product.Manufacturer;
                        ReleaseDate = product.ReleaseDate;
                        NameCommonSpecs = product.NameProduct;
                        RangeTotal = string.Format("{0:n3} - {1:n3} {2}", group.minTotal, group.maxTotal, "VNĐ");
                        Quantity = group.detailSpecs.Count;
                    }
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        #endregion

        #region Class
        private class ModelProductGroupBy
        {
            public string LineUp { get; set; }
            public string Manufacturer { get; set; }
            public string Country { get; set; }
            public string NameProduct { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public string CaseMaterial { get; set; }
            public string PortString { get; set; }
            public string Webcam { get; set; }
            public string SizeProductString { get; set; }
            public string Wifi { get; set; }
            public string Bluetooth { get; set; }
            //missing item.OS in groupBy
            /*public string OS { get; set; }*/

            public bool IsGroup(ModelProductGroupBy model)
            {
                if (model == null || LineUp != model.LineUp
                || Manufacturer != model.Manufacturer
                || Country != model.Country
                || NameProduct != model.NameProduct
                || ReleaseDate != model.ReleaseDate
                || CaseMaterial != model.CaseMaterial
                || PortString != model.PortString
                || Webcam != model.Webcam
                || SizeProductString != model.SizeProductString
                /*|| OS != model.OS*/
                || Wifi != model.Wifi
                || Bluetooth != model.Bluetooth)
                {
                    return false;
                }
                return true;
            }

            public static IEnumerable<(ModelProductGroupBy, AddInvoiceCommonSpecsGroup)> ConvertGroup(IList<ModelProduct> products)
            {
                return products == null ? null : products.GroupBy(item => new ModelProductGroupBy
                {
                    LineUp = item.LineUp,
                    Manufacturer = item.Manufacturer,
                    Country = item.Country,
                    NameProduct = item.NameProduct,
                    ReleaseDate = item.ReleaseDate,
                    CaseMaterial = item.CaseMaterial,
                    PortString = item.PortString,
                    Webcam = item.Webcam,
                    SizeProductString = item.SizeProductString,
                    /*OS = item.OS,*/
                    Wifi = item.Wifi,
                    Bluetooth = item.Bluetooth,
                }).Select(item => (item.Key, new AddInvoiceCommonSpecsGroup(item.ToList())));
            }
        }
        #endregion

        #region Variable
        BindingList<ICommonSpecsCustom> bindingTable = null;
        Dictionary<ModelProductGroupBy, ICommonSpecsGroup<ModelProduct>> commonSpecsGroups;
        BaseDetailInvoiceImportWarehouse_Form.ResultDetailInvoiceImportWarehouse resultChanged;
        ImportWarehouseCustom convertImportWarehouse = null;
        List<ModelProduct> initProducts;
        Timer timerUpdateImportDate = null;
        #endregion

        public AddInvoiceImportWarehouse_Form()
        {
            resultChanged = new BaseDetailInvoiceImportWarehouse_Form.ResultDetailInvoiceImportWarehouse();
            AddProductByExcel_Button.Click += AddProductByExcel_Button_Click;
            TableData_DataGridView.CellDoubleClick += TableData_DataGridView_CellDoubleClick;
            AddProduct_Button.Click += AddProduct_Button_Click;
            Load += AddInvoiceImportWarehouse_Form_Load;
            DeleteProduct_Button.Click += DeleteProduct_Button_Click;
            DateTimeImportWarehouse_DateTimePicker.ValueChanged += DateTimeImportWarehouse_DateTimePicker_ValueChanged;
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
        private void DeleteProduct_Button_Click(object sender, EventArgs e)
        {
            BindingList<ICommonSpecsCustom> bindingTable = TableData_DataGridView.DataSource as BindingList<ICommonSpecsCustom>;
            if (TableData_DataGridView.SelectedRows.Count > 0)
            {
                int currentIndex = TableData_DataGridView.SelectedRows[0].Index;
                ICommonSpecsCustom target = bindingTable[currentIndex];
                if (MessageBox.Show(
                        string.Format("Bạn chắc chắn sẽ xóa:\nSản phẩm: {0}\nRa mắt năm: {1}\nSố lượng hiện tại: {2}",
                        target.NameCommonSpecs,
                        target.ReleaseDate.Value.ToString("yyyy"),
                        target.Quantity),
                    "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    KeyValuePair<ModelProductGroupBy, ICommonSpecsGroup<ModelProduct>> find = commonSpecsGroups.FirstOrDefault(item =>
                    {
                        ModelProduct product = item.Value.Represent;
                        return product.TypeProduct == ModelProduct.TypeModel.New ? target.NameID == product.Serial : target.NameID == product.ID.ToString();
                    });
                    if (find.Key != null)
                    {
                        commonSpecsGroups.Remove(find.Key);
                        ReloadBinding();
                    }
                }
            }
        }

        private void AddProduct_Button_Click(object sender, EventArgs e)
        {
            BaseDetailInvoiceImportWarehouse_Form detailInvoiceImportWarehouse = new AddDetailInvoiceImportWarehouse_Form();
            BaseDetailInvoiceImportWarehouse_Form.ResultDetailInvoiceImportWarehouse afterEdit = detailInvoiceImportWarehouse.ShowDialog(this, null);
            if (afterEdit.Remove != null && afterEdit.Remove.Count > 0)
            {
                IEnumerable<(ModelProductGroupBy, AddInvoiceCommonSpecsGroup)> removed = ModelProductGroupBy.ConvertGroup(afterEdit.Remove);
                foreach ((ModelProductGroupBy, AddInvoiceCommonSpecsGroup) group in removed)
                {
                    KeyValuePair<ModelProductGroupBy, ICommonSpecsGroup<ModelProduct>> existsGroup = commonSpecsGroups.FirstOrDefault(item => item.Key.IsGroup(group.Item1));
                    if (existsGroup.Key != null)
                    {
                        IList<ModelProduct> productInGroup = commonSpecsGroups[existsGroup.Key].detailSpecs;
                        foreach (ModelProduct product in group.Item2.detailSpecs)
                        {
                            productInGroup.Remove(product);
                        }
                    }
                }
            }

            if (afterEdit.NewProduct != null && afterEdit.NewProduct.Count > 0)
            {
                AddProductsToCommonSpecsGroup(afterEdit.NewProduct);
            }

            if (afterEdit.SpecsChanged != null && afterEdit.SpecsChanged.Count > 0)
            {
                foreach (KeyValuePair<ModelProduct, ModelProduct> item in afterEdit.SpecsChanged)
                {
                    item.Key.OverrideData(item.Value);
                }
            }

            ReloadBinding();
        }

        private void TableData_DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nameIdCommonSpecs = (sender as DataGridView).Rows[e.RowIndex].Cells["NameID"].Value as string;
            int.TryParse(nameIdCommonSpecs, out int ModelProductID);
            KeyValuePair<ModelProductGroupBy, ICommonSpecsGroup<ModelProduct>> selected = commonSpecsGroups.FirstOrDefault(item => item.Value.Represent.TypeProduct == ModelProduct.TypeModel.New ? item.Value.Represent.Serial == nameIdCommonSpecs : item.Value.Represent.ID == ModelProductID);
            if (selected.Value != null)
            {
                BaseDetailInvoiceImportWarehouse_Form edit = new AddDetailInvoiceImportWarehouse_Form();
                BaseDetailInvoiceImportWarehouse_Form.ResultDetailInvoiceImportWarehouse afterEdit = edit.ShowDialog(this, selected.Value.detailSpecs.ToList());
                if (afterEdit.Remove != null && afterEdit.Remove.Count > 0)
                {
                    IEnumerable<(ModelProductGroupBy, AddInvoiceCommonSpecsGroup)> removed = ModelProductGroupBy.ConvertGroup(afterEdit.Remove);
                    foreach ((ModelProductGroupBy, AddInvoiceCommonSpecsGroup) group in removed)
                    {
                        KeyValuePair<ModelProductGroupBy, ICommonSpecsGroup<ModelProduct>> existsGroup = commonSpecsGroups.FirstOrDefault(item => item.Key.IsGroup(group.Item1));
                        if (existsGroup.Key != null)
                        {
                            IList<ModelProduct> productInGroup = commonSpecsGroups[existsGroup.Key].detailSpecs;
                            foreach (ModelProduct product in group.Item2.detailSpecs)
                            {
                                productInGroup.Remove(product);
                            }
                        }
                    }
                }

                if (afterEdit.NewProduct != null && afterEdit.NewProduct.Count > 0)
                {
                    AddProductsToCommonSpecsGroup(afterEdit.NewProduct);
                }

                if (afterEdit.SpecsChanged != null && afterEdit.SpecsChanged.Count > 0)
                {
                    foreach (KeyValuePair<ModelProduct, ModelProduct> item in afterEdit.SpecsChanged)
                    {
                        item.Key.OverrideData(item.Value);
                    }
                }

                ReloadBinding();
            }
        }

        private void AddProductByExcel_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tab-seperator values | *.tsv";

            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.CheckFileExists)
            {
                ModelProduct[] products = ModelProduct.GetTSV(openFileDialog.FileName);

                AddProductsToCommonSpecsGroup(products);

                ReloadBinding();
            }
        }
        #endregion

        #region Loading data
        private Task LoadingData(IProgress<int> progress)
        {
            return Task.Factory.StartNew(() =>
            {
                if (importWarehouse != null && initProducts == null)
                {
                    int counter = 0;
                    initProducts = new List<ModelProduct>();
                    convertImportWarehouse = ImportWarehouseCustom.Convert(importWarehouse);
                    ICollection<DETAIL_IMPORT_WAREHOUSE> detailImportWarehouse = importWarehouse.DETAIL_IMPORT_WAREHOUSE;
                    foreach (DETAIL_IMPORT_WAREHOUSE detailImport in detailImportWarehouse)
                    {
                        PRODUCT product = detailImport.PRODUCT;
                        DETAIL_SPECS detail = product.DETAIL_SPECS;
                        UNIQUE_SPECS uniqueSpecs = detail.UNIQUE_SPECS;
                        DISPLAY_SPECS display = uniqueSpecs.DISPLAY_SPECS;
                        COLOR color = detail.COLOR;
                        COMMON_SPECS commonSpecs = detail.COMMON_SPECS;
                        LINE_UP lineup = commonSpecs.LINE_UP;

                        initProducts.Add(ModelProduct.DatabaseToModel(product, detailImport, lineup, display, uniqueSpecs, commonSpecs, color));
                        progress.Report(++counter);
                    }

                    List<ModelProduct> cloneInit = new List<ModelProduct>();
                    foreach (ModelProduct product in initProducts)
                    {
                        cloneInit.Add(product.Clone());
                    }

                    AddProductsToCommonSpecsGroup(cloneInit);
                    ReloadBinding();
                }
            });
        }

        private void AddInvoiceImportWarehouse_Form_Load(object sender, EventArgs e)
        {
            commonSpecsGroups = new Dictionary<ModelProductGroupBy, ICommonSpecsGroup<ModelProduct>>();
            bindingTable = new BindingList<ICommonSpecsCustom>();
            TableData_DataGridView.DataSource = bindingTable;
            if (importWarehouse == null && timerUpdateImportDate == null)
            {
                timerUpdateImportDate = new System.Windows.Forms.Timer();
                timerUpdateImportDate.Interval = 1000;
                timerUpdateImportDate.Tick += (owner, ea) =>
                {
                    DateTimeImportWarehouse_DateTimePicker.ValueChanged -= DateTimeImportWarehouse_DateTimePicker_ValueChanged;
                    DateTimeImportWarehouse_DateTimePicker.Value = DateTime.Now;
                    DateTimeImportWarehouse_DateTimePicker.ValueChanged += DateTimeImportWarehouse_DateTimePicker_ValueChanged;
                };
                timerUpdateImportDate.Start();
            }
            else DisposeTimer();

            if (importWarehouse != null && initProducts == null)
            {
                Progress<int> progress = new Progress<int>();
                Waiting_Form waiting = new Waiting_Form();
                Task runLoading = LoadingData(progress);

                waiting.FormClosed += (owner, ev) =>
                {
                    if (convertImportWarehouse != null)
                    {
                        Distributor_ComboBox.SelectedValue = convertImportWarehouse.IDDistributor;
                        DateTimeImportWarehouse_DateTimePicker.Value = convertImportWarehouse.ImportDate.Value;
                        ImportToStore_ComboBox.SelectedValue = convertImportWarehouse.IDStore;
                        TotalImportWarehouse_Value.Text = string.Format("{0:n3} VND", convertImportWarehouse.Total);
                        IDImportWarehouse_Value.Text = convertImportWarehouse.NameIDImportWarehouse;
                    }
                };

                runLoading.GetAwaiter().OnCompleted(() => waiting.Close());

                int stoppingWaitingCounter = 5;

                progress.ProgressChanged += (owner, value) =>
                {
                    if (value >= stoppingWaitingCounter && !waiting.IsDisposed && waiting.shown)
                    {
                        waiting.Close();
                    }
                };

                waiting.ShowDialog(this);
            }
        }

        private void DisposeTimer()
        {
            if (timerUpdateImportDate != null)
            {
                timerUpdateImportDate.Stop();
                timerUpdateImportDate.Dispose();
                timerUpdateImportDate = null;
            }
        }

        private void DateTimeImportWarehouse_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DisposeTimer();
        }

        private void ReloadBinding()
        {
            IEnumerable<KeyValuePair<ModelProductGroupBy, ICommonSpecsGroup<ModelProduct>>> sortBinding = commonSpecsGroups.OrderBy(item => item.Value.Represent.NameProduct);
            if (TableData_DataGridView.InvokeRequired)
            {
                TableData_DataGridView.Invoke(new Action(() =>
                {
                    bindingTable.Clear();
                    foreach (KeyValuePair<ModelProductGroupBy, ICommonSpecsGroup<ModelProduct>> group in sortBinding)
                    {
                        bindingTable.Add(new AddInvoiceCommonSpecs(group.Value));
                    }
                }));
            }
            else
            {
                bindingTable.Clear();
                foreach (KeyValuePair<ModelProductGroupBy, ICommonSpecsGroup<ModelProduct>> group in sortBinding)
                {
                    bindingTable.Add(new AddInvoiceCommonSpecs(group.Value));
                }
            }
        }

        private void AddProductsToCommonSpecsGroup(IList<ModelProduct> products)
        {
            //chưa handle nếu trùng serial ở các group khác nhau. extract rồi check?
            IEnumerable<(ModelProductGroupBy, AddInvoiceCommonSpecsGroup)> import = ModelProductGroupBy.ConvertGroup(products.ToList());

            foreach ((ModelProductGroupBy, AddInvoiceCommonSpecsGroup) group in import)
            {
                KeyValuePair<ModelProductGroupBy, ICommonSpecsGroup<ModelProduct>> existsGroup = commonSpecsGroups.FirstOrDefault(item => item.Key.IsGroup(group.Item1));
                if (existsGroup.Key == null)
                {
                    commonSpecsGroups.Add(group.Item1, group.Item2);
                }
                else
                {
                    IList<ModelProduct> productInGroup = commonSpecsGroups[existsGroup.Key].detailSpecs;
                    foreach (ModelProduct product in group.Item2.detailSpecs)
                    {
                        if (productInGroup.FirstOrDefault(item => item.Serial == product.Serial) != null)
                        {
                            MessageBox.Show(string.Format("{0}, {1}", product.ID, product.Serial));
                        }
                        else
                        {
                            productInGroup.Add(product);
                        }
                    }
                }
            }
        }
        #endregion

        #region IO Handle

        public override bool ShowDialog(IWin32Window owner, IMPORT_WAREHOUSE importWarehouse, bool edit = true)
        {
            return base.ShowDialog(owner, importWarehouse, edit);
        }

        protected async override void Exit_Clicked(object sender, EventArgs e)
        {
            List<string> checkValidation = ValidationInvoiceImportWarehouse();
            if (checkValidation?.Count > 0)
            {
                if (MessageBox.Show(string.Join("\n", checkValidation) + "\n\n" + "Quay trở lại(Yes) hay hủy thay đổi(No)?", "Thiếu thông tin", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                IList<ModelProduct> extract = ExtractionGroup();
                if (ValidationProduct(extract).Count() > 0)
                {
                    //handle duplicate serial
                }
                else
                {
                    CheckChange(extract);
                    switch (MessageBox.Show("Xác nhận trước khi thay đổi:\n" +
                        (resultChanged.NewProduct == null ? "" : $"{resultChanged.NewProduct.Count} sản phẩm thêm mới.\n") +
                        (resultChanged.NoChanged == null ? "" : $"{resultChanged.NoChanged.Count} sản phẩm không thay đổi.\n") +
                        (resultChanged.SpecsChanged == null ? "" : $"{resultChanged.SpecsChanged.Count} sản phẩm thay đổi cấp hình.\n") +
                        (resultChanged.Remove == null ? "" : $"{resultChanged.Remove.Count} sản phẩm bị xóa."),
                        "Xác nhận",
                        MessageBoxButtons.YesNoCancel))
                    {
                        case DialogResult.Yes:
                            break;
                        case DialogResult.No:
                            hasChanged = false;
                            base.Exit_Clicked(sender, e);
                            return;
                        default:
                            resultChanged = null;
                            return;
                    }

                    if (resultChanged.NewProduct != null && resultChanged.NewProduct.Count > 0 && LoginServices.Instance.CurrentStaff != null)
                    {
                        int? storeIDSelected = ImportToStore_ComboBox.SelectedValue as int?;
                        int? distributorID = Distributor_ComboBox.SelectedValue as int?;
                        STORE store = storeIDSelected != null ? StoreServices.Instance.GetStoreByID(storeIDSelected.Value) : null;
                        DISTRIBUTOR distributor = distributorID != null ? DistributorServices.Instance.GetDistributorByID(distributorID.Value) : null;
                        if (store == null)
                        {
                            store = new STORE { NAME = ImportToStore_ComboBox.Text };
                            store = await StoreServices.Instance.GetStore(store);
                        }

                        if (distributor == null)
                        {
                            distributor = new DISTRIBUTOR { NAME = Distributor_ComboBox.Text };
                            distributor = await DistributorServices.Instance.GetDistributor(distributor);
                        }

                        //new invoice import warehouse
                        STAFF staff = LoginServices.Instance.CurrentStaff;

                        ModelProduct[] products = resultChanged.NewProduct.ToArray();

                        DateTime importDate = DateTimeImportWarehouse_DateTimePicker.Value;
                        if (store != null && distributor != null)
                        {
                            (IMPORT_WAREHOUSE, List<ModelProduct>) respone = await ImportWarehouseServices.Instance.Import(products, store, staff, distributor, importDate);
                            MessageBox.Show(string.Format("Chấp nhận nhập {0}/{1}", products.Length - respone.Item2.Count, products.Length));
                        }
                    }

                    if (resultChanged.Remove != null && resultChanged.Remove.Count > 0)
                    {
                        IList<ModelProduct> errorProduct = new List<ModelProduct>();
                        IList<ModelProduct> saledProduct = new List<ModelProduct>();
                        foreach (ModelProduct product in resultChanged.Remove)
                        {
                            bool? result = await ProductServices.Instance.RemoveProduct(product);
                            if (result == null)
                                saledProduct.Add(product);
                            else if (result == false)
                                errorProduct.Add(product);
                        }
                        if (saledProduct.Count == 0 && errorProduct.Count == 0)
                            await ImportWarehouseServices.Instance.Delete(this.importWarehouse);
                        if (saledProduct.Count > 0)
                            MessageBox.Show(string.Format("Có {0} sản phẩm đã bán nên không thể thay đổi thông tin:\n{1}", saledProduct.Count, string.Join("\n", saledProduct.Select(item => item.ID))));
                        if (errorProduct.Count > 0)
                            MessageBox.Show(string.Format("Đã xảy ra {0} lỗi khi xóa các sản phẩm:\n{1}", errorProduct.Count, string.Join("\n", errorProduct.Select(item => item.ID))));
                        else
                            MessageBox.Show("Đã xóa thành công!");
                    }

                    if (resultChanged.SpecsChanged != null && resultChanged.SpecsChanged.Count > 0)
                    {
                        IList<ModelProduct> errorProduct = new List<ModelProduct>();
                        IList<ModelProduct> saledProduct = new List<ModelProduct>();
                        foreach (KeyValuePair<ModelProduct, ModelProduct> product in resultChanged.SpecsChanged)
                        {
                            bool? result = await ProductServices.Instance.ChangeInfo(product);
                            if (result == null)
                                saledProduct.Add(product.Key);
                            else if (result == false)
                                errorProduct.Add(product.Key);
                        }
                        if (saledProduct.Count > 0)
                            MessageBox.Show(string.Format("Có {0} sản phẩm đã bán nên không thể thay đổi thông tin:\n{1}", saledProduct.Count, string.Join("\n", saledProduct.Select(item => item.ID))));
                        if (errorProduct.Count > 0)
                            MessageBox.Show(string.Format("Đã xảy ra lỗi khi xóa các sản phẩm:\n{0}", string.Join("\n", errorProduct.Select(item => item.ID))));
                        else
                            MessageBox.Show("Đã cập nhật thành công!");
                    }

                    base.Exit_Clicked(sender, e);
                    hasChanged = true;
                }
            }
        }
        #endregion

        #region Validation
        private IList<ModelProduct> ExtractionGroup()
        {
            List<ModelProduct> extract = new List<ModelProduct>();
            foreach (KeyValuePair<ModelProductGroupBy, ICommonSpecsGroup<ModelProduct>> group in commonSpecsGroups)
            {
                extract.AddRange(group.Value.detailSpecs);
            }
            return extract;
        }

        private IList<IList<ModelProduct>> ValidationProduct(IList<ModelProduct> productsCheckValidation)
        {
            IList<IList<ModelProduct>> result = new List<IList<ModelProduct>>();
            IEnumerable<IGrouping<string, ModelProduct>> groupBySerial = productsCheckValidation.GroupBy(item => item.Serial);
            foreach (IGrouping<string, ModelProduct> group in groupBySerial)
            {
                if (group.Count() > 1)
                {
                    result.Add(group.ToList());
                }
            }
            return result;
        }

        private void CheckChange(IList<ModelProduct> productList)
        {
            if (resultChanged != null)
            {
                resultChanged.ResetField(true);
            }
            else
                resultChanged = new BaseDetailInvoiceImportWarehouse_Form.ResultDetailInvoiceImportWarehouse();
            if (initProducts == null)
            {
                resultChanged.NoChanged = null;
                resultChanged.SpecsChanged = null;
                resultChanged.Remove = null;
                resultChanged.NewProduct = productList.ToList();
            }
            else
            {
                resultChanged.NoChanged = initProducts.Where(item => productList.FirstOrDefault(item2 => item2.CompareProduct(item)) != null).ToList();
                resultChanged.NewProduct = productList.Where(item => item.TypeProduct == ModelProduct.TypeModel.New && initProducts.FirstOrDefault(item2 => item2.Serial == item.Serial) == null).ToList();
                resultChanged.Remove = initProducts.Where(item => productList.FirstOrDefault(item2 => item2.TypeProduct == ModelProduct.TypeModel.New ? item2.Serial == item.Serial : item2.ID == item.ID) == null).ToList();
                resultChanged.SpecsChanged = new Dictionary<ModelProduct, ModelProduct>();
                foreach (ModelProduct product in initProducts)
                {
                    ModelProduct after = product.TypeProduct == ModelProduct.TypeModel.Exist ? productList.FirstOrDefault(item => item.ID == product.ID) : productList.FirstOrDefault(item => item.Serial == product.Serial);
                    if (after != null && (product.TypeProduct == ModelProduct.TypeModel.Exist ? !product.CompareProduct(after) : !product.CompareSpecs(after)))
                    {
                        resultChanged.SpecsChanged.Add(product, after);
                    }
                }
            }
        }
        #endregion
    }
}
