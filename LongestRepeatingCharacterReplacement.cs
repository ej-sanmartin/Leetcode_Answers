/*   
    You are given a string s and an integer k. You can choose any character of 
    the string and change it to any other uppercase English character. You can 
    perform this operation at most k times.

    Return the length of the longest substring containing the same letter you 
    can get after performing the above operations.

    T - O(n), n being the size of input string, we traverse through all chars
    S - O(1), we don't make any additional space that is dependent on inputs
*/
public class Solution {
    public int CharacterReplacement(string s, int k) {
        if(s == null || s.Length == 0){
            return 0;
        }
        
        int left = 0;
        int maxCount = 0;
        int maxLength = 1;
        int[] counts = new int[26];
        
        for(int right = 0; right < s.Length; right++){
            char c = s[right];
            counts[c - 'A']++;
            maxCount = Math.Max(maxCount, counts[c - 'A']);
            
            while(right - left - maxCount + 1 > k){
                counts[s[left++] - 'A']--;
            }
            
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        
        return maxLength;
    }
}
