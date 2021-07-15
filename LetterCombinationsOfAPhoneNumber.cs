/*
    Given a string containing digits from 2-9 inclusive, return all possible letter 
    combinations that the number could represent. Return the answer in any order.

    A mapping of digit to letters (just like on the telephone buttons) is given below. 
    Note that 1 does not map to any letters.
    
    T - O(4^n), as at worst case we are exploring 4 "paths" for n number of digits 
    S - O(n), where n is the length of digits and the depth of the recursive call stack
*/
public class Solution {
    public IList<string> LetterCombinations(string digits){
        if(digits.Length == 0 || digits == null) return new List<string>();
        Dictionary<char, string> table = createDigitsMapping();
        List<string> result = new List<string>();
        LetterCombinationsHelper("", digits, 0, result, table);
        return result;
    }

    private void LetterCombinationsHelper(string word, string digits, int index,  List<string> list, Dictionary<char, string> table){
	    if(word.Length == digits.Length){
  	        list.Add(word);
        } else {
  	        string s = table[digits[index]];
  	        for(int i = 0; i < s.Length; i++){
			    LetterCombinationsHelper(word + s[i], digits, index + 1, list, table);
            }
        }  
    }

    private Dictionary<char, string> createDigitsMapping(){
	    Dictionary<char, string> table = new Dictionary<char, string>();
        table.Add('2', "abc");
        table.Add('3', "def");
        table.Add('4', "ghi");
        table.Add('5', "jkl");
        table.Add('6', "mno");
        table.Add('7', "pqrs");
        table.Add('8', "tuv");
        table.Add('9', "wxyz");
        return table;
    }
}
