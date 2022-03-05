using System;
using System.Collections.Generic;

namespace lista_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadanie 1");
            Console.Write("Podaj długość boku: ");
            int dlugoscBoku = Convert.ToInt32(Console.ReadLine());
            Szescian(dlugoscBoku);

            Console.WriteLine("\nZadanie 2");
            Console.Write("Podaj a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            double wynikSumy = Suma(a, b);
            Console.WriteLine(wynikSumy);

            Console.WriteLine("\nZadanie 3");
            Console.Write("Podaj liczbe: ");
            int c = Convert.ToInt32(Console.ReadLine());
            WszystkieDzielniki(c);

            Console.WriteLine("\nZadanie 4");
            int liczbaMax = Max();
            Console.WriteLine($"Największa liczba to: {liczbaMax}");

            Console.WriteLine("\nZadanie 5");
            TabliczaMnozenia();
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
            if (0 < wynik && wynik >= 10)
            {
                return Math.Pow(a, 3) * Math.Pow(b, 3);
            }
            else if (10 < wynik && wynik >= 100)
            {
                return a + b;
            }
            else if (wynik > 100)
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
            var list = new List<int>();
            while (true)
            {
                Console.Write("Podaj liczbe: ");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 0)
                {
                    if (list.Count == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        break;
                    }
                }
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
            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= a; j++)
                {
                    Console.Write(i * j + "\t");
                }
                Console.Write("\n");
            }
        }
    }
}
