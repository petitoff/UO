using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lista_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(PrintSquares);

            thread.Start();

            Thread thread2 = new Thread(PrintQuobes);
            thread2.Start();


            thread.Join();
            thread2.Join();

            Thread.Sleep(3000);
            Thread.Sleep(200);


            //PrintQuobes();

            //PrintSquares();
            PintHelloFriend();

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

        static void PintHelloFriend()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Hello my friend");
            }
        }
    }
}
