/*
  Implement function ToLowerCase() that has a string parameter str, and returns the same string in lowercase.
*/

public class Solution {
    public string ToLowerCase(string str) {
        StringBuilder answer = new StringBuilder(str);
        
        for(int i = 0; i < str.Length; i++){
            int ascii = (int) str[i];
            
            if(Char.IsLower(str[i]) || ascii < 65 || ascii > 122){
                continue;
            }
            
            ascii += 32;
            char currentLetter = (char) ascii;
            answer.Replace(answer[i], currentLetter);
        }
        return answer.ToString();
    }
}
