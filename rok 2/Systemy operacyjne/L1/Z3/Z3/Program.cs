using System;
using System.Threading;

namespace Z3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(PrintSquares);
            thread.Start();

            thread.Join();

            PrintQuobes();


            //PrintSquares();
            PintHelloFriend();

            Console.ReadKey();
        }

        static void PrintSquares()
        {
            var max = 100;

            for (int i = 1; i < max; i++)
            {
                Console.WriteLine((i * i).ToString());
            }
        }

        static void PrintQuobes()
        {
            var max = 100;

            for (int i = 1; i < max; i++)
            {
                Console.WriteLine((i * i * i).ToString());
            }
        }

        static void PintHelloFriend()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Hello my friend");
            }
        }
    }
}
