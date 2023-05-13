using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pi.Core;

namespace Pi.Tests;

[TestClass]
public class GosperSeriesCalcPiTest
{
    [TestMethod]
    public void TestFirst5Dec()
    {
/*
M: app.js:36:11
1 0 app.js:37:11
0 1 app.js:38:11
y 3 app.js:56:12
z 3 app.js:57:12
3 app.js:88:10
M: app.js:36:11
10 -30 app.js:37:11
0 1 app.js:38:11
y 0 app.js:56:12
z 6 app.js:57:12
M: app.js:36:11
10 0 app.js:37:11
0 60 app.js:38:11
y 1 app.js:56:12
z 1 app.js:57:12
1 app.js:88:10
M: app.js:36:11
100 -600 app.js:37:11
0 60 app.js:38:11
y 4 app.js:56:12
z 5 app.js:57:12
M: app.js:36:11
600 33600 app.js:37:11
0 10080 app.js:38:11
y 4 app.js:56:12
z 4 app.js:57:12
4 app.js:88:10
M: app.js:36:11
6000 -67200 app.js:37:11
0 10080 app.js:38:11
y 1 app.js:56:12
z 1 app.js:57:12
1 app.js:88:10
M: app.js:36:11
60000 -772800 app.js:37:11
0 10080 app.js:38:11
y 5 app.js:56:12
z 9 app.js:57:12
M: app.js:36:11
900000 2376000 app.js:37:11
0 3326400 app.js:38:11
y 5 app.js:56:12
z 6 app.js:57:12
M: app.js:36:11
25200000 10142496000 app.js:37:11
0 1816214400 app.js:38:11
y 5 app.js:56:12
z 5 app.js:57:12
5 app.js:88:10
GET
http://127.0.0.1:5500/favicon.ico
[HTTP/1.1 404 Not Found 0ms]
        */
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