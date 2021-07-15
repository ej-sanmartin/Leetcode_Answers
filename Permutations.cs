/*
    Given an array nums of distinct integers, return all the possible 
    permutations. You can return the answer in any order.
    
    T - O(N! * N), permutations have factorial time complexity, and we must
                   also create a new list 
    S - O(N!), as we must create and keep factorial amount of solutions
*/
public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var result = new List<IList<int>>();
        PermutateHelper(nums, 0, result);
        return result;
    }
    
    private void PermutateHelper(int[] arr, int start, List<IList<int>> list){
        if(arr.Length == start){
            List<int> newEntry = new List<int>(arr);
            list.Add(newEntry);
        } else {
            for(int i = start; i < arr.Length; i++){
                Swap(start, i, arr);
                PermutateHelper(arr, start + 1, list);
                Swap(start, i, arr);
            }
        }
    }
    
    private void Swap(int a, int b, int[] arr){
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
}
