using System.Numerics;
using System;
//-----------------------------【买卖股票的最佳时机含手续费 - 中等】-----------------------------
public class BestTimeToBuyAndSellStockWithTransactionFee
{
    /**
    
    给定一个整数数组 prices，其中第 i 个元素代表了第 i 天的股票价格 ；非负整数 fee 代表了交易股票的手续费用。

    你可以无限次地完成交易，但是你每次交易都需要付手续费。如果你已经购买了一个股票，在卖出它之前你就不能再继续购买股票了。

    返回获得利润的最大值。

    示例 1:

    输入: prices = [1, 3, 2, 8, 4, 9], fee = 2
    输出: 8
    解释: 能够达到的最大利润:  
    在此处买入 prices[0] = 1
    在此处卖出 prices[3] = 8
    在此处买入 prices[4] = 4
    在此处卖出 prices[5] = 9
    总利润: ((8 - 1) - 2) + ((9 - 4) - 2) = 8.
    **/


    /**
    解题：DP动态规划:

        1.状态：dp[i,j]， i 代表天数，j代表状态，0 => 不持有， 1=> 持有

        2.状态转移方程：
            不持有  可能来自 昨天也不持有 或者 昨天持有，今天卖出(需要减去手续费)
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i] - fee);
            持有    可能来自 昨天也持有中 或者 昨天不持有，今天买入
            dp[i, 1] = Math.Max(dp[i-1, 1], dp[i - 1, 0] - prices[i]);

        取最后一天的不持有股票状态就是问题的解
        **/
    public int MaxProfit(int[] prices, int fee)
    {
        int n = prices.Length;
        if (n == 0) return 0; // 边界条件
        // dp[i,j] i 代表天数，j代表 持有或者不持有，0 => 不持有， 1=> 持有
        int[,] dp = new int[n, 2];

        dp[0, 0] = 0;
        dp[0, 1] = -prices[0];

        for (int i = 1; i < n; i++)
        {
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i] - fee);
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
        }

        return dp[n - 1, 0];
    }

    //-----------------------------【空间优化后】-----------------------------
    
    public int MaxProfit_O(int[] prices, int fee)
    {
        int n = prices.Length;
        if (n == 0) return 0; // 边界条件
        // dp[i,j] i 代表天数，j代表 持有或者不持有，0 => 不持有， 1=> 持有
        // int[,] dp = new int[n, 2];
        // dp[0, 0] = 0;
        // dp[0, 1] = -prices[0];

        int dp_0 = 0;
        int dp_1 = -prices[0];
        int temp = 0;

        for (int i = 1; i < n; i++)
        {
            temp = dp_0;
            dp_0 = Math.Max(temp, dp_1 + prices[i] - fee);
            dp_1 = Math.Max(dp_1, temp - prices[i]);
        }

        return dp_0;
    }
}