int x = 1;
int y = 10;


for(var i = 0; i < 10; i++)
{
    int wynik = x / y;
    int wynik1 = (x + y / 2) / y;

    Console.WriteLine($"Dla x: {x} a dla y: {y}");
    Console.WriteLine(wynik);
    Console.WriteLine(wynik1);

    Console.WriteLine("-------");

    x++;
}
