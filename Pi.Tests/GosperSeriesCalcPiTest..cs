using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pi.Core;

namespace Pi.Tests;

[TestClass]
public class GosperSeriesCalcPiTest
{
    [TestMethod]
    public void TestFirst5Dec()
    {
        var pi = new GosperSeriesCalcPi();
        var ndec = pi.NextDigit();

        Assert.AreEqual(3, ndec);

        ndec = pi.NextDigit();

        Assert.AreEqual(1, ndec);

        ndec = pi.NextDigit();

        Assert.AreEqual(4, ndec);

        ndec = pi.NextDigit();

        Assert.AreEqual(1, ndec);

        ndec = pi.NextDigit();

        Assert.AreEqual(5, ndec);

        ndec = pi.NextDigit();

        Assert.AreEqual(9, ndec);

        ndec = pi.NextDigit();

        Assert.AreEqual(2, ndec);
    }
}