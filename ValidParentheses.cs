/*
    Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', 
    determine if the input string is valid.

    An input string is valid if:

    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.

    T - O(n), since we must traverse the length of the string to determine if valid
    S - O(n), since at worst case the stack may be filled with every element in the 
              string, if string was just filled with open elements. Best case,
              stack is filled with half of elements in string, half being the open
              elements
*/
public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        char c;
        
        for(int i = 0; i < s.Length; i++){
            if(s[i] == '(' || s[i] == '{' || s[i] == '['){
                stack.Push(s[i]);
            } else {
                if(stack.Count == 0) return false;
                c = stack.Pop();
                if(c == '(' && s[i] != ')') return false;;
                if(c == '{' && s[i] != '}' ) return false;
                if(c == '[' && s[i] != ']') return false;
            }
        }
        
        return stack.Count == 0;
    }
}
