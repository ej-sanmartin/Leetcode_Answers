/*
    There are n houses in a village. We want to supply water for all the houses by building 
    wells and laying pipes.

    For each house i, we can either build a well inside it directly with cost wells[i - 1] 
    (note the -1 due to 0-indexing), or pipe in water from another well to it. The costs to 
    lay pipes between houses are given by the array pipes, where each pipes[j] = [house1j, 
    house2j, costj] represents the cost to connect house1j and house2j together using a 
    pipe. Connections are bidirectional.

    Return the minimum total cost to supply water to all houses.

    Note: n is number of house, m is number of pipes from input
    T - O((n + m) log (n + m)), sorting the list of edges we created which is size n + m
    S - O(n + m), the space required to create the list of edges
*/
public class Solution {
    public class UnionFind {
        private int[] root;
        private int[] rank;
        
        public UnionFind(int vertices){
            root = new int[vertices + 1];
            rank = new int[vertices + 1];
            for(int i = 0; i < vertices + 1; i++){
                root[i] = i;
                rank[i] = 0;
            }
        }
        
        public int Find(int x){
            if(root[x] == x){
                return x;
            }
            return root[x] = Find(root[x]);
        }
        
        public bool Union(int x, int y){
            int xRoot = Find(x);
            int yRoot = Find(y);
            
            if(xRoot == yRoot) return false;
            
            if(rank[xRoot] > rank[yRoot]){
                root[yRoot] = xRoot;
            } else if(rank[xRoot] < rank[yRoot]){
                root[xRoot] = yRoot;
            } else {
                root[yRoot] = xRoot;
                rank[xRoot]++;
            }
            
            return true;
        }
    }
    
    public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes) {
        List<int[]> orderedEdges = new List<int[]>(n + 1 + pipes.Length);
        
        for(int i = 0; i < wells.Length; i++){
            orderedEdges.Add(new int[]{ 0, i + 1, wells[i] });
        }
        
        for(int i = 0; i < pipes.Length; i++){
            int[] edge = pipes[i];
            orderedEdges.Add(edge);
        }
        
        orderedEdges.Sort((a, b) => a[2] - b[2]);
        
        UnionFind uf = new UnionFind(n);
        int totalCost = 0;
        
        foreach(int[] edge in orderedEdges){
            int houseOne = edge[0];
            int houseTwo = edge[1];
            int cost = edge[2];
            if(uf.Union(houseOne, houseTwo)){
                totalCost += cost;
            }
        }
        
        return totalCost;
    }
}
