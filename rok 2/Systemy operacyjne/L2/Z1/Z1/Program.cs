using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Z1
{
    class Program
    {
        static void Main(string[] args)
        {
            ImportanThingsCalculator important1 = new ImportanThingsCalculator();
            //ImportanThingsCalculator important2 = new ImportanThingsCalculator();

            Thread t1 = new Thread(important1.PrintCalculation);
            Thread t2 = new Thread(important1.PrintCalculation);

            t1.Start();
            t2.Start();

            important1.PrintCalculation();

            Console.ReadKey();
        }
    }
}
