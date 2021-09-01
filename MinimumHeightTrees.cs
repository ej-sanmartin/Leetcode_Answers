/*
    A tree is an undirected graph in which any two vertices are connected by 
    exactly one path. In other words, any connected graph without simple 
    cycles is a tree.

    Given a tree of n nodes labelled from 0 to n - 1, and an array of n - 1 
    edges where edges[i] = [ai, bi] indicates that there is an undirected edge 
    between the two nodes ai and bi in the tree, you can choose any node of 
    the tree as the root. When you select a node x as the root, the result 
    tree has height h. Among all possible rooted trees, those with minimum 
    height (i.e. min(h))  are called minimum height trees (MHTs).

    Return a list of all MHTs' root labels. You can return the answer in any 
    order.

    The height of a rooted tree is the number of edges on the longest downward 
    path between the root and a leaf.

    T - O(V + E), time complexity of BFS on an adjacency list
    S - O(V + E), as this is the space needed to create adjacency list
*/
public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        if(n == 1){
            return new List<int>(Enumerable.Repeat(0, 1));
        }
        
        
        
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        for(int i = 0; i < n; i++){
            graph[i] = new List<int>();
        }
        
        foreach(int[] edge in edges){
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }
        
        List<int> leaves = new List<int>();
        for(int i = 0; i < n; i++){
            if(graph[i].Count == 1){
                leaves.Add(i);
            }
        }
        
        while(n > 2){
            n -= leaves.Count;
            List<int> newLeaves = new List<int>();
            
            foreach(int leaf in leaves){
                int neighbor = graph[leaf][0];
                graph[neighbor].Remove(leaf);
                if(graph[neighbor].Count == 1){
                    newLeaves.Add(neighbor);
                }
            }
            
            leaves = newLeaves;
        }
        
        return leaves;
    }
}
