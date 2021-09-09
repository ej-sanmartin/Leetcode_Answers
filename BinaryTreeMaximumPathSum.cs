/**
 A path in a binary tree is a sequence of nodes where each pair of adjacent nodes in the sequence 
 has an edge connecting them. A node can only appear in the sequence at most once. Note that the
 path does not need to pass through the root.

 The path sum of a path is the sum of the node's values in the path.

 Given the root of a binary tree, return the maximum path sum of any path.

 T - O(n), n being the number of nodes in the tree, which we traverse through all of
 S - O(h), depends on if the tree is balanced

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
    int max;
    public int MaxPathSum(TreeNode root) {
        max = Int32.MinValue;
        Search(root);
        return max;
    }
    
    public int Search(TreeNode root){
        if(root == null) return 0;
        int left = Math.Max(0, Search(root.left));
        int right = Math.Max(0, Search(root.right));
        max = Math.Max(max, left + right + root.val);
        return Math.Max(left, right) + root.val;
    }
}
