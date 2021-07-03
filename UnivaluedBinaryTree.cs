/*
    A binary tree is univalued if every node in the tree has the same value.
    Return true if and only if the given tree is univalued.

    T - O(n), where n is the number of nodes in the tree since we have to check every node
              to make sure the tree is univalued
    S - O(h), where h is the height of the tree which effects the recursive call stack
              Unbalanced - O(n)
              Balanced - O(logn)
*/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool IsUnivalTree(TreeNode root) {
        if(root == null) return true;
        if(root.left != null && root.val != root.left.val) return false;
        if(root.right != null && root.val != root.right.val) return false;
        return IsUnivalTree(root.left) && IsUnivalTree(root.right);
    }
}
