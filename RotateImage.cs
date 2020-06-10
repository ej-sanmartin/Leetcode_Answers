/*
  You are given an n x n 2D matrix representing an image.

  Rotate the image by 90 degrees (clockwise).

  Note:

  You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.
*/

public class Solution {
    public void Rotate(int[][] matrix) {
        int matrixLength = matrix.Length;
        
        // swap row and columns
        for(int i = 0; i < matrixLength; i++){
            for(int j = i; j < matrixLength; j++){
                int temporary = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temporary;
            }
        }
        
        // each column is in correct order, but the rows are not. Reverse the rows to complete problem
        for(int i = 0; i < matrixLength; i++){
            for(int j = 0; j < matrixLength/2; j++){
                int temporary = matrix[i][j];
                matrix[i][j] = matrix[i][matrixLength - 1 - j];
                matrix[i][matrixLength - 1 -j] = temporary;
            }
        }
    }
}
