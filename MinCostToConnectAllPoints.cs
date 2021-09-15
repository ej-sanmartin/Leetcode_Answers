/*
    You are given an array points representing integer coordinates of some points on a 2D-plane, where 
    points[i] = [xi, yi].

    The cost of connecting two points [xi, yi] and [xj, yj] is the manhattan distance between them: |xi 
    - xj| + |yi - yj|, where |val| denotes the absolute value of val.

    Return the minimum cost to make all points connected. All points are connected if there is exactly 
    one simple path between any two points.
    
    Note: V is all unique vertices and e is all unique edges
    T - O(V^2 + eloge), time for creating and calculating all the edges and then sorting
    S - O(V^2), all edges, created int List<int[]> of ordered edges
*/
public class Solution {
    public class UnionFind {
        private int[] root;
        private int[] rank;
        public UnionFind(int vertices){
            root = new int[vertices];
            rank = new int[vertices];
            for(int i = 0; i < vertices; i++){
                root[i] = i;
                rank[i] = 1;
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
    
    public int MinCostConnectPoints(int[][] points) {
        int vertices = points.Length;
        List<int[]> orderedEdges = new List<int[]>();
        int edges = 0;
        int cost = 0;
        
        // T- O(v^2)
        for(int i = 0; i < points.Length; i++){
            for(int j = 1; j < points.Length; j++){
                int manhattanDistance = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                orderedEdges.Add(new int[]{i, j, manhattanDistance});
            }
        }
        
        // T - O(eloge)
        orderedEdges.Sort((a, b) => a[2] - b[2]);
        
        UnionFind uf = new UnionFind(vertices);
        
        int index = 0;
        while(edges < vertices - 1){
            int[] edge = orderedEdges[index++];
            int start = edge[0];
            int end = edge[1];
            int distance = edge[2];
            
            if(uf.Union(start, end)){
                cost += distance;
                edges++;
            }
        }
        
        return cost;
    }
}
