using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lista_2
{
    public class Calculator : Form1
    {
        public int ConvertToNumber(string str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd! Wprowadzono niepoprawny typ danych!");
                return 0;
            }
        }
        public int SzescianPole(string a)
        {
            int b = ConvertToNumber(a);
            return b * b * 6;
        }
        public int SzescianObjetosc(string a)
        {
            int b = ConvertToNumber(a);
            return (b * b * b);
        }
        public int Suma(string a, string b)
        {
            int c = ConvertToNumber(a);
            int d = ConvertToNumber(b);

            int wynik = c + d;
            if (0 < wynik && wynik <= 10)
            {
                return c * c * c * d * d * d;
            }
            else if (10 < wynik && wynik <= 100)
            {
                return wynik;
            }
            else if (wynik > 100)
            {
                return c - d;
            }
            return 0;
        }
    }
}
