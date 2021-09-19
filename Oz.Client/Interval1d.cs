using static System.Math;
namespace Oz.Client
{
    public class Interval1d
    {
        public double Left { get; }
        public double Right { get; }

        public Interval1d(double left, double right) =>
            (Left, Right) = (left, right);

        public void Deconstruct(out double left, out double right) =>
            (left, right) = (Left, Right);

        public bool IsIntersectsWith(Interval1d other) =>
            IsIntersects(this, other);

        public static bool IsIntersects(Interval1d first, Interval1d second)
        {
            return !(Max(first.Left, first.Right) < Min(second.Left, second.Right) || Max(second.Left, second.Right) < Min(first.Left, first.Right));
        }

        public override string ToString()
        {
            return $"({Left:0.00}, {Right:0.00})";
        }
    }
}