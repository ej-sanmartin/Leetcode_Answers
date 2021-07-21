/*
    Given an m x n matrix, return all elements of the matrix in spiral order
    
    T - O(n), where n is the number of elements in the martix
    S - O(n), where n is the size of the list created which depends on number of elements in matrix
*/
public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        List<int> spiralArray = new List<int>();
        int startColumn = 0;
        int startRow = 0;
        int endColumn = matrix[0].Length - 1;
        int endRow = matrix.Length - 1;
        
        while(startRow <= endRow && startColumn <= endColumn){
            for(int column = startColumn; column <= endColumn; column++){
                spiralArray.Add(matrix[startRow][column]);
            }
            
            for(int row = startRow + 1; row <= endRow; row++){
                spiralArray.Add(matrix[row][endColumn]);
            }
            
            if(startRow < endRow && startColumn < endColumn){
                for(int column = endColumn - 1; column > startColumn; column--){
                    spiralArray.Add(matrix[endRow][column]);
                }
            
                for(int row = endRow; row > startRow; row--){
                    spiralArray.Add(matrix[row][startColumn]);
                }   
            }
            
            startRow++;
            startColumn++;
            endRow--;
            endColumn--;
        }
        
        return spiralArray;
    }
}
