/*
    Given an array of integers nums which is sorted in ascending 
    order, and an integer target, write a function to search target 
    in nums. If target exists, then return its index. Otherwise, 
    return -1.

    You must write an algorithm with O(log n) runtime complexity.

    T - O(logn), time complexity of binary search, as search breaks
                 search space in half per iteration
    S - O(1),    no additional space created that depends on input
*/
public class Solution {
    public int Search(int[] nums, int target) {
        if(nums.Length == 0 || nums == null) return -1;
        int low = 0;
        int high = nums.Length - 1;
        
        while(low <= high){
            int mid = low + ((high - low) / 2);
            int current = nums[mid];
            if(current > target){
                high = mid - 1;
            } else if(current < target){
                low = mid + 1;
            } else {
                return mid;
            }
        }
        
        return -1;
    }
}
