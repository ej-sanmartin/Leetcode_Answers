/** UPDATED 2021 ANSWER **/ 
/*
    Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

    Symbol       Value
    I             1
    V             5
    X             10
    L             50
    C             100
    D             500
    M             1000
    
    For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which 
    is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

    Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is 
    not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making 
    four. The same principle applies to the number nine, which is written as IX. There are six instances where 
    subtraction is used:

    I can be placed before V (5) and X (10) to make 4 and 9. 
    X can be placed before L (50) and C (100) to make 40 and 90. 
    C can be placed before D (500) and M (1000) to make 400 and 900.
    Given a roman numeral, convert it to an integer.


    T - O(n), as we must past through the entire string to get its numerical equivalent
    S - O(1), as roman table dictionary will always be same size
*/
public class Solution {
    public int RomanToInt(string s) {
        Dictionary<char, int> romanTable = CreateRomanTable();
        
        int sum = 0;
        
        for(int i = 0; i < s.Length; i++){
            if(i == s.Length - 1) sum += romanTable[s[i]];
            else if(romanTable[s[i]] < romanTable[s[i + 1]]) sum += romanTable[s[i + 1]] - romanTable[s[i++]];
            else sum += romanTable[s[i]];
        }
        
        return sum;
    }
    
    private Dictionary<char, int> CreateRomanTable(){
        Dictionary<char, int> romanTable = new Dictionary<char, int>();
        
        romanTable.Add('M', 1000);
        romanTable.Add('D', 500);
        romanTable.Add('C', 100);
        romanTable.Add('L', 50);
        romanTable.Add('X', 10);
        romanTable.Add('V', 5);
        romanTable.Add('I', 1);
        
        return romanTable;
    }
}

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
