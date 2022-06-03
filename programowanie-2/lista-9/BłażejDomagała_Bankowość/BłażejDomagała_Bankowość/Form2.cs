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

        private void button1_Click(object sender, EventArgs e)
        {
            int temp1 = Transaction.ConvertToInt(textBox3.Text);
            if (temp1 == -1) return;

            float temp2 = Transaction.ConvertToFloat(textBox4.Text);
            if (temp2 == -1) return;

            StandardTransfer standardTransfer = new StandardTransfer(textBox2.Text, textBox1.Text, temp1, temp2, comboBox1.SelectedItem.ToString(), textBox6.Text, comboBox2.SelectedItem.ToString(), (Bitmap)pictureBox1.Image, Form1.AmountMoneyInAccount);
            //standardTransfer.CheckIsCorrect();
            Program.Transactions.Add(standardTransfer);
            Program.Transactions[Program.Transactions.Count - 1].CheckIsCorrect();
            Program.Transactions[Program.Transactions.Count - 1].Write(listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Błażej";
            textBox1.Text = "Domagała";
            textBox3.Text = "1";
            textBox4.Text = "20";
            comboBox1.Text = "PLN";
            textBox6.Text = "Przelew zwykły";
            comboBox2.Text = "Jedzenie";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Transaction.LoadImageDialog(pictureBox1);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
