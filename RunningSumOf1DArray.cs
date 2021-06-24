/*
  Given an array nums. We define a running sum of an array as runningSum[i] = sum(nums[0]…nums[i]).
  Return the running sum of nums.

  T - O(n), n being length of inputted array
  S - O(1), no additional space used, in place transformation
*/
public class Solution {
    public int[] RunningSum(int[] nums) {
        for(int i = 1; i < nums.Length; i++){
            nums[i] += nums[i - 1];
        }
        return nums;
    }
}
