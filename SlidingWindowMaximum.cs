/*
    You are given an array of integers nums, there is a sliding window of size k which 
    is moving from the very left of the array to the very right. You can only see the k 
    numbers in the window. Each time the sliding window moves right by one position.

    Return the max sliding window.
    
    T - O(n), n being the size of the input array. We traverse through each element once
    S - O(n), output string can be size of array
*/
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if(nums.Length == 0 || nums == null || k == 0 || k == null){
            return new int[0];
        }
        
        if(k == 1){
            return nums;
        }
        
        LinkedList<int> deque = new LinkedList<int>();
        int maxIndex = 0;
        int n = nums.Length;
        
        // populate deque with k valuesto start
        for(int i = 0; i < k; i++){
            CleanDeque(deque, nums, i, k);
            deque.AddLast(i);
            if(nums[i] > nums[maxIndex]){
                maxIndex = i;
            }
        }
        
        int[] output = new int[n - k + 1];
        output[0] = nums[maxIndex];
        
        for(int i = k; i < n; i++){
            CleanDeque(deque, nums, i, k);
            deque.AddLast(i);
            output[i - k + 1] = nums[deque.First.Value];
        }
        
        return output;
    }
    
    public void CleanDeque(LinkedList<int> deque, int[] nums, int i, int k){
        if(deque.Count != 0 && deque.First.Value == i - k){
            deque.RemoveFirst();
        }
        
        while(deque.Count != 0 && nums[i] > nums[deque.Last.Value]){
            deque.RemoveLast();
        }
    }
}
