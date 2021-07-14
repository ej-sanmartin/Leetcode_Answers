/*
    Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
    
    T - O(4^n / square root of n)
    S - O(4^n / square root of n), with O(n) space to hold the sequence
*/
public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        List<string> output = new List<string>();
        GenerateParenthesisHelper(output, "", n, 0, 0);
        return output;
    }
    
    private void GenerateParenthesisHelper(List<string> list, string word, int maxOpen, int open, int closed){
        if(word.Length == maxOpen * 2){
            list.Add(word);
            return;
        }
        
        if(open < maxOpen) GenerateParenthesisHelper(list, word + "(", maxOpen, open + 1, closed);
        if(closed < open) GenerateParenthesisHelper(list, word + ")", maxOpen, open, closed + 1);
    }

    public IList<string> GenerateParenthesis(int n) {
        List<string> output = new List<string>();
        GenerateParenthesisHelper(output, "", n, n);
        return output;
    }
    
    private void GenerateParenthesisHelper(List<string> list, string word, int open, int closed){
        if(open < 0 || open > closed) return;
        if(open == 0 && closed == 0){
            list.Add(word);
            return;
        }
        
        GenerateParenthesisHelper(list, word + "(", open - 1, closed);
        GenerateParenthesisHelper(list, word + ")", open, closed - 1);
    }
}
