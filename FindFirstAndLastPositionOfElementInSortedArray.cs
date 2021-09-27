/*
    Given an array of integers nums sorted in ascending order, find the starting and 
    ending position of a given target value.

    If target is not found in the array, return [-1, -1].

    You must write an algorithm with O(log n) runtime complexity.

    T - O(logn), we are doing two binary searches, but time complexity remains logn
    S - O(1), create no additonal space that depends on input size
*/
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        if(nums.Length == 0 || nums == null) return new int[]{-1, -1};
        int[] output = new int[2];
        
        output[0] = BinarySearch(nums, target, true);
        if(output[0] == -1) return new int[]{-1, -1};
        output[1] = BinarySearch(nums, target, false);
        
        return output;
    }
    
    public int BinarySearch(int[] nums, int target, bool IsFirst){
        int low = 0;
        int high = nums.Length - 1;
        
        while(low <= high){
            int middle = low + ((high - low) / 2);
            int current = nums[middle];
            if(current > target){
                high = middle - 1;
            } else if(current < target){
                low = middle + 1;
            } else {
                if(IsFirst){
                    if(middle - 1 < 0 || nums[middle - 1] != target){
                        return middle;
                    } else {
                        high = middle - 1;
                    }
                } else {
                    if(middle + 1 >= nums.Length || nums[middle + 1] != target){
                        return middle;
                    } else {
                        low = middle + 1;
                    }
                }
            }
        }
        
        return -1;
    }
}
