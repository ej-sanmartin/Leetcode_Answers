/*
    Given a m x n grid filled with non-negative numbers, find a path from top left 
    to bottom right, which minimizes the sum of all numbers along its path.
    Note: You can only move either down or right at any point in time.

    T - O(mn), we solve m x n sub problems, one for every cell in given matrix
    S - O(mn), we store sub solution in a 2d DP matrix
*/
public class Solution {
    public int MinPathSum(int[][] grid) {
        if (grid.Length == 0 || grid == null) {
            return 0;
        }
        int row = grid.Length;
        int col = grid[0].Length;
        int[,] memo = new int[row,col];
        return MinPathSumHelper(grid, 0, 0, memo);
    }
    
    public int MinPathSumHelper(int[][] grid, int row, int col, int[,] memo) {
        if (row >= grid.Length || col >= grid[row].Length) {
            return Int32.MaxValue;
        }
        
        if (row == grid.Length - 1 && col == grid[row].Length - 1) {
            return grid[row][col];
        }
        
        if (memo[row, col] < 1) {
            int routeOneSum = MinPathSumHelper(grid, row + 1, col, memo);
            int routeTwoSum = MinPathSumHelper(grid, row, col + 1, memo);
            memo[row, col] = Math.Min(routeOneSum, routeTwoSum) + grid[row][col];
        }
        
        return memo[row, col];
    }
}
