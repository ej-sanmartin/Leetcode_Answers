/*
    We want to split a group of n people (labeled from 1 to n) into two groups of any size. 
    Each person may dislike some other people, and they should not go into the same group.

    Given the integer n and the array dislikes where dislikes[i] = [ai, bi] indicates that the 
    person labeled ai does not like the person labeled bi, return true if it is possible to 
    split everyone into two groups in this way.

    T - O(V + E), time complexity of DFS on adjacency list
    S - O(V + E), space needed to create adjacency list
*/
public class Solution {
    public bool PossibleBipartition(int n, int[][] dislikes) {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        for(int i = 0; i < n; i++){
            graph[i] = new List<int>();
        }
        
        foreach(int[] relationship in dislikes){
            graph[relationship[0] - 1].Add(relationship[1] - 1);
            graph[relationship[1] - 1].Add(relationship[0] - 1);
        }
        
        // 0 = not visited, 1 = group a, -1 = group b
        int[] visited = new int[n];
        for(int i = 0; i < n; i++){
            if(visited[i] == 0 && !DFS(graph, visited, i, 1)){
                return false;
            }    
        }
        
        return true;
    }
    
    private bool DFS(Dictionary<int, List<int>> graph, int[] visited, int person, int group){
        visited[person] = group;
        foreach(int adjacent in graph[person]){
            if(visited[adjacent] == group){
                return false;
            }
            
            if(visited[adjacent] == 0 && !DFS(graph, visited, adjacent, -group)){
                return false;
            }
        }
        
        return true;
    }
}
