/**
 * Given the root of a binary tree, invert the tree, and return its root.
 *
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
 * T - O(n), where n is number of nodes that are in the tree
 * S - O(h), where h is the height of the tree and how large the recursive call stack would be
 */
public class Solution {
    public TreeNode InvertTree(TreeNode root) {
        if(root == null) return root;
        
        TreeNode left = InvertTree(root.left);
        TreeNode right = InvertTree(root.right);
        
        root.left = right;
        root.right = left;
        
        return root;
    }
}
