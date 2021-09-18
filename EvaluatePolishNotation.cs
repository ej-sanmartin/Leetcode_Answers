/*
    Evaluate the value of an arithmetic expression in Reverse Polish Notation.

    Valid operators are +, -, *, and /. Each operand may be an integer or another expression.

    Note that division between two integers should truncate toward zero.

    It is guaranteed that the given RPN expression is always valid. That means the expression 
    would always evaluate to a result, and there will not be any division by zero operation.

    T - O(n), we do one pass through array of string tokens, of size n
    S - O(n), at worst, stack holds all numbers, which is of size n / 2
*/
public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<string> stack = new Stack<string>();
        foreach(string token in tokens){
            if(int.TryParse(token, out _)){
                stack.Push(token);
            } else {
                int num1 = Convert.ToInt32(stack.Pop());
                int num2 = Convert.ToInt32(stack.Pop());
                if(token.Equals("+")){
                    stack.Push("" + (num1 + num2));
                } else if(token.Equals("-")){
                    stack.Push("" + (num2 - num1));
                } else if(token.Equals("*")){
                    stack.Push("" + (num1 * num2));
                } else if(token.Equals("/")){
                    stack.Push("" + (num2 / num1));
                }
            }
        }
        return Convert.ToInt32(stack.Pop());
    }
}
