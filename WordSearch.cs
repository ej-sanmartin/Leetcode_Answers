/*
    Given an m x n grid of characters board and a string word, return true if 
    word exists in the grid.

    The word can be constructed from letters of sequentially adjacent cells, 
    where adjacent cells are horizontally or vertically neighboring. The same 
    letter cell may not be used more than once.
    
    T - O(N), as we must traverse through every cell at worst case if we can't 
              find word
    S - O(N), depends on recursive stack. Worst case, as long as every cell if 
              the word is somehow that long
*/
public class Solution {
    public bool Exist(char[][] board, string word) {
        if(board == null || board.Length == 0){
            return false;
        }
        
        for(int row = 0; row < board.Length; row++){
            for(int col = 0; col < board[row].Length; col++){
                if(board[row][col] == word[0]){
                    if(DFS(row, col, board, word, 0)) return true;
                }
            }
        }
        
        return false;
    }
    
    public bool DFS(int row, int col, char[][] board, string word, int index){
        if(index >= word.Length){
            return true;
        }
        
        if(IsOutOfBounds(row, col, board)){
            return false;
        }
        
        if(board[row][col] == '.'){
            return false;
        }
        
        if(board[row][col] != word[index]){
            return false;
        }
        
        char current = board[row][col];
        board[row][col] = '.';
        
        bool top = DFS(row + 1, col, board, word, index + 1);
        bool bottom = DFS(row - 1, col, board, word, index + 1);
        bool left = DFS(row, col - 1, board, word, index + 1);
        bool right = DFS(row, col + 1, board, word, index + 1);
        
        board[row][col] = current;
        
        return top || bottom || left || right;
    }
    
    public bool IsOutOfBounds(int row, int col, char[][] grid){
        if(row < 0 || col < 0 || row >= grid.Length || col >= grid[row].Length){
            return true;
        }
        return false;
    }
}
