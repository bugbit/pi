using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pi.Core;

namespace Pi.Tests;

[TestClass]
public class FastPiTest
{
    [TestMethod]
    public void TestFirst5Dec()
    {
        var pi = new SpigotAlgorithmCalcPi();
        var piExpected = "3141592";
        var piStr = pi.CalcPiNDigit(7);

        Assert.AreEqual(piExpected.Length, piStr.Length);
        Assert.AreEqual(piExpected, piStr);
    }
    
    [TestMethod]
    public async Task TestFirst1000Dec()
    {
        var pi = new SpigotAlgorithmCalcPi();
        var httpClient = new HttpClient() { };
        var piExpected = (await httpClient.GetStringAsync("http://pi2e.ch/blog/wp-content/uploads/2017/03/pi_dec_1k.txt")).Replace(".", "");
        var piStr = pi.CalcPiNDigit(1000 + 1);

        Assert.AreEqual(piExpected.Length, piStr.Length);
        Assert.AreEqual(piExpected, piStr);
    }
}