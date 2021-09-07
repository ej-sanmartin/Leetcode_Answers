/*
    Given a string s, return the longest palindromic substring in s.

    T - O(n^2), filling up dp table means we are bounded by n * n 
                sub solutions needed to solve globally optimal 
                solution
    S - O(n^2), to hold dp table which is of size n * n
*/
public class Solution {
    public string LongestPalindrome(string s) {
        int l = s.Length;
        bool[,] table = new bool[l, l];
        int maxLength = 1;
        int start = l - 1;
        
        for(int i = 0; i < l; i++){
            table[i, i] = true;
        }
        
        for(int i = 0; i < l - 1; i++){
            if(s[i] == s[i + 1]){
                table[i, i + 1] = true;
                if(maxLength == 1){
                    maxLength = 2;
                    start = i;
                }
            }
        }
        
        for(int width = 3; width <= l; width++){
            for(int i = 0; i <= l - width; i++){
                int j = i + width - 1;
                if(table[i + 1, j - 1] && s[i] == s[j]){
                    table[i, j] = true;
                    if(width > maxLength){
                        maxLength = width;
                        start = i;
                    }
                }
            }
        }
        
        return s.Substring(start, maxLength);
    }
}
