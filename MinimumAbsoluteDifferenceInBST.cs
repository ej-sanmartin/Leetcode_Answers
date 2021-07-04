/*
    Given the root of a Binary Search Tree (BST), return the minimum absolute 
    difference between the values of any two different nodes in the tree.

    T - O(n), n being the number of nodes in the tree, which we must traverse 
              through all to get out answer
    S - O(h), where h is the height of the tree which effects the recursive 
              call stack
              Unbalanced - O(n)
              Balanced - O(logn)
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
    public int GetMinimumDifference(TreeNode root) {
        int[] values = new int[]{ Int32.MaxValue, Int32.MaxValue };
        InorderTraversal(root, values);
        return values[0];
    }
    
    private void InorderTraversal(TreeNode root, int[] array){
        if(root == null) return;
        InorderTraversal(root.left, array);
        
        int minDistance = array[0];
        int previous = array[1];
        int currentDistance = Math.Abs(root.val - previous);
        array[0] = Math.Min(array[0], currentDistance);
        array[1] = root.val;
        
       InorderTraversal(root.right, array);
    }
}
