/*
    Given a root node reference of a BST and a key, delete the node with the given 
    key in the BST. Return the root node reference (possibly updated) of the BST.

    Basically, the deletion can be divided into two stages:
        Search for a node to remove.
        If the node is found, delete the node.

    Follow up: Can you solve it with time complexity O(height of tree)?

    T - O(H), depends on if tree is balanced
    S - O(H), depends on if tree is balanced
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
    public TreeNode DeleteNode(TreeNode root, int key) {
        return DeleteNodeHelper(root, key);
    }
    
    private TreeNode GetMin(TreeNode root){
        if(root.left == null){
            return root;
        }
        return GetMin(root.left);
    }
    
    private TreeNode DeleteNodeHelper(TreeNode root, int key){
        if(root == null){
            return null;
        } else if(root.val > key){
            root.left = DeleteNodeHelper(root.left, key);
        } else if(root.val < key){
            root.right = DeleteNodeHelper(root.right, key);
        } else {
            if(root.left == null && root.right == null){ // no children
                root = null;
            } else if(root.left == null){ // one children
                root = root.right;
            } else if(root.right == null){
                root = root.left;
            } else { // two children
                TreeNode minNode = GetMin(root.right);
                root.val = minNode.val;
                root.right = DeleteNodeHelper(root.right, minNode.val);
            }
        }
        return root;
    }
}
