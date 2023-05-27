using System.Numerics;

namespace Pi.Core;

public class BigIntegerMachinSerie
{
    // Pi = 16 * arctan(1/5) - 4 * arctan(1/239)
    public BigInteger CalcNumberPiNDigit(int digits)
    {
        var mag = BigInteger.Pow(10, digits);
        var _digits = digits + 1;
        //var pi = 16 * ArcTan(5, _digits) - 4 * ArcTan(239, _digits);
        var pi1 = ArcTan2(5, _digits);
        var pi2 = ArcTan2(239, _digits);
        var pi3 = (16 * pi1.Item1 * pi2.Item2 - 4 * pi2.Item1 * pi1.Item2, pi1.Item2 * pi2.Item2);
        var pi = pi3.Item1 / pi3.Item2;

        while (pi > mag)
            pi /= 10;

        return pi;
    }

    public string CalcPiNDigit(int digits) => CalcNumberPiNDigit(digits).ToString();

    //arctan(x) = x - x^3/3 + x^5/5 - x^7/7 + x^9/9 - ...
    public BigInteger ArcTan(int x, int digits)
    {
        /*
5^x=10^y
log(5^x)=log(10^y)
x*log(5)=y*log(10)
x=y/log(5)
        */
        var _iterations = (double)digits / Math.Log10(x);
        var iter = (int)Math.Ceiling((_iterations));
        //var iter = 100000;
        var _x = -x * x * x;
        var mag = BigInteger.Pow(10, digits);
        var pi = mag / new BigInteger(x);
        var reciprocal = -x * x;
        var divisor = 3;

        for (var i = iter; i-- > 0; divisor += 2, _x *= reciprocal)
        {
            var calc = mag / (_x * divisor);

            pi += calc;
        }

        return pi;
    }

    public (BigInteger, BigInteger) ArcTan2(int x, int digits)
    {
        /*
5^x=10^y
log(5^x)=log(10^y)
x*log(5)=y*log(10)
x=y/log(5)
        */
        var _iterations = (double)digits / Math.Log10(x);
        var iter = (int)Math.Ceiling((_iterations));
        //var iter = 100000;
        var _x = x * x * x;
        var pi = (new BigInteger(x), BigInteger.One);
        var reciprocal = x * x;
        var divisor = 3;
        bool restar = true;

        for (var i = iter; i-- > 0; divisor += 2, _x *= reciprocal, restar = !restar)
        {
            var calc = _x * divisor;

            pi.Item1 *= calc;
            if (restar)
                pi.Item1 -= pi.Item2;
            else
                pi.Item1 += pi.Item2;
            pi.Item2 *= calc;
        }

        //return pi;
        return (pi.Item1, pi.Item2);
    }
}