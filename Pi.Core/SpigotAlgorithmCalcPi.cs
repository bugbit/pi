using System.Text;

namespace Pi.Core;

public class SpigotAlgorithmCalcPi
{
    public string CalcPiNDigit(int digits)
    {
        //digits++;

        uint[] x = new uint[digits * 10 / 3 + 2];
        uint[] r = new uint[digits * 10 / 3 + 2];

        uint[] pi = new uint[digits];

        for (int j = 0; j < x.Length; j++)
            x[j] = 20;

        for (int i = 0; i < digits; i++)
        {
            uint carry = 0;
            for (int j = 0; j < x.Length; j++)
            {
                uint num = (uint)(x.Length - j - 1);
                uint dem = num * 2 + 1;

                x[j] += carry;

                uint q = x[j] / dem;
                r[j] = x[j] % dem;

                carry = q * num;
            }


            pi[i] = (x[x.Length - 1] / 10);


            r[x.Length - 1] = x[x.Length - 1] % 10;

            for (int j = 0; j < x.Length; j++)
                x[j] = r[j] * 10;
        }

        var result = new StringBuilder();

        uint c = 0;

        for (int i = pi.Length - 1; i >= 0; i--)
        {
            pi[i] += c;
            c = pi[i] / 10;

            //result = (pi[i] % 10).ToString() + result;
            result.Insert(0, pi[i] % 10);
        }

        return result.ToString();
    }
}
