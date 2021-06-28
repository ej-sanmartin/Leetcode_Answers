/*
  Given an integer n, return an array ans of length n + 1 such that for each i (0 <= i <= n),
  ans[i] is the number of 1's in the binary representation of i.
  
  Was trying to practice Dynamic Programming, not best help for me since I did not know bit manipulation

  T - O(n) going through loops n number of times, where n is the inputted integer
  S - O(n) we are creating an array of size n + 1, where n is the inputted integer
*/
public class Solution {
    public int[] CountBits(int n) {
        int[] table = new int[n + 1];
        table[0] = 0;
        
        for(int i = 1; i <= n; i++){
            table[i] = table[i & (i - 1)] + 1;
        }
        
        return table;
    }
}
