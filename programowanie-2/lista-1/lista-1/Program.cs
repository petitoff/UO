using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj długość boku: ");
            int dlugoscBoku = Convert.ToInt32(Console.ReadLine());
            Szescian(dlugoscBoku);

            Console.Write("Podaj a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            double wynikSumy = Suma(a, b);
            Console.WriteLine(wynikSumy);

            Console.Write("Podaj liczbe: ");
            int c = Convert.ToInt32(Console.ReadLine());
            WszystkieDzielniki(c);

            int liczbaMax = Max();
            Console.WriteLine(liczbaMax);

        }
        static void Szescian(double a)
        {
            double pole = Math.Pow(a, 2) * 6;
            double objetosc = Math.Pow(a, 3D);
            Console.WriteLine($"Pole sześcianu wynosi: {pole} a objętość {objetosc}");

        }
        static double Suma(int a, int b)
        {
            int wynik = a + b;
            if(0<wynik && wynik>=10)
            {
                return Math.Pow(a, 3) * Math.Pow(b, 3);
            }
            else if(10<wynik && wynik >=100)
            {
                return a + b;
            }
            else if(wynik > 100)
            {
                return a - b;
            }
            return 0;
        }
        static void WszystkieDzielniki(int liczba)
        {
            Console.WriteLine($"Wypisuje dzielniki liczby {liczba}");
            for (int i = 1; i <= liczba; i++)
            {
                if (liczba % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static int Max()
        {
             List<int> list = new List<int>();
            while(true)
            {
                Console.Write("Podaj liczbe: ");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 0)
                    break;
                list.Add(input);
            }
            int maxLiczba = list[0];

            foreach (var item in list)
            {
                if (maxLiczba < item)
                    maxLiczba = item;
            }


            return maxLiczba;
        }
        static void TabliczaMnozenia()
        {
            Console.Write("Podaj liczbe: ");
            int a = Convert.ToInt32(Console.ReadLine());
            for
        }
    }
}
