/*
    Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in 
    the BST.

    According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between 
    two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a 
    node to be a descendant of itself).”
    
    T - O(h), where h is the height of the tree. If tree is balanced, traversal is O(logn) while
              if the tree is unbalanced, then time complexity if O(n) if heavily skewed
    S - O(h), see time complexity ananlysis explanation
*/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(p.val < root.val && q.val < root.val) return LowestCommonAncestor(root.left, p, q);
        else if(p.val > root.val && q.val > root.val) return LowestCommonAncestor(root.right, p, q);
        return root;
    }
}
