/*
  Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
*/

public class Solution {
    public int MaxSubArray(int[] nums){
        for(int i = 1; i < nums.Length; i++){
            if(nums[i-1] > 0){
                nums[i] += nums[i-1];
            }
        }

        return nums.Max();
        }
}
