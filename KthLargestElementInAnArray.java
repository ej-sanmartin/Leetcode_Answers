/*
    Given an integer array nums and an integer k, return the kth largest element in the array.

    Note that it is the kth largest element in the sorted order, not the kth distinct element.

    T - O(nlogk), for adding all elements and maintaining k elements in pq
    S - O(k), pq will only ever be the size of the k given
*/
class Solution {
    public int findKthLargest(int[] nums, int k) {
        if(k > nums.length || k == 0 || nums.length == 0 || nums == null){
            return -1; // or any other error
        }
        PriorityQueue<Integer> pq = new PriorityQueue<>();
        for(int num : nums){
            pq.offer(num);
            if(pq.size() > k){
                pq.poll();
            }
        }
        return pq.peek();
    }
}
