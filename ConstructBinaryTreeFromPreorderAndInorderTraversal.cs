/*
    Given two integer arrays preorder and inorder where preorder is the preorder traversal
    of a binary tree and inorder is the inorder traversal of the same tree, construct and
    return the binary tree.

    T - O(n), as we must traverse through all elements in the lists provided
    S - O(n), depends on the recursice call stack,which depends on if the tree is balanced
              or not
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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return BuildTreeHelper(0, 0, preorder.Length - 1, preorder, inorder);
    }
    
    private TreeNode BuildTreeHelper(int preorderIndex, int start, int end, int[] preorder, int[] inorder){
        if(preorderIndex > preorder.Length - 1 || start > end) return null;
        
        TreeNode root = new TreeNode(preorder[preorderIndex]);
        
        int inorderIndex = 0;
        for(int i = start; i <= end; i++){
            if(root.val == inorder[i]) inorderIndex = i;
        }
        
        root.left = BuildTreeHelper(preorderIndex + 1, start, inorderIndex - 1, preorder, inorder);
        root.right = BuildTreeHelper(preorderIndex + inorderIndex - start + 1, inorderIndex + 1, end, preorder, inorder);
        
        return root;
    }
}
