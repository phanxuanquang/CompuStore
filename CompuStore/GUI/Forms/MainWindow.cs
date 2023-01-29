using CompuStore.GUI.Tab;
using CompuStore.Tab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.GUI
{
    public partial class MainWindow : Form
    {
        UserControl staffManage_Tab, salesManage_Tab, serviceManage_Tab, warehouseManage_Tab, statistics_Tab;
        public MainWindow(string role)
        {
            InitializeComponent();
            staffManage_Tab = null;
            salesManage_Tab = null;
            serviceManage_Tab = null;
            warehouseManage_Tab = null;
            statistics_Tab = null;
            guna2ShadowForm1.SetShadowForm(this);
            this.Icon = Properties.Resources.Icon;
            switch (role)
            {
                case "Chủ cửa hàng":
                    SetHeaderState_From(StaffManage_Button, Properties.Resources.Staff___Header);
                    if (staffManage_Tab == null)
                    {
                        staffManage_Tab = new StaffManagement_Tab();
                    }
                    LoadTab(staffManage_Tab);
                    return;
                case "Nhân viên quản lý bán hàng":
                    SetHeaderState_From(SaleManage_Button, Properties.Resources.Sale___Header);
                    if (salesManage_Tab == null)
                    {
                        salesManage_Tab = new SaleManagement_Tab();
                    }
                    LoadTab(salesManage_Tab);
                    MenuPanel.Visible = false;
                    return;
                case "Nhân viên quản lý kho":
                    SetHeaderState_From(StorageManage_Button, Properties.Resources.Storage___Header);
                    if (warehouseManage_Tab == null)
                    {
                        warehouseManage_Tab = new Warehouse_UC();
                    }
                    LoadTab(warehouseManage_Tab);
                    MenuPanel.Visible = false;
                    return;
                case "Quản lý CSKH":
                    SetHeaderState_From(ServiceManage_Button, Properties.Resources.Service___Header);
                    if (serviceManage_Tab == null)
                    {
                        serviceManage_Tab = new ServiceManagement_Tab();
                    }
                    LoadTab(serviceManage_Tab);
                    MenuPanel.Visible = false;
                    return;
            }
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

        void SetHeaderState_From(Guna.UI2.WinForms.Guna2TileButton button, Image img)
        {
            Header.Text = "COMPUSTORE - QUẢN LÝ " + button.Text;
            //HeaderIcon.BackgroundImage = button.Image;
            HeaderIcon.BackgroundImage = img;
        }

        void LoadTab(UserControl tab)
        {
            if (!ContainerPanel.Controls.Contains(tab))
            {
                ContainerPanel.Controls.Add(tab);
            }
            tab.BringToFront();
        }

        private void StaffManage_Button_Click(object sender, EventArgs e)
        {
            SetHeaderState_From(StaffManage_Button, Properties.Resources.Staff___Header);
            if(staffManage_Tab == null)
            {
                staffManage_Tab = new StaffManagement_Tab();
            }
            LoadTab(staffManage_Tab);
        }

        private void SaleManage_Button_Click(object sender, EventArgs e)
        {
            SetHeaderState_From(SaleManage_Button, Properties.Resources.Staff___Header);
            if (salesManage_Tab == null)
            {
                salesManage_Tab = new SaleManagement_Tab();
            }
            LoadTab(salesManage_Tab);
        }

        private void ServiceManage_Button_Click(object sender, EventArgs e)
        {
            SetHeaderState_From(ServiceManage_Button, Properties.Resources.Service___Header);
            if (serviceManage_Tab == null)
            {
                serviceManage_Tab = new ServiceManagement_Tab();
            }
            LoadTab(serviceManage_Tab);
        }

        private void StorageManage_Button_Click(object sender, EventArgs e)
        {
            SetHeaderState_From(StorageManage_Button, Properties.Resources.Storage___Header);
            if (warehouseManage_Tab == null)
            {
                warehouseManage_Tab = new Warehouse_UC();
            }
            LoadTab(warehouseManage_Tab);
        }

        private void Statistics_Button_Click(object sender, EventArgs e)
        {
            SetHeaderState_From(Statistics_Button, Properties.Resources.Statistics___Header);
            if (statistics_Tab == null)
            {
                statistics_Tab = new Statistics_Tab();
            }
            LoadTab(statistics_Tab);
        }

        private void Statistics_Button_MouseEnter(object sender, EventArgs e)
        {
            MenuPanel.Height = DeviceDpi > 96 ? 225 : 120;
        }

        private void Statistics_Button_MouseLeave(object sender, EventArgs e)
        {
            MenuPanel.Height = DeviceDpi > 96 ? 20 : 10;
        }

        private void Logout_Button_Click(object sender, EventArgs e)
        {
            Login_Form login_Form = new Login_Form();
            login_Form.Show();
            this.Close();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            //StaffManage_Button_Click(null,null);
        }

        private void StaffManage_Button_MouseEnter(object sender, EventArgs e)
        {
            MenuPanel.Height = DeviceDpi > 96 ? 225 : 120;
        }

        private void StaffManage_Button_MouseLeave(object sender, EventArgs e)
        {
            MenuPanel.Height = DeviceDpi > 96 ? 20 : 10;
        }
    }
}
