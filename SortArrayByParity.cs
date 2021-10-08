/*
  Given an array nums of non-negative integers, return an array consisting of all the even elements of nums, followed by all the odd elements of nums.

  You may return any answer array that satisfies this condition.
  
  T - O(n), must traverse through entire length of input array
  S - O(1), only ever making int variable
*/
public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        int afterLastEven = 0;
        for(int i = 1; i < nums.Length; i++){
            if(nums[i] % 2 == 0){
                Swap(afterLastEven, i, nums);
                afterLastEven++;
            }
            if(afterLastEven < i && nums[afterLastEven] % 2 == 0) afterLastEven++;
        }
        return nums;
    }
    
    private void Swap(int a, int b, int[] arr){
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
}

// Slightly more optimal, at least logic wise
/*
    Given an integer array nums, move all the even integers at the 
    beginning of the array followed by all the odd integers.

    Return any array that satisfies this condition.

    T - O(n), one pass, where n is size of input array
    S - O(1), all done in place
*/
public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        int lastEven = 0;
        for (int i = 0; i < nums.Length; i++) {
            if(nums[i] % 2 == 0) {
                Swap(nums, lastEven++, i);
            }
        }
        
        return nums;
    }
    
    private void Swap(int[] nums, int a, int b) {
        int temp = nums[a];
        nums[a] = nums[b];
        nums[b] = temp;
    }
}
