/*
    Given an integer array nums of unique elements, return all possible subsets (the power set).

    The solution set must not contain duplicate subsets. Return the solution in any order.

    T - O(N * 2^N), exponential as we have to go through every subset and then create a copy of   
                    every subset of size N
    S - O(N),       recursive call stack is depth of the size of the input array
*/
public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var subsets = new List<IList<int>>();
        SubsetsHelper(nums, 0, new List<int>(), subsets);
        return subsets;
    }
    
    public void SubsetsHelper(int[] arr, int index, List<int> subset, List<IList<int>> list){
        list.Add(new List<int>(subset));
        if(index >= arr.Length){
            return;
        }
        for(int i = index; i < arr.Length; i++){
            subset.Add(arr[i]);
            SubsetsHelper(arr, i + 1, subset, list);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}
