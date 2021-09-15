/*
    Given an n x n binary matrix grid, return the length of the shortest clear path in the matrix. If there is 
    no clear path, return -1.

    A clear path in a binary matrix is a path from the top-left cell (i.e., (0, 0)) to the bottom-right cell   
    (i.e., (n - 1, n - 1)) such that:

    All the visited cells of the path are 0.
    All the adjacent cells of the path are 8-directionally connected (i.e., they are different and they share 
        an edge or a corner).

    The length of a clear path is the number of visited cells of this path.

    T - O(n), worst case we go through every cell which is n number of cells
    S - O(n), visited bool multi dimensional array holds n number of cells, which are all blocks in grid
*/
public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        int[,] directions =  new int[,]{{-1, -1}, {-1, 0}, {-1, 1}, {0, -1}, {0, 1}, {1, -1}, {1, 0}, {1, 1}};
        int n = grid.GetLength(0);
        if(grid[0][0] != 0 || grid[n - 1][n - 1] != 0) return -1;
        Queue<int[]> q = new Queue<int[]>(); // int[]{row, col, distance}
        bool[,] visited = new bool[n, n];
        visited[0,0] = true;
        q.Enqueue(new int[]{0, 0, 1});
        
        while(q.Count != 0){
            int[] cell = q.Dequeue();
            int row = cell[0];
            int col = cell[1];
            int distance = cell[2];
            if(row == n - 1 && col == n - 1) return distance;
            foreach(int[] adjacent in GetAdjacent(grid, row, col, directions)){
                int adjacentRow = adjacent[0];
                int adjacentCol = adjacent[1];
                if(visited[adjacentRow, adjacentCol]){
                    continue;
                }
                visited[adjacentRow, adjacentCol] = true;
                q.Enqueue(new int[]{adjacentRow, adjacentCol, distance + 1});
            }
        } 
        return -1;
    }
    
    private List<int[]> GetAdjacent(int[][] grid, int row, int col, int[,] directions){
        List<int[]> adjacent = new List<int[]>();
        for(int i = 0; i < directions.GetLength(0); i++){
            int newRow = row + directions[i,0];
            int newCol = col + directions[i,1];
            if(IsOutOfBounds(grid, newRow, newCol)){
                continue;
            }
            adjacent.Add(new int[]{newRow, newCol});
        }
        return adjacent;
    }
    
    private bool IsOutOfBounds(int[][] grid, int row, int col){
        if(row < 0 || col < 0 || row >= grid.Length || col >= grid[row].Length || grid[row][col] != 0){
            return true;
        }
        return false;
    }
}
