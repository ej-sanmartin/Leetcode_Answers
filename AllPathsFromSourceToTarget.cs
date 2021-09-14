/*
    Given a directed acyclic graph (DAG) of n nodes labeled from 0 to n - 1, find all possible paths 
    from node 0 to node n - 1 and return them in any order.

    The graph is given as follows: graph[i] is a list of all nodes you can visit from node i (i.e., 
    there is a directed edge from node i to node graph[i][j]).

    T - O(2^v * V + E), time complexity to find all paths and DFS from every path
    S - O(2^v * V+ E), space to create solution and recursive stack space
*/
public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph){
        int vertices = graph.GetLength(0);
        var output = new List<IList<int>>();
        List<int> path = new List<int>();
        path.Add(0);
        DFS(graph, 0, vertices - 1, path, output);
        return output;
    }
    
    public void DFS(int[][] graph, int current, int end, List<int> path, List<IList<int>> list){
        if(current == end){
            list.Add(new List<int>(path));
            return;
        }
        foreach(int adjacent in graph[current]){
            path.Add(adjacent);
            DFS(graph, adjacent, end, path, list);
            path.RemoveAt(path.Count - 1);
        }
    }
}
