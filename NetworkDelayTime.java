// With priority queue
/*
    You are given a network of n nodes, labeled from 1 to n. You are also given times, a list of travel 
    times as directed edges times[i] = (ui, vi, wi), where ui is the source node, vi is the target node, 
    and wi is the time it takes for a signal to travel from source to target.

    We will send a signal from a given node k. Return the time it takes for all the n nodes to receive the 
    signal. If it is impossible for all the n nodes to receive the signal, return -1.

    T - O((V + E)logv), time complexity of dijkstras algorithm
    S - O(V + E), space to create adjacency list
*/
class Solution {
    public int networkDelayTime(int[][] times, int n, int k) {
        if(times == null || times.length == 0 || k == 0 || k > n) return -1;
        Map<Integer, ArrayList<int[]>> graph = CreateGraph(times, n);
        
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> a[1] - b[1]);
        pq.offer(new int[]{k, 0});
        Map<Integer, Integer> distances = new HashMap<>();
        
        while(!pq.isEmpty()){
            int[] current = pq.poll();
            int weight = current[1];
            int vertex = current[0];
            if(distances.containsKey(vertex)) continue;
            distances.put(vertex, weight);
            if(graph.containsKey(vertex)){
                for(int[] edge : graph.get(vertex)){
                    int adjacentVertex = edge[0];
                    int adjacentWeight = edge[1];
                    if(!distances.containsKey(adjacentVertex)){
                        pq.offer(new int[]{adjacentVertex, weight + adjacentWeight});
                    }
                }
            }
        }
        
        if(distances.size() != n) return -1;
        int result = 0;
        for(int distance : distances.values()){
            result = Math.max(result, distance);
        }
        return result;
    }
    
    private Map<Integer, ArrayList<int[]>> CreateGraph(int[][] edges, int vertices){
        Map<Integer, ArrayList<int[]>> graph = new HashMap<>();
        
        for(int vertex = 1; vertex <= vertices; vertex++){
            graph.put(vertex, new ArrayList<>());
        }
        
        for(int[] edge : edges){
            graph.get(edge[0]).add(new int[]{edge[1], edge[2]});
        }
        
        return graph;
    }
}
