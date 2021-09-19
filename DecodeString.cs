/*
    Given an encoded string, return its decoded string.

    The encoding rule is: k[encoded_string], where the encoded_string inside the square 
    brackets is being repeated exactly k times. Note that k is guaranteed to be a positive 
    integer.

    You may assume that the input string is always valid; No extra white spaces, square 
    brackets are well-formed, etc.

    Furthermore, you may assume that the original data does not contain any digits and that 
    digits are only for those repeat numbers, k. For example, there won't be input like 3a or 
    2[4].
    
    T - O(maxK^countK  * n), worst case time complexity, depends on nested []. Worst case we
                             have the maxK outside the nested [] which is then raised to the
                             power of the inner k count. Then we times that by the length of 
                             the longest decoded string within the input
    S - O(sum(maxK^countK * n)), size of stack at worst case, due to nested []
*/
public class Solution {
    public string DecodeString(string s) {
        Stack<char> stack = new Stack<char>();
        
        foreach(char c in s.ToCharArray()){
            if(!c.Equals(']')){
                stack.Push(c);
            } else {
                List<char> decodedString = new List<char>();
                while(stack.Peek() != '['){
                    decodedString.Add(stack.Pop());
                }
                stack.Pop();
                int digits = 1;
                int k = 0;
                while(stack.Count != 0 && Char.IsDigit(stack.Peek())){
                    k = k + (stack.Pop() - '0') * digits;
                    digits *= 10;
                }
                while(k-- != 0){
                    for(int i = decodedString.Count - 1; i >= 0; i--){
                        stack.Push(decodedString[i]);
                    }
                }
            }
        }
        
        int n = stack.Count;
        char[] output = new char[n];
        for(int i = n - 1; i >= 0; i--){
            output[i] = stack.Pop();
        }
        
        return new string(output);
    }
}
