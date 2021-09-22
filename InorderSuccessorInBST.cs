/*
    Given the root of a binary search tree and a node p in it, return the in-order 
    successor of that node in the BST. If the given node has no in-order successor 
    in the tree, return null.

    The successor of a node p is the node with the smallest key greater than p.val.

    T - O(h), depends on tree balance
    S - O(1), no recursion, so constant space
*/
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        TreeNode successor = null;
        
        while(root != null){
            if(p.val >= root.val){
                root = root.right;
            } else {
                successor = root;
                root = root.left;
            }
        }
        
        return successor;
    }
}
