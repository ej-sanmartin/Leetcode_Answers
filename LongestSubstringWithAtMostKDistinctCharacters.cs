/*
    Given a string s and an integer k, return the length of the longest 
    substring of s that contains at most k distinct characters.
    
    T - O(n), n being the input string's size, we go through each element once
    S - O(k), the dictionary created will be of size k + 1 since it will only 
              hold k + 1 distinct elements at worst case
*/
public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        if(s.Length == 0 || s == null || k == 0 || k == null){
            return 0;
        }
        
        if(s.Length == k){
            return k;
        }
        
        int maxLength = 1;
        int left = 0;
        Dictionary<char, int> table = new Dictionary<char, int>();
        
        for(int right = 0; right < s.Length; right++){
            char c = s[right];
            if(!table.ContainsKey(c)){
                table.Add(c, 0);
            }
            table[c]++;
            
            while(table.Count > k){
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
