/*
    Given a binary tree, find its minimum depth.

    The minimum depth is the number of nodes along the shortest path from the 
    root node down to the nearest leaf node.

    Note: A leaf is a node with no children.

    T - O(n), where n is the amount of nodes in the tree. We would have to 
              touch them all to get the min height
    S - O(n), where n is the height of the tree which effects the recursive 
              call stack
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
    public int MinDepth(TreeNode root) {
        return MinDepthHelper(root, 0);
    }
    
    private int MinDepthHelper(TreeNode root, int height){
        if(root == null) return height;
        if(root.left == null && root.right == null) return height + 1;
        int left = Int32.MaxValue;
        int right = Int32.MaxValue;
        if(root.left != null) left = MinDepthHelper(root.left, height + 1);
        if(root.right != null) right = MinDepthHelper(root.right, height + 1);
        return Math.Min(left, right);
    }
}
