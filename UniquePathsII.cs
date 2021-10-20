/*
    A robot is located at the top-left corner of a m x n grid (marked 'Start' in the 
    diagram below).

    The robot can only move either down or right at any point in time. The robot is 
    trying to reach the bottom-right corner of the grid (marked 'Finish' in the 
    diagram below).

    Now consider if some obstacles are added to the grids. How many unique paths 
    would there be?

    An obstacle and space is marked as 1 and 0 respectively in the grid.

    T - O(nm), where nm is the dimensions of a two dimension grid, we solve that many
               subsolutions to get the global optimal solution
    S - O(nm), we create a memo table of the size input grid nm to keep track of all
               subsolutions
*/
public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        if (obstacleGrid.Length == 0 || obstacleGrid == null) {
            return 0;
        }
        int row = obstacleGrid.Length;
        int col = obstacleGrid[0].Length;
        if (obstacleGrid[0][0] == 1 || obstacleGrid[row - 1][col - 1] == 1) {
            return 0;
        }
        int[,] memo = new int[row + 1, col + 1];
        return UniquePathsHelper(obstacleGrid, 0, 0, memo);
    }
    
    private int UniquePathsHelper(int[][] grid, int row, int col, int[,] memo) {
        if (row + 1 == grid.Length && col + 1 == grid[0].Length) {
            return 1;   
        }
        
        if (IsInvalidCoordinates(grid, row, col)) {
            return 0;
        }

        if (memo[row, col] == 0) {
            memo[row, col] = UniquePathsHelper(grid, row + 1, col, memo) + UniquePathsHelper(grid, row, col + 1, memo);
        }
        
        return memo[row, col];
    }
    
    private bool IsInvalidCoordinates(int[][] grid, int row, int col) {
        if (row >= grid.Length || col >= grid[row].Length) {
            return true;
        }
        
        if (grid[row][col] == 1) {
            return true;
        }
        
        return false;
    }
}
