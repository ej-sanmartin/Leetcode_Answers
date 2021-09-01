/*
    Given an array of positive integers nums and a positive integer 
    target, return the minimal length of a contiguous subarray 
    [numsl, numsl+1, ..., numsr-1, numsr] of which the sum is 
    greater than or equal to target. If there is no such subarray, 
    return 0 instead.

    T - O(n), n being the length of the input array, we must 
              traverse through every element
    S - O(1), no additonal space created besides ints
*/
public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        if(nums == null || nums.Length == 0){
            return 0;
        }
        
        int left = 0;
        int sum = 0;
        int minSize = Int32.MaxValue;
        
        for(int right = 0; right < nums.Length; right++){
            sum += nums[right];
            while(sum >= target){
                minSize = Math.Min(minSize, right - left + 1);
                sum -= nums[left++];
            }
        }
        
        return (minSize != Int32.MaxValue ? minSize : 0);
    }
}
