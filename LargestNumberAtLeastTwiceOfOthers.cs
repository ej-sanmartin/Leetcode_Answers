/*
    You are given an integer array nums where the largest integer is unique.

    Determine whether the largest element in the array is at least twice as
    much as every other number in the array. If it is, return the index of
    the largest element, or return -1 otherwise.

    T - O(n), going through array of size n twice
    S - O(1), only keeping track of data from largest num
*/
public class Solution {
    public int DominantIndex(int[] nums) {
        if (nums.Length == 0 || nums == null) {
            return -1;
        }
        
        int maxNum = Int32.MinValue;
        int maxNumIndex = -1;
        
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] > maxNum) {
                maxNum = nums[i];
                maxNumIndex = i;
            }
        }
        
        for (int i = 0; i < nums.Length; i++) {
            if (i != maxNumIndex) {
                if (nums[i] * 2 > maxNum) {
                    return -1;
                }   
            }
        }
        
        return maxNumIndex;
    }
}
