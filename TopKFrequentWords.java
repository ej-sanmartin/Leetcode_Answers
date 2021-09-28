/*
    Given an array of strings words and an integer k, return the k most frequent strings.

    Return the answer sorted by the frequency from highest to lowest. Sort the words with 
    the same frequency by their lexicographical order.

    T - O(nlogk), going through all elements n in string array, where priority queue 
                  maintains order for k elements
    S - O(k), Priority Queue only holds up to k elements
*/
class Solution {
    public List<String> topKFrequent(String[] words, int k) {
        Map<String, Integer> frequencies = new HashMap<>();
        for(String word : words){
            frequencies.put(word, frequencies.getOrDefault(word, 0) + 1);
        }
        
        PriorityQueue<String> pq = new PriorityQueue<>((a, b) -> {
            int wordOne = frequencies.get(a);
            int wordTwo = frequencies.get(b);
            if(wordOne == wordTwo){
                return b.compareTo(a);
            } else {
                return wordOne - wordTwo;
            }
        });
        
        for(Map.Entry<String, Integer> entry : frequencies.entrySet()){
            pq.offer(entry.getKey());
            if(pq.size() > k) pq.poll();
        }
        
        String[] output = new String[pq.size()];
        for(int i = pq.size() - 1; i >= 0; i--){
            output[i] = pq.poll();
        }
      
        return Arrays.asList(output);
    }
}
