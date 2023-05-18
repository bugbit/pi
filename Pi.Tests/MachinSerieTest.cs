using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

using Pi.Core;

namespace Pi.Tests;

[TestClass]
public class MachinSerieTest
{
    [TestMethod]
    public void TestFirst5Dec()
    {
        var pi = new MachinSerie();
        var piExpected = "3141592";
        var piStr = pi.CalcPiNDigit(7);

        Assert.AreEqual(piExpected.Length, piStr.Length);
        Assert.AreEqual(piExpected, piStr);
    }

    [TestMethod]
    public async Task TestFirst1000Dec()
    {
        var pi = new MachinSerie();
        var httpClient = new HttpClient() { };
        var piExpected = (await httpClient.GetStringAsync("http://pi2e.ch/blog/wp-content/uploads/2017/03/pi_dec_1k.txt")).Replace(".", "");
        var piStr = pi.CalcPiNDigit(1000 + 1);

        Assert.AreEqual(piExpected.Length, piStr.Length);
        Assert.AreEqual(piExpected, piStr);
    }

    [TestMethod]
    public async Task TestFirst1000DecAsThread()
    {
        var pi = new MachinSerie();
        var httpClient = new HttpClient() { };
        var piExpected = (await httpClient.GetStringAsync("http://pi2e.ch/blog/wp-content/uploads/2017/03/pi_dec_1k.txt")).Replace(".", "");
        var piStr = pi.CalcPiNDigitAsThread(1000 + 1);

        Assert.AreEqual(piExpected.Length, piStr.Length);
        Assert.AreEqual(piExpected, piStr);
    }

    [TestMethod]
    public async Task TestFirst1000000Dec()
    {
        var httpClient = new HttpClient() { };
        var pi1000k = (await httpClient.GetStringAsync("http://pi2e.ch/blog/wp-content/uploads/2017/03/pi_dec_1m.txt")).Replace(".", "");
        var piBuilderStr = new StringBuilder();
        var pi = new MachinSerie();
        var piStr = pi.CalcPiNDigit(1000000 + 1);

        Assert.AreEqual(pi1000k.Length, piStr.Length);
        Assert.AreEqual(pi1000k, piStr);
    }
}