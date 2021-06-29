/*
  Given a string s and an integer array indices of the same length.

  The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.

  Return the shuffled string.
  
  T - O(n), looping through entire length of indicies array that maps to indices on the scrambled s string
  S - O(n), size of char array created to hold answer, equal to the length of the s string
*/
public class Solution {
    public string RestoreString(string s, int[] indices) {
        char[] answer = new char[s.Length];
        
        for(int i = 0; i < indices.Length; i++){
            answer[indices[i]] = s[i];
        }
        
        return String.Join("", answer);
    }
}
