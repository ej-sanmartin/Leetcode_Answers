/*
    Given a m x n matrix grid which is sorted in non-increasing order both row-wise and 
    column-wise, return the number of negative numbers in grid.

    There is a binary search solution that runs O(nlogm)

    T - O(n + m), since we are traversing the matrix in a staircase fashion
    S - O(1), constant space, only creating int variables to hold counts and indexes
*/
public class Solution {
    public int CountNegatives(int[][] grid) {
        int negativeCount = 0;
        int row = grid.GetLength(0);
        int column = grid[0].Length;
        
        for(int i = 0; i < row; i++){
            for(int j = column - 1; j >= 0; j--){
                if(grid[i][j] < 0) negativeCount++;
                else break;
            }
        }
        
        return negativeCount;
    }
}
