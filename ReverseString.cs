/*
  Write a function that reverses a string. The input string is given as an array of characters char[].

  Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
*/

public class Solution {
    public void ReverseString(char[] s) {
        Stack sInput = new Stack();
        
        for(int i = 0; i < s.Length; i++){
            sInput.Push(s[i]);
        }
        
        for(int i = 0; i < s.Length; i++){
            s[i] = (char) sInput.Pop();
        }
    }
}
