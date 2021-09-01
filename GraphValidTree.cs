/*
    You have a graph of n nodes labeled from 0 to n - 1. You are given an integer n and a list of 
    edges where edges[i] = [ai, bi] indicates that there is an undirected edge between nodes ai and 
    bi in the graph.

    Return true if the edges of the given graph make up a valid tree, and false otherwise.

    T - O(V + E), time complexity of DFS
    S - O(V + E), space needed to create adjacenecy list
*/
public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if(edges.Length != n - 1) return false;
        
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        for(int i = 0; i < n; i++){
            graph[i] = new List<int>();
        }
        
        foreach(int[] edge in edges){
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }
        
        HashSet<int> visited = new HashSet<int>();
        
        return DFS(graph, visited, 0, -1) && visited.Count == n;
    }
    
    public bool DFS(Dictionary<int, List<int>> graph, HashSet<int> visited, int current, int parent){
        if(visited.Contains(current)) return false;
        visited.Add(current);
        foreach(int adjacent in graph[current]){
            if(parent != adjacent){
                bool result = DFS(graph, visited, adjacent, current);
                if(!result) return false;
            }
        }
        return true;
    }
}
