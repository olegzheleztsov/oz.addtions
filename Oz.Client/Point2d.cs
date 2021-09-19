#region

using System;
using System.Text.Json;

#endregion

namespace Oz.Client
{
    public class Point2d
    {
        public Point2d() : this(0.0, 0.0)
        {
        }

        public Point2d(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; init; }
        public double Y { get; init; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

        public double DistanceTo(Point2d other) => Distance(this, other);

        public static double Distance(Point2d p1, Point2d p2)
        {
            return Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
        }
    }
}