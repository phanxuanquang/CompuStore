using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore.Control
{
    public class ComboBoxCustom : ComboBox
    {
        public delegate void InsertKeyEvent(object sender, string value);
        public event InsertKeyEvent InsertKeyPressed;

        public ComboBoxCustom()
        {
            AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteSource = AutoCompleteSource.ListItems;
            KeyUp += ComboBoxCustom_KeyUp;
        }

        private void ComboBoxCustom_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert && InsertKeyPressed != null)
            {
                InsertKeyPressed(sender, this.Text);
            }
        }
    }
}
