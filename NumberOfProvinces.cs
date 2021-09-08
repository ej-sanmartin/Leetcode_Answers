/*
    There are n cities. Some of them are connected, while some are not. If city a is 
    connected directly with city b, and city b is connected directly with city c, 
    then city a is connected indirectly with city c.

    A province is a group of directly or indirectly connected cities and no other 
    cities outside of the group.

    You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith 
    city and the jth city are directly connected, and isConnected[i][j] = 0 
    otherwise.

    Return the total number of provinces.

    T - O(n^2), using optimized union find data structure
    S - O(n), union find DS uses two arrays, both size n number of vertices in graph
*/
public class Solution {
    class UnionSet {
        private int[] root;
        private int[] rank;
        
        public UnionSet(int vertices){
            root = new int[vertices];
            rank = new int[vertices];
            for(int i = 0; i < vertices; i++){
                root[i] = -1;
                rank[i] = 1;
            }
        }
        
        public int GetSets(){
            int count = 0;
            
            foreach(int parent in root){
                if(parent == -1) count++;
            }
            
            return count;
        }
        
        public int Find(int x){
            if(root[x] == -1){
                return x;
            }
            return root[x] = Find(root[x]);
        }
        
        public void Union(int x, int y){
            int rootX = Find(x);
            int rootY = Find(y);
            if(rootX != rootY){
                if(rank[rootX] > rank[rootY]){
                    root[rootY] = rootX;
                } else if(rank[rootX] < rank[rootY]){
                    root[rootX] = rootY;
                } else {
                    root[rootY] = rootX;
                    rank[rootX]++;
                }
            }
        }
    }
    
    public int FindCircleNum(int[][] isConnected) {
        if(isConnected.Length == 0 || isConnected == null){
            return 0;
        }
        
        UnionSet set = new UnionSet(isConnected.Length);
        for(int row = 0; row < isConnected.Length; row++){
            for(int col = 0; col < isConnected[row].Length; col++){
                if(isConnected[row][col] == 1 && row != col){
                    set.Union(row, col);
                }    
            }
        }
        return set.GetSets();
    }
}
