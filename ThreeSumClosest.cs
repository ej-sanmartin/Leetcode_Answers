/*
    Given an array nums of n integers and an integer target, find three integers in 
    nums such that the sum is closest to target. Return the sum of the three 
    integers. You may assume that each input would have exactly one solution.

    T - O(n^2), as we are calculating the sum for ith element plus all possible 
                pairs to the right of i
    S - O(logn), space needed for quick sort
*/
public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        int difference = Int32.MaxValue;
        int left, right, currentSum;
        Array.Sort(nums);
        
        for(int i = 0; i < nums.Length; i++){
            left = i + 1;
            right = nums.Length - 1;
            while(left < right){
                currentSum = nums[left] + nums[right] + nums[i];
                if(Math.Abs(target - currentSum) < Math.Abs(difference)){
                    difference = target - currentSum;
                }
                if(currentSum > target) left++;
                if(currentSum < target) right--;
            }
        }
        
        return target - difference;
    }
}
