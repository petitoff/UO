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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private int indexStart; // wielkość listy Program.Transactions
        private int index; // aktualny wybrany index z listy Program.Transactions

        private void Execute()
        {
            // metoda ładuje z listy Program.Transactions odpowiednie metody za pomocą polimorfizmu
            // metoda posiada walidacje dzięki której jeżeli dany index nie istnieje to nie powoduje to błędu programu
            try
            {
                listBox1.Items.Clear();
                Program.Transactions[index].Write(listBox1);
                Program.Transactions[index].LoadImage(pictureBox1);

                button2.Enabled = true;
                button3.Enabled = true;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show(@"Nie posiadasz żadych transakcji do wyświetlenia!");
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Execute();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index - 1 < 0)
            {
                button3.Enabled = true;
                MessageBox.Show("Nie posiadasz już więcej transakcji do przeglądania!");
                button2.Enabled = false;
                return;
            }
            index--;
            Execute();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (index + 1 > indexStart)
            {
                MessageBox.Show("Nie posiadasz już więcej transakcji do przeglądania!");
                button3.Enabled = false;
                return;
            }
            index++;
            Execute();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            indexStart = Program.Transactions.Count - 1;
            index = indexStart;
        }
    }
}
