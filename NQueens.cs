/*
    The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two 
    queens attack each other.

    Given an integer n, return all distinct solutions to the n-queens puzzle. You may return the 
    answer in any order.

    Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and 
    '.' both indicate a queen and an empty space, respectively.

    T - O(N!)
    S - O(N^2), creating N * N board that keeps track of state of board
*/
public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        char[][] board = new char[n][];
        
        for(int row = 0; row < n; row++){
            board[row] = new char[n];
        }
        
        for(int row = 0; row < n; row++){
            for(int col = 0; col < n; col++){
                board[row][col] = '.';
            }
        }
        
        var output = new List<IList<string>>();
        DFS(board, 0, output);
        return output;
    }
    
    private void DFS(char[][] board, int col, List<IList<string>> list){
        if(col >= board.Length){
            list.Add(BuildBoard(board));
            return;
        }
        
        for(int i = 0; i < board.Length; i++){
            if(ValidateBoard(board, i, col)){
                board[i][col] = 'Q';
                DFS(board, col + 1, list);
                board[i][col] = '.';
            }
        }
    }
    
    private bool ValidateBoard(char[][] board, int x, int y){
        for(int row = 0; row < board.Length; row++){
            for(int col = 0; col < y; col++){
                if(board[row][col] == 'Q' && (x + col == y + row || x + y == row + col || x == row)){
                    return false;
                }
            }
        }
        return true;
    }
    
    private List<string> BuildBoard(char[][] board){
        List<string> result = new List<string>();
        
        for(int i = 0; i < board.Length; i++){
            string row = new String(board[i]);
            result.Add(row);
        }
        
        return result;
    }
}
