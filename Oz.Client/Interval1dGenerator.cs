using System;
using System.Collections.Generic;

namespace Oz.Client
{
    public class Interval1dGenerator
    {
        private readonly double _xMin;
        private readonly double _xMax;
        private readonly int _intervalCount;
        private readonly Random _random = new();

        public Interval1dGenerator(double xMin, double xMax, int intervalCount)
        {
            _xMin = xMin;
            _xMax = xMax;
            _intervalCount = intervalCount;
        }

        public IEnumerable<Interval1d> GenerateIntervals()
        {
            for (int i = 0; i < _intervalCount; i++)
            {
                var xMin = _random.RandomDouble(_xMin, _xMax);
                var xMax = _random.RandomDouble(_xMin, _xMax);

                if (xMin > xMax)
                {
                    (xMin, xMax) = (xMax, xMin);
                }

                yield return new Interval1d(xMin, xMax);
            }
        }
    }
}