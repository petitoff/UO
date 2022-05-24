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

        public static string UserFirstName = ""; // imie użytkownika wyjściowego
        public static string UserLastName = ""; // nazwisko użytkownika wyjściowego
        public static int UserId = 0;
        public static float AmountMoneyInAccount = 0F; // ilośc pieniędzy użytkownika wyjściowego
        public static int Id = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (Transaction.CheckIsField(UserFirstName, UserLastName))
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
            UserFirstName = textBox1.Text;
            UserLastName = textBox2.Text;

            int temp1 = Transaction.ConvertToInt(textBox4.Text);
            if (temp1 == -1) return;
            UserId = temp1;

            float temp2 = Transaction.ConvertToFloat(textBox3.Text);
            if (temp2 == -1) return;
            AmountMoneyInAccount = temp2;

            Transaction.GetInfo(listBox1, UserFirstName, UserLastName, UserId, AmountMoneyInAccount);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Błażej";
            textBox2.Text = "Domagała";
            textBox3.Text = @"100";
            textBox4.Text = @"0";
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
