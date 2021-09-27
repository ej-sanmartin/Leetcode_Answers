/*
    There is an integer array nums sorted in ascending order (with distinct values).

    Prior to being passed to your function, nums is possibly rotated at an unknown 
    pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], 
    nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For 
    example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become 
    [4,5,6,7,0,1,2].

    Given the array nums after the possible rotation and an integer target, return 
    the index of target if it is in nums, or -1 if it is not in nums.

    You must write an algorithm with O(log n) runtime complexity.

    T - O(logn), binary search time complexity
    S - O(1), no additional space created that depends on input
*/
public class Solution {
    public int Search(int[] nums, int target) {
        int start = 0;
        int end = nums.Length - 1;
        while(start <= end){
            int mid = start + ((end - start) / 2);
            int current = nums[mid];
            if(current == target){
                return mid;
            } else if(current >= nums[start]){
                if(target >= nums[start] && target < current){
                    end = mid - 1;
                } else {
                    start = mid + 1;
                }
            } else {
                if(target <= nums[end] && target > current){
                    start = mid + 1;
                } else {
                    end = mid - 1;
                }
            }
        }
        
        return -1;
    }
}
