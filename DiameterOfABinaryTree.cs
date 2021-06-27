/*
    Given the root of a binary tree, return the length of the diameter of the tree.

    The diameter of a binary tree is the length of the longest path between any two nodes in a tree. 
    This path may or may not pass through the root.

    The length of a path between two nodes is represented by the number of edges between them.

    T - O(n), where n is the number of nodes in the binary tree. Have to go through them all to find
              max heights and find largest diameter
    S - O(h), where h is the height of the binary tree which effects the recursive call stack
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
    private int _diameter;
    
    public int DiameterOfBinaryTree(TreeNode root) {
        _diameter = 0;
        LongestPath(root);
        return _diameter;
    }
    
    private int LongestPath(TreeNode node){
        if(node == null) return 0;
        
        int left = LongestPath(node.left);
        int right = LongestPath(node.right);
        
        _diameter = Math.Max(_diameter, left + right);
        
        return Math.Max(left, right) + 1;
    }
}
