using System;
using System.Collections.Generic;
using System.Text;

namespace lista_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // Dodanie obsługi polskich znaków diakrytycznych

            Console.WriteLine("Zadanie 1");
            Console.Write("Podaj długość boku: ");
            int dlugoscBoku = GetInputFromUser();
            Szescian(dlugoscBoku);

            Console.WriteLine("\nZadanie 2");
            Console.Write("Podaj a: ");
            int a = GetInputFromUser();

            Console.Write("Podaj b: ");
            int b = GetInputFromUser();
            double wynikSumy = Suma(a, b);
            Console.WriteLine(wynikSumy);

            Console.WriteLine("\nZadanie 3");
            Console.Write("Podaj liczbe: ");
            int c = GetInputFromUser();
            WszystkieDzielniki(c);

            Console.WriteLine("\nZadanie 4");
            int liczbaMax = Max();
            Console.WriteLine($"Największa liczba to: {liczbaMax}");

            Console.WriteLine("\nZadanie 5");
            TabliczaMnozenia();
        }

        static int GetInputFromUser()
        {
            // walidacja wejścia
            // funkcja zwraca typ int
            try
            {
                int userInput = Convert.ToInt32(Console.ReadLine());
                return userInput;
            }
            catch (Exception e)
            {
                Console.WriteLine("Błąd!");
                Console.WriteLine("Został wprowadzony niepoprawny typ danych!");
                return 0;
            }
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
            if (0 < wynik && wynik <= 10)
                return Math.Pow(a, 3) * Math.Pow(b, 3);
            else if (10 < wynik && wynik <= 100)
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
                int input = GetInputFromUser();
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
            int a = GetInputFromUser();
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
