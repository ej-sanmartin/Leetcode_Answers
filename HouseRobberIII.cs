/**
 The thief has found himself a new place for his thievery again. There is only one 
 entrance to this area, called root.

 Besides the root, each house has one and only one parent house. After a tour, the 
 smart thief realized that all houses in this place form a binary tree. It will 
 automatically contact the police if two directly-linked houses were broken into on 
 the same night.

 Given the root of the binary tree, return the maximum amount of money the thief can 
 rob without alerting the police.

 T - O(n), we optimized with the memo and only need to touch every node of tree once,
           which is of size n
 S - O(n), memo table holds as much n kvp which is equal to the number of nodes and 
           thus number of different choices we can make
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
    public int Rob(TreeNode root) {
        if(root == null) return 0;
        Dictionary<TreeNode, int> memo = new Dictionary<TreeNode, int>();
        return Helper(root, memo);
    }
    
    private int Helper(TreeNode root, Dictionary<TreeNode, int> memo){
        if(root == null) return 0;
        if(memo.ContainsKey(root)) return memo[root];
        
        int excludeCurrent = Helper(root.left, memo) + Helper(root.right, memo);
        int includeCurrent = root.val;
        int left = 0;
        int right = 0;
        if(root.left != null){
            left = Helper(root.left.left, memo) + Helper(root.left.right, memo);
        }
        
        if(root.right != null){
            right = Helper(root.right.left, memo) + Helper(root.right.right, memo);
        }
        
        includeCurrent += left + right;
        
        int maxCurrent = Math.Max(excludeCurrent, includeCurrent);
        memo[root] = maxCurrent;
        return maxCurrent;
    }
}
