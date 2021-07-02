/*
    Given the root of an n-ary tree, return the preorder traversal of its nodes' 
    values.

    T - O(n), n is the amount of nodes in tree. We must traverse through them all to
              create the list with the tree nodes in preorder
    S - O(n), where h is the height of the tree and the amount of recursive call     
              stacks we will have.
              If counting the list we are creating in space analysis, we are         
              creating a list that is of space n, where n is the amount of nodes in 
              the tree
*/

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<int> Preorder(Node root) {
        List<int> preorderList = new List<int>();
        preorderHelper(root, preorderList);
        return preorderList;
    }
    
    private void preorderHelper(Node node, List<int> list){
        if(node == null) return;
        
        list.Add(node.val);
        
        foreach(Node child in node.children){
            preorderHelper(child, list);
        }
    }
}
