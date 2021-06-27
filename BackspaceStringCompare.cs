/*
  Given two strings s and t, return true if they are equal when both are typed into empty text editors. '#' means a backspace character.

  Note that after backspacing an empty text, the text will continue empty.

  T - O(n + m), as we only have to traverse through both strings
  S - O(1), as we are not creating any additional space
*/
public class Solution {
    public bool BackspaceCompare(string s, string t) {
        int sIndex = s.Length - 1;
        int tIndex = t.Length - 1;
        int sHashTagCount, tHashTagCount;
        sHashTagCount = tHashTagCount = 0;
        
        while(sIndex >= 0 || tIndex >= 0){
            while(sIndex >= 0){
                if(s[sIndex] == '#'){
                    sHashTagCount++;
                    sIndex--;
                } else if(sHashTagCount > 0){
                    sHashTagCount--;
                    sIndex--;
                } else {
                    break;
                }
            }
            
            while(tIndex >= 0){
                if(t[tIndex] == '#'){
                    tHashTagCount++;
                    tIndex--;
                } else if(tHashTagCount > 0){
                    tHashTagCount--;
                    tIndex--;
                } else {
                    break;
                }
            }
            
            if(sIndex >= 0 && tIndex >= 0 && s[sIndex] != t[tIndex]) return false;
            if((sIndex >= 0) != (tIndex >= 0)) return false;
            
            sIndex--;
            tIndex--;
        }
        
        return true;
    }
}
