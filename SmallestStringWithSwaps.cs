/*
    You are given a string s, and an array of pairs of indices in the string pairs where pairs[i] = [a, 
    b] indicates 2 indices(0-indexed) of the string.

    You can swap the characters at any pair of indices in the given pairs any number of times.

    Return the lexicographically smallest string that s can be changed to after using the swaps.
    
    T - O(M + VlogV), where m is the size of our pairs list and V is the string size, which we sort n 
                      number of times in final foreach loop
    S - O(v), creating disjoint set of size number of vertices, our dictionary is also of size vertices
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
    
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs) {
        if(s == null || s.Length == 0){
            return s;
        }
        
        int vertices = s.Length;
        UnionFind uf = new UnionFind(vertices);
        foreach(var pair in pairs){
            uf.Union(pair[0], pair[1]);
        }
        
        Dictionary<int, List<int>> table = new Dictionary<int, List<int>>();
        for(int i = 0; i < vertices; i++){
            int parent = uf.Find(i);
            if(!table.ContainsKey(parent)){
                table[parent] = new List<int>();
            }
            table[parent].Add(i);
        }
        
        char[] output = new char[vertices];
        foreach(KeyValuePair<int, List<int>> entry in table){
            int parent = entry.Key;
            List<int> list = entry.Value;
            char[] charList = new char[list.Count];
            int i = 0;
            foreach(int index in list){
                charList[i++] = s[index];
            }
            Array.Sort(charList);
            i = 0;
            foreach(int index in list){
                output[index] = charList[i++];
            }
        }
        return new string(output);
    }
}
