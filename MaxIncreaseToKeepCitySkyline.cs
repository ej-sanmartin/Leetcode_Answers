/*
  In a 2 dimensional array grid, each value grid[i][j] represents the height of a building located there.
  We are allowed to increase the height of any number of buildings, by any amount (the amounts can be
  different for different buildings). Height 0 is considered to be a building as well. 

  At the end, the "skyline" when viewed from all four directions of the grid, i.e. top, bottom, left, and
  right, must be the same as the skyline of the original grid. A city's skyline is the outer contour of the
  rectangles formed by all the buildings when viewed from a distance. See the following example.

  What is the maximum total sum that the height of the buildings can be increased?
*/

public class Solution {
    public int MaxIncreaseKeepingSkyline(int[][] grid) {
        int sum = 0;
        List<int> northSideView = new List<int>(); // from the north and south side view, highest level building
        List<int> eastSideView = new List<int>(); // from the east and west side view, highest level building
        
        // populates northSideView and eastSideView list with highest number for each column and row
        for(int row = 0; row < grid.Length; row++){
            List<int> columnList = new List<int>();
            for(int column = 0; column < grid[row].Length; column++){
                columnList.Add(grid[column][row]);
            }
            northSideView.Add(grid[row].Max());
            eastSideView.Add(columnList.ToArray().Max());
        }
        
        // increments sum by comparing each number in grid with the max value for each row and column
        for(int row = 0; row < grid.Length; row++){
            for(int column = 0; column < grid[row].Length; column++){
                sum += Math.Min(northSideView[row], eastSideView[column]) - grid[row][column];
            }
        }
        
        return sum;
    }
}
