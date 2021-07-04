/*
    Given the root of a binary tree, return the sum of all left leaves.

    T - O(n), where n is the number of nodes in the tree, since we have to 
              traverse through every element in the tree to get to the leaves
    S - O(h), where h is the height of the binary tree.
              Unbalanced: O(n)
              Balanced: O(logn)
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
    public int SumOfLeftLeaves(TreeNode root) {
        if(root == null) return 0;
        return SumOfLeftLeaves(root, false);
    }
    
    private int SumOfLeftLeaves(TreeNode root, bool isLeftLeaf){
        if(root.left == null && root.right == null){
            if(isLeftLeaf) return root.val;
            else return 0;
        }

        int total = 0;
        
        if(root.left != null) total += SumOfLeftLeaves(root.left, true);
        if(root.right != null) total += SumOfLeftLeaves(root.right, false);
        
        return total;
    }
}
