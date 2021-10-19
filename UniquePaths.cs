/*
    A robot is located at the top-left corner of a m x n grid (marked 'Start' in 
    the diagram below).

    The robot can only move either down or right at any point in time. The robot 
    is trying to reach the bottom-right corner of the grid (marked 'Finish' in the 
    diagram below).

    How many possible unique paths are there?

    T - O(mn), we are calculating m x n sub solutions to reach out solution
    S - O(mn), memo table holds m x n values
*/
public class Solution {
    public int UniquePaths(int m, int n) {
        int[,] memo = new int[m + 1, n + 1];
        return UniquePathsHelper(m, n, memo);
    }
    
    public int UniquePathsHelper(int m, int n, int[,] memo) {
        if (m == 0 || n == 0) {
            return 0;
        }
        
        if (m == 1 || n == 0) {
            return 1;
        }
        
        if (memo[m, n] == 0) {
            memo[m, n] = UniquePathsHelper(m - 1, n, memo) + UniquePathsHelper(m, n - 1, memo);
        }
        return memo[m, n];
    }
}
