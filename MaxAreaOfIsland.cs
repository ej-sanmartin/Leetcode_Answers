/*
    You are given an m x n binary matrix grid. An island is a group of 1's (representing land) connected 4-
    directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

    The area of an island is the number of cells with a value 1 in the island.

    Return the maximum area of an island in grid. If there is no island, return 0.
    
    Note for self: if input must not be mutated, either revert all islands back to 1 in a second pass through
                   grid or keep hashset of all coordinates traversed. Space complexity remains the same
    
    T - O(nm), as we much touch all cells in nm grid at least once
    S - O(nm), worst case we have a grid that is entirely an island. Recursive call stack would be that entire
               grid's size
*/
public class Solution {
    private int[][] _directions;
    
    public int MaxAreaOfIsland(int[][] grid) {
        if (grid.Length == 0 || grid == null) {
            return 0;
        }
        
        _directions = new int[][]{new int[]{-1, 0}, new int[]{0, -1}, new int[]{1, 0}, new int[]{0, 1}};
        int maxArea = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;
        
        for (int row = 0; row < rows; row++) {
            for(int col = 0;  col < cols; col++) {
                if (grid[row][col] == 1) {
                    int currentIslandArea = GetIslandArea(grid, row, col);
                    maxArea = Math.Max(maxArea, currentIslandArea);
                }
            }
        }
        
        return maxArea;
    }
    
    private int GetIslandArea(int[][] grid, int row, int col) {
        if (IsOutOfBounds(grid, row, col) || grid[row][col] == 0) {
            return 0;
        }
        grid[row][col] = 0;
        int count = 1;
        foreach (int[] adjacent in _directions) {
            int adjacentRow = row + adjacent[0];
            int adjacentCol = col + adjacent[1];
            count += GetIslandArea(grid, adjacentRow, adjacentCol);
        }
        return count;
    }
    
    private bool IsOutOfBounds(int[][] grid, int row, int col) {
        if (row < 0 || col < 0 || row >= grid.Length || col >= grid[row].Length) {
            return true;
        }
        return false;
    }
}
