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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            float temp1 = Transaction.ConvertToFloat(numericUpDown1.Text);
            float temp2 = Transaction.ConvertToFloat(numericUpDown2.Text);
            if (temp1 == -1 || temp2 == -1)
            {
                return;
            }

            StandardTransfer standardTransfer1;
            StandardTransfer standardTransfer2 = new StandardTransfer(temp1);
            StandardTransfer standardTransfer3 = new StandardTransfer(temp2);

            standardTransfer1 = standardTransfer2 * standardTransfer3;

            listBox1.Items.Add($"Zarobisz: {standardTransfer1.a} PLN");
            listBox1.Items.Add("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int temp1 = Transaction.ConvertToInt(numericUpDown3.Text);
            int temp2 = Transaction.ConvertToInt(numericUpDown4.Text);

            if (temp1 == -1 || temp2 == -2) return;

            StandardTransfer standardTransfer1 = new StandardTransfer(temp1);
            StandardTransfer standardTransfer2 = new StandardTransfer(temp2);
            StandardTransfer standardTransfer;

            standardTransfer = standardTransfer1 == standardTransfer2;

            listBox1.Items.Add($"{(standardTransfer.b ? "Możesz dokonać przelewu!" : "Nie możesz dokonać przelewu!")}");
            listBox1.Items.Add("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float temp1 = Transaction.ConvertToFloat(numericUpDown5.Text);
            float temp2 = Transaction.ConvertToFloat(numericUpDown6.Text);

            if (temp1 == -1 || temp2 == -2) return;

            StandardTransfer standardTransfer1 = new StandardTransfer(temp1);
            StandardTransfer standardTransfer2 = new StandardTransfer(temp2);
            StandardTransfer standardTransfer;

            standardTransfer = standardTransfer1 != standardTransfer2;

            listBox1.Items.Add($"{(standardTransfer.b ? "Ceny są takie same!" : "Ceny nie są takie same!")}");
            listBox1.Items.Add("");
        }
    }
}
