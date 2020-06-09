/*
  Given an array of integers, find if the array contains any duplicates.

  Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct.
*/

// creates set from input and calculate count in set. If there are duplicates, it will not be equal to length of original input.
// thus it will return true because it contains duplicates. If they are the same size, there are no duplicates and Set didn't
// filter out any numbers
public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        return (new HashSet<int>(nums)).Count != nums.Length;
    }
}
