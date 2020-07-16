using System;
using System.Diagnostics.Tracing;

namespace IterationLib
{
    public class Highest
    {
        public static int HighestWhileLoop(int[] nums)
        {
            int i = 0;
            int highest = 0;
            while (i < nums.Length)
            {
                if (nums[i] > highest)
                {
                    highest = nums[i];
                }
                i++;
            }
            return highest;
        }

        public static int HighestForLoop(int[] nums)
        {
            int highest = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > highest)
                {
                    highest = nums[i];
                }
            }
            return highest;
        }

        public static int HighestForEachLoop(int[] nums)
        {
            int highest = 0;
            foreach(int i in nums)
            {
                if (i > highest)
                {
                    highest = i;
                }
            }
            return highest;
        }

        public static int HighestDoWhileLoop(int[] nums)
        {
            int highest = 0;
            int i = 0;
            do
            {
                if (nums[i] > highest)
                {
                    highest = nums[i];
                }
                i++;
            }
            while (i < nums.Length);
            return highest;
        }
    }
}