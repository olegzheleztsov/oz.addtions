using System;

namespace Oz.Client
{
    public static class RandomExtensions
    {
        public static double RandomDouble(this Random random, double xMin, double xMax) =>
            xMin + random.NextDouble() * (xMax - xMin);
    }
}