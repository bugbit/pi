﻿using System.Diagnostics;
using Pi.Core;

Console.WriteLine("num dec: ");

var ndec = int.Parse(Console.ReadLine());
//var pi = new GosperSeriesCalcPi();
var pi = new FastPi();
var watch = Stopwatch.StartNew();

/*
for (var i = 0; i <= ndec; i++)
    pi.NextDigit();
*/

pi.CalcPiNDigit(ndec + 1);

watch.Stop();

Console.WriteLine($"Total ComputationTime: {watch.Elapsed}");
