/*
    Given a string s, return the number of palindromic substrings in it.

    A string is a palindrome when it reads the same backward as forward.

    A substring is a contiguous sequence of characters within the string.

    T - O(n^2), we are checking from the end of the string and stretching leftward,
                finding all the palindromic and conitgious substrings. We do not have 
                to recalculate a sub solution when we come across it thus reducing 
                time complexity from O(2^n) to O(n^2)
    S - O(n^2), dp table needs n * n space for creation. N being size of input string
*/
public class Solution {
    public int CountSubstrings(string s) {
        int l = s.Length;
        bool[,] table = new bool[l, l];
        int count = 0;
        
        for(int i = 0; i < l; i++){
            table[i, i] = true;
            count++;
        }
        
        for(int start = l - 1; start >= 0; start--){
            for(int end = start + 1; end < l; end++){
                if(s[start] == s[end]){
                    if(end - start == 1 || table[start + 1, end - 1]){
                        table[start, end] = true;
                        count++;
                    }
                }
            }
        }
        
        return count;
    }
}
