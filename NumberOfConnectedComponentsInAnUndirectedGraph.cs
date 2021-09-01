/*
    You have a graph of n nodes. You are given an integer n and an array edges where 
    edges[i] = [ai, bi] indicates that there is an edge between ai and bi in the 
    graph.

    Return the number of connected components in the graph.


    T - O(E + V), time complexity of DFS
    S - O(E + V), to build adjacency list
*/
public class Solution {
    public int CountComponents(int n, int[][] edges) {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        for(int i = 0; i < n; i++){
            graph[i] = new List<int>();
        }
        
        for(int i = 0; i < edges.Length; i++){
            graph[edges[i][0]].Add(edges[i][1]);
            graph[edges[i][1]].Add(edges[i][0]);
        }
        
        bool[] visited = new bool[n];
        
        int count = 0;
        
        for(int i = 0; i < n; i++){
            if(!visited[i]){
                count++;
                DFS(graph, i, visited);
            }
        }
        
        return count;
    }
    
    public void DFS(Dictionary<int, List<int>> graph, int vertex, bool[] visited){
        visited[vertex] = true;
        foreach(int adjacent in graph[vertex]){
            if(!visited[adjacent]){
                DFS(graph, adjacent, visited);
            }
        }
    }
}
