public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        if(matrix.Length == 0 || matrix == null){
            return false;
        }
        int n = matrix[0].Length;
        int low = 0;
        int high = (matrix.Length * n) - 1;
        
        while(low <= high){
            int mid = low + ((high - low) / 2);
            int midRow = mid / n;
            int midCol = mid % n;
            int current = matrix[midRow][midCol];
            if(current > target){
                high = mid - 1;
            } else if(current < target){
                low = mid + 1;
            } else {
                return true;
            }
        }
        
        return false;
    }
}
