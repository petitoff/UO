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

        public int ConvertToNumber(string str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd! Wprowadzono niepoprawny typ danych!");
                return 0;
            }
        }

        public void Szescian(int a)
        {
            if (a < 0)
            {
                label3.Text = "Podałeś nieprawidłowe wymiary!";
                return;
            }

            int pole = a * a * 6;
            int objetosc = a * a * a;
            label3.Text = $"Pole szceścianu wynosi {pole} cm2 a objetość {objetosc} cm3";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Szescian(ConvertToNumber(textBox1.Text));
        }

        private int Suma(int a, int b)
        {
            int wynik = a + b;
            if (0 < wynik && wynik <= 10)
            {
                return a * a * a * b * b * b;
            }
            else if (10 < wynik && wynik <= 100)
            {
                return wynik;
            }
            else if (wynik > 100)
            {
                return a - b;
            }
            return 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                int result = Suma(ConvertToNumber(textBox2.Text), ConvertToNumber(textBox3.Text));
                label7.Text = $"wynik: {result}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label9.Text = $"Wyświetlanie dzielników liczby {textBox4.Text}";
            int liczba = ConvertToNumber(textBox4.Text);

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
        private int Maks()
        {
            if (ListN.Count() != 0) label13.Text = "Największą liczbą jest " + ListN.Max();
            return ListN.Max();
        }

        public void textBox5_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true; // prevent beep

                if (textBox5.Text == "0")
                {
                    textBox5.Text = "";
                    Maks();
                    ListN.RemoveRange(0, ListN.Count);
                    return;
                }
                ListN.Add(ConvertToNumber(textBox5.Text));
                textBox5.Text = "";
                label13.Text = "";
            }
        }

        private void TabliczkaMnozenia()
        {
            label16.Text = "";
            int a = ConvertToNumber(textBox6.Text);
            listBox1.Items.Clear();
            for (int i = 1; i <= a; i++)
            {
                string wyswietlanieTabeli = null;
                for (int j = 1; j <= a; j++)
                {
                    wyswietlanieTabeli += i * j + "\t";
                }

                listBox1.Items.Add(wyswietlanieTabeli ?? string.Empty);
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
