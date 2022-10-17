using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore
{
    public partial class MainWindow : Form
    {
        StaffManage_Tab staffManage_Tab;
        Tab.Warehouse.Warehouse_UC warehouse_UC;

        public MainWindow()
        {
            InitializeComponent();
            staffManage_Tab = null;
            SetHeaderState_From(StaffManage_Button);
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
                staffManage_Tab = new StaffManage_Tab();
            }
            LoadTab(staffManage_Tab);
        }

        private void SaleManage_Button_Click(object sender, EventArgs e)
        {
            SetHeaderState_From(SaleManage_Button); 
        }

        private void ServiceManage_Button_Click(object sender, EventArgs e)
        {
            SetHeaderState_From(ServiceManage_Button);
        }

        private void StorageManage_Button_Click(object sender, EventArgs e)
        {
            SetHeaderState_From(StorageManage_Button);
            if (warehouse_UC == null)
            {
                warehouse_UC = new Tab.Warehouse.Warehouse_UC();
            }
            LoadTab(warehouse_UC);
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            StaffManage_Button_Click(null,null);
        }
    }
}
