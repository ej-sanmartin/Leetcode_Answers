/*
    Given an array of distinct integers candidates and a target integer target, return a list 
    of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in 
    any order.

    The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the 
    frequency of at least one of the chosen numbers is different.

    It is guaranteed that the number of unique combinations that sum up to target is less than 150 combinations for the 
    given input.


    T - O(N ^ t/m), We have exponential time, where at each DFS path of size t/m (t being the target value and m being 
                    the minimal value among the candidates) we are doing N passes due to the for loop going throught 
                    the remaining parts of the given arrray.
    S - O(t/m), as the DFS recursive stack is equal to, at worst case, t/m.
*/
public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var combinations = new List<IList<int>>();
        CombinationSumHelper(candidates, target, 0, new List<int>(), combinations);
        return combinations;
    }
    
    public void CombinationSumHelper(int[] arr, int target, int index, List<int> combination, List<IList<int>> list){
        if(target == 0){
            list.Add(new List<int>(combination));
        } else if(target < 0 || index >= arr.Length){
            return;
        } else {
            for(int i = index; i < arr.Length; i++){
                combination.Add(arr[i]);
                CombinationSumHelper(arr, target - arr[i], i, combination, list);
                combination.RemoveAt(combination.Count - 1);
            }   
        }
    }
}
