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
    public partial class Waiting_Form : Form
    {
        Timer timer = null;
        public bool shown = false;

        public Waiting_Form(int interval = 50)
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = interval;
            timer.Tick += Timer_Tick;
        }

        public void ShowDialog(IWin32Window owner)
        {
            shown = true;
            base.ShowDialog(owner);
        }

        private void Waiting_Form_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Loading_ProgressBar.Value += 1;
        }

        private void Loading_ProgressBar_ValueChanged(object sender, EventArgs e)
        {
            if (Loading_ProgressBar.Value >= 100)
            {
                Loading_ProgressBar.Value = 0;
            }
        }

        private void Waiting_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
        }
    }
}
