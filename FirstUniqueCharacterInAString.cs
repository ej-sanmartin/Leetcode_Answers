/*
  Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.
*/

public class Solution {
    public int FirstUniqChar(string s) {
        Dictionary<char, int> characterCount = new Dictionary<char, int>();
        
        for(int i = 0; i < s.Length; i++){
            if(characterCount.ContainsKey(s[i])){
                characterCount[s[i]]++;
            } else {
                characterCount.Add(s[i], 1);
            }
        }
        
        for(int i = 0; i < s.Length; i++){
            if(characterCount[s[i]] == 1){
                return i;
            }
        }
        
        return -1;
    }
}
