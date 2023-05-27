using System.Diagnostics;
using Pi.Core;

Console.Write("algoritmo: ");

var alg = Console.ReadLine();

Console.Write("num dec: ");

var ndec = int.Parse(Console.ReadLine());
//var pi = new GosperSeriesCalcPi();
// var pi = new SpigotAlgorithmCalcPi();
var pi = new MachinSerie();
var watch = Stopwatch.StartNew();

/*
for (var i = 0; i <= ndec; i++)
    pi.NextDigit();
*/

switch (alg)
{
    case "1":
        pi.CalcPiNDigit(ndec + 1);
        break;
    case "2":
        pi.CalcPiNDigitAsThread(ndec + 1);
        break;
}

watch.Stop();

Console.WriteLine($"Total ComputationTime: {watch.Elapsed}");

