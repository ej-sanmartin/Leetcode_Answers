/*
    You are given row x col grid representing a map where grid[i][j] = 1 represents 
    land and grid[i][j] = 0 represents water.

    Grid cells are connected horizontally/vertically (not diagonally). The grid is 
    completely surrounded by water, and there is exactly one island (i.e., one or 
    more connected land cells).

    The island doesn't have "lakes", meaning the water inside isn't connected to 
    the water around the island. One cell is a square with side length 1. The grid 
    is rectangular, width and height don't exceed 100. Determine the perimeter of 
    the island.
    
    T - O(n*m(n + m)) -> O(n^3), nested for loop adds a lot of time inefficiency
              and to run a DFS within that does make the algorithm that much more 
              slower
    S - O(1), since we are not creating much space besides the count for the 
              perimeter
*/
public class Solution {
    private int perimeter;
    public int IslandPerimeter(int[][] grid) {
        perimeter = 0;
        
        for(int row = 0; row < grid.Length; row++){
            for(int column = 0; column < grid[0].Length; column++){
                if(grid[row][column] == 1){
                    FindLand(grid, row, column);
                    return perimeter;
                }
            }
        }
        
        return perimeter;
    }
    
    private void FindLand(int[][] grid, int row, int column){
        if(IsOutOfBounds(grid, row, column)){
            perimeter++;
            return;
        } else if(grid[row][column] == 0){
            perimeter++;
            return;
        } else if(grid[row][column] == -1) return;
        
        grid[row][column] = -1;
        
        FindLand(grid, row + 1, column);
        FindLand(grid, row - 1, column);
        FindLand(grid, row, column + 1);
        FindLand(grid, row, column - 1);
    }
    
    private bool IsOutOfBounds(int[][] grid, int row, int column){
        if(row < 0 || column > grid[0].Length - 1 || row > grid.Length - 1 || column < 0) return true;
        return false;
    }
}
