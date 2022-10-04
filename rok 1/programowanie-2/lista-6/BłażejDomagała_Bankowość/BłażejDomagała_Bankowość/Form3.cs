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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Transakcja transakcja = new Transakcja();
            transakcja.Write(listBox2);

            textBox3.Text = @"Przelew stały";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrzelewStaly przelewStaly= new PrzelewStaly(textBox1.Text, Transakcja.ConvertToFloat(textBox2.Text), comboBox1.SelectedItem.ToString(), dateTimePicker1.Value, textBox3.Text, textBox4.Text, textBox5.Text, Transakcja.ConvertToInt(textBox6.Text));
            przelewStaly.Write(listBox1);
        }
    }
}
