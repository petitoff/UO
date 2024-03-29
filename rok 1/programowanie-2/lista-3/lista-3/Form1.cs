﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace lista_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
        }

        private void BlednyLoginNapis()
        {
            label4.Text = "Błędny login!";
            label4.ForeColor = Color.Red;
        }

        private void PoprawnyLoginNapis()
        {
            label4.Text = "Poprawny login!";
            label4.ForeColor = Color.Green;
            button2.Visible = true;
            button3.Visible = true;
        }

        private void SprawdzanieCzyLoginPoprawny()
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
            {
                BlednyLoginNapis();
                return;
            }
            string login = "blazej";
            string haslo = "domagala";

            if(textBox1.Text == login && textBox2.Text == haslo)
            {
                PoprawnyLoginNapis();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SprawdzanieCzyLoginPoprawny();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }
    }
}
