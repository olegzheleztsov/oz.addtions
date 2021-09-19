using System;
using System.Linq;

namespace Oz.Client
{
    public class BinarySearch
    {
        public static int Rank(int key, int[] array, Counter counter)
        {
            int lo = 0;
            int hi = array.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                counter.Increment();
                if (key < array[mid])
                {
                    hi = mid - 1;
                } else if (key > array[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        public static void Run()
        {
            while (true)
            {
                Console.Write("Input array: ");
                string arrStr = Console.ReadLine();
                if (arrStr.ToUpper() == "QUIT")
                {
                    break;
                }
                int[] args = arrStr.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => int.Parse(a)).ToArray();
                Console.Write("Input key: ");
                string keyStr = Console.ReadLine();
                if (keyStr.ToUpper() == "QUIT")
                {
                    break;
                }

                int key = int.Parse(keyStr);
                var counter = new Counter("Counter");
                Rank(key, args, counter);
                Console.WriteLine($"{counter}");
            }
            
        }
    }
}