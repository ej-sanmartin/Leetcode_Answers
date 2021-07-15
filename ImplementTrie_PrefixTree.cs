/*
    A trie (pronounced as "try") or prefix tree is a tree data structure used to 
    efficiently store and retrieve keys in a dataset of strings. There are various 
    applications of this data structure, such as autocomplete and spellchecker.

    Implement the Trie class:

    Trie() Initializes the trie object.
    void insert(String word) Inserts the string word into the trie.
    boolean search(String word) Returns true if the string word is in the trie (i.e., 
        was inserted before), and false otherwise.
    boolean startsWith(String prefix) Returns true if there is a previously inserted 
        string word that has the prefix prefix, and false otherwise.
*/
public class Trie {
    public class Node {
        public Dictionary<char, Node> children;
        public bool isEndWord;
        public Node(){
            this.children = new Dictionary<char, Node>();
            this.isEndWord = false;
        }
    }
    
    private Node root;
    
    /** Initialize your data structure here. */
    public Trie() {
        this.root = new Node();
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        InsertHelper(root, word, 0);
    }
    
    private void InsertHelper(Node root, string word, int index){
        if(word.Length == index){
            root.isEndWord = true;
            return;
        }
        
        char c = word[index];
        if(!root.children.ContainsKey(c)){
            Node newNode = new Node();
            root.children.Add(c, newNode);
        }
        
        InsertHelper(root.children[c], word, index + 1);
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        return SearchHelper(root, word, 0);
    }
    
    private bool SearchHelper(Node root, string word, int index){
        if(word.Length == index) return root.isEndWord;
        
        char c = word[index];
        if(!root.children.ContainsKey(c)) return false;
        
        return SearchHelper(root.children[c], word, index + 1);
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
        return StartsWithHelper(root, prefix, 0);
    }
    
    private bool StartsWithHelper(Node root, string prefix, int index){
        if(prefix.Length == index) return true;
        
        char c = prefix[index];
        if(!root.children.ContainsKey(c)) return false;
        
        return StartsWithHelper(root.children[c], prefix, index + 1);
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
