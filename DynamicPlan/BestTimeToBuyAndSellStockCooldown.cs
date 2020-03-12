using System.Numerics;
using System;
//-----------------------------【买卖股票的最佳时机 包含冷冻期 - 中等】-----------------------------
public class BestTimeToBuyAndSellStockCooldown
{
    /**
    
    给定一个整数数组，其中第 i 个元素代表了第 i 天的股票价格 。​

    设计一个算法计算出最大利润。在满足以下约束条件下，你可以尽可能地完成更多的交易（多次买卖一支股票）:

    你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。
    卖出股票后，你无法在第二天买入股票 (即冷冻期为 1 天)。

    示例:

    输入: [1,2,3,0,2]
    输出: 3 
    解释: 对应的交易状态为: [买入, 卖出, 冷冻期, 买入, 卖出]
    **/
    /**
    解题：DP动态规划:

        第i天有三种状态，不持有、持有股票、冷冻期，

        1.当天不持有股票的状态
            有两种情况：昨天也不持有 、 冷冻期，
        2.当天持有股票的状态
            有两种情况：昨天买入 、 昨天也持有中，
        3.当天冷冻的状态
            只有一种情况：昨天卖出，

        取最后一天的不持有股票状态和冷冻状态的最大值 就是问题的解
        **/
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        if (n == 0) return 0; // 边界条件
        // dp[i,j] i 代表天数，j代表状态（持有、不持有、冷冻），0 => 不持有， 1=> 持有， 2=> 冷冻
        int[,] dp = new int[n, 3];
        dp[0, 0] = 0;   //第一天不持有
        dp[0, 1] = -prices[0];//第一天持有
        dp[0, 2] = 0;//第一天冷冻

        for (int i = 1; i < n; i++)
        {
            // 不持有: 可能来自 昨天也不持有 或者 冷冻期
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 2]);
            // 持有: 可能来自 昨天也持有中 或者 昨天买入
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
            // 冷冻期: 只能来自 昨天卖出
            dp[i, 2] = dp[i - 1, 1] + prices[i];
        }
        return Math.Max(dp[n - 1, 0], dp[n - 1, 2]);
    }

    //-----------------------------【优化空间复杂度后】-----------------------------

    public int MaxProfit_O(int[] prices)
    {
        int n = prices.Length;
        if (n == 0) return 0; // 边界条件
        // dp[i,j] i 代表天数，j代表状态（持有、不持有、冷冻），0 => 不持有， 1=> 持有， 2=> 冷冻

        int dp_0_0 = 0;//第一天不持有
        int dp_0_1 = -prices[0];//第一天持有
        int dp_0_2 = 0;//第一天冷冻

        int dp_0_0_temp,dp_0_1_temp;
        for (int i = 1; i < n; i++)
        {
            dp_0_0_temp = dp_0_0;
            dp_0_1_temp = dp_0_1;
            // 不持有: 可能来自 昨天也不持有 或者 冷冻期
            dp_0_0 = Math.Max(dp_0_0_temp, dp_0_2);
            // 持有: 可能来自 昨天也持有中 或者 昨天买入
            dp_0_1 = Math.Max(dp_0_1_temp, dp_0_0_temp - prices[i]);
            // 冷冻期: 只能来自 昨天卖出
            dp_0_2 = dp_0_1_temp + prices[i];
        }
        return Math.Max(dp_0_0, dp_0_2);
    }
}