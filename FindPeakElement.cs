/*
    A peak element is an element that is strictly greater than its neighbors.

    Given an integer array nums, find a peak element, and return its index. If the 
    array contains multiple peaks, return the index to any of the peaks.

    You may imagine that nums[-1] = nums[n] = -∞.

    You must write an algorithm that runs in O(log n) time.

    T - O(logn), time complexity of binary search
    S - O(1), no additional space created for algorithm
*/
public class Solution {
    public int FindPeakElement(int[] nums) {
        if(nums == null || nums.Length == 0) return 0;
        int low = 0;
        int high = nums.Length - 1;
        while(low < high){
            int middle = low + ((high - low) / 2);
            int current = nums[middle];
            if(current > nums[middle + 1]){
                high = middle;
            } else {
                low = middle + 1;
            }
        }
        return low;
    }
}
