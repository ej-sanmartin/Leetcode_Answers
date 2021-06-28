/*
    You are given an integer array cost where cost[i] is the cost of ith step on a staircase. Once you 
    pay the cost, you can either climb one or two steps.

    You can either start from the step with index 0, or the step with index 1.

    Return the minimum cost to reach the top of the floor

    T - O(n), Must loop through the entire cost array as they represent steps to the top of staircase
    S - O(n), as we create a table that is size cost.Length + 1 to store pass solutions and get out
              ultimate answer
*/
public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int[] table = new int[cost.Length + 1];
        
        for(int i = 2; i < table.Length; i++){
            int oneStep = table[i - 1] + cost[i - 1];
            int twoStep = table[i - 2] + cost[i - 2];
            table[i] = Math.Min(oneStep, twoStep);
        }
        
        return table[cost.Length];
    }
}
