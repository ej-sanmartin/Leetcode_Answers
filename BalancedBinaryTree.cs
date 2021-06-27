/*
    Given a binary tree, determine if it is height-balanced.

    For this problem, a height-balanced binary tree is defined as:

    a binary tree in which the left and right subtrees of every node differ in 
    height by no more than 1.
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

/*
    T - O(n), since for every subtree we compute its height in constant time as well
              as compare the height of its children
    S - O(n), where n is the height of the stack, which can at worst be n size where
              n is every node in the tree. This would occur if tree is horribly
              unbalanced
*/
public class Solution {
    public bool IsBalanced(TreeNode root) {
        return PathHeight(root) != -1;
    }
    
    private int PathHeight(TreeNode root){
        if(root == null) return 0;
        int left = PathHeight(root.left);
        int right = PathHeight(root.right);
        if(CheckIfBalanced(left, right)) return -1;
        return Math.Max(left, right) + 1;
    }
    
    private bool CheckIfBalanced(int left, int right){
        if(left == -1 || right == -1 || Math.Abs(left - right) > 1) return true;
        return false;
    }
}

/*
    Slower implementation
    T - O(nlogn), as we are doing logn work for every node which is n times.
    S - O(n), where n is our recursion stack that is the height of the tree
*/
public class Solution {
    public bool IsBalanced(TreeNode root) {
        return IsBalancedHelper(root);
    }
    
    private bool IsBalancedHelper(TreeNode root){
        if(root == null) return true;
        int left = PathHeight(root.left);
        int right = PathHeight(root.right);
        
        if(IsBalancedHelper(root.left) && IsBalancedHelper(root.right)){
            return Math.Abs(left - right) <= 1;
        }
        
        return false;
    }
    
    private int PathHeight(TreeNode root){
        if(root == null) return 0;
        int left = PathHeight(root.left);
        int right = PathHeight(root.right);
        return Math.Max(left, right) + 1;
    }
}
