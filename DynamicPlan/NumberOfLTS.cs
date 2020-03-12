using System;
//-----------------------------【最长上升子序列 - 中等】-----------------------------
public class NumberOfLTS
{
    /**
    给定一个未排序的整数数组，找到最长递增子序列的长度。

    示例 1:

    输入: [10,9,2,5,3,7,101,18]
    输出: 4 
    解释: 最长的上升子序列是 [2,3,7,101]，它的长度是 4。
    **/
    public int FindNumberOfLIS(int[] nums)
    {
        int[] dp = new int[nums.Length];
        Array.Fill(dp, 1);

        for (int i = 0, len = nums.Length; i < len; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        int res = 0;
        for (int i = 0, len = nums.Length; i < len; i++)
        {
            res = Math.Max(res, dp[i]);
        }
        return res;
    }
}

