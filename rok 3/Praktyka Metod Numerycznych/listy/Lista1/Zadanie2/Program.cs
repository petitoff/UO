float f = 100000000;
float acc = 0f;
for (int i = 0; i < 10000; i++)
    acc += 1;

f += acc;

Console.WriteLine(f);
