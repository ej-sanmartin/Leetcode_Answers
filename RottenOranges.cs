/*
    You are given an m x n grid where each cell can have one of three values:

    0 representing an empty cell,
    1 representing a fresh orange, or
    2 representing a rotten orange.

    Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.

    Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is 
    impossible, return -1.
    
    T - O(n), n being the number of cells in the grid, which at worst case we traverse through all
    S - O(n), queue can be filled with all cells if entire grid is just rotten oranges
*/
public class Solution {
    int freshOrange;
    public int OrangesRotting(int[][] grid) {
        int[,] directions = new int[,]{{-1, 0}, {0, -1}, {1, 0}, {0, 1}};
        Queue<int[]> q = new Queue<int[]>();
        int time = -1;
        freshOrange = 0;
        foreach(int[] rottenOrange in FindRottenOrange(grid)){
            q.Enqueue(new int[]{rottenOrange[0], rottenOrange[1]});
        }
        while(q.Count != 0){
            int[] current = q.Dequeue();
            int row = current[0];
            int col = current[1];
            if(row == -1){
                time++;
                if(q.Count != 0) q.Enqueue(new int[]{-1, -1});
                continue;
            }
            foreach(int[] adjacent in GetAdjacent(grid, row, col, directions)){
                int adjacentRow = adjacent[0];
                int adjacentCol = adjacent[1];
                if(grid[adjacentRow][adjacentCol] != 1) continue;
                grid[adjacentRow][adjacentCol] = 2;
                freshOrange--;
                q.Enqueue(new int[]{adjacentRow, adjacentCol});
            }
        }
        
        return freshOrange == 0 ? time : -1;
    }
    
    private List<int[]> FindRottenOrange(int[][] grid){
        List<int[]> rotten = new List<int[]>();
        for(int row = 0; row < grid.Length; row++){
            for(int col = 0; col < grid[row].Length; col++){
                if(grid[row][col] == 2) rotten.Add(new int[]{row, col});
                if(grid[row][col] == 1) freshOrange++;
            }
        }
        rotten.Add(new int[]{-1, -1}); // signal end of a layer
        return rotten;
    }
    
    private List<int[]> GetAdjacent(int[][] grid, int row, int col, int[,] directions){
        List<int[]> adjacent = new List<int[]>();
        for(int i = 0;i < directions.GetLength(0); i++){
            int newRow = row + directions[i,0];
            int newCol = col + directions[i,1];
            if(IsNotValid(grid, newRow, newCol)) continue;
            adjacent.Add(new int[]{newRow, newCol});
        }
        return adjacent;
    }
    
    private bool IsNotValid(int[][] grid, int row, int col){
        if(row < 0 || col < 0 || row >= grid.Length || col >= grid[row].Length || grid[row][col] != 1){
            return true;
        }
        return false;
    }
}
