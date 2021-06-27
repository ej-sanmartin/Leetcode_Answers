/*
    Given two strings s and t, return true if s is a subsequence of t, or false otherwise.

    A subsequence of a string is a new string that is formed from the original string by deleting some (can be none) 
    of the characters without disturbing the relative positions of the remaining characters. (i.e., "ace" is a 
    subsequence of "abcde" while "aec" is not).

    T - O(n), as we must traverse through the length of t string, every character, in worst case
    S - O(1), we are only creating the int variable sIndex to check for subsequence
*/
public class Solution {
    public bool IsSubsequence(string s, string t) {
        if(s.Length == 0) return true;
        if(s.Length > t.Length) return false;
        
        int sIndex = 0;
        
        for(int i = 0; i < t.Length; i++){
            if(t[i] == s[sIndex]) sIndex++;
            if(sIndex == s.Length) return true;
        }
        
        return false;
    }
}
