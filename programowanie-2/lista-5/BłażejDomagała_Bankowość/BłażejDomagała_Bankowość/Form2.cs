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

            var przelewStaly = new PrzelewStaly();
            przelewStaly.Write(listBox1);
        }
    }
}
