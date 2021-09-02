/*
    Given two strings s and t of lengths m and n respectively, return the minimum window 
    substring of s such that every character in t (including duplicates) is included in the 
    window. If there is no such substring, return the empty string "".

    The testcases will be generated such that the answer is unique.

    A substring is a contiguous sequence of characters within the string.

    T - O(n + m), n being size of s string, m being size of t string. We traverse through 
                  all elements of both strings once
    S - O(1),     constant space as we do not create any additional space in program that is 
                  dependent on the input size. Integer array of 58 is also bounded by the  
                  fact it is of size 58 which is able to hold both upper and lowercase 
                  letters
*/
public class Solution {
    public string MinWindow(string s, string t) {
        if(s.Length == 0 || s == null || t.Length == 0 || t == null || t.Length > s.Length){
            return "";
        }
        
        int[] alphabet = new int[58];
        foreach(char c in t.ToCharArray()){
            alphabet[c - 'A']++;
        }
        
        int left = 0;
        int length = t.Length;
        int difference = length;
        int minLength = Int32.MaxValue;
        int minStart = -1;
        int minEnd = -1;
        
        char temp;
        for(int right = 0; right < s.Length; right++){
            temp = s[right];
            alphabet[temp - 'A']--;
            if(alphabet[temp - 'A'] >= 0){
                difference--;
            }
            
            while(difference <= 0){
                if(right - left + 1 < minLength){
                    minLength = right - left + 1;
                    minStart = left;
                    minEnd = right;
                }
                
                temp = s[left++];
                alphabet[temp - 'A']++;
                if(alphabet[temp - 'A'] > 0){
                    difference++;
                }
            }
        }
        
        return minStart == -1 ? "" : s.Substring(minStart, minEnd - minStart + 1);
    }
}
