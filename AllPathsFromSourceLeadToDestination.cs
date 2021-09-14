/*
    Given the edges of a directed graph where edges[i] = [ai, bi] indicates there 
    is an edge between nodes ai and bi, and two nodes source and destination of 
    this graph, determine whether or not all paths starting from source 
    eventually, end at destination, that is:

    At least one path exists from the source node to the destination node
    If a path exists from the source node to a node with no outgoing edges, then 
        that node is equal to destination.
    The number of possible paths from source to destination is a finite number.


    Return true if and only if all roads from source lead to destination.

    T - O(V + E), DFS time complexity
    S - O (V + E), space to create adjacency list
*/
public class Solution {
    public bool LeadsToDestination(int n, int[][] edges, int source, int destination) {
        Dictionary<int, List<int>> graph = CreateGraph(n, edges);
        // 0 = not visited, -1 = visited, 1 = visiting
        int[] visited = new int[n];
        
        if(DFS(graph, source, destination, visited)) return false;
        
        return true;
    }
    
    public bool DFS(Dictionary<int, List<int>> graph, int current, int destination, int[] visited){
        if(visited[current] == 1) return true;
        if(visited[current] == -1) return false;
        if(graph[current].Count == 0) return current != destination;
        visited[current] = 1;
        
        foreach(int adjacent in graph[current]){
            if(DFS(graph, adjacent, destination, visited)){
                return true;
            }
        }
        visited[current] = -1;
        return false;
    }
    
    public Dictionary<int, List<int>> CreateGraph(int vertices, int[][] edges){
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        
        for(int i = 0; i < vertices; i++){
            graph.Add(i, new List<int>());
        }
        
        foreach(int[] edge in edges){
            graph[edge[0]].Add(edge[1]);
        }
        
        return graph;
    }
}
