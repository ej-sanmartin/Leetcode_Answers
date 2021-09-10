/*
    Given an integer array nums and an integer k, return the k most frequent elements. 
    You may return the answer in any order.

    T - O(Nlogk), we add items in n amount of times where n is the size of the array. K 
                  elements are shuffled to keep PQ order assumming k < n
    S - O(N + k), store n items in hashmap and create k space array for output
*/
class Solution {
    public int[] topKFrequent(int[] nums, int k) {
        if(k == nums.length) return nums;
        Map<Integer, Integer> table = new HashMap<>();
        for(int item : nums){
            table.put(item, table.getOrDefault(item, 0) + 1);
        }
        
        Queue<Integer> pq = new PriorityQueue<>((a, b) -> table.get(b) - table.get(a));
        
        for(int num : table.keySet()){
            pq.add(num);
        }
        
        int[] output = new int[k];
        for(int i = 0; i < k; i++){
            output[i] = pq.poll();
        }
        
        return output;
    }
}
