/*
    Given a binary array nums, return the maximum number of consecutive 1's in the array.
    
    T - O(n), must go through entire array in one pass
    S - O(1), only creating variables to keep track of count
*/
public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        int count, maxConsecutiveOnes;
        count = maxConsecutiveOnes = 0;
        
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] == 1) count++;
            else count = 0;
            
            maxConsecutiveOnes = Math.Max(count, maxConsecutiveOnes);
        }
        
        return maxConsecutiveOnes;
    }
}
