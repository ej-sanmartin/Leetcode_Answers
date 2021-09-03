/*
    Given an integer array nums and an integer k, return the length of the shortest non-
    empty subarray of nums with a sum of at least k. If there is no such subarray, 
    return -1.

    A subarray is a contiguous part of an array.

    T - O(n), n being the size of the input array, we go through elements once
    S - O(n), int[] that keeps track of indices are of size n + 1
*/
public class Solution {
    public int ShortestSubarray(int[] nums, int k) {
        int n = nums.Length;
        int[] indices = new int[n + 1];
        for(int i = 0; i < n; i++){
            indices[i + 1] = indices[i] + nums[i];
        }
        
        int minLength = n + 1;
        LinkedList<int> deque = new LinkedList<int>();
        
        for(int i = 0; i < indices.Length; i++){
            while(deque.Count != 0 && indices[i] <= indices[deque.Last.Value]){
                deque.RemoveLast();
            }
            while(deque.Count != 0 && indices[i] >= indices[deque.First.Value] + k){
                minLength = Math.Min(minLength, i - deque.First.Value);
                deque.RemoveFirst();
            }
            
            deque.AddLast(i);
        }
        
        return minLength == n + 1 ? -1 : minLength;
    }
}
