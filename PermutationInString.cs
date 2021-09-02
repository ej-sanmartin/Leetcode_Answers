/*
    Given two strings s1 and s2, return true if s2 contains a permutation of 
    s1, or false otherwise.

    In other words, return true if one of s1's permutations is the substring 
    of s2.

    T - O(n + m), n being the length of s1, m being the length of s2. We 
                  traverse through both strings once
    S - O(1), as we are not creating any additional space that is dependent on 
              the inputs. Even the integer array of size 26 is constantly 
              bounded by the fact is will always be of size 26, the amount of 
              letters in the latin alphabet
*/
public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if(s2.Length == 0 || s2 == null){
            return false;
        }
        
        int[] alphabet = new int[26];
        foreach(char c in s1.ToCharArray()){
            alphabet[c - 'a']++;
        }
        
        int left = 0;
        int length = s1.Length;
        int difference = length;
        
        char temp;
        for(int right = 0; right < s2.Length; right++){
            if(right - left >= length){
                temp = s2[left++];
                alphabet[temp - 'a']++;
                if(alphabet[temp - 'a'] > 0){
                    difference++;
                }
            }
            
            temp = s2[right];
            alphabet[temp - 'a']--;
            if(alphabet[temp - 'a'] >= 0){
                difference--;
            }
            
            if(difference == 0){
                return true;
            }
        }
        
        return false;
    }
}
