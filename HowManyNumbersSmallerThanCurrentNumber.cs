/*
  Given the array nums, for each nums[i] find out how many numbers in the array are smaller than it.
  That is, for each nums[i] you have to count the number of valid j's such that j != i and nums[j] < nums[i].

  Return the answer in an array.
*/

public class Solution {
    public int[] SmallerNumbersThanCurrent(int[] nums) {
        List<int> answer = new List<int>(); // create List of type int, easier to work with
        for(int i = 0; i < nums.Length; i++){
            int count = 0; // set up new counter whenever loop occurs at i
            for(int j = 0; j < nums.Length; j++){ // loops through array twice, comparing the j iteration to i iteration
                if(nums[i] > nums[j] && nums[i] != nums[j]){ // if i is larger than j and isn't the same number, increment count
                    count++;
                }
            }
            answer.Add(count); // push result of count to list and loop nack again with next number
        }
        return answer.ToArray(); // return answer, being sure not to forget to transform list to an array
    }
}
