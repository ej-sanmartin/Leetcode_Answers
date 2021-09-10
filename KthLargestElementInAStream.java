/*
    Design a class to find the kth largest element in a stream. Note that 
    it is the kth largest element in the sorted order, not the kth 
    distinct element.

    Implement KthLargest class:

    KthLargest(int k, int[] nums) Initializes the object with the integer 
        k and the stream of integers nums.
    int add(int val) Appends the integer val to the stream and returns 
        the element representing the kth largest element in the stream
        
    T - O(nlogn + mlogk), creating pq and then adding and getting kth 
                          element
    S - O(n), pq holds n elements initially, the size of input array
*/
class KthLargest {
    private PriorityQueue<Integer> pq;
    private int k;
    
    public KthLargest(int k, int[] nums) {
        this.k = k;
        pq = new PriorityQueue<>();
        for(int num : nums){
            pq.offer(num);
        }
        
        while(pq.size() > k){
            pq.poll();
        }
    }
    
    public int add(int val) {
        pq.offer(val);
        if(pq.size() > k){
            pq.poll();
        }
        return pq.peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.add(val);
 */
