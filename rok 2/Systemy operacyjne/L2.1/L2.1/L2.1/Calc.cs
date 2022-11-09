using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L2._1
{
    internal class Calc
    {
        private const int loop = 10000;
        // create list from 0 to 100 with 0
        List<int> list = Enumerable.Repeat(0, 100).ToList();

        public void Main()
        {
            var thread1 = new Thread(Add);
            var thread2 = new Thread(Subtract);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            // max number from list
            Console.WriteLine("Max number from list: " + list.Max());
            // min number from list
            Console.WriteLine("Min number from list: " + list.Min());

            try
            {
                // save list to txt
                System.IO.File.WriteAllLines(@"C:\Users\petit\Desktop\repos\UO\rok 2\Systemy operacyjne\L2.1\WriteLines.txt", list.Select(x => x.ToString()));
            }
            catch (System.UnauthorizedAccessException e)
            {
                Console.WriteLine(e);
                return;
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                {
                    Console.WriteLine(e);
                    return;
                }
            }
        }

        void Add()
        {
            Random random = new Random();
            for (int i = 0; i < loop; i++)
            {
                // random number from 0 to 100
                int randomNumber = random.Next(0, 100);
                list[randomNumber] += 1;
            }
        }

        void Subtract()
        {
            Random random = new Random();
            for (int i = 0; i < loop; i++)
            {
                // random number from 0 to 100
                int randomNumber = random.Next(0, 100);
                list[randomNumber] -= 1;
            }
        }
    }
}
