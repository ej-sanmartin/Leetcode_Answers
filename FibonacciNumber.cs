/*
  The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence, such that each number is the sum of the two preceding ones, starting from 0 and 1. That is,

  F(0) = 0, F(1) = 1
  F(n) = F(n - 1) + F(n - 2), for n > 1.
  
  Given n, calculate F(n).
  
  
  Wanted to try tabultation solution
  

  T - O(n), where n is the number inputted to the solution which creates an array of size n + 1 which we traverse through all indices
  S - O(n), where n is the size of the array we created that is dependent on the input. Technically, O(n + 1) but we drop constants
*/
public class Solution {
    public int Fib(int n) {
        if(n == 0) return 0;
        if(n == 1) return 1;
        
        int[] table = new int[n + 1];
        table[0] = 0;
        table[1] = 1;
        for(int i = 2; i <= n; i++){
            table[i] = table[i - 1] + table[i - 2];
        }
        
        return table[n];
    }
}
