/*
  Given an array of size n, find the majority element. The majority element is the element that appears
  more than ⌊ n/2 ⌋ times.

  You may assume that the array is non-empty and the majority element always exist in the array.  
*/

public class Solution {
    public int MajorityElement(int[] nums) {
        Dictionary<int, int> numCounters = new Dictionary<int, int>();
        
        for(int i = 0; i < nums.Length; i++){
            if(numCounters.ContainsKey(nums[i])){
                numCounters[nums[i]]++;
            } else {
                numCounters.Add(nums[i], 1);
            }
        }
        
        return numCounters.FirstOrDefault(key => key.Value.Equals(numCounters.Values.Max())).Key;
    }
}
