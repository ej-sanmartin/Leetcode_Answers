/*
    Given an array of integers nums, calculate the pivot index of this array.

    The pivot index is the index where the sum of all the numbers strictly to 
    the left of the index is equal to the sum of all the numbers strictly to 
    the index's right.

    If the index is on the left edge of the array, then the left sum is 0 
    because there are no elements to the left. This also applies to the right 
    edge of the array.

    Return the leftmost pivot index. If no such index exists, return -1.

    T - O(n), n being the size of input array, we loop through all elements twice
    S - O(1), no additional space created that depends on input size
*/
public class Solution {
    public int PivotIndex(int[] nums) {
        if (nums == null || nums.Length == 0) {
            return -1;
        }
        
        int sum = 0;
        int leftSum = 0;
        foreach (int num in nums) {
            sum += num;
        }
        
        for (int i = 0; i < nums.Length; i++) {
            if (leftSum == sum - leftSum - nums[i]) {
                return i;
            }
            leftSum += nums[i];
        }
        
        return -1;
    }
}
