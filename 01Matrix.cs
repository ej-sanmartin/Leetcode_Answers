/*
    Given an m x n binary matrix mat, return the distance of the nearest 0 for each cell.

    The distance between two adjacent cells is 1.

    T - O(nm), can be c where c is all the cells. nm is the same as we will be processing each cell
    S - O(nm), queue can, at worst case, hold all cells 
*/
public class Solution {
    public int[][] UpdateMatrix(int[][] mat) {
        int rows = mat.Length;
        int cols = mat[0].Length;
        if(rows == 0 || cols == 0 || mat == null){
            return mat;
        }
        
        Queue<int[]> q = new Queue<int[]>();
        for(int row = 0; row < rows; row++){
            for(int col = 0; col < cols; col++){
                if(mat[row][col] == 0){
                    q.Enqueue(new int[]{row, col});
                } else {
                    mat[row][col] = Int32.MaxValue;
                }
            }
        }
        
        int[][] directions = new int[4][]{ new int[]{-1, 0}, new int[]{0, -1}, new int[]{1, 0}, new int[]{0, 1}};
        while(q.Count != 0){
            int[] current = q.Dequeue();
            int row = current[0];
            int col = current[1];
            foreach(int[] direction in directions){
                int newRow = row + direction[0];
                int newCol = col + direction[1];
                if(IsValid(mat, newRow, newCol)){
                    if(mat[newRow][newCol] > mat[row][col]){
                        mat[newRow][newCol] = mat[row][col] + 1;
                        q.Enqueue(new int[]{newRow, newCol});
                    }
                }
            }
        }
        
        return mat;
    }
    
    private bool IsValid(int[][] grid, int row, int col){
        if(row < 0 || col < 0 || row >= grid.Length || col >= grid[row].Length){
            return false;
        }
        return true;
    }
}
