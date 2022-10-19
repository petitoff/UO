using System;
using System.Threading;

namespace Z5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(PrintSquares);
            Thread thread2 = new Thread(PrintQuobes);

            thread.Start();
            thread.Join();

            thread2.Start();
            thread2.Join();

            PrintHelloFriend();

            Console.ReadKey();
        }

        static void PrintSquares()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("tutaj są kwadraty");
            Console.WriteLine("=========================================");

            var max = 100;

            for (int i = 1; i < max; i++)
            {
                Console.WriteLine((i * i).ToString());
            }
        }

        static void PrintQuobes()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("tutaj są szcześciany");
            Console.WriteLine("=========================================");

            var max = 100;

            for (int i = 1; i < max; i++)
            {
                Console.WriteLine((i * i * i).ToString());
            }
        }

        static void PrintHelloFriend()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Hello my friend");
            }
        }
    }
}
