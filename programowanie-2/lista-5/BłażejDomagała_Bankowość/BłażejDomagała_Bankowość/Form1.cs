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
        private DateTime dateOfTransaction;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Transakcja transakcja1 = new Transakcja();
            transakcja1.Write(listBox1);

            listBox1.Items.Add("");

            Transakcja transakcja2 = new Transakcja("eBank", "EUR", true, 45124, "Andrzej", "Jackowski", dateOfTransaction,76342, "Paweł", "Waglik", "ING", "Oddaje");
            transakcja2.Write(listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form3 = new Form3();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Transakcja transakcja = new Transakcja();
            transakcja.LoadImage(pictureBox1);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateOfTransaction = dateTimePicker1.Value;
        }
    }
}
