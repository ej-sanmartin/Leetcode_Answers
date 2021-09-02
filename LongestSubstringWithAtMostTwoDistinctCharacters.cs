/*
    Given a string s, return the length of the longest substring that 
    contains at most two distinct characters.
    
    T - O(n), n being the size of the input string. We traverse through 
              each element in string once
    S - O(1), we create a dictionary but that dictionary will ever be 
              at most size of 3
*/
public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        if(s.Length == 0 || s == null){
            return 0;
        }
        
        int left = 0;
        int maxLength = 1;
        Dictionary<char, int> table = new Dictionary<char, int>();
        
        for(int right = 0; right < s.Length; right++){
            char c = s[right];
            if(!table.ContainsKey(c)){
                table.Add(c, 0);
            }
            table[c]++;
            while(table.Count > 2){
                char leftChar = s[left++];
                table[leftChar]--;
                if(table[leftChar] == 0){
                    table.Remove(leftChar);
                }
            }
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        
        return maxLength;
    }
}
