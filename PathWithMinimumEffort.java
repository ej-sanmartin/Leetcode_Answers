/*  
    You are a hiker preparing for an upcoming hike. You are given heights, a 2D array of 
    size rows x columns, where heights[row][col] represents the height of cell (row, col). You are situated in the top-
    left cell, (0, 0), and you hope to travel to the bottom-right cell, (rows-1, columns-1) (i.e., 0-indexed). You can 
    move up, down, left, or right, and you wish to find a route that requires the minimum effort.

    A route's effort is the maximum absolute difference in heights between two consecutive cells of the route.

    Return the minimum effort required to travel from the top-left cell to the bottom-right cell.

    Note: m is row, n is col
    T - O(mnlogmn), mn to visit all cells in martix and logmn for maintaining pq
    S - O(mn), pq can hold, at worst case, all cells in mn
*/
class Solution {
    public int minimumEffortPath(int[][] heights) {
        int[][] directions = new int[][]{{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
        int row = heights.length;
        int col = heights[0].length;
        int[][] differenceMatrix = new int[row][col];
        for(int[] eachRow : differenceMatrix){
            Arrays.fill(eachRow, Integer.MAX_VALUE);
        }
        differenceMatrix[0][0] = 0;
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> a[2] -b[2]);
        boolean[][] visited = new boolean[row][col];
        pq.offer(new int[]{0, 0, differenceMatrix[0][0]});
        while(!pq.isEmpty()){
            int[] current = pq.poll();
            int currentRow = current[0];
            int currentCol = current[1];
            int currentEffort = current[2];
            if(currentRow == row - 1 && currentCol == col - 1){
                return currentEffort;
            }
            for(int[] direction : directions){
                int adjacentRow = currentRow + direction[0];
                int adjacentCol = currentCol + direction[1];
                if(IsValidCell(adjacentRow, adjacentCol, row, col) && !visited[adjacentRow][adjacentCol]){
                    int adjacentEffort = Math.abs(heights[adjacentRow][adjacentCol] - heights[currentRow][currentCol]);
                    int maxDifference = Math.max(adjacentEffort, differenceMatrix[currentRow][currentCol]);
                    if(maxDifference < differenceMatrix[adjacentRow][adjacentCol]){
                        differenceMatrix[adjacentRow][adjacentCol] = maxDifference;
                        pq.offer(new int[]{adjacentRow, adjacentCol, maxDifference});
                    }
                }
            }
        }
        return differenceMatrix[row - 1][col - 1];
    }
    
    private boolean IsValidCell(int newRow, int newCol, int row, int col){
        if(newRow < 0 || newCol < 0 || newRow >= row || newCol >= col){
            return false;
        }
        return true;
    }
}
