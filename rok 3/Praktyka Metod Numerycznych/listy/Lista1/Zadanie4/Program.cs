
using System.Diagnostics;

var N = 1000000000;

// P ie rw s zy
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

var f = 1.0;
var f1 = 1.0 / 3.0;
for (var i = 0; i < N; i++)
    f *= f1;

stopwatch.Stop();
Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

// Drug i
stopwatch.Restart();
stopwatch.Start();
f = 1.0;
for (var i = 0; i < N; i++)
    f /= 3.0;

stopwatch.Stop();
Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

// T r z e c i
stopwatch.Restart();
stopwatch.Start();
f = 1.0;
for (var i = 0; i < N; i++)
    f *= (1.0 / 3.0);

stopwatch.Stop();
Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);