namespace System.Numerics;

public static class Matrix2x2
{
    public static T[,] Mult<T>(T[,] m1, T[,] m2) where T : INumber<T>
    {
        var r = new T[,]
        {
            { m1[0,0]*m2[0,0]+m1[1,0]*m2[0,1], m1[0,0]*m2[1,0]+m1[1,0]*m2[1,1]},
            { m1[0,1]*m2[0,0]+m1[1,1]*m2[0,1], m1[0,1]*m2[1,0]+m1[1,1]*m2[1,1]}
        };

        return r;
    }
}