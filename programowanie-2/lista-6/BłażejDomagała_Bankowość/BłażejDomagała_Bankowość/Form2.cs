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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private DateTime dateOfTransaction;

        private void button1_Click(object sender, EventArgs e)
        {
            PrzelewStaly przelewStaly = new PrzelewStaly();
            przelewStaly.Write(listBox1);
            listBox1.Items.Add("");
            PrzelewStaly przelewStaly2 = new PrzelewStaly("eBank", "mBank", 785F, "PLN", 1000F, dateOfTransaction, "przelew");
            przelewStaly2.Write(listBox1);
            listBox1.Items.Add("");
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            dateOfTransaction = dateTimePicker1.Value;
        }
    }
}
