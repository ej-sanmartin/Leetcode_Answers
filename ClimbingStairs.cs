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
