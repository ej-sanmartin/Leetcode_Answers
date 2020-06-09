/*
  Given a roman numeral, convert it to an integer. Input is guaranteed to be within the range from 1 to 3999.
*/

public class Solution {
    public int RomanToInt(string s) {
        // creates dictionary where all roman numberals and arabic numeral counterparts are contained
        Dictionary<char, int> romanSymbolValues = new Dictionary<char, int>{
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
        
        int answer = 0; // answer
        int previous = 0; // reference to previous romanNumber that was iterated through
        int romanNumber = 0;
    
        // goes from last character to first, if the answer is larger than calculated roman numeral and the roman numeral is not
        // the same as the previous number iterated, it must be a case such as IX or CM and we must subtract from answer and
        // set new previous value. Otherwise, increment answer and set new previous value.
        for(int i = s.Length - 1; i >= 0; i--){
            romanNumber = romanSymbolValues[s[i]];
            if(answer > romanNumber && previous != romanNumber){
                answer -= romanNumber;
                previous = romanNumber;
            } else {
                answer += romanNumber;
                previous = romanNumber;
            }
        }
        
        return answer;
    }
}
