/*
  Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.

  T - O(n), must traverse through length of the string to find vowels and remove them
  S - O(n), the stack and the stringbuilder use up space that, at worst case, will hold the entirety of
            the string
*/
public class Solution {
    public string RemoveVowels(string s) {
        Stack<char> stack = new Stack<char>();
        StringBuilder sb = new StringBuilder();
        
        for(int i = s.Length - 1; i >= 0; i--){
            if(s[i] != 'a' && s[i] != 'e' && s[i] != 'i' && s[i] != 'o' && s[i] != 'u'){
                stack.Push(s[i]);
            }
        }
        
        while(stack.Count != 0){
            sb.Append(stack.Pop());
        }
        
        return sb.ToString();
    }
}
