using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lista_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            var textBoxInput = textBox1.Text;
            var obliczanie = new Calculator();
            int pole = obliczanie.SzescianPole(textBoxInput);
            int objetosc = obliczanie.SzescianObjetosc(textBoxInput);
            label3.Text = $"Pole szceścianu wynosi {pole} cm2 a objetość {objetosc} cm3";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                var obliczanie = new Calculator();
                int result = obliczanie.Suma(textBox2.Text, textBox3.Text);

                label7.Text = $"wynik: {result}";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label9.Text = $"Wyświetlanie dzielników liczby {textBox4.Text}";
            var obliczanie = new Calculator();
            int liczba = obliczanie.ConvertToNumber(textBox4.Text);

            label10.Text = "";
            int ifBreak = 0;
            for (int i = 1; i <= liczba; i++)
            {
                if (liczba % i == 0)
                {
                    label10.Text += $"{i}";
                    if (i != liczba) label10.Text += ", ";
                    ifBreak++;
                    if (ifBreak > 13)
                    {
                        ifBreak = 0;
                        label10.Text += "\n";
                    }
                }
            }
        }
        public List<int> ListN = new List<int>();
        public void textBox5_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true; // prevent beep

                if (textBox5.Text == "0")
                {
                    textBox5.Text = "";
                    if (ListN.Count() != 0) label13.Text = "Największą liczbą jest " + ListN.Max().ToString();
                    ListN.RemoveRange(0, ListN.Count);
                    return;
                }
                var obliczanie = new Calculator();
                ListN.Add(obliczanie.ConvertToNumber(textBox5.Text));
                textBox5.Text = "";
                label13.Text = "";
            }
        }
        private void TabliczkaMnozenia()
        {
            label16.Text = "";
            var obliczanie = new Calculator();
            int a = obliczanie.ConvertToNumber(textBox6.Text);

            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= a; j++)
                {
                    label16.Text += i * j + @"    ";
                }
                label16.Text += "\n";
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            TabliczkaMnozenia();
        }
        private void textBox6_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true; // prevent beep
                TabliczkaMnozenia();
            }
        }
    }
}
