/*
  Given an array nums, write a function to move all 0's to the end of it while maintaining
  the relative order of the non-zero elements.
*/

public class Solution {
    public void MoveZeroes(int[] nums) {
        int lastNonZeroIndex = 0;
        
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] != 0){
                nums[lastNonZeroIndex++] = nums[i];
            }
        }
        
        for(int i = lastNonZeroIndex; i < nums.Length; i++){
            nums[i] = 0;
        }
    }
}

/*
    Given an integer array nums, move all 0's to the end of it while maintaining 
    the relative order of the non-zero elements.

    Note that you must do this in-place without making a copy of the array.

    T - O(n), we go through array in one pass
    S - O(1), we are modifying array in place
*/
public class Solution {
    public void MoveZeroes(int[] nums) {
        int writePointer = 0;
        
        for (int readPointer = 0; readPointer < nums.Length; readPointer++) {
            if(nums[readPointer] != 0){
                Swap(nums, writePointer++, readPointer);
            }
        }
    }
    
    private void Swap(int[] nums, int a, int b) { 
        int temp = nums[a];
        nums[a] = nums[b];
        nums[b] = temp;
    }
}
