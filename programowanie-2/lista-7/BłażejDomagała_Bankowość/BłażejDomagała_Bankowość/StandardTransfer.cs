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
        public override void Write(ListBox listBox)
        {
            base.Write(listBox);
            listBox.Items.Add("");
        }
    }
}
