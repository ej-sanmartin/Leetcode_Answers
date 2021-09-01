/*
    There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 
    1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that 
    you must take course bi first if you want to take course ai.

    For example, the pair [0, 1], indicates that to take course 0 you have to first take 
    course 1.

    Return true if you can finish all courses. Otherwise, return false.

    T - O(V + E), time complexity of DFS
    S - O(V + E), space needed to create adjacency list
*/
public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        for(int i = 0; i < numCourses; i++){
            graph[i] = new List<int>();
        }
        
        for(int i = 0; i < prerequisites.Length; i++){
            graph[prerequisites[i][0]].Add(prerequisites[i][1]);
        }
        
        // 0 = not visted, -1 = visted, 1 = visiting
        int[] visited = new int[numCourses];
        for(int i = 0; i < numCourses; i++){
            if(CycleExists(graph, i, visited)){
                return false;
            }
        }
        
        return true;
    }
    
    public bool CycleExists(Dictionary<int, List<int>> graph, int vertex, int[] visited){
        if(visited[vertex] == 1){
            return true;
        }
        if(visited[vertex] == -1){
            return false;
        }
        visited[vertex] = 1;
        
        foreach(int adjacent in graph[vertex]){
            if(CycleExists(graph, adjacent, visited)){
                return true;
            }
        }
        
        visited[vertex] = -1;
        return false;
    }
}
