/*
    Given the root of a binary search tree, rearrange the tree in in-order so that 
    the leftmost node in the tree is now the root of the tree, and every node has no 
    left child and only one right child.

    T - O(n), where n is the number of nodes to in the tree that we have to go 
              through every one of them to get output
    S - O(h), where h is the height of the tree and also the amount of recursive 
              call stacks
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
    TreeNode constructedTree;
    public TreeNode IncreasingBST(TreeNode root) {
        TreeNode increasedTree = new TreeNode(0);
        constructedTree = increasedTree;
        inorderTraversal(root);
        return increasedTree.right;
    }
    
    private void inorderTraversal(TreeNode node){
        if(node == null) return;
        inorderTraversal(node.left);
        
        node.left = null;
        constructedTree.right = node;
        constructedTree = node;
        
        inorderTraversal(node.right);
    }
}
