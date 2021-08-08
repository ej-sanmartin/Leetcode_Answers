/*
  Given a string s and a dictionary of strings wordDict, return true if s can be segmented
  into a space-separated sequence of one or more dictionary words.

  Note that the same word in the dictionary may be reused multiple times in the segmentation.
  
  T - O(n^3), due to the nested for loops and Substring method
  S - O(n), due to space used by table array to store sub solutions
*/
public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        bool[] table = new bool[s.Length + 1];
        table[0] = true;
        
        for(int i = 1; i <= s.Length; i++){
            for(int j = 0; j < i; j++){
                if(table[j] && wordDict.Contains(s.Substring(j, i - j))){
                    table[i] = true;
                    break;
                }
            }
        }
        
        return table[s.Length];
    }
}
