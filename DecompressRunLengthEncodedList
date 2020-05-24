/*
  We are given a list nums of integers representing a list compressed with run-length encoding.

  Consider each adjacent pair of elements [freq, val] = [nums[2*i], nums[2*i+1]] (with i >= 0).
  For each such pair, there are freq elements with value val concatenated in a sublist.
  Concatenate all the sublists from left to right to generate the decompressed list.

  Return the decompressed list.
*/

public class Solution {
    public int[] DecompressRLElist(int[] nums) {
        List<int> answer = new List<int>();
        
        // checks if parameter passes constraints
        if(nums.Length % 2 != 0 && nums.Length <= 2 && nums.Length >= 100){
            return answer.ToArray();
        }
        
        for(int i = 0; i < nums.Length; i = i + 2){
            List<int> subList = new List<int>();
            subList.AddRange(Enumerable.Repeat(nums[i + 1], nums[i]));
            answer.AddRange(subList);
        }      
        return answer.ToArray();
    }
}
