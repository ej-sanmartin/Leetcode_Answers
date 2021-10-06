/*
    Given an m x n matrix board where each cell is a battleship 'X' or empty '.', return the number of 
    the battleships on board.

    Battleships can only be placed horizontally or vertically on board. In other words, they can only be 
    made of the shape 1 x k (1 row, k columns) or k x 1 (k rows, 1 column), where k can be of any size.   
    At least one horizontal or vertical cell separates between two battleships (i.e., there are no 
    adjacent battleships).

    T - O(mn), as we must go through all cells in battleship board once
    S - O(k * 1 or k), DFS creates a call stack the size of largest battleship on field
*/
public class Solution {
    private int[][] _directions;
    
    public int CountBattleships(char[][] board) {
        if (board.Length == 0 || board == null) {
            return 0;
        }
        
        _directions = new int[][]{new int[]{-1, 0}, new int[]{0, -1}, new int[]{1, 0}, new int[]{0, 1}};
        
        int rows = board.Length;
        int cols = board[0].Length;
        int count = 0;
        
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                if (board[row][col] == 'X') {
                    count++;
                    SinkShip(board, row, col);
                }
            }
        }
        
        return count;
    }
    
    private void SinkShip(char[][] board, int row, int col) {
        if (IsOutOfBounds(board, row, col)) {
            return;
        }
        
        if (board[row][col] == '.') {
            return;
        }
        
        board[row][col] = '.';
        
        foreach (int[] adjacent in _directions) {
            int adjacentRow = row + adjacent[0];
            int adjacentCol = col + adjacent[1];
            SinkShip(board, adjacentRow, adjacentCol);
        }
    }
    
    private bool IsOutOfBounds(char[][] board, int row, int col) {
        if(row < 0 || col < 0 || row >= board.Length || col >= board[row].Length){
            return true;
        }
        return false;
    }
}
