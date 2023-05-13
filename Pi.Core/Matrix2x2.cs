using System.Numerics;

namespace Pi.Core;

/// <summary>
/// (M11 M12)
/// (M21 M22)
/// </summary>
public class Matrix2x2
{
    private BigInteger m11;
    private BigInteger m12;
    private BigInteger m21;
    private BigInteger m22;

    public BigInteger M11 => m11;
    public BigInteger M12 => m12;
    public BigInteger M21 => m21;
    public BigInteger M22 => m22;

    public Matrix2x2(BigInteger _m11, BigInteger _m12, BigInteger _m21, BigInteger _m22)
    {
        m11 = _m11;
        m12 = _m12;
        m21 = _m21;
        m22 = _m22;
    }

    public static Matrix2x2 GetIdentity() => new Matrix2x2(BigInteger.One, BigInteger.Zero, BigInteger.Zero, BigInteger.One);

    /*
        (M11 M12)      (M11 M12)        (M11*M11+M12*M21    M11*M12+M12*M22)
        (       )   *  (       )    = 
        (M21 M22)      (M21 M22)        (M21*M11+M22*M21    M21*M12+M22*M22)
    */

    public void MultTo(Matrix2x2 m) => MultTo(m.m11, m.m12, m.m21, m.m22);

    public void MultTo(BigInteger mf11, BigInteger mf12, BigInteger mf21, BigInteger mf22)
    {
        var _m11 = m11 * mf11 + m12 * mf21;
        var _m12 = m11 * mf12 + m12 * mf22;
        var _m21 = m21 * mf11 + m22 * mf21;
        var _m22 = m21 * mf12 + m22 * mf22;

        m11 = _m11;
        m12 = _m12;
        m21 = _m21;
        m22 = _m22;
    }

    public void MultFrom(BigInteger mt11, BigInteger mt12, BigInteger mt21, BigInteger mt22)
    {
        var _m11 = mt11 * m11 + mt12 * m21;
        var _m12 = mt11 * m12 + mt12 * m22;
        var _m21 = mt21 * m11 + mt22 * m21;
        var _m22 = mt21 * m12 + mt22 * m22;

        m11 = _m11;
        m12 = _m12;
        m21 = _m21;
        m22 = _m22;
    }
}