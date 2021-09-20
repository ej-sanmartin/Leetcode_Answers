/*
    Given an integer n, return all the structurally unique BST's (binary search trees), which 
    has exactly n nodes of unique values from 1 to n. Return the answer in any order.

    T - O(nGn), catalan number, combinations formula
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
    public IList<TreeNode> GenerateTrees(int n) {
        if(n == 0){
            return new List<TreeNode>();
        }
        return GenerateTreesRecursive(1, n);
    }
    
    public List<TreeNode> GenerateTreesRecursive(int start, int end){
        List<TreeNode> allTrees = new List<TreeNode>();
        if(start > end){
            allTrees.Add(null);
            return allTrees;
        }
        
        for(int i = start; i <= end; i++){
            List<TreeNode> leftTrees = GenerateTreesRecursive(start, i - 1);
            List<TreeNode> rightTrees = GenerateTreesRecursive(i + 1, end);
            
            foreach(TreeNode left in leftTrees){
                foreach(TreeNode right in rightTrees){
                    TreeNode current = new TreeNode(i);
                    current.left = left;
                    current.right = right;
                    allTrees.Add(current);
                }
            }
        }
        
        return allTrees;
    }
}
