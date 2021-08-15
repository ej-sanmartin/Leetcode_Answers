/*
    You are given an integer array nums and an integer target.

    You want to build an expression out of nums by adding one of the symbols '+' and '-' before 
    each integer in nums and then concatenate all the integers.

    For example, if nums = [2, 1], you can add a '+' before 2 and a '-' before 1 and concatenate 
    them to build the expression "+2-1".
    
    Return the number of different expressions that you can build, which evaluates to target.

    T - O(n * t), where n is the length of the input array times the constant t which is 10000
    S - O(n * t), as we must create this table to hold all sub solutions
*/
public class Solution {
    // Recursive, top down approach
    public int FindTargetSumWays(int[] nums, int target) {
        int?[,] memo = new int?[nums.Length, 10000];
        return FindTargetSumWaysRecursive(nums, target, 0, memo);
    }
    
    public int FindTargetSumWaysRecursive(int[] arr, int target, int index, int?[,] memo){
        if(target == 0 && index >= arr.Length){
            return 1;
        }
        
        if(index >= arr.Length){
            return 0;
        }
        
        if(memo[index, target + 1000] == null){
            int countOne = FindTargetSumWaysRecursive(arr, target - arr[index], index + 1, memo);
            int countTwo = FindTargetSumWaysRecursive(arr, target + arr[index], index + 1, memo);
            memo[index, target + 1000] = countOne + countTwo;
        }
        return (int)memo[index, target + 1000];
    }
    
    // Iteratie, bottom up approach
    public int FindTargetSumWays(int[] nums, int target){
        int[,] table = new int[nums.Length, 10000];
        table[0, nums[0] + 1000] = 1;
        table[0, -nums[0] + 1000] += 1;
        
        for(int i = 1; i < nums.Length; i++){
            for(int sum = -1000; sum <= 1000; sum++){
                if(table[i - 1, sum + 1000] > 0){
                    table[i, sum + nums[i] + 1000] += table[i - 1, sum + 1000];
                    table[i, sum - nums[i] + 1000] += table[i - 1, sum + 1000];
                }
            }
        }
        
        return target > 1000 ? 0 : table[nums.Length - 1, target + 1000];
    }
}
