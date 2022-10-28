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
        BaseTab staffManage_Tab, salesManage_Tab, serviceManage_Tab, warehouseManage_Tab;
        public MainWindow()
        {
            InitializeComponent();
            this.Size = new Size(1240, 800);
            staffManage_Tab = null;
            salesManage_Tab = null;
            SetHeaderState_From(SaleManage_Button);
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

        void SetHeaderState_From(Guna.UI2.WinForms.Guna2TileButton button)
        {
            Header.Text = "QUẢN LÝ " + button.Text;
            HeaderIcon.BackgroundImage = button.Image;
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
            SetHeaderState_From(StaffManage_Button);
            if(staffManage_Tab == null)
            {
                staffManage_Tab = new StaffManagement_Tab();
            }
            LoadTab(staffManage_Tab);
        }

        private void SaleManage_Button_Click(object sender, EventArgs e)
        {
            SetHeaderState_From(SaleManage_Button);
            if (salesManage_Tab == null)
            {
                salesManage_Tab = new SaleManagement_Tab();
            }
            LoadTab(salesManage_Tab);
        }

        private void ServiceManage_Button_Click(object sender, EventArgs e)
        {
            SetHeaderState_From(ServiceManage_Button);
        }

        private void StorageManage_Button_Click(object sender, EventArgs e)
        {
            SetHeaderState_From(StorageManage_Button);
            if (warehouseManage_Tab == null)
            {
                warehouseManage_Tab = new Warehouse_UC();
            }
            LoadTab(warehouseManage_Tab);
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            StaffManage_Button_Click(null,null);
        }

        private void StaffManage_Button_MouseEnter(object sender, EventArgs e)
        {
            MenuPanel.Height = 120;
        }

        private void StaffManage_Button_MouseLeave(object sender, EventArgs e)
        {
            MenuPanel.Height = 10;
        }
    }
}
