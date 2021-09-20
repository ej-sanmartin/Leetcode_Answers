/*
    Given the root of a binary tree, determine if it is a valid binary search tree (BST).

    A valid BST is defined as follows:

    The left subtree of a node contains only nodes with keys less than the node's key.
    The right subtree of a node contains only nodes with keys greater than the node's key.
    Both the left and right subtrees must also be binary search trees.

    T - O(n), n being the number of nodes in the tree that we must traverse through
    S - O(h), recursive call stack, depends on if tree is balanced
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
    public bool IsValidBST(TreeNode root) {
        return IsValidBSTHelper(root, null, null);
    }
    
    public bool IsValidBSTHelper(TreeNode root, int? leftBound, int? rightBound){
        if(root == null){
            return true;
        }
        if((leftBound != null && root.val <= leftBound) || (rightBound != null && root.val >= rightBound)){
            return false;
        }
        bool leftResult = IsValidBSTHelper(root.left, leftBound, root.val);
        bool rightResult = IsValidBSTHelper(root.right, root.val, rightBound);
        return leftResult && rightResult;
    }
}
