using System;
using System.Threading;

namespace Z2
{
    internal class Program
    {
        // Zmienne współdzielone przez wątki
        static int adresat = 0;
        static string wiadomosc = "";

        static void Main(string[] args)
        {
            // Tworzenie i uruchamianie 6 wątków
            for (int i = 0; i < 6; i++)
            {
                int numerID = i;
                Thread thread = new Thread(() => WatekFunkcja(numerID));
                thread.Start();
            }
        }

        static void WatekFunkcja(int numerID)
        {
            Random rand = new Random();

            // Działanie wątku w pętli
            while (true)
            {
                // 1. Wątek czyta zmienną adresat i porównuje ze swoim numerID.
                if (adresat == numerID)
                {
                    // 2. Jeśli adresat = numerID, to wątek czyta wiadomość (np. wypisuje ją w przydzielonym mu okienku)
                    Console.WriteLine("Wątek {0}: otrzymano wiadomość: {1}", numerID, wiadomosc);

                    // a następnie zapisuje własną wiadomość i ustawia losowo wybrany numer adresata.
                    wiadomosc = "Wiadomość od wątku " + numerID;
                    adresat = rand.Next(0, 6);
                }

                // 3. Wątek zasypia na k milisekund, gdzie k jest losowo wybrana liczbą z przedziału [10, 30].
                int milisekundy = rand.Next(10, 31);
                Thread.Sleep(milisekundy);
            }
        }
    }
}