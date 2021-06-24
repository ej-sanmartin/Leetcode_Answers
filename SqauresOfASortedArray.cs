/*
  Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.

  T - O(n), n being the size of the output array which is the size of the input array we have to traverse
  S - O(n), n being the size of the output array which is the size of the input array
*/
public class Solution {
    public int[] SortedSquares(int[] nums) {
        int[] output = new int[nums.Length];
        int start = 0;
        int end = nums.Length - 1;
        int largestAbsoluteValue;
        
        for(int i = output.Length - 1; i >= 0; i--){
            largestAbsoluteValue = Math.Max(Math.Abs(nums[start]), Math.Abs(nums[end]));
            if(largestAbsoluteValue == Math.Abs(nums[start])){
                start++;
            } else if (largestAbsoluteValue == Math.Abs(nums[end])){
                end--;
            }
            output[i] = (int)Math.Pow(largestAbsoluteValue, 2);
        }
        
        return output;
    }
}
