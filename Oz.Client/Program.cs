#region

using Oz.Client.IO;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace Oz.Client
{
    internal static class Program
    {
        private static Random _random = new Random();
        private static async Task Main(string[] args)
        {
            TestListDeletion();
            await Task.CompletedTask;
        }


        private static void TestListDeletion()
        {
            var list = BuildListFromArray(new int[] { 1, 2, 3, 4, 5 });
            Console.WriteLine(list.ToString());
            list.RemoveLast();
            Console.WriteLine(list.ToString());

            while (list != list.RemoveLast())
            {
                Console.WriteLine(list.ToString());
            }
            
        }

        private static ListNode<T> BuildListFromArray<T>(T[] array)
        {
            ListNode<T> first = null;
            ListNode<T> last = null;
            foreach (var element in array)
            {
                if (last == null)
                {
                    first = new ListNode<T>(element);
                    last = first;
                }
                else
                {
                    var newNode = new ListNode<T>(element);
                    last.Next = newNode;
                    last = newNode;
                }
            }

            return first;
        }

        private static void TestResizingQueue()
        {
            var queue = new ResizingArrayQueue<int>();
            int operationCount = 100000;
            bool isInserting = true;
            
            for (int i = 0; i < operationCount; i++)
            {
                int count = _random.Next() % 100;
                if (isInserting)
                {
                    for (int j = 0; j < count; j++)
                    {
                        queue.Enqueue(_random.Next() % 100);
                    }
                    Console.WriteLine(queue.GetStructureString(false));

                    isInserting = false;
                }
                else
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (queue.IsEmpty)
                        {
                            break;
                        }

                        queue.Dequeue();
                    }
                    Console.WriteLine(queue.GetStructureString(false));
                    isInserting = true;
                }
            }
        }

        public static string Mystery(string s)
        {
            var n = s.Length;
            if (n <= 1)
            {
                return s;
            }

            var a = s.Substring(0, n / 2);
            var b = s.Substring(n / 2, n - (n / 2));
            return Mystery(b) + Mystery(a);
        }

        private static void TestIsRotation()
        {
            var s1 = "ACTGACG";
            var s2 = "TGACGAC";
            Console.WriteLine(s1.IsRotation(s2));
        }

        private static void TestSortArrayByParity()
        {
            int[] nums = { 2, 3, 1, 1, 4, 0, 0, 4, 3, 3 };
            var solutions = new Solutions();
            var result = solutions.SortArrayByParityII(nums);
            Console.WriteLine(string.Join(' ', result));
        }

        private static async Task TestIntervalIntersection()
        {
            var generator = new Interval1dGenerator(0.0, 10.0, 20);
            var intervals = generator.GenerateIntervals();
            var intersectPairs = intervals.GetIntersectPairs();

            foreach (var (first, second) in intersectPairs)
            {
                Console.WriteLine($"{first}  with  {second}");
            }

            await Task.CompletedTask;
        }

        private static async Task TestDataReader()
        {
            var reader = new DataReader();
            var numbers = await reader.ReadDoublePairsAsync(PathUtils.GetFileNameOnDesktop("pairs.txt"));
            foreach (var (a, b) in numbers)
            {
                Console.WriteLine($"a: {a:0.00}\tb: {b:0.00}");
            }
        }

        private static async Task TestDataWriter(string[] args)
        {
            var numPairs = int.Parse(args[0]);
            var writer = new DataWriter();
            var random = new Random();
            var pairs = new List<(double, double)>();
            for (var i = 0; i < numPairs; i++)
            {
                var a = random.NextDouble();
                var b = random.NextDouble();
                pairs.Add((a, b));
            }

            await writer.WriteDoublePairsAsync(PathUtils.GetFileNameOnDesktop("pairs.txt"), pairs,
                CancellationToken.None);
            Console.WriteLine("Done.");
        }

        private static void TestSquarePointGenerator(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Pass number of points as argument");
                return;
            }

            if (!int.TryParse(args[0], out var number))
            {
                Console.WriteLine("Pass integer as number of arguments");
                return;
            }

            if (number < 2)
            {
                Console.WriteLine("Pass more than 2");
                return;
            }

            for (var i = 2; i <= number; i++)
            {
                var generator = new SquarePointGenerator(i);
                var points = generator.Generate();
                var pair = generator.FindNearestPoints(points);
                Console.WriteLine($"For {i} points min distance: {pair.Point1.DistanceTo(pair.Point2)}");
            }
        }
    }
}