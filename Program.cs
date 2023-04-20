using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_41_FirstMissingPositive
{
    class Program
    {
        // https://leetcode.com/problems/first-missing-positive/
        static void Main(string[] args)
        {
            Console.WriteLine("Task 41. First Missing Positive");
            Console.WriteLine($"[...] = {FirstMissingPositive(new int[] { 12, 34, 41, 9, 14, 9, 26, 13, 13, 4, 19, 5, 19, 18, -1, 6, 5, 32, -9, 8, 35, -6, 41, -2, 11, 41, -6, 13, 17, -8, 41, 34, -2, 40, 2, 24, 21, 36, 1, 22, 1, 3 })}");
            Console.WriteLine($"[...] = {FirstMissingPositive(new int[] { 3, -1, 23, 7, 21, 12, 8, 9, 18, 21, -1, 16, 1, 13, -3, 22, 23, 13, 7, 14, 3, 6, 4, -3 })}");
            Console.WriteLine($"[...] = {FirstMissingPositive(new int[] { 39, 8, 43, 12, 38, 11, -9, 12, 34, 20, 44, 32, 10, 22, 38, 9, 45, 26, -4, 2, 1, 3, 3, 20, 38, 17, 20, 25, 41, 35, 37, 18, 37, 34, 24, 29, 39, 9, 36, 28, 23, 18, -2, 28, 34, 30})}");
            Console.WriteLine($"[1, 2, 6, 3, 5, 4] = {FirstMissingPositive(new int[] { 1, 2, 6, 3, 5, 4 })}");
            Console.WriteLine($"[1, 3, 3] = {FirstMissingPositive(new int[] { 1, 3, 3 })}");
            Console.WriteLine($"[0] = {FirstMissingPositive(new int[] { 0 })}");
            Console.WriteLine($"[1, 2, 0] = {FirstMissingPositive(new int[] { 1, 2, 0 })}");
            Console.WriteLine($"[3, 4, -1, 1] = {FirstMissingPositive(new int[] { 3, 4, -1, 1 })}");
            Console.WriteLine($"[7, 8, 9, 11, 12] = {FirstMissingPositive(new int[] { 7, 8, 9, 11, 12 })}");
            Console.WriteLine($"[1, 2, 9, 11] = {FirstMissingPositive(new int[] { 1, 2, 9, 11 })}");
            Console.WriteLine($"[1, 2, 3, 4, 8] = {FirstMissingPositive(new int[] { 1, 2, 3, 4, 8 })}");
            Console.WriteLine($"[1, 3, 4, 8, 100] = {FirstMissingPositive(new int[] { 1, 3, 4, 8, 100 })}");
            Console.WriteLine($"[1, 2, 3, 10, 100] = {FirstMissingPositive(new int[] { 1, 2, 3, 10, 100 })}");

            Console.ReadKey();
        }

        //Given an unsorted integer array nums, return the smallest missing positive integer.
        //You must implement an algorithm that runs in O(n) time and uses constant extra space.

        //Example 1:
        //Input: nums = [1, 2, 0]
        //Output: 3
        //Explanation: The numbers in the range [1,2] are all in the array.

        //Example 2:
        //Input: nums = [3, 4, -1, 1]
        //Output: 2
        //Explanation: 1 is in the array but 2 is missing.

        //Example 3:
        //Input: nums = [7, 8, 9, 11, 12]
        //Output: 1
        //Explanation: The smallest positive integer 1 is missing.

        static public int FirstMissingPositive(int[] nums)
        {
            Console.WriteLine("-------------------------");

            List<int> lst = new List<int>();
            lst.AddRange(nums);
            lst = lst.Where(x => x > 0).Distinct().OrderBy(x => x).ToList();

            Console.WriteLine("[ "+String.Join(", ", lst)+$" ] COUNT = {lst.Count()}");

            int len = lst.Count();
            int range = len / 2;
            int finder = range;

            if (len == 0)
                return 1;

            if (lst[0] > 1)
                return 1;

            if (lst.Last() == len)
                return len + 1;

            int result = lst.Last() + 1;
            do
            {
                int value = lst[finder];

                if (value > finder + 1)
                {
                    Console.WriteLine(" <-");
                    range /= 2;
                    finder -= range;

                    if (range == 0)
                    {
                        do
                        {
                            Console.WriteLine("Back");
                            result = lst[finder - 1] + 1;
                            if (result > finder + 1 && finder - 2 >= 0)
                            {
                                finder--;
                            }
                            else
                            {
                                break;
                            }
                        } while (true);
                        
                    }

                }
                else
                {
                    Console.WriteLine(" ->");
                    range /= 2;
                    finder += range;
                    result = value + 1;
                    if (range == 0)
                    {
                        do
                        {
                            Console.WriteLine("Front");
                            if (lst[finder + 1] == result)
                            {
                                result++;
                                finder++;
                            }
                            else
                            {
                                break;
                            }
                        } while (true);
                        
                    }
                }

                Console.WriteLine($"range = {range}");

            } while (range > 0); 
            return result;
        }

    }
}
