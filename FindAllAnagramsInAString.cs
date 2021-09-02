/*
    Given two strings s and p, return an array of all the start indices of p's 
    anagrams in s. You may return the answer in any order.

    An Anagram is a word or phrase formed by rearranging the letters of a 
    different word or phrase, typically using all the original letters exactly 
    once.

    T - O(n + m), n being length of s and m being length of p. We will be 
                  traversing through both strings
    S - O(1),     int array created to keep track of chars in pattern will 
                  never exceed length of 26
*/
public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        List<int> anagrams = new List<int>();
        if(s.Length == 0 || s == null || p.Length == 0 || p == null){
            return anagrams;
        }
        
        int[] alphabet = new int[26];
        foreach(char c in p.ToCharArray()){
            alphabet[c - 'a']++;
        }
        
        int left = 0;
        int length = p.Length;
        int difference = length;
        
        char temp;
        for(int right = 0; right < s.Length; right++){
            if(right - left >= length){
                temp = s[left++];
                alphabet[temp - 'a']++;
                if(alphabet[temp - 'a'] > 0){
                    difference++;
                }
            }
            
            temp = s[right];
            alphabet[temp - 'a']--;
            if(alphabet[temp - 'a'] >= 0){
                difference--;
            }
            
            if(difference == 0){
                anagrams.Add(left);
            }
        }
        
        return anagrams;
    }
}
