/**
 Given the root node of a binary search tree, return the sum of
 values of all nodes with value between L and R (inclusive).

 The binary search tree is guaranteed to have unique values.
 
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
    public int RangeSumBST(TreeNode root, int L, int R) {
        if(root == null){
            return 0;
        }
        
        if(root.val <= L && root.val >= R || root.val >= L && root.val <= R){
            return root.val + RangeSumBST(root.left, L, R) + RangeSumBST(root.right, L, R);
        } else {
            return RangeSumBST(root.left, L, R) + RangeSumBST(root.right, L, R);
        }
    }
}
