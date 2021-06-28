/*
  You are given a network of n nodes, labeled from 1 to n. You are also given times, a list of travel times as directed edges
  times[i] = (ui, vi, wi), where ui is the source node, vi is the target node, and wi is the time it takes for a signal to
  travel from source to target.

  We will send a signal from a given node k. Return the time it takes for all the n nodes to receive the signal. If it is
  impossible for all the n nodes to receive the signal, return -1.
  
  
  Can use DFS but Dijsktra's algorithm is faster to get the min cost from start node to every other node
  We get the maxium from this generated list since we want to be able to reach every node. If we find a default value
  not every node was traversed.
  

  T - O(|V^2|), this implementation will go through every vertex and then every adjacency vertices and at worst case every vertices is connected to each other.
                To increase speed massively for this algorithm, we would need to use a heap to get quicker access to the shortest path at every adjacent 
  S - O(|V| + |E|), as we are creating an adjacency list to have faster access to connected vertices and their weights
*/
public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        Dictionary<int, List<int[]>> table = new Dictionary<int, List<int[]>>();
        foreach(int[] edge in times){
            if(!table.ContainsKey(edge[0])){
                table.Add(edge[0], new List<int[]>());
            }
            
            table[edge[0]].Add(new int[]{ edge[1], edge[2] });
        }
        
        int[] distances = new int[n + 1];
        for(int node = 1; node <= n; node++){
            distances[node] = Int32.MaxValue;
        }
        
        distances[k] = 0;
        bool[] visited = new bool[n + 1];
        int vertex;
        int distance;
        
        while(true){
            vertex = -1;
            distance = Int32.MaxValue;
            for(int i = 1; i <= n; i++){
                if(!visited[i] && distances[i] < distance){
                    distance = distances[i];
                    vertex = i;
                }
            }
            
            if(vertex < 1) break;
            visited[vertex] = true;
            
            if(table.ContainsKey(vertex)){
                foreach(int[] edge in table[vertex]){
                    distances[edge[0]] = Math.Min(distances[edge[0]], distances[vertex] + edge[1]);
                }
            }
        }
        
        int answer = 0;
        foreach(int cost in distances){
            if(cost == Int32.MaxValue) return -1;
            answer = Math.Max(answer, cost);
        }
        
        return answer;
    }
}
