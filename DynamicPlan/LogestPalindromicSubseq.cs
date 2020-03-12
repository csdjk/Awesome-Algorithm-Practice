using System;

//-----------------------------【最长回文子序列 - 中等】-----------------------------
public class LogestPalindromicSubseq
{
    /**
  给定一个字符串s，找到其中最长的回文子序列。可以假设s的最大长度为1000。

    示例 1:
    输入:

    "bbbab"
    输出:

    4
    一个可能的最长回文子序列为 "bbbb"。

    **/

    /**
    题解思路：   动态规划法

    1.状态
        f[left][right] 表示 s 的第 left 个字符到第 right 个字符组成的子串中，最长的回文序列长度是多少。

    2.转移方程
        如果 s 的第 left 个字符和第 right 个字符相同的话

        f[left][right] = f[left + 1][right - 1] + 2

        如果 s 的第 left 个字符和第 right 个字符不同的话

        f[left][right] = max(f[left + 1][right], f[left][right - 1])

        然后注意遍历顺序，left 从最后一个字符开始往前遍历，right 从 left + 1 开始往后遍历，这样可以保证每个子问题都已经算好了。

    3.初始化
        f[left][left] = 1 单个字符的最长回文序列是 1

    4.结果
        f[0][n - 1]


    **/
    public int LongestPalindromeSubseq(string s)
    {
        if (s.Length < 2)
        {
            return s.Length;
        }

        int[,] dp = new int[s.Length, s.Length];

        // 左边索引 倒着遍历，保证每个子问题都已经解决
        for (int left = s.Length-1; left >= 0; left--)
        {
            dp[left,left] = 1;
            // 右边边索引 从 left + 1 开始往后遍历
            for (int right = left+1 , len = s.Length; right < len; right++)
            {
                // 左右两边字符相等
                if (s[left] == s[right])
                {
                    dp[left, right] = dp[left + 1, right - 1] + 2;
                }
                else
                {
                    dp[left, right] = Math.Max(dp[left, right - 1], dp[left + 1, right]);
                }
            }
        }
        return dp[0, s.Length - 1];
    }
}