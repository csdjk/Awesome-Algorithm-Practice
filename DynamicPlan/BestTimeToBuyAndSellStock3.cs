using System.Numerics;
using System;
//-----------------------------【买卖股票的最佳时机 三 - 困难】-----------------------------
public class BestTimeToBuyAndSellStock3
{
    /**
    
    给定一个数组，它的第 i 个元素是一支给定的股票在第 i 天的价格。

    设计一个算法来计算你所能获取的最大利润。你最多可以完成 两笔 交易。

    注意: 你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。

    示例 1:

    输入: [3,3,5,0,0,3,1,4]
    输出: 6
    解释: 在第 4 天（股票价格 = 0）的时候买入，在第 6 天（股票价格 = 3）的时候卖出，这笔交易所能获得利润 = 3-0 = 3 。
         随后，在第 7 天（股票价格 = 1）的时候买入，在第 8 天 （股票价格 = 4）的时候卖出，这笔交易所能获得利润 = 4-1 = 3 。

    **/


    /**
    解题：

        对于任意一天考虑四个变量:
        firstBuy: 在该天第一次买入股票可获得的最大收益 
        firstSell: 在该天第一次卖出股票可获得的最大收益
        secondBuy: 在该天第二次买入股票可获得的最大收益
        secondSell: 在该天第二次卖出股票可获得的最大收益
        分别对四个变量进行相应的更新, 最后secondSell就是最大
        收益值(secondSell >= firstSell)
        **/
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        if (n == 0) return 0; // 边界条件

        int firstBuy = Int32.MinValue;
        int firstSell = 0;
        int secondBuy = Int32.MaxValue;
        int secondSell = 0;

        for (int i = 0; i < n; i++)
        {
            // 在该天第一次买入股票可获得的最大收益
            firstBuy = Math.Max(firstBuy, -prices[i]);
            // 在该天第一次卖出股票可获得的最大收益
            firstSell = Math.Max(firstSell, firstBuy + prices[i]);
            // 在该天第二次买入股票可获得的最大收益
            secondBuy = Math.Max(secondBuy, firstSell - prices[i]);
            // 在该天第二次卖出股票可获得的最大收益
            secondSell = Math.Max(secondSell, secondBuy + prices[i]);
        }
        return secondSell;
    }
}