using System.Numerics;
using System;
//-----------------------------【买卖股票的最佳时机 二 - 中等】-----------------------------
public class BestTimeToBuyAndSellStock2
{
    /**
    
    给定一个数组，它的第 i 个元素是一支给定股票第 i 天的价格。

    设计一个算法来计算你所能获取的最大利润。你可以尽可能地完成更多的交易（多次买卖一支股票）。

    注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。

    示例 1:

    输入: [7,1,5,3,6,4]
    输出: 7
    解释: 在第 2 天（股票价格 = 1）的时候买入，在第 3 天（股票价格 = 5）的时候卖出, 这笔交易所能获得利润 = 5-1 = 4 。
         随后，在第 4 天（股票价格 = 3）的时候买入，在第 5 天（股票价格 = 6）的时候卖出, 这笔交易所能获得利润 = 6-3 = 3 。

    **/


    /**
    解题：DP动态规划:

        1.状态：dp[i,j]， i 代表天数，j代表状态，0 => 不持有， 1=> 持有

        2.状态转移方程：
            不持有  可能来自 昨天也不持有 或者 昨天卖出
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
            持有    可能来自 昨天也持有中 或者 昨天买入
            dp[i, 1] = Math.Max(dp[i-1, 1], dp[i - 1, 0] - prices[i]);

        取最后一天的不持有股票状态就是问题的解
        **/
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        if (n == 0) return 0; // 边界条件
        // dp[i,j] i 代表天数，j代表 持有或者不持有，0 => 不持有， 1=> 持有
        int[,] dp = new int[n, 2];
        dp[0, 0] = 0;   //第一天不持有
        dp[0, 1] = -prices[0];//第一天持有

        for (int i = 1; i < n; i++)
        {
            // 不持有  可能来自 昨天也不持有 或者 昨天卖出
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
            // 持有    可能来自 昨天也持有中 或者 昨天买入
            dp[i, 1] = Math.Max(dp[i-1, 1], dp[i - 1, 0] - prices[i]);
        }
        return dp[n-1, 0];
    }
}