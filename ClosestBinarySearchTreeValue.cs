/*
    Given the root of a binary search tree and a target value, return the value in 
    the BST that is closest to the target.

    T - O(n), we would need to check all nodes n to see which node is closest to target
    S - O(h), recursive stack space would depend on height of tree
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
    public int ClosestValue(TreeNode root, double target) {
        return ClosestValueHelper(root, target, Int32.MaxValue, Int32.MaxValue);
    }
    
    private int ClosestValueHelper(TreeNode root, double target, double closest, int closestNode){
        if(root == null) return closestNode;
        double currentClosest = Math.Abs(root.val - target);
        if(currentClosest < closest){
            closest = currentClosest;
            closestNode = root.val;
        }
        closestNode = ClosestValueHelper(root.left, target, closest, closestNode);
        closestNode = ClosestValueHelper(root.right, target, closest, closestNode);
        return closestNode;
    }
}
