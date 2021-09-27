/*
    Suppose an array of length n sorted in ascending order is rotated between 1 and n 
    times. For example, the array nums = [0,1,2,4,5,6,7] might become:

    [4,5,6,7,0,1,2] if it was rotated 4 times.
    [0,1,2,4,5,6,7] if it was rotated 7 times.

    Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in 
    the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].

    Given the sorted rotated array nums of unique elements, return the minimum 
    element of this array.

    You must write an algorithm that runs in O(log n) time.

    T - O(logn), binary search time complexity
    S - O(1), no additional space created
*/
public class Solution {
    public int FindMin(int[] nums) {
        if(nums == null || nums.Length == 0) return 0;
        int low = 0;
        int high = nums.Length - 1;
        while(low < high){
            int middle = low + ((high - low) / 2);
            int current = nums[middle];
            if(current < nums[high]){
                high = middle;
            } else {
                low = middle + 1;
            }
        }
        return nums[low];
    }
}
