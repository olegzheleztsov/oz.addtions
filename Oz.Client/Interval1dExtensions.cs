using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Oz.Client
{
    public static class Interval1dExtensions
    {
        public static IEnumerable<(Interval1d, Interval1d)> GetIntersectPairs(this IEnumerable<Interval1d> intervals)
        {
            var intervalArrays = intervals.ToImmutableArray();

            for (int i = 0; i < intervalArrays.Length; i++)
            {
                for (int j = i + 1; j < intervalArrays.Length; j++)
                {
                    if (intervalArrays[i].IsIntersectsWith(intervalArrays[j]))
                    {
                        yield return (intervalArrays[i], intervalArrays[j]);
                    }
                }
            }
        }
    }
}