using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BłażejDomagała_Bankowość
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float sum = 0;
            foreach (Transaction transaction in Program.Transactions)
            {
                sum += transaction.GetAmount();
            }

            listBox1.Items.Add($"Ilość wszystkich twoich transakcji to: {sum} PLN");
        }
    }
}
