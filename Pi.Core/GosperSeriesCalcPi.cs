using System.Numerics;

namespace Pi.Core;

public class GosperSeriesCalcPi
{
    private static readonly BigInteger n27 = new BigInteger(27);
    private static readonly BigInteger n12 = new BigInteger(12);
    private static readonly BigInteger n5 = new BigInteger(5);
    private static readonly BigInteger n675 = new BigInteger(675);
    private static readonly BigInteger n216 = new BigInteger(216);
    private static readonly BigInteger n125 = new BigInteger(125);
    private static readonly BigInteger n10 = new BigInteger(10);
    private static readonly BigInteger n_10 = new BigInteger(-10);
    private static readonly BigInteger n2 = new BigInteger(2);
    private static readonly BigInteger n3 = new BigInteger(3);

    public BigInteger[,] M { get; private set; }
    public int I { get; private set; }

    public GosperSeriesCalcPi()
    {
        M = GetM0();
        I = 1;
    }

    public static BigInteger[,] GetM0()
        => new BigInteger[,]
        {
            { BigInteger.One,BigInteger.Zero},
            {BigInteger.Zero,BigInteger.One}
        };

    // 27*i - 12
    public BigInteger CalcY0() => n27 * I - n12;

    public BigInteger CalcY()
    {
        var x = CalcY0();
        var y1 = M[0, 0] * x + M[1, 0] * n5;
        var y2 = M[0, 1] * x + M[1, 1] * n5;
        var y = y1 / y2;

        return y;
    }

    // 675*i - 216
    public BigInteger CalcZ0() => n675 * I - n216;

    public BigInteger CalcZ()
    {
        var x = CalcZ0();
        var z1 = M[0, 0] * x + M[1, 0] * n125;
        var z2 = M[0, 1] * x + M[1, 1] * n125;
        var z = z1 / z2;

        return z;
    }

    public int NextDigit()
    {
        for (; ; )
        {
            var y = CalcY();
            var z = CalcZ();

            if (y == z)
            {
                M = Matrix2x2.Mult
                (
                    new BigInteger[,]
                    {
                    { n10,n_10*y },
                    {BigInteger.Zero,BigInteger.One}
                    },
                    M
                );

                return (int)y;
            }

            // j=3(3i+1)(3i+2)
            var j = n3 * (n3 * I + BigInteger.One) * (n3 * I + n2);
            M = Matrix2x2.Mult
            (
                M,
                new BigInteger[,]
                {
                {I*(n2-BigInteger.One),j*(n5*I-n2)},
                {BigInteger.Zero,j}
                }
            );
        }
    }
}
