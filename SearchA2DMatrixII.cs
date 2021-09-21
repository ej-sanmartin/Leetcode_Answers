/*
    Write an efficient algorithm that searches for a target value in an m x n integer matrix. The 
    matrix has the following properties:

    Integers in each row are sorted in ascending from left to right.
    Integers in each column are sorted in ascending from top to bottom.
*/
public class Solution {
    // T- O(n + m)
    // S - O(1)
    public bool SearchMatrix(int[][] matrix, int target){
        int row = matrix.Length - 1;
        int col = 0;
        while(row >= 0 && col < matrix[0].Length){
            if(matrix[row][col] > target){
                row--;
            } else if(matrix[row][col] < target){
                col++;
            } else {
                return true;
            }
        }
        return false;
    }
    
    // T - O(nlogn)
    // S - O(logn)
    public bool SearchMatrix(int[][] matrix, int target) {
        if(matrix == null || matrix.Length == 0) return false;
        return Helper(matrix, target, 0, 0, matrix.Length - 1, matrix[0].Length - 1);
    }
    
    public bool Helper(int[][] matrix, int target, int lowRow, int lowCol, int highRow, int highCol){
        if(lowRow > highRow || lowCol > highCol){
            return false;
        } else if(target < matrix[lowRow][lowCol] || target > matrix[highRow][highCol]){
            return false;
        }
        
        int mid = lowCol + ((highCol - lowCol) / 2);
        int currentRow = lowRow;
        while(currentRow <= highRow && matrix[currentRow][mid] <= target){
            if(matrix[currentRow][mid] == target){
                return true;
            }
            currentRow++;
        }
        return Helper(matrix, target, currentRow, lowCol, highRow, mid - 1) || Helper(matrix, target, lowRow, mid + 1, currentRow - 1, highCol);
    }
    */
}
