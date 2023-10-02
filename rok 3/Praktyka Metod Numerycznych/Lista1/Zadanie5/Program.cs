using System;

class Program
{
    static void Main()
    {
        double x = 1.0;  // Wartość, dla której chcesz obliczyć e^x
        double epsilon = 0.0001;  // Tolerancja błędu
        double result = CalculateExponential(x, epsilon);
        Console.WriteLine(result);
    }

    static double CalculateExponential(double x, double epsilon)
    {
        double sum = 1.0;  // Początkowa suma (pierwszy składnik szeregu Taylora)
        double term = 1.0;  // Początkowy składnik szeregu Taylora
        int n = 1;  // Licznik składników

        // Kontynuuj dodawanie składników, aż różnica będzie mniejsza niż epsilon
        while (true)
        {
            term *= x / n;  // Oblicz kolejny składnik szeregu
            double newSum = sum + term;  // Oblicz nową sumę

            // Sprawdź, czy różnica jest mniejsza niż epsilon
            if (Math.Abs(newSum - sum) < epsilon)
                break;

            sum = newSum;  // Zaktualizuj sumę
            n++;  // Zwiększ licznik składników
        }

        return sum;
    }
}
