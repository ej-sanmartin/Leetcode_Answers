/*
    You are given an m x n integer grid accounts where accounts[i][j] is the 
    amount of money the i^th customer has in the j^th bank. Return the wealth 
    that the richest customer has.

    A customer's wealth is the amount of money they have in all their bank 
    accounts. The richest customer is the customer that has the maximum 
    wealth.

    T - O(nm), where n is the number of customers there are and m is the
               number of banks they have. Must traverse through all elements
               in grid to get each customers sum and update the maxWealth
    S - O(1),  constant space, only creating variables to keep track of each
               cusomters wealth and the maxWealth
*/
public class Solution {
    public int MaximumWealth(int[][] accounts) {
        int maxWealth = 0;
        int currentWealth;
        
        for(int customer = 0; customer < accounts.Length; customer++){
            currentWealth = 0;
            for(int bank = 0; bank < accounts[0].Length; bank++){
                currentWealth += accounts[customer][bank];
            }
            maxWealth = Math.Max(maxWealth, currentWealth);
        }
        
        return maxWealth;
    }
}
