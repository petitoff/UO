﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            int temp1 = Transaction.ConvertToInt(textBox3.Text);
            if (temp1 == -1) return;

            float temp2 = Transaction.ConvertToFloat(textBox4.Text);
            if (temp2 == -1) return;

            ScheduledTransfer scheduledTransfer = new ScheduledTransfer(temp2, dateTimePicker1.Value, textBox1.Text, textBox2.Text, temp1,
                textBox5.Text, (Bitmap)pictureBox1.Image);
            //standardTransfer.CheckIsCorrect();
            Program.Transactions.Add(scheduledTransfer);
            Program.Transactions[Program.Transactions.Count - 1].CheckIsCorrect();
            Program.Transactions[Program.Transactions.Count - 1].Write(listBox1);

            if (!scheduledTransfer.isCorrectSt)
            {
                Program.Transactions.RemoveAt(Program.Transactions.Count - 1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Transaction.LoadImageDialog(pictureBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Błażej";
            textBox2.Text = "Domagała";
            textBox3.Text = "1";
            textBox4.Text = "20";
            textBox5.Text = "Przelew stały";
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
