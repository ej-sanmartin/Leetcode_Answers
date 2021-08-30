/*
    You are given an m x n binary matrix grid, where 0 represents a sea cell and 1 represents 
    a land cell.

    A move consists of walking from one land cell to another adjacent (4-directionally) land 
    cell or walking off the boundary of the grid.

    Return the number of land cells in grid for which we cannot walk off the boundary of the 
    grid in any number of moves.
    
    T - O(n), as we must traverse through every cell at least once
    S - O(n), worst case, DFS can create a call stack the size of every cell in the grid
*/
public class Solution {
    public int NumEnclaves(int[][] grid) {
        int count = 0;
        
        // top row
        for(int i = 0; i < grid[0].Length; i++){
            if(grid[0][i] == 1){
                Sink(0, i, grid);
            }
        }
        
        // left side
        for(int i = 0; i < grid.GetLength(0); i++){
            if(grid[i][0] == 1){
                Sink(i, 0, grid);
            }
        }
        
        // right side
        for(int i = 0; i < grid.GetLength(0); i++){
            if(grid[i][grid[i].Length - 1] == 1){
                Sink(i, grid[i].Length - 1, grid);
            }
        }
        
        // bottom row
        for(int i = 0; i < grid[grid.Length - 1].Length; i++){
            if(grid[grid.Length - 1][i] == 1){
                Sink(grid.Length - 1, i, grid);
            }
        }
        
        for(int row = 0; row < grid.GetLength(0); row++){
            for(int column = 0; column < grid[row].Length; column++){
                if(grid[row][column] == 1){
                    count++;
                }
            }
        }
        
        return count;
    }
    
    public void Sink(int row, int column, int[][] grid){
        if(IsOutOfBounds(row, column, grid)){
            return;
        }
        
        if(grid[row][column] == 0){
            return;
        }
        
        grid[row][column] = 0;
        
        Sink(row + 1, column, grid);
        Sink(row - 1, column, grid);
        Sink(row, column + 1, grid);
        Sink(row, column - 1, grid);
    }
    
    public bool IsOutOfBounds(int row, int column, int[][] grid){
        if(row < 0 || column < 0 || row >= grid.GetLength(0) || column >= grid[row].Length){
            return true;
        }
        return false;
    }
}
