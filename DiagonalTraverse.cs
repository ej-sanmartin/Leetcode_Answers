/*
    Given an m x n matrix mat, return an array of all the elements of the 
    array in a diagonal order.

    T - O(nm), as we are going through all elements in matrix of size n X m
    S - O(min(n, m)), size of diagonal temp array that holds items per
                      diagonal iteration
*/
public class Solution {
    public int[] FindDiagonalOrder(int[][] mat) {
        if (mat == null || mat.Length == 0) {
            return new int[0];
        }
        
        int rows = mat.Length;
        int cols = mat[0].Length;
        int[] output = new int[rows * cols];
        int index = 0;
        List<int> diagonal = new List<int>();
        
        for (int i = 0; i < rows + cols - 1; i++) {
            diagonal.Clear();
            int row = i < cols ? 0 : i - cols + 1;
            int col = i < cols ? i : cols - 1;
            while (row < rows && col > -1) {
                diagonal.Add(mat[row++][col--]);
            }
            if (i % 2 == 0) {
                diagonal.Reverse();
            }
            
            for (int j = 0; j < diagonal.Count; j++) {
                output[index++] = diagonal[j];
            }
        }
        
        
        return output;
    }
}
