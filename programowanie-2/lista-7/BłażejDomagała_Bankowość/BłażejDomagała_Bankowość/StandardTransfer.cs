using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    class StandardTransfer : Transaction
    {
        private List<string> Categories = new List<string>{"Jedzenie", "Zakupy","Paliwo"};
        public override void Write(ListBox listBox)
        {
            base.Write(listBox);
            listBox.Items.Add("");
        }
    }
}
