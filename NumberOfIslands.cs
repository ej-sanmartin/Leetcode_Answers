/*
    Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the 
    number of islands.

    An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
    You may assume all four edges of the grid are all surrounded by water.

    T - O(nm), as we are traversing through every row and every column to find potential islands
    S - O(nm), as the DFS call stack can be the size of every row and column if entire input is island
*/
public class Solution {
    public int NumIslands(char[][] grid) {
        int islands = 0;
        
        for(int row = 0; row < grid.Length; row++){
            for(int column = 0; column < grid[row].Length; column++){
                if(grid[row][column] == '1'){
                    SinkLand(grid, row, column);
                    islands++;
                }
            }
        }
        
        return islands;
    }
    
    private void SinkLand(char[][] grid, int row, int column){
        if(IsOutOfBounds(grid, row, column)) return;
        if(grid[row][column] == '0') return;
        
        grid[row][column] = '0';
        
        SinkLand(grid, row + 1, column);
        SinkLand(grid, row - 1, column);
        SinkLand(grid, row, column + 1);
        SinkLand(grid, row, column - 1);
    }
    
    private bool IsOutOfBounds(char[][] grid, int row, int column){
        if(row < 0 || column < 0 || row >= grid.Length || column >= grid[row].Length) return true;
        return false;
    }
}
