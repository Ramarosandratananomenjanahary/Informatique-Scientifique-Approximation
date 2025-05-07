using System;
using System.Runtime.CompilerServices;


namespace TpIsEulerPair
{
    class Program
    {
        public static void Main(string[] args)
        {
            float PInitial = 0;
            float PFinal = 5;

            float[] h = { 0.05F, 0.1F, 0.2F };

            float y0 = 1;

            for (int i = 0; i < h.Length; i++)
            {
                int N = (int)((PFinal - PInitial) / h[i]);

                Approximation approxi = new Approximation(PInitial, PFinal, N, (int)y0);

                Console.WriteLine($"h = {h[i]}");
                approxi.RungeKutta4(PInitial, PFinal, N, (int)y0, (t, y) => -y + t + 1);

                Console.WriteLine();
            }
        }
    }
}
