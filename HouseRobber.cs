/*
    You are a professional robber planning to rob houses along a street. Each house has a certain 
    amount of money stashed, the only constraint stopping you from robbing each of them is that 
    adjacent houses have security systems connected and it will automatically contact the police if 
    two adjacent houses were broken into on the same night.

    Given an integer array nums representing the amount of money of each house, return the maximum 
    amount of money you can rob tonight without alerting the police.

    T - O(n), since we have to traverse through entire table array with is size nums.Length
    S - O(n), which is the size of the table array which stores all previously done operations and answer
*/
public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length == 1) return nums[0];
        
        int[] table = new int[nums.Length];
        table[0] = nums[0];
        table[1] = Math.Max(nums[0], nums[1]);
        
        for(int i = 2; i < table.Length; i++){
            table[i] = Math.Max(nums[i] + table[i - 2], table[i - 1]);
        }
        
        return table[nums.Length - 1];
    }
}
