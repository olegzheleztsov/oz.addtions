namespace Oz.Client
{
    public class Solutions
    {
        public int ThreeSumMulti(int[] arr, int target) {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }

            const int Max = 101;
            var countSort = new int[Max];

            foreach (var i in arr)
            {
                countSort[i]++;
            }

            long Size = 1000_000_000 + 7;
            long ways = 0;

            for (int first = 0; first < Max; first++)
            {
                var search = target - first;
                if (search < 2 * first)
                {
                    break;
                }

                var no1 = countSort[first];
                if (no1 == 0)
                {
                    continue;
                }

                for (int second = first; second <= search / 2 && second < Max; second++)
                {
                    var third = search - second;
                    if (third >= Max)
                    {
                        continue;
                    }

                    var no2 = countSort[second];
                    var no3 = countSort[third];

                    if (no2 == 0 || no3 == 0)
                    {
                        continue;
                    }

                    if (first == second && second == third)
                    {
                        if (no1 > 2)
                        {
                            ways += (long)no1 * (no1 - 1) * (no1 - 2) / 3 / 2;
                        }
                    } else if (first == second)
                    {
                        if (no2 > 1)
                        {
                            ways += ((long)no2 * (no2 - 1) / 2) * no3;
                        }
                    } else if (second == third)
                    {
                        if (no2 > 1)
                        {
                            ways += (long)no1 * no2 * (no2 - 1) / 2;
                        }
                    }
                    else
                    {
                        ways += (long)no1 * no2 * no3;
                    }

                    ways %= Size;
                }
            }

            return (int)ways;
        }
        
        
        public int[] SortArrayByParityII(int[] nums)
        {
            int leftPointer = 0;
            int rightPointer = nums.Length - 1;
            bool leftNeedSwap = false;
            bool rightNeedSwap = false;
            while (leftPointer < nums.Length - 1 && 0 < rightPointer)
            {
                if (leftPointer % 2 == 0 && nums[leftPointer] % 2 == 0)
                {
                    leftPointer += 2;
                } else if(leftPointer % 2 == 0 && nums[leftPointer] % 2 != 0)
                {
                    leftNeedSwap = true;
                }

                if ((rightPointer % 2 != 0 && nums[rightPointer] % 2 != 0))
                {
                    rightPointer -= 2;
                }
                else if(rightPointer % 2 != 0 && nums[rightPointer] % 2 == 0)
                {
                    rightNeedSwap = true;
                }

                if (leftNeedSwap && rightNeedSwap)
                {
                    (nums[leftPointer], nums[rightPointer]) = (nums[rightPointer], nums[leftPointer]);
                    leftNeedSwap = false;
                    rightNeedSwap = false;
                }
            }

            return nums;
        }
    }
}