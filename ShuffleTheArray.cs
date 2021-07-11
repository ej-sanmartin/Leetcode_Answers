/*
    Given the array nums consisting of 2n elements in the form 
    [x1,x2,...,xn,y1,y2,...,yn].

    Return the array in the form [x1,y1,x2,y2,...,xn,yn].

    T - O(n), we are looping through every element in the nums array n/2
              amount of iterations.
    S - O(n), we created a new array the same size of the old array
*/
public class Solution {
    public int[] Shuffle(int[] nums, int n) {
        int xIndex, shuffledNumsIndex;
        int yIndex = n;
        xIndex = shuffledNumsIndex = 0;
        int[] shuffledNums = new int[nums.Length];
        
        while(shuffledNumsIndex < nums.Length){
            if(shuffledNumsIndex % 2 == 0 || shuffledNumsIndex == 0){
                shuffledNums[shuffledNumsIndex++] = nums[xIndex++];
            } else {
                shuffledNums[shuffledNumsIndex++] = nums[yIndex++];
            }
        }
        
        return shuffledNums;
    }
}
