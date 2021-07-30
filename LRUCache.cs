/*
    Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.

    Implement the LRUCache class:


    LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
    int get(int key) Return the value of the key if the key exists, otherwise return -1.
    void put(int key, int value) Update the value of the key if the key exists. Otherwise, add 
        the key-value pair to the cache. If the number of keys exceeds the capacity from this 
        operation, evict the least recently used key.


    The functions get and put must each run in O(1) average time complexity.
*/
public class LRUCache {
    Dictionary<int, LinkedListNode<int[]>> table;
    LinkedList<int[]> cache;
    int size;
    int capacity;
    
    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.size = 0;
        this.table = new Dictionary<int, LinkedListNode<int[]>>();
        this.cache = new LinkedList<int[]>();
    }
    
    public int Get(int key) {
        bool exists = false;
        
        if(table.ContainsKey(key)){
            UpdateItem(key);
            exists = true;
        }
        
        return exists ? cache.First.Value[1] : -1;
    }
    
    public void Put(int key, int value) {
        if(capacity == size && !table.ContainsKey(key)){
            table.Remove(cache.Last.Value[0]);
            cache.RemoveLast();
            size--;
        }
        
        if(table.ContainsKey(key)){
            UpdateItem(key);
            cache.First.Value[1] = value;
        } else {
            size++;
            cache.AddFirst(new int[]{ key, value });
            table.Add(key, cache.First);
        }
    }
    
    private void UpdateItem(int key){
        LinkedListNode<int[]> recentlyAccessed = table[key];
        cache.Remove(recentlyAccessed);
        cache.AddFirst(recentlyAccessed);
        table[key] = cache.First;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
