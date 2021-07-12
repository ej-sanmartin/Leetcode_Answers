/*
    The product difference between two pairs (a, b) and (c, d) is defined 
    as (a * b) - (c * d).

    For example, the product difference between (5, 6) and (2, 7) is (5 * 
    6) - (2 * 7) = 16.

    Given an integer array nums, choose four distinct indices w, x, y, 
    and z such that the product difference between pairs (nums[w], 
    nums[x]) and (nums[y], nums[z]) is maximized.

    Return the maximum such product difference.


    T - O(n), must traverse through entire array to find 2 largest and 2
              smallest values
    S - O(1), constant space since we are only creating variables to
              store the 4 relevant numbers
*/
public class Solution {
    public int MaxProductDifference(int[] nums) {
        int largest = Int32.MinValue;
        int secondLargest = Int32.MinValue;
        int smallest = Int32.MaxValue;
        int secondSmallest = Int32.MaxValue;
        
        for(int i = 0; i < nums.Length; i++){
            if(largest < nums[i]){
                secondLargest = largest;
                largest = nums[i];
            } else if(secondLargest < nums[i]){
                secondLargest = nums[i];
            }
            
            if(smallest > nums[i]){
                secondSmallest = smallest;
                smallest = nums[i];
            } else if(secondSmallest > nums[i]){
                secondSmallest = nums[i];
            }
        }
        
        int smallProduct = smallest * secondSmallest;
        int largeProduct = largest * secondLargest;
        return largeProduct - smallProduct;
    }
}
