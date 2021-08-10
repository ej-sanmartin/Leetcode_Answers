/*
    Given a non-empty array nums containing only positive integers, find if the array 
    can be partitioned into two subsets such that the sum of elements in both subsets 
    is equal.

    T - O(n * s), as we must make n * s calculations at worst case where we have to
                  fill out entire table
    S - O(n * s), as we are saving our sub solutions int a table of size n * s
                  n being the size of the input array and s being the target sum
*/
public class Solution {
    // Bottom Up Appraoch
    public bool CanPartition(int[] nums){
        int sum = 0;
        foreach(int item in nums){
            sum += item;
        }
        
        if(sum % 2 != 0){
            return false;
        }
        
        sum /= 2;
        
        bool[,] table = new bool[nums.Length, sum + 1];
        
        for(int i = 0; i < nums.Length; i++){
            table[i, 0] = false;
        }
        
        for(int s = 1; s <= sum; s++){
            table[0, s] = s == nums[0] ? true : false;
        }
        
        for(int i = 1; i < nums.Length; i++){
            for(int s = 1; s <= sum; s++){
                if(table[i - 1, s]){
                    table[i, s] = true;
                } else if (nums[i] <= s){
                    table[i, s] = table[i - 1, s - nums[i]];
                }
            }
        }
        
        return table[nums.Length - 1, sum];
    }
    
    // Top Down Approach
    public bool CanPartition(int[] nums) {
        int sum = 0;
        foreach(int item in nums){
            sum += item;
        }
        
        if(sum % 2 != 0){
            return false;
        }
        
        sum /= 2;
        
        bool?[,] memo = new bool?[nums.Length, sum + 1];
        return CanPartitionRecursive(nums, sum, 0, memo);
    }
    
    public bool CanPartitionRecursive(int[] arr, int sum, int index, bool?[,] memo){
        if(sum == 0){
            return true;
        }
        
        if(index >= arr.Length){
            return false;
        }
        
        if(memo[index, sum] == null){
            if(arr[index] <= sum){
                if(CanPartitionRecursive(arr, sum - arr[index], index + 1, memo)){
                    memo[index, sum] = true;
                    return true;
                }
            }

            memo[index, sum] = CanPartitionRecursive(arr, sum, index + 1, memo);
        }

        return (bool)memo[index, sum];
    }
}
