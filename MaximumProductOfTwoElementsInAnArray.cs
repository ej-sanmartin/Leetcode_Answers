/*
    Given the array of integers nums, you will choose two different indices i and j of that 
    array. Return the maximum value of (nums[i]-1)*(nums[j]-1).
*/
class Solution {
    // T - O(nlogn), pq sorting the input array, S - O(1), PQ only holds up to 2 items 
    public int maxProduct(int[] nums) {
        PriorityQueue<Integer> pq = new PriorityQueue<>(2);
        for(int num : nums){
            pq.offer(num);
            if(pq.size() > 2) pq.poll();
        }
        return (pq.poll() - 1) * (pq.poll() - 1);
    }

    // T - O(n), one scan through array, S - O(1) just create two vars to keep track of top 2 
    public int maxProduct(int[] nums){
        int largest = nums[0];
        int secondLargest = Integer.MIN_VALUE;
        for(int i = 1; i < nums.length; i++){
            int num = nums[i];
            if(num >= largest){
                secondLargest = largest;
                largest = num;
            } else if(num > secondLargest){
                secondLargest = num;
            }
        }
        
        return (largest - 1) * (secondLargest - 1);
    }
}
