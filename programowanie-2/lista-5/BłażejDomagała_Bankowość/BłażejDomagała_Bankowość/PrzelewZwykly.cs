using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    internal class PrzelewZwykly : Transakcja
    {

        public PrzelewZwykly() : base()
        {

        }

        public new void Write(ListBox listBox)
        {
            base.Write(listBox);
        }
    }
}
