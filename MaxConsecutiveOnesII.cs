/*
    Given a binary array nums, return the maximum number of consecutive
    1's in the array if you can flip at most one 0.

    T - O(n), n being size of input array. Must traverse all elements
    S - O(1), only keeping track of window variables
*/
public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        if (nums == null || nums.Length == 0) {
           return 0; 
        }
        
        int left = 0;
        int zeroCount = 0;
        int maxLength = 0;
        
        for (int right = 0; right < nums.Length; right++) {
            if (nums[right] == 0) {
                zeroCount++;
            }
            
            while (zeroCount > 1) {
                if (nums[left++] == 0) {
                    zeroCount--;
                }
            }
            
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        
        return maxLength;
    }
}
