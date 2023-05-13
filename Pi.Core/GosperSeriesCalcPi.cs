using System.Diagnostics;
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

    public Matrix2x2 M { get; private set; }
    public int I { get; private set; }

    public GosperSeriesCalcPi()
    {
        M = Matrix2x2.GetIdentity();
        I = 1;
    }

    public void Init() => M = Matrix2x2.GetIdentity();

    // 27*i - 12
    public BigInteger CalcY0() => n27 * I - n12;

    /*
       x = 27*i - 12
       (M11 M12)      (x)        (M11*x+M12*5)
       (       )   *  (  )    = 
       (M21 M22)      (5)        (M21*x+M22*5)
   */
    public BigInteger CalcY()
    {
        var x = CalcY0();
        var y1 = M.M11 * x + M.M12 * n5;
        var y2 = M.M21 * x + M.M22 * n5;
        var y = y1 / y2;

        return y;
    }

    // 675*i - 216
    public BigInteger CalcZ0() => n675 * I - n216;

    /*
       x = 675*i - 216
       (M11 M12)      (x  )        (M11*x+M12*5)
       (       )   *  (   )    = 
       (M21 M22)      (125)        (M21*x+M22*5)
   */
    public BigInteger CalcZ()
    {
        var x = CalcZ0();
        var z1 = M.M11 * x + M.M12 * n125;
        var z2 = M.M21 * x + M.M22 * n125;
        var z = z1 / z2;

        return z;
    }

    public int NextDigit()
    {
        for (; ; )
        {
            var y = CalcY();
            var z = CalcZ();

            Debug.WriteLine("M:");
            Debug.WriteLine($"{M.M11} {M.M12}");
            Debug.WriteLine($"{M.M21} {M.M22}");
            Debug.WriteLine($"y: {y}");
            Debug.WriteLine($"z: {z}");

            if (y == z)
            {
                M.MultFrom
                (
                    n10, n_10 * y,
                    BigInteger.Zero, BigInteger.One
                );

                return (int)y;
            }

            // j=3(3i+1)(3i+2)
            var j = n3 * (n3 * I + BigInteger.One) * (n3 * I + n2);

            M.MultTo
            (
                I * (n2 - BigInteger.One), j * (n5 * I - n2),
                BigInteger.Zero, j
            );
            I++;
        }
    }
}
