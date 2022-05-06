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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var transakcja = new Transakcja();
            transakcja.Write(listBox1);
            listBox1.Items.Add("");

            var transakcja2 = new Transakcja("eBank", "mBank", 785F, "PLN", DateTime.Now, "Przelew");
            transakcja2.Write(listBox1);
            listBox1.Items.Add("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var transakcja = new Transakcja(textBox1.Text, textBox2.Text, GetInputValidator.ConvertToFloat(textBox3.Text), comboBox1.Text, GetInputValidator.GetOnlyDDMMYYY(dateTimePicker1), textBox4.Text);
            transakcja.Write(listBox1);
            listBox1.Items.Add("");
        }
    }
}
