/*
  Given an array nums of integers, return how many of them contain an even number of digits.
*/

public class Solution {
    public int FindNumbers(int[] nums) {
        int count = 0;
        foreach (int num in nums){
            if(num.ToString().Length % 2 == 0){
                count++;
            }
        }
        return count;
    }
}
