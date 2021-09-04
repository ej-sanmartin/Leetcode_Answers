/*
    Given two strings text1 and text2, return the length of their longest common subsequence. If there 
    is no common subsequence, return 0.

    A subsequence of a string is a new string generated from the original string with some characters 
    (can be none) deleted without changing the relative order of the remaining characters.

    For example, "ace" is a subsequence of "abcde".
    A common subsequence of two strings is a subsequence that is common to both strings.
    
    T - O(nm), where n is the length of the first string and m is the length of the second. With memo,
               we fill out the memo with sub solutions equal to n*m space. After solution is found, 
               each call to those sub problems that has already been solved is cut down to constant 
               time
    S - O(nm), where we create a memo or dp table of size n and m. These hold all our sub solutions
*/
public class Solution {
    // top down solution
    public int LongestCommonSubsequence(string text1, string text2) {
        if(text1 == null || text1.Length == 0 || text2 == null || text.Length == 0){
            return 0;
        }
        int?[,] memo = new int?[text1.Length + 1, text2.Length + 1];
        return LCSRecursive(text1, text2, 0, 0, memo);
    }
    
    public int LCSRecursive(string s1, string s2, int indexOne, int indexTwo, int?[,] memo){
        if(indexOne >= s1.Length || indexTwo >= s2.Length){
            return 0;
        }
        
        if(memo[indexOne, indexTwo] == null){
            if(s1[indexOne] == s2[indexTwo]){
                memo[indexOne, indexTwo] = 1 + LCSRecursive(s1, s2, indexOne + 1, indexTwo + 1, memo);
            } else {
                int lengthOne = LCSRecursive(s1, s2, indexOne + 1, indexTwo, memo);
                int lengthTwo = LCSRecursive(s1, s2, indexOne, indexTwo + 1, memo);
                memo[indexOne, indexTwo] = Math.Max(lengthOne, lengthTwo);
            }
        }
        
        return (int)memo[indexOne, indexTwo];
    }

    // Bottom up solution
    public int LongestCommonSubsequence(string text1, string text2){
        if(text1 == null || text1.Length == 0 || text2 == null || text2.Length == 0){
            return 0;
        }
        
        int[,] table = new int[text1.Length + 1, text2.Length + 1];
        
        for(int i = 1; i <= text1.Length; i++){
            for(int j = 1; j <= text2.Length; j++){
                if(text1[i - 1] == text2[j - 1]){
                    table[i, j] = 1 + table[i - 1, j - 1];
                } else {
                    table[i, j] = Math.Max(table[i - 1, j], table[i, j - 1]);
                }
            }
        }
        
        return table[text1.Length, text2.Length];
    }
}
