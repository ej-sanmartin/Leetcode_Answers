/*
    There are n people in a social group labeled from 0 to n - 1. You are given an array logs where 
    logs[i] = [timestampi, xi, yi] indicates that xi and yi will be friends at the time timestampi.

    Friendship is symmetric. That means if a is friends with b, then b is friends with a. Also, person 
    a is acquainted with a person b if a is friends with b, or a is a friend of someone acquainted with 
    b.

    Return the earliest time for which every person became acquainted with every other person. If there 
    is no such earliest time, return -1.
    
    T - O(|E| * V), for each array in our multidimensional array of edges, we do a Union operation that 
                    runs on average O(V)
    S - O(|V|), we create disjoint set which creates an array the size of the number of vertices
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
            if(x == root[x]){
                return x;
            }
            return root[x] = Find(root[x]);
        }
        
        public int Union(int x, int y){
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
                return 1;
            }
            return 0;
        }
    }
    
    public int EarliestAcq(int[][] logs, int n) {
        if(n == 0 || n == null){
            return -1;
        }
        int total = n;
        UnionFind disjointSet = new UnionFind(n);
        Array.Sort(logs, (a, b) => a[0] - b[0]);
        foreach(int[] log in logs){
            total -= disjointSet.Union(log[1], log[2]);
            if(total == 1) return log[0];
        }
        return -1;
    }
}
