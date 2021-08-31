/*
    Given an integer array nums, return the length of the longest 
    strictly increasing subsequence.

    A subsequence is a sequence that can be derived from an array by 
    deleting some or no elements without changing the order of the 
    remaining elements. For example, [3,6,2,7] is a subsequence of the 
    array [0,3,1,6,2,2,7].
    
    T - O(N^2), as we are traversing thrugh the nums array quadratic 
                amount of times with the nested for loop
    S -  O(N), as our DP table is of Length n, where n is the length of
               the input array
*/
public class Solution {
    // bottom up
    public int LengthOfLIS(int[] nums) {
        int[] table = new int[nums.Length];
        table[0] = 1;
        
        int maxLength = 1;
        for(int i = 1; i < nums.Length; i++){
            table[i] = 1;
            for(int j = 0; j < i; j++){
                if(nums[i] > nums[j] && table[i] <= table[j]){
                    table[i] = table[j] + 1;
                    maxLength = Math.Max(maxLength, table[i]);
                }
            }
        }
        
        return maxLength;
    }
    
    // top down
    public int LIS(int[] nums){
        int?[,] memo = new int?[nums.Length, nums.Length + 1];
        return LISRecursive(nums, 0, -1, memo);
    }
    
    public int LISRecursive(int[] nums, int current, int prev, int?[,] memo){
        if(current >= nums.Length) return 0;
        
        if(memo[current, prev + 1] == null){
            int countOne = 0;
            if(prev == -1 || nums[current] > nums[prev]){
                countOne = 1 + LISRecursive(nums, current + 1, current, memo)
            }
            int countTwo = LISRecursive(nums, current + 1, prev);
            memo[current, prev + 1] = Math.Max(countOne, countTwo);
        }
        
        return (int)memo[current, prev + 1];
    }
}
