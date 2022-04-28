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
            var przelewZwykly1 = new PrzelewZwykly();
            przelewZwykly1.Write(listBox1);

            var przelewZwykly2 = new PrzelewZwykly(50, 10, "przelew zwykly");
            przelewZwykly2.Write(listBox1);
        }
    }
}
