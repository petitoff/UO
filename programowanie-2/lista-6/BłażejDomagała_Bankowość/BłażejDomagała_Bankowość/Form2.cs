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
            PrzelewZwykly przelewZwykly = new PrzelewZwykly(textBox1.Text, Transakcja.ConvertToFloat(textBox2.Text), comboBox1.SelectedItem.ToString(), dateTimePicker1.Value, textBox3.Text);
            przelewZwykly.Write(listBox1);
            listBox1.Items.Add("");

            //MessageBox.Show(comboBox1.SelectedItem.ToString());
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            PrzelewZwykly przelewZwykly = new PrzelewZwykly();
            przelewZwykly.WriteWidget(listBox2);
            listBox1.Items.Add("");
            //listBox2.Items.Add(string.Format("Ilość pieniędzy w towim banku: {0}", Transakcja.amountMoneyInAccount));
        }
    }
}
