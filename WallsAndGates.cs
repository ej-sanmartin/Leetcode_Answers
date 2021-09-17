/*
    You are given an m x n grid rooms initialized with these three possible values.

    -1 A wall or an obstacle.
    0 A gate.
    INF Infinity means an empty room. We use the value 231 - 1 = 2147483647 to 
        represent INF as you may assume that the distance to a gate is less than 
        2147483647.

    Fill each empty room with the distance to its nearest gate. If it is impossible to 
    reach a gate, it should be filled with INF.

    T - O(mn), to visit all cells which we will have to do at worst case at least once
    S - O(mn), our queue can hold all elements in the grid input at worst case
*/
public class Solution {
    private int[][] directions = new int[][]{new int[]{-1, 0}, new int[]{0, -1}, new int[]{1, 0}, new int[]{0, 1}};
    
    public void WallsAndGates(int[][] rooms) {
        if(rooms.Length == 0 || rooms[0].Length == 0) return;
        
        Queue<int[]> q = new Queue<int[]>();
        
        for(int row = 0; row < rooms.Length; row++){
            for(int col = 0; col < rooms[row].Length; col++){
                if(rooms[row][col] == 0){
                    q.Enqueue(new int[]{row, col});
                }
            }
        }
        
        while(q.Count != 0){
            int[] current = q.Dequeue();
            int row = current[0];
            int col = current[1];
            foreach(int[] direction in directions){
                int newRow = row + direction[0];
                int newCol = col + direction[1];
                if(IsValid(rooms, newRow, newCol)){
                    rooms[newRow][newCol] = rooms[row][col] + 1;
                    q.Enqueue(new int[]{newRow, newCol});
                }
            }
        }
    }

    private bool IsValid(int[][] grid, int row, int col){
        if(row < 0 || col < 0 || row >= grid.Length || col >= grid[row].Length){
            return false;
        }
        if(grid[row][col] != Int32.MaxValue){
            return false;
        }
        return true;
    }
}
