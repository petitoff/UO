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

        private void button1_Click(object sender, EventArgs e)
        {
            StandardTransfer standardTransfer = new StandardTransfer(textBox2.Text, textBox1.Text);
            Program.Transactions.Add(standardTransfer);
            Program.Transactions[Program.Transactions.Count - 1].Write(listBox1);
        }
    }
}
