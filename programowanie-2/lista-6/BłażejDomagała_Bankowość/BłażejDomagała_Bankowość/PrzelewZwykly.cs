using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość 
{
    class PrzelewZwykly : Transakcja
    {
        private List<string> categoriesList = new List<string>{"jedzenie", "zakupy", "paliwo"};

        public PrzelewZwykly()
        {

        }

        public PrzelewZwykly(string endBankName, float amount, string currency, DateTime dateofTransaction, string description) : base(endBankName, amount, currency, dateofTransaction, description)
        {

        }

        public new void Write(ListBox listBox)
        {
            base.WriteData(listBox);
        }

        public void WriteWidget(ListBox listBox)
        {
            base.Write(listBox);
        }
    }
}
