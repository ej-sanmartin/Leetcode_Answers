/*
    Given an array nums of n integers where nums[i] is in the range [1, n], 
    return an array of all the integers in the range [1, n] that do not appear 
    in nums.

    T - O(n), technically O(2n), but we drop constants. We make two passes
              through input array
    S - O(1), not counting output list, not creating any additional space 
              based on input
*/
public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return new List<int>();
        }
        
        for (int i = 0; i < nums.Length; i++) {
            int index = Math.Abs(nums[i]) - 1;
            if (nums[index] > 0) {
               nums[index] *= -1; 
            }
        }
        
        List<int> output = new List<int>();
        
        for(int i = 1; i <= nums.Length; i++) {
            if (nums[i - 1] > 0) {
                output.Add(i);
            }
        }
        
        return output;
    }
}
