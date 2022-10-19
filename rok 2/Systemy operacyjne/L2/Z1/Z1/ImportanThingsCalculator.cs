using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Z1
{
    class ImportanThingsCalculator
    {
        bool isDone = true;

        public void PrintCalculation()
        {
            int calc1 = 1;


            if (isDone)
            {
                Console.WriteLine("Already done");
            }

            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(500);
                calc1++;
                calc1 = i + calc1;
            }

            isDone = true;
        }
    }
}
