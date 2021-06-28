/*
`   Write a function to find the longest common prefix string amongst an array of strings.

    If there is no common prefix, return an empty string "".

    T - O(S), where at worst case we have to traverse through every string up until the length of the
              smallest string in the list
    S - O(1), constant since the only space we are creating is the output space with the 
              longestCommonPrefix
*/
public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if(strs.Length == 0 || strs == null) return "";
        
        string longestCommonPrefix = "";
        int index = 0;
        
        foreach(char c in strs[0].ToCharArray()){
            for(int i = 1; i < strs.Length; i++){
                if(index >= strs[i].Length || c != strs[i][index]) return longestCommonPrefix;
            }
            longestCommonPrefix += c;
            index++;
        }
        
        return longestCommonPrefix;
    }
}
