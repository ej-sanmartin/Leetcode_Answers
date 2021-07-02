/*
    Given a n-ary tree, find its maximum depth.

    The maximum depth is the number of nodes along the longest path from the root node 
    down to the farthest leaf node.

    T - O(n), where n is the number of nodes in the tree. We must traverse all of them
              as we have to find the max height between all paths between root and
              leaf node
    S - O(h), worst space case is based on height of tree. If unbalanced, could be as
              as bad as O(n) space where the tree height is the size of all the nodes
              in it. If balanced, space would be O(logn)
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

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    int maxHeight;
    
    public int MaxDepth(Node root) {
        if(root == null) return 0;
        if(root.children.Count == 0) return 1;
        maxHeight = 0;
        MaxDepthHelper(root, 1);
        return maxHeight;
    }
    
    private int MaxDepthHelper(Node root, int height){
        if(root == null) return height;
        if(root.children.Count == 0){
            if(maxHeight < height) maxHeight = height;
            return height;
        }
        
        foreach(var child in root.children){
            int currentHeight = MaxDepthHelper(child, height + 1);
            if(maxHeight < currentHeight) maxHeight = currentHeight;
        }
        
        return height;
    }
}
