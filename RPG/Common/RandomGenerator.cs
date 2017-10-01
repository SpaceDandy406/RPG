using System;

namespace RPG.Common
{
    public static class RandomGenerator
    {
        // Теория получения псевдослучайного числа с нормальным распределением 
        // взята из методических материалов выданных Максимовым П.В.

        private readonly static Random random = new Random();

        public static int NextIntEven()
        {
            return random.Next();
        }

        public static int NextIntEven(int a, int b)
        {
            return random.Next(a, b);
        }

        public static double NextDoubleEven()
        {
            return random.NextDouble();
        }

        public static double NextDoubleNormal()
        {
            double r = 0;
            for (int i = 0; i < 12; i++)
            {
                r += random.NextDouble();
            }
            r -= 6;
            return r;
        }

        public static double NextDoubleNormal(double m, double sigma)
        {
            return m * sigma * NextDoubleNormal();
        }
    }
}
