/*
  You are given a string s consisting of lowercase English letters. A duplicate removal consists of choosing two adjacent and equal letters and removing them.

  We repeatedly make duplicate removals on s until we no longer can.

  Return the final string after all such duplicate removals have been made. It can be proven that the answer is unique.

  T - O(n), as we have to traverse through the entire array, albiet backwards
  S - O(n), where at worst case the stack can be holding every character in string
*/
public class Solution {
    public string RemoveDuplicates(string s) {
        Stack<char> stack = new Stack<char>();
        StringBuilder sb = new StringBuilder();
        
        for(int i = s.Length - 1; i>= 0; i--){
            if(stack.Count != 0 && s[i] == stack.Peek()){
                stack.Pop();
            } else {
                stack.Push(s[i]);
            }
        }
        
        while(stack.Count != 0){
            sb.Append(stack.Pop());
        }
        
        return sb.ToString();
    }
}
