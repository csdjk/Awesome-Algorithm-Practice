using System.Collections.Generic;
using System;
//-----------------------------【编辑距离 - 困难】-----------------------------
public class EditDistance
{

    /**
        给定两个单词 word1 和 word2，计算出将 word1 转换成 word2 所使用的最少操作数 。

        你可以对一个单词进行如下三种操作：

        插入一个字符
        删除一个字符
        替换一个字符
        示例 1:

        输入: word1 = "horse", word2 = "ros"
        输出: 3
        解释: 
        horse -> rorse (将 'h' 替换为 'r')
        rorse -> rose (删除 'r')
        rose -> ros (删除 'e')

    **/
    /**
    解题思路： 动态规划
        dp[i][j] 代表 word1 从 0 到 i 位置的字符 转换成 word2 从 0 到 j 位置的字符 需要最少步数

        所以：

        当 word1[i] == word2[j]，不动，继续进行下一步
            dp[i][j] = dp[i-1][j-1]；

        当 word1[i] != word2[j]，取 替换、删除，插入 这三个操作中编辑距离最小的一种，即：
            dp[i][j] = min(dp[i-1][j-1], dp[i-1][j], dp[i][j-1]) + 1

        其中，dp[i-1][j-1] 表示替换操作，dp[i-1][j] 表示删除操作，dp[i][j-1] 表示插入操作。


        注意，针对第一行，第一列要单独考虑，我们引入 '' 下图所示：

        |    |  '' | r | o | s |
        | '' |  0  | 1 | 2 | 3 |
        | h  |  1  |   |   |   |
        | o  |  2  |   |   |   |
        | r  |  3  |   |   |   |
        | s  |  4  |   |   |   |
        | e  |  5  |   |   |   |


        第一行，是 word1 为空变成 word2 最少步数，就是插入操作

        第一列，是 word2 为空，需要的最少步数，就是删除操作

        
        PS：
            对“dp[i-1][j-1] 表示替换操作，dp[i-1][j] 表示删除操作，dp[i][j-1] 表示插入操作。”的补充理解：

            以 word1 为 "horse"，word2 为 "ros"，且 dp[5][3] 为例，即要将 word1的前 5 个字符转换为 word2的前 3 个字符，也就是将 horse 转换为 ros，因此有：

            (1) dp[i-1][j-1]，即先将 word1 的前 4 个字符 hors 转换为 word2 的前 2 个字符 ro，然后将第五个字符 word1[4]（因为下标基数以 0 开始） 由 e 替换为 s（即替换为 word2 的第三个字符，word2[2]）

            (2) dp[i][j-1]，即先将 word1 的前 5 个字符 horse 转换为 word2 的前 2 个字符 ro，然后在末尾补充一个 s，即插入操作

            (3) dp[i-1][j]，即先将 word1 的前 4 个字符 hors 转换为 word2 的前 3 个字符 ros，然后删除 word1 的第 5 个字符

    
    **/
    public int MinDistance(string word1, string word2)
    {
        int len1 = word1.Length, len2 = word2.Length;
        int[,] dp = new int[len1 + 1, len2 + 1];

        // 初始化
        for (int i = 0; i <= len1; i++)
        {
            dp[i, 0] = i;
        }
        for (int j = 0; j <= len2; j++)
        {
            dp[0, j] = j;
        }

        // 
        for (int i = 1; i <= len1; i++)
        {
            for (int j = 1; j <= len2; j++)
            {
                // 如果两个字符相等，那么直接进行下一步
                if (word1[i - 1] == word2[j - 1])
                {

                    dp[i, j] = dp[i - 1, j - 1];
                }
                //不相等， 就取 替换、删除，插入 这三个操作中编辑距离最小的一种
                else
                {
                    dp[i, j] = Math.Min(dp[i - 1, j - 1], dp[i - 1, j]);
                    dp[i, j] = Math.Min(dp[i, j], dp[i, j - 1]) + 1;
                }
            }
        }
        return dp[len1, len2];
    }
}