using System;

namespace Oz.Client
{
    public readonly struct PointPair
    {
        public Point2d Point1 { get; }
        public Point2d Point2 { get; }

        public PointPair(Point2d p1, Point2d p2)
        {
            (Point1, Point2) = (p1, p2);
        }

        public override string ToString()
        {
            return $"Point1: {Point1}{Environment.NewLine}Point2: {Point2}";
        }
    }
}