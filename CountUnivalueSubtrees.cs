/*
  Given a binary tree, find all univalue subtrees
  Univalue subtreess are defined as trees where parent and all of its
  descendants have the same value
  
  T - O(n), we are going to check through all nodes in tree to see which
            are apart of a univalue trees
  S - O(h), where the space is determined by the recursive call stack which
            depends on whether or not the tree is balanced
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
    private int count;
    public int CountUnivalSubtrees(TreeNode root) {
        count = 0;
        UnivalSubtrees(root, 0);
        return count;
    }
    
    private bool UnivalSubtrees(TreeNode root, int value){
        if(root == null) return true;
        if(!UnivalSubtrees(root.left, root.val) | !UnivalSubtrees(root.right, root.val)) return false;
        count++;
        return root.val == value;
    }
}
