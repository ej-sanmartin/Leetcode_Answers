/*
    Given a string s, return true if the s can be palindrome after deleting at most one character from 
    it.

    T - O(3n) -> O(n), we must traverse through n length of the s
    S - O(1), as no additional space that is dependent on the size of the input is created
*/
public class Solution {
    public bool ValidPalindrome(string s) {
        int left = 0;
        int right = s.Length - 1;
        
        while(left < right){
            if(s[left] != s[right]){
                return IsPalindrome(s, left + 1, right) || IsPalindrome(s, left, right - 1);
            }
            left++;
            right--;
        }
        
        return true;
    }
    
    private bool IsPalindrome(string s, int left, int right){
        while(left < right){
            if(s[left] != s[right]) return false;
            left++;
            right--;
        }
        return true;
    }
}
