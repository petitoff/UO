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

        private void button2_Click(object sender, EventArgs e)
        {
            //Form2 form2 = new Form2();
            //form2.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Transakcja transakcja = new Transakcja("Błażej", "Domagała", 100F);
            transakcja.Write(listBox1);
            listBox1.Items.Add("");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Transakcja transakcja = new Transakcja(textBox1_1.Text, textBox1_2.Text, Transakcja.ConvertToFloat(textBox1_3.Text));
            transakcja.Write(listBox1);
            listBox1.Items.Add("");
        }

        private bool isClicked = false;

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Transakcja.CheckTransaction()) return;
            isClicked = true;

            Form form2 = new Form2();
            form2.Show();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (isClicked)
            {
                Transakcja transakcja = new Transakcja();
                transakcja.Write(listBox1);
            }
        }
    }
}
