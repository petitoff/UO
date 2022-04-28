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

        private void Form2_Load(object sender, EventArgs e)
        {
            //var transaction = new Transakcja();
            //transaction.Write(listBox1);

            var przelewStaly1 = new PrzelewStaly();
            przelewStaly1.Write(listBox1);
            listBox1.Items.Add("");
            var przelewStaly2 = new PrzelewStaly("28-04-2022", "20.15", "-8", false, "przelew stały" ,2019);
            przelewStaly2.Write(listBox1);
        }
    }
}
