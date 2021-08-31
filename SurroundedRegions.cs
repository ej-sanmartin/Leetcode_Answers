/*
    Given an m x n matrix board containing 'X' and 'O', capture all regions that are 
    4-directionally surrounded by 'X'.

    A region is captured by flipping all 'O's into 'X's in that surrounded region.

    T - O(N), as at worst case we will be traversing through all the cells
    S - O(N), as the recursive call stack can be at a max depth of every cell in board
*/
public class Solution {
    public void Solve(char[][] board) {
        if(board.Length == 0 || board == null){
            return;
        }
        
        // top
        for(int i = 0; i < board[0].Length; i++){
            if(board[0][i] == 'O'){
                DFS(0, i, board);
            }
        }
        
        // bottom
        for(int i = 0; i < board[board.Length - 1].Length; i++){
            if(board[board.Length - 1][i] == 'O'){
                DFS(board.Length - 1, i, board);
            }
        }
        
        // left
        for(int i = 0; i < board.GetLength(0); i++){
            if(board[i][0] == 'O'){
                DFS(i, 0, board);
            }
        }
        
        // right
        for(int i = 0; i < board.GetLength(0); i++){
            if(board[i][board[i].Length - 1] == 'O'){
                DFS(i, board[i].Length - 1, board);
            }
        }
        
        for(int row = 0; row < board.GetLength(0); row++){
            for(int col = 0; col < board[row].Length; col++){
                if(board[row][col] == 'O'){
                    board[row][col] = 'X';
                }
                if(board[row][col] == 'E'){
                    board[row][col] = 'O';
                }
            }
        }
    }
    
    public void DFS(int row, int col, char[][] board){
        if(IsOutOfBounds(row, col, board)){
            return;
        }
        
        if(board[row][col] == 'X' || board[row][col] == 'E'){
            return;
        }
        
        board[row][col] = 'E';
        
        DFS(row + 1, col, board);
        DFS(row - 1, col, board);
        DFS(row, col + 1, board);
        DFS(row, col - 1, board);
    }
    
    public bool IsOutOfBounds(int row, int col, char[][] board){
        if(row < 0 || col < 0 || row >= board.Length || col >= board[row].Length){
            return true;
        }
        return false;
    }
}
