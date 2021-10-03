/*
    Given an array nums of integers, return how many of them contain an even number of digits.


    T - O(n), n being the size of the input array we must traverse once
    S - O(1), no additional space dependent on input size created
*/
public class Solution {
    public int FindNumbers(int[] nums) {
        if(nums == null || nums.Length == 0){
            return 0;
        }
        
        int count = 0;
        
        foreach(int num in nums){
            if((int)(Math.Log10(num) + 1) % 2 == 0){
                count++;
            }
        }
        
        return count;
    }
}
