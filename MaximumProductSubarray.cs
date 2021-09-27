/*
    Given an integer array nums, find a contiguous non-empty subarray within the array that has the largest product, 
    and return the product.

    It is guaranteed that the answer will fit in a 32-bit integer.

    A subarray is a contiguous subsequence of the array.

    T - O(n), one pass through nums array of size n
    S - O(1), constant space is only ever created to solve problem
*/
public class Solution {
    public int MaxProduct(int[] nums) {
        if(nums.Length == 0 || nums == null) return 0;
        int maxEnding = nums[0];
        int minEnding = nums[0];
        int currentMax = nums[0];
        
        for(int i = 1; i < nums.Length; i++){
            int temp = maxEnding;
            maxEnding = Math.Max(nums[i], Math.Max(nums[i] * maxEnding, nums[i] * minEnding));
            minEnding = Math.Min(nums[i], Math.Min(nums[i] * temp, nums[i] * minEnding));
            currentMax = Math.Max(currentMax, maxEnding);
        }
        
        return currentMax;
    }
}
