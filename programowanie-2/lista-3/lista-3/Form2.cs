using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lista_3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //listBox1.Items.Add("ad");
            //listBox1.Items.Remove("ad");
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
