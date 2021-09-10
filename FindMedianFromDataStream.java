/*
    The median is the middle value in an ordered integer list. If the size 
    of the list is even, there is no middle value and the median is the mean 
    of the two middle values.

    For example, for arr = [2,3,4], the median is 3.
    For example, for arr = [2,3], the median is (2 + 3) / 2 = 2.5.

    Implement the MedianFinder class:

    MedianFinder() initializes the MedianFinder object.
    void addNum(int num) adds the integer num from the data stream to the 
        data structure.
    double findMedian() returns the median of all elements so far. Answers 
        within 10-5 of the actual answer will be accepted.
        
    T - O(logn), pq makes access of middle values logn time
    S - O(n), linear space from two pqs that hold all elements placed into 
              this data structure
*/
class MedianFinder {

    PriorityQueue<Integer> maxHeap; // bottom half numbers
    PriorityQueue<Integer> minHeap; // top half largest numbers
    
    /** initialize your data structure here. */
    public MedianFinder() {
        maxHeap = new PriorityQueue<>(Collections.reverseOrder());
        minHeap = new PriorityQueue<>();
    }
    
    public void addNum(int num) {
        maxHeap.offer(num);
        minHeap.offer(maxHeap.poll());
        if(maxHeap.size() < minHeap.size()){
            maxHeap.offer(minHeap.poll());
        }
    }
    
    public double findMedian() {
        if(maxHeap.size() == minHeap.size()){
            return (double)(maxHeap.peek() + minHeap.peek()) / 2;
        } else {
            return (double)maxHeap.peek();
        }
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.addNum(num);
 * double param_2 = obj.findMedian();
 */
