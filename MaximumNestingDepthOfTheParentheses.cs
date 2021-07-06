/*
    A string is a valid parentheses string (denoted VPS) if it meets one of the 
    following:

    It is an empty string "", or a single character not equal to "(" or ")",
    It can be written as AB (A concatenated with B), where A and B are VPS's, or
    It can be written as (A), where A is a VPS.
    We can similarly define the nesting depth depth(S) of any VPS S as follows:

    depth("") = 0
    depth(C) = 0, where C is a string with a single character not equal to "(" or ")".
    depth(A + B) = max(depth(A), depth(B)), where A and B are VPS's.
    depth("(" + A + ")") = 1 + depth(A), where A is a VPS.
    
    For example, "", "()()", and "()(()())" are VPS's (with nesting depths 0, 1, and 2), 
    and ")(" and "(()" are not VPS's.

    Given a VPS represented as string s, return the nesting depth of s.

    T - O(n), where n is the length of s we must traverse through to get depth
    S - O(n), stack space, worst case half of string is '(' which would be in the
              stack. It is only half because we are expecting VPS
*/
public class Solution {
    public int MaxDepth(string s) {
        Stack<char> stack = new Stack<char>();
        int maxDepth = 0;
        
        foreach(char c in s){
            if(c == '('){
                stack.Push(c);
            } else if(c == ')'){
                stack.Pop();
            }
            maxDepth = Math.Max(maxDepth, stack.Count);
        }
        
        return maxDepth;
    }
}
