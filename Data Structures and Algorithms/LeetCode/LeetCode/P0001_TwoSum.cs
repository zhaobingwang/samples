using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// https://leetcode-cn.com/problems/two-sum/solution/leetcode-1-two-sum-liang-shu-zhi-he-c-ha-xi-biao-d/
    /// </summary>
    public class P0001_TwoSum
    {
        public static void Run()
        {
            int[] nums = { 3, 4, 8, 1, 7, 11, 15, 9, 2, 10, 5, 4 };
            int target = 9;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result1 = TwoSum1(nums, target);
            sw.Stop();
            Console.WriteLine(result1[0].ToString() + "\t" + result1[1].ToString());
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var result2 = TwoSum2(nums, target);
            sw.Stop();
            Console.WriteLine(result2[0].ToString() + "\t" + result2[1].ToString());
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            var result3 = TwoSum3(nums, target);
            sw.Stop();
            Console.WriteLine(result3[0].ToString() + "\t" + result3[1].ToString());
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// 暴力法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static int[] TwoSum1(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { 0, 0 };
        }

        /// <summary>
        /// 两遍哈希表
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                // 需要对重复值进行判断；
                // 因为结果的唯一，所以若有重复值，且答案中包含了重复值的话，说明必有 重复值*2 == target; 否则直接忽略重复值即可
                if (dict.ContainsKey(nums[i]))
                {
                    if (nums[i] * 2 == target)
                    {
                        return new int[] { i, dict[nums[i]] };
                    }
                }
                else
                {
                    dict.Add(nums[i], i);
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement) && dict[complement] != i)
                {
                    return new int[] { i, dict[complement] };
                }
            }

            return new int[] { 0, 0 };
        }

        /// <summary>
        /// 一遍哈希表
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static int[] TwoSum3(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement) && dict[complement] != i)
                {
                    return new int[] { i, dict[complement] };
                }
                // 需要对重复值进行判断,若结果包含了重复值，则已经被上面给return了；所以此处对于重复值直接忽略
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }
            return new int[] { 0, 0 };
        }
    }
}
