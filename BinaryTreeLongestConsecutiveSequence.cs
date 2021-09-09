/**
 Given the root of a binary tree, return the length of the longest consecutive sequence path.

 The path refers to any sequence of nodes from some starting node to any node in the tree along the 
 parent-child connections. The longest consecutive path needs to be from parent to child (cannot be 
 the reverse).

 T - O(n), as we go through every node in the tree n once
 S - O(h), depends on if tree is balanced
 
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
    int result;
    public int LongestConsecutive(TreeNode root) {
        if(root == null) return 0;
        result = 0;
        LCSRecursive(root);
        return result;
    }
    
    public int LCSRecursive(TreeNode root){
        if(root == null) return 0;
        int left = LCSRecursive(root.left);
        int right = LCSRecursive(root.right);
        int max = 1;
        if(root.left != null && root.left.val == root.val + 1){
            max = Math.Max(left + 1, max);
        }
        if(root.right != null && root.right.val == root.val + 1){
            max = Math.Max(right + 1, max);
        }
        result = Math.Max(result, max);
        return max;
    }
}
