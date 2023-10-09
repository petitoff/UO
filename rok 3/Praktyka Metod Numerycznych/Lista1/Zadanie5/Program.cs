using System;

class Program
{
    static void Main(string[] args)
    {
        double x = 1.0;
        double epsilon = 0.0001;
        Console.WriteLine(ComputeExponential(x, epsilon));
    }

    static double ComputeExponential(double x, double epsilon)
    {
        double sum = 1.0;  // Początkowa suma szeregu Taylora (0! = 1)
        double term = 1.0; // Pierwszy wyraz szeregu (x^0/0! = 1)
        int n = 1;         // Licznik wyrazów szeregu

        while (true)
        {
            term *= x / n; // Obliczanie kolejnego wyrazu szeregu
            sum += term;   // Dodawanie wyrazu do sumy

            // Sprawdzanie warunku zbieżności
            if (Math.Abs(term / sum) < epsilon)
            {
                break;
            }

            n++;
        }

        return sum;
    }
}