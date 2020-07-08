/*
  Given an integer n and an integer start.

  Define an array nums where nums[i] = start + 2*i (0-indexed) and n == nums.length.

  Return the bitwise XOR of all elements of nums.
*/

public class Solution {
    public int XorOperation(int n, int start) {
        int result = 0;
        
        for(int i = 0; i < n; i++){
            int temporary = start + 2 * i;
            result ^= temporary;
        }
        
        return result;
    }
}
