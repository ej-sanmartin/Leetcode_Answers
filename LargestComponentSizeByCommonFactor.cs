/*
    You are given an integer array of unique positive integers nums. Consider the following graph:

    There are nums.length nodes, labeled nums[0] to nums[nums.length - 1],
    There is an undirected edge between nums[i] and nums[j] if nums[i] and nums[j] share a common 
        factor greater than 1.

    Return the size of the largest connected component in the graph.
    
    Note: n is the number of elements in the list, and m is the max value of the input list
    T - O(n * SQRT(m) * log star m), largest operation was unioning all the numbers and their factors 
    S - O(n + m), we create dictionary of size n at worst case, and DS array is of size m
*/
public class Solution {
    public class UnionFind {
        private int[] root;
        private int[] rank;
        
        // O(n)
        public UnionFind(int vertices){
            root = new int[vertices];
            rank = new int[vertices];
            for(int i = 0; i < vertices; i++){
                root[i] = i;
                rank[i] = 1;
            }
        }
        
        // O(1), average
        public int Find(int x){
            if(x == root[x]){
                return x;
            }
            return root[x] = Find(root[x]);
        }
        
        // O(1), average
        public void Union(int x, int y){
            int xRoot = Find(x);
            int yRoot = Find(y);
            if(xRoot != yRoot){
                if(rank[xRoot] > rank[yRoot]){
                    root[yRoot] = xRoot;
                } else if(rank[xRoot] < rank[yRoot]){
                    root[xRoot] = yRoot;
                } else {
                    root[yRoot] = xRoot;
                    rank[xRoot]++;
                }
            }
        }
    }
    
    public int LargestComponentSize(int[] nums) {
        int maxValue = nums.Aggregate((x, y) => x > y ? x : y); // Uses LINQ's reduce method
        UnionFind ds = new UnionFind(maxValue + 1); // +1 to hold just enough items
        
        foreach(int num in nums){
            for(int factor = 2; factor < (int)(Math.Sqrt(num)) + 1; ++factor){
                if(num % factor == 0){
                    ds.Union(num, factor);
                    ds.Union(num, num / factor);
                }
            }
        }
        
        int maxGroupSize = 0;
        Dictionary<int, int> groupCount = new Dictionary<int, int>();
        foreach(int num in nums){
            int groupID = ds.Find(num);
            if(!groupCount.ContainsKey(groupID)){
                groupCount.Add(groupID, 0);
            }
            groupCount[groupID]++;
            maxGroupSize = Math.Max(maxGroupSize, groupCount[groupID]);
        }
        
        return maxGroupSize;
    }
}
