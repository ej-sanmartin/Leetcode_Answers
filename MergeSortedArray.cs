/*
    You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two 
    integers m and n, representing the number of elements in nums1 and nums2 respectively.

    Merge nums1 and nums2 into a single array sorted in non-decreasing order.

    The final sorted array should not be returned by the function, but instead be stored inside 
    the array nums1. To accommodate this, nums1 has a length of m + n, where the first m 
    elements denote the elements that should be merged, and the last n elements are set to 0 
    and should be ignored. nums2 has a length of n.

    T - O(m + n), must go through both arrays entirely to find their order
    S - O(m), created a copy array if size m
*/
public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        if (nums1.Length == 0 || nums1 == null) {
            nums1 = nums2;
            return;
        }
        
        if (nums2.Length == 0 || nums2 == null) {
            return;
        }
        
        int[] copiedArray = new int[m];
        for (int j = 0; j < m; j++) {
            copiedArray[j] = nums1[j];
        }
        
        int i = 0;
        int indexOne = 0;
        int indexTwo = 0;
        
        while (indexOne < m || indexTwo < n) {
            if (indexOne < m && indexTwo < n) {
                if (copiedArray[indexOne] <= nums2[indexTwo]) {
                    nums1[i++] = copiedArray[indexOne++];
                } else {
                    nums1[i++] = nums2[indexTwo++];
                }
            } else if (indexOne < m) {
                nums1[i++] = copiedArray[indexOne++];
            } else {
                nums1[i++] = nums2[indexTwo++];
            }
        }
    }
}
