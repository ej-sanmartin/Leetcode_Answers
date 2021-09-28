/*
    Given an array of integers nums and an integer k, return the total number of continuous 
    subarrays whose sum equals to k.


    T - O(n), we go through array once, of size n
    S - O(n), dictionary created will keep track of, at worst, n elements
*/
public class Solution {
    public int SubarraySum(int[] nums, int k) {
        Dictionary<int, int> table = new Dictionary<int, int>();
        table.Add(0, 1);
        int count = 0;
        int runningSum = 0;
        
        for(int i = 0; i < nums.Length; i++){
            runningSum += nums[i];
            if(table.ContainsKey(runningSum - k)){
                count += table[runningSum - k];
            }
            
            if(!table.ContainsKey(runningSum)){
                table.Add(runningSum, 0);
            }
            table[runningSum]++;
        }
        
        return count;
    }
}
