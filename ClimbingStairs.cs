/*
  UPDATED 2021 SOLUTION

    You are climbing a staircase. It takes n steps to reach the top.

    Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
    
    T - O(n), where we loop through every element in table minus the first 3 elements as they are our base cases
    S - O(n), where we create a new array to store our table, with size n. + 1
*/
public class Solution {
    public int ClimbStairs(int n) {
        if(n == 1) return 1;
        
        int[] table = new int[n + 1];
        table[1] = 1;
        table[2] = 2;
        
        for(int i = 3; i < table.Length; i++){
            table[i] = table[i - 1] + table[i - 2];
        }
        
        return table[n];
    }
}

/*
  You are climbing a stair case. It takes n steps to reach to the top.

  Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
*/

public class Solution {
    private int[] memo = new int[1001];
    
    public int ClimbStairs(int n) {
        if(n == 1) { return 1; }
        if(n == 2) { return 2; }
        else if(memo[n] == 0) {
            memo[n] = ClimbStairs(n - 1) + ClimbStairs(n - 2);
        }
        return memo[n];
    }
}
