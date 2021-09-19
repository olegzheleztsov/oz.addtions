using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Oz.Client
{
    public class SquarePointGenerator
    {
        private readonly int _numPoints;
        private readonly Random _random = new();

        public SquarePointGenerator(int numPoints)
        {
            _numPoints = numPoints;
        }

        public IEnumerable<Point2d> Generate()
        {
            for (var i = 0; i < _numPoints; i++)
            {
                var x = _random.NextDouble();
                var y = _random.NextDouble();
                yield return new Point2d(x, y);
            }
        }

        public PointPair FindNearestPoints(IEnumerable<Point2d> points)
        {
            var pointArray = points.ToImmutableArray();
            if (pointArray.Length < 2) throw new ArgumentException("Array length should be greater than 2");

            var minDistance = double.MaxValue;
            Point2d p1 = null, p2 = null;
            for (var i = 0; i < pointArray.Length; i++)
            for (var j = i + 1; j < pointArray.Length; j++)
            {
                var testDistance = pointArray[i].DistanceTo(pointArray[j]);
                if (testDistance < minDistance)
                {
                    minDistance = testDistance;
                    p1 = pointArray[i];
                    p2 = pointArray[j];
                }
            }

            return new PointPair(p1, p2);
        }
    }
}