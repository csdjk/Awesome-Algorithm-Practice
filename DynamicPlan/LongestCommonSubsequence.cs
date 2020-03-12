using System;
namespace AlgorithmPractice.DynamicPlan
{
    //-----------------------------【最长公共子序列 - 中等】-----------------------------
    public class LongestCommonSubsequence
    {
        /**
        给定两个字符串 text1 和 text2，返回这两个字符串的最长公共子序列。

        示例 1:

        输入：text1 = "abcde", text2 = "ace" 
        输出：3  
        解释：最长公共子序列是 "ace"，它的长度为 3。
        */


        /**
        思路：

        1.　S{s1,s2,s3....si} T{t1,t2,t3,t4....tj}

        2.　子问题划分

            (1) 如果S的最后一位等于T的最后一位，则最大子序列就是{s1,s2,s3...si-1}和{t1,t2,t3...tj-1}的最大子序列+1

            (2) 如果S的最后一位不等于T的最后一位，那么最大子序列就是

            ① {s1,s2,s3..si}和 {t1,t2,t3...tj-1} 最大子序列

            ② {s1,s2,s3...si-1}和{t1,t2,t3....tj} 最大子序列

            以上两个自序列的最大值

        3.　边界

            只剩下{s1}和{t1}，如果相等就返回1，不等就返回0

        4.　使用一个表格来存储dp的结果

            如果 S[i] == T[j] 则dp[i][j] = dp[i-1][j-1] + 1

            否则 dp[i][j] = max(dp[i][j-1],dp[i-1][j])

        
        **/
        public int GetLongestCommonSubsequence(string text1, string text2)
        {
            // 这里选择 1 为开始索引是因为好计算最开始的dp值
            int[,] dp = new int[text1.Length + 1, text2.Length + 1];

            for (int i = 1, len1 = text1.Length + 1; i < len1; i++)
            {
                for (int j = 1, len2 = text2.Length + 1; j < len2; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[text1.Length, text2.Length];
        }
    }
}