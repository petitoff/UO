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
            Transakcja transakcja1 = new Transakcja();
            transakcja1.Write(listBox1);

            listBox1.Items.Add("");

            Transakcja transakcja2 = new Transakcja("eBank", "EUR", 150.60F, 970, 45124, "Andrzej", "Jackowski", "20-04-2022", 76342, "Paweł", "Waglik", "ING", "Oddaje");
            transakcja2.Write(listBox1);

            //Transakcja transakcja3 = new Transakcja();
        }
    }
}
