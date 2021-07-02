/*
    You are given the root of a binary tree where each node has a value 0 or 1.  Each root-to-
    leaf path represents a binary number starting with the most significant bit.  For example, 
    if the path is 0 -> 1 -> 1 -> 0 -> 1, then this could represent 01101 in binary, which is 
    13.

    For all leaves in the tree, consider the numbers represented by the path from the root to 
    that leaf.

    Return the sum of these numbers. The answer is guaranteed to fit in a 32-bits integer.

    T - O(n), n being the amount of nodes in the tree. Must traverse through all paths from 
              root to tree, which entails going through every node
    S - O(h), where h is the height of the tree and thus the recursive call stack.
              Unbalanced tree has O(n) space and balanced tree takes O(logn) space to recurse
              through it
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
    public int SumRootToLeaf(TreeNode root) {
        return SumRootToLeafHelper(root, 0);
    }
    
    private int SumRootToLeafHelper(TreeNode node, int count){
        if(node == null) return 0;
        count = (count * 2) + node.val;
        if(node.left == null && node.right == null) return count;
        return SumRootToLeafHelper(node.left, count) + SumRootToLeafHelper(node.right, count);
    }
}
