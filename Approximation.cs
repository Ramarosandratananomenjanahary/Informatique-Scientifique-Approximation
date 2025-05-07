using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpIsEulerPair
{
    public class Approximation
    {
        public float a;
        public float b;
        public int N;
        public float Alpha;
        public float yPrim;
        public float h;
        public float t;
        public float w;

        public  Approximation (float a, float b, int n, float alpha)
        {
            this.a = a;
            this.b = b;
            this.N = n;
            this.Alpha = alpha;
        }

        public void Euler(float a, float b, int n, float alpha, Func<float, float, float> yPrim)
        {
            //Step1:
            float h = (b - a) / n;
            float t = a;
            float w = Alpha;

            Console.WriteLine($" t = {t} et w = {w}");

            //Step2:
            for (int i = 1; i <= N; i++)
            {
                //Step3:
                w = w + h * yPrim(t, w);
                t = a + i * h;

                //Step4:
                Console.WriteLine($" t = {t} et w = {w}");
            }

        }

        public void PointMilieu(float a, float b, int n, float alpha, Func<float, float, float> yPrim)
        {
            //Step1: 
            float h = (b - a) / n;
            float t = a;
            float w = Alpha;

            Console.WriteLine($" t = {t} et w = {w}");

            //Step2:
            for(int i = 1;i <= N; i++)
            {
                //Step3:
                w = w + h * yPrim(t + (h/2), w + (h/2) * (yPrim(t, w)));
                t = a + i * h;

                //Step4:
                Console.WriteLine($" t[{i}] = {t} et w[{i}] = {w}");
            }
        }

        public void RungeKutta4(float a, float b, int n, float alpha, Func<float, float, float> yPrim)
        {
            //Step1: 
            float h = (b - a) / n;
            float t = a;
            float w = Alpha;
           
            Console.WriteLine($" t = {t} et w = {w}");

            //Step2:
            for (int i = 1; i <= N; i++)
            {
                //Step3:
                float k1 = h * yPrim(t, w);
                float k2 = ( h * yPrim(t + (h/2), w + (1/2) * k1));
                float k3 = (h * yPrim(t + (h/2), w + (1/2) * k2));
                float k4 = h * yPrim(t + (h/2), w + k3);

                //Step4:
                w = w + (k1 + 2*k2 + 2 * k3 + k4)/6;
                t = a + i * h;

                //Step5:
                Console.WriteLine($" t[{i}] = {t} et w[{i}] = {w}");
            }
        }

    }
}
