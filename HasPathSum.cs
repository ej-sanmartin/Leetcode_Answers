/*
    Given the root of a binary tree and an integer targetSum, return true if the tree 
    has a root-to-leaf path such that adding up all the values along the path equals 
    targetSum.

    A leaf is a node with no children.

    T - O(n), at worst we check through every path to find no path has reached target
    S - O(h), depends on height of the tree, which effects recursive call stack
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
    public bool HasPathSum(TreeNode root, int targetSum) {
        if(root == null) return false;
        targetSum -= root.val;
        if((root.left == null) && (root.right == null)) return targetSum == 0;
        return HasPathSum(root.left, targetSum) || HasPathSum(root.right, targetSum);
    }
}
