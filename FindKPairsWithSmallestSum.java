/*
    You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.

    Define a pair (u, v) which consists of one element from the first array and one element from 
    the second array.

    Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) with the smallest sums.
    
    T - O(klogk), we create PQ with k elements and then for k loops we add to our output list and 
                  to pq which maintains its order in logk per loop
    S - O(k), PQ can only up to k arrays that contain pairs
*/
class Solution {
    public List<List<Integer>> kSmallestPairs(int[] nums1, int[] nums2, int k) {
        List<List<Integer>> pairs = new ArrayList<>();
        if(nums1.length == 0 || nums2.length == 0 || k == 0){
            return pairs;
        }
        
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> a[0] + a[1] - b[0] - b[1]);
        
        for(int i = 0; i < nums1.length && i < k; i++){
            pq.offer(new int[]{ nums1[i], nums2[0], 0 });
        }
        
        while(k-- != 0 && !pq.isEmpty()){
            int[] current = pq.poll();
            pairs.add(List.of(current[0], current[1]));
            if(current[2] + 1 < nums2.length){
                pq.offer(new int[]{ current[0], nums2[current[2] + 1], current[2] + 1 });
            }
        }
        
        return pairs;
    }
}
