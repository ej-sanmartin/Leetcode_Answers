/*
    You are given the root of a binary search tree (BST) and an integer val.

    Find the node in the BST that the node's value equals val and return the subtree 
    rooted with that node. If such a node does not exist, return null.
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
    /*
        Recursive solutions
        T - O(h), time complexity depends on tree height. If unbalanced, O(n),
                  and if the tree is balanced O(logn) would be the time for search
        S - O(h), where the space complexity depends on the height of the tree due
                  to the recusive stack calls created to complete this function.
                  Unbalanced has an O(n) sized call stack and balanced trees have a
                  O(logn) call stack
    */
    public TreeNode SearchBST(TreeNode root, int val) {
        if(root == null) return null;
        if(root.val > val) return SearchBST(root.left, val);
        if(root.val < val) return SearchBST(root.right, val);
        else return root;
    }
    
    /*
        Iterative solutions
        T - O(h), time complexity depends on tree height. If unbalanced, O(n),
                  and if the tree is balanced O(logn) would be the time for search
        S - O(1), since we are not creating any additional space to run this
                  function
    */
    public TreeNode SearchBST(TreeNode root, int val){
        while(root != null && root.val != val){
            if(root.val >= val) root = root.left;
            else root = root.right;
        }
        return root;
    }
}
