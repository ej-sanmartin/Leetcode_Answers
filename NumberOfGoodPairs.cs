/*
    Given an array of integers nums.

    A pair (i,j) is called good if nums[i] == nums[j] and i < j.

    Return the number of good pairs.
    

    T - O(n + m), as we are traversing through n number of elements in nums
                  and then traverse through dictionary which is size of m
                  which is number of unique values from the nums array
    S - O(n),     as we are creating a dictionary with n kvp, where n is
                  the unique values from the nums array
*/
public class Solution {
    public int NumIdenticalPairs(int[] nums) {
        Dictionary<int, int> frequencyTable = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            if(!frequencyTable.ContainsKey(nums[i])){
                frequencyTable.Add(nums[i], 0);
            }
            frequencyTable[nums[i]]++;
        }
        
        int pairs = 0;
        
        foreach(KeyValuePair<int, int> number in frequencyTable){
            pairs += (number.Value * (number.Value - 1)) / 2;
        }
        
        return pairs;
    }
}
