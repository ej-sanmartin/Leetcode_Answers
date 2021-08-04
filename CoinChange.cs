/*
    You are given an integer array coins representing coins of different 
    denominations and an integer amount representing a total amount of 
    money.

    Return the fewest number of coins that you need to make up that amount. 
    If that amount of money cannot be made up by any combination of the 
    coins, return -1.

    You may assume that you have an infinite number of each kind of coin.

    T - O(nm), where we have to loop from 1 up to the amount given as n, 
               solving sub problems and at each loop looping through coins 
               away m times which is the length of the coins array
    S - O(n), we are creating a dp array to store our sub solutions of size
              n + 1. Drop constants so we have n space
*/
public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if(coins.Length < 1 || coins == null) return -1;
        int[] table = new int[amount + 1];
        Array.Fill(table, amount + 1);
        table[0] = 0;
        
        for(int i = 1; i <= amount; i++){
            foreach(int coin in coins){
                if(coin <= i){
                    table[i] = Math.Min(table[i], table[i - coin] + 1);
                }
            }
        }
        
        return table[amount] > amount ? -1 : table[amount];
    }
}
