/*
    Given a string s of lower and upper case English letters.

    A good string is a string which doesn't have two adjacent 
    characters s[i] and s[i + 1] where:

    0 <= i <= s.length - 2
    s[i] is a lower-case letter and s[i + 1] is the same letter but in 
        upper-case or vice-versa.

    To make the string good, you can choose two adjacent characters 
    that make the string bad and remove them. You can keep doing this 
    until the string becomes good.

    Return the string after making it good. The answer is guaranteed 
    to be unique under the given constraints.

    Notice that an empty string is also good.

    T - O(n), where n is the length of the string
    S - O(n), where n is the size of the stack, which could hold the
              entire string if the entire string is good
*/
public class Solution {
    public string MakeGood(string s) {
        Stack<char> stack = new Stack<char>();
        StringBuilder sb = new StringBuilder();
        char c;
        
        for(int i = s.Length - 1; i >= 0; i--){
            if(stack.Count == 0){
                stack.Push(s[i]);
            } else {
                c = stack.Peek();
                if(c + 32 == s[i] || s[i] + 32 == c) stack.Pop();
                else stack.Push(s[i]);
            }
        }
        
        while(stack.Count != 0){
            sb.Append(stack.Pop());
        }
        
        return sb.ToString();
    }
}
