float a = 0.1f;
float b = 0.2f;
float c = 0.3f;

bool additionAssociativitySinglePrecision = (a + (b + c)) == ((a + b) + c);
bool multiplicationAssociativitySinglePrecision = (a * (b * c)) == ((a * b) * c);

Console.WriteLine((a + (b + c)));
Console.WriteLine(((a + b) + c));

Console.WriteLine((a * (b * c)));
Console.WriteLine(((a * b) * c));

double x = 0.1;
double y = 0.2;
double z = 0.3;

bool additionAssociativityDoublePrecision = (x + (y + z)) == ((x + y) + z);
bool multiplicationAssociativityDoublePrecision = (x * (y * z)) == ((x * y) * z);

Console.WriteLine((x + (y + z)));
Console.WriteLine(((x + y) + z));

Console.WriteLine((x * (y * z)));
Console.WriteLine(((x * y) * z));

Console.WriteLine("Associativity check for single precision:");
Console.WriteLine("Addition: " + additionAssociativitySinglePrecision);
Console.WriteLine("Multiplication: " + multiplicationAssociativitySinglePrecision);

Console.WriteLine("\nAssociativity check for double precision:");
Console.WriteLine("Addition: " + additionAssociativityDoublePrecision);
Console.WriteLine("Multiplication: " + multiplicationAssociativityDoublePrecision);