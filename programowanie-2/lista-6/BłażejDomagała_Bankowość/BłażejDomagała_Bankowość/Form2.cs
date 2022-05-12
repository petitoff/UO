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
            PrzelewZwykly przelewZwykly = new PrzelewZwykly(textBox1.Text, Transakcja.ConvertToFloat(textBox2.Text), comboBox1.SelectedItem.ToString(), dateTimePicker1.Value, textBox3.Text, textBox4.Text, textBox5.Text, Transakcja.ConvertToInt(textBox6.Text), comboBox2.SelectedIndex);
            przelewZwykly.Write(listBox1);
            przelewZwykly.UpdateData(listBox2);
            //listBox1.Items.Add("");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            PrzelewZwykly przelewZwykly = new PrzelewZwykly();
            przelewZwykly.WriteWidget(listBox2);
            listBox1.Items.Add("");

            textBox3.Text = @"Przelew zwykły";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrzelewZwykly przelewZwykly = new PrzelewZwykly("mBank", 50, "PLN", DateTime.Now,  "Przelew zwykły", "Patryk", "Ignasiak", 1, 0);
            przelewZwykly.Write(listBox1);
            przelewZwykly.UpdateData(listBox2);
        }
    }
}
