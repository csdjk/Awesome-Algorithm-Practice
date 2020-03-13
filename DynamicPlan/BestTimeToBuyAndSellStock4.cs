using System.Numerics;
using System;
//-----------------------------【买卖股票的最佳时机 四 - 困难】-----------------------------
public class BestTimeToBuyAndSellStock4
{
    /**
    
    给定一个数组，它的第 i 个元素是一支给定的股票在第 i 天的价格。

    设计一个算法来计算你所能获取的最大利润。你最多可以完成 k 笔交易。

    注意: 你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。

    示例 1:

    输入: [2,4,1], k = 2
    输出: 2
    解释: 在第 1 天 (股票价格 = 2) 的时候买入，在第 2 天 (股票价格 = 4) 的时候卖出，这笔交易所能获得利润 = 4-2 = 2 。

    **/


    /**
    解题：

        状态： dp[i,j,k] => 代表 第 i 天，第 j 笔交易，状态为k 的最大收益，k = 0 代表不持有，k = 1 代表持有

        状态转移方程：
            1.不持有: 可能来自 昨天也不持有 或者 昨天持有，今天卖出
            dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], dp[i - 1, j, 1] + prices[i]);

            2.持有: 可能来自 昨天也持有中 或者 昨天不持有，今天买入(有新交易 所以j-1)
            dp[i, j, 1] = Math.Max(dp[i - 1, j, 1], dp[i - 1, j - 1, 0] - prices[i]);

        注意：
            如果 k >= n / 2 相当于不限交易数，就用贪心算法

        **/
    public int MaxProfit(int k, int[] prices)
    {
        int n = prices.Length;
        if (n == 0 || n < 2) return 0; // 边界条件

        if (k >= n / 2)
        {
            return greedy(prices);
        }

        int[,,] dp = new int[n, k + 1, 2];

        //  初始化第一天数据，买入股票
        for (int i = 1; i < k + 1; i++)
        {
            dp[0, i, 1] = -prices[0];
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < k + 1; j++)
            {
                // 不持有: 可能来自 昨天也不持有 或者 昨天持有，今天卖出
                dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], dp[i - 1, j, 1] + prices[i]);
                // 持有: 可能来自 昨天也持有中 或者 昨天不持有，今天买入(有新交易 所以j-1)
                dp[i, j, 1] = Math.Max(dp[i - 1, j, 1], dp[i - 1, j - 1, 0] - prices[i]);
            }
        }
        return dp[n - 1, k, 0];
    }
    // 不限制交易次数
    public int greedy(int[] prices)
    {
        // 贪婪算法，存在利润就卖出
        // 转换为股票系列的第 2 题，使用贪心算法完成，思路是只要有利润，就交易
        int res = 0;
        for (int i = 1, len = prices.Length; i < len; i++)
        {
            if (prices[i - 1] < prices[i])
            {
                res += prices[i] - prices[i - 1];
            }
        }
        return res;
    }

}