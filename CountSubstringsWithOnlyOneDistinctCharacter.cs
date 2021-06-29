/*
    Given a string s, return the number of substrings that have only one distinct letter.

    T - O(n), traverse through length of the string
    S - O(1), we are not creating any variables or space that is dependent on our input size
*/
public class Solution {
    public int CountLetters(string s) {
        int total, substringLength;
        total = 0;
        
        for(int left = 0, right = 0; right <= s.Length; right++){
            if(right == s.Length || s[left] != s[right]){
                substringLength = right - left;
                total += (1 + substringLength) * substringLength / 2; // sum equations of arithmatic sequence
                left = right;
            }
        }
        
        return total;
    }
}
