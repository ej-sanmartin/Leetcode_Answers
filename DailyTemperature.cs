/*
    Given an array of integers temperatures represents the daily temperatures, return an 
    array answer such that answer[i] is the number of days you have to wait after the ith 
    day to get a warmer temperature. If there is no future day for which this is possible, 
    keep answer[i] == 0 instead.

    T - O(n), one pass through the array, of size n
    S - O(n), stack, at worst case, can hold all elements n of the array
*/
public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        int[] output = new int[temperatures.Length];
        Stack<int> stack = new Stack<int>();
        
        for(int i = temperatures.Length - 1; i >= 0; i--){
            while(stack.Count != 0 && temperatures[stack.Peek()] <= temperatures[i]){
                stack.Pop();
            }
            output[i] = stack.Count == 0 ? 0 : (stack.Peek() - i);
            stack.Push(i);
        }
        
        return output;
    }
}
