/*
  Given two strings s and t , write a function to determine if t is an anagram of s.
*/

public class Solution {
    public bool IsAnagram(string s, string t) {
        Dictionary<char, int> characterHolder = new Dictionary<char, int>();
        
        // checks if inputs are equal, if not impossible to be anagrams
        if(s.Length != t.Length){
            return false;
        }
        
        // check for empty strings, will mess up last return value in this function if not checked
        if(s == "" && t == ""){
            return true;
        }
        
        // populate dictionary with count for each unique character in s
        for(int i = 0; i < s.Length; i++){
            if(characterHolder.ContainsKey(s[i])){
                characterHolder[s[i]]++;
            } else {
                characterHolder.Add(s[i], 1);
            }
        }
        
        // loops through t and subtracts from dictionarya
        for(int i = 0; i < t.Length; i++){
            if(!characterHolder.ContainsKey(t[i])){
                return false;
            } else {
                characterHolder[t[i]]--;   
            }
        }
        
        // should return true if there is only one kind of distinct value in dictionary (0 in this case), otherwise if there are more than 1 return false
        return characterHolder.Values.Distinct().Count() == 1;
    }
}
