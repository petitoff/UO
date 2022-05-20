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
            if (Transaction.CheckIsField())
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Transaction.UserFirstName = textBox1.Text;
            Transaction.UserLastName = textBox2.Text;
            
            int temp1 = Transaction.ConvertToInt(textBox4.Text);
            if (temp1 == -1) return;
            Transaction.UserId = temp1;

            float temp2 = Transaction.ConvertToFloat(textBox3.Text);
            if (temp2 == -1) return;
            Transaction.AmountMoneyInAccount = temp2;

            Transaction.GetInfo(listBox1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Transaction.UserFirstName = "Błażej";
            Transaction.UserLastName = "Domagała";
            Transaction.AmountMoneyInAccount = 100F;
            Transaction.GetInfo(listBox1);
        }
    }
}
