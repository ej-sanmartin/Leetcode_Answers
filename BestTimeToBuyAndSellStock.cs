/*
  You are given an array prices where prices[i] is the price of a given stock on the ith day.

  You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

  Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

  T - O(n) where n is the size of the prices array. Must go through every item to find min prices and best times to buy and sell
  S - O(1), since we are only ever creating two int variables to keep track of minPrices and the maxProfit
*/
public class Solution {
    public int MaxProfit(int[] prices) {
        int minPrice = Int32.MaxValue;
        int maxProfit = 0;
        
        for(int i = 0; i < prices.Length; i++){
            if(prices[i] < minPrice){
                minPrice = prices[i];
            } else if(prices[i] - minPrice > maxProfit){
                maxProfit = prices[i] - minPrice;
            }
        }
        
        return maxProfit;
    }
}
