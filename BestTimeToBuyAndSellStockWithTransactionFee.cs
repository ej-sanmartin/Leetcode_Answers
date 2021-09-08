/*
    You are given an array prices where prices[i] is the price of a given stock on 
    the ith day, and an integer fee representing a transaction fee.

    Find the maximum profit you can achieve. You may complete as many transactions as 
    you like, but you need to pay the transaction fee for each transaction.

    Note: You may not engage in multiple transactions simultaneously (i.e., you must 
    sell the stock before you buy again).

    T - O(n), one loop through the prices array which is of size n
    S - O(1), we are only creating two int variables to store past day's output
*/
public class Solution {
    public int MaxProfit(int[] prices, int fee) {
        int sell = 0;
        int buy = -prices[0];
        
        for(int i = 1; i < prices.Length; i++){
            sell = Math.Max(sell, buy + prices[i] - fee);
            buy = Math.Max(buy, sell - prices[i]);
        }
        
        return sell;
    }
}
