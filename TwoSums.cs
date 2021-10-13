/*
  Given an array of integers, return indices of the two numbers such that they add up to a specific target.
  You may assume that each input would have exactly one solution, and you may not use the same element twice.
*/

public class Solution {
    public int[] TwoSum(int[] nums, int target) {        
        // checks if array is long enough to have a sum
        if(nums.Length < 2){
            return null;
        }
        
        // checks if array has two items, if so add them up and compare to target
        if(nums.Length == 2){
            if(target == nums[0] + nums[1]){
                int[] answer = new int[2] {0, 1};
                return answer;
            }
            else {
                return null;
            }
        }
        
        // checks for arrays longer than 2.
        if(nums.Length > 2){
            for(int i = 0; i < nums.Length; i++){
                for(int j = 0; j < nums.Length; j++){
                    if(nums[j] == target - nums[i] && i != j){
                        int[] answer = new int[2];
                        answer[0]= i;
                        answer[1]= j;
                        return answer;
                    } else {
                        continue;
                    }
                }
            }
            return null;
        }
        return null;
    }
}


// A year later, came up with a better answer
// T - O(n), S - O(n)
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        if (nums.Length == 0 || nums == null) {
            return new int[0];
        }
        
        Dictionary<int, int> table = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++) {
            int remainder = target - nums[i];
            if (table.ContainsKey(remainder)) {
                return new int[]{i, table[remainder]};
            }
            table[nums[i]] = i;
        }
        
        return new int[0];
    }
}
