/*
    Given the root of a binary tree, return the preorder traversal of its nodes' values.

    T - O(n), where n is the number of nodes in the tree, which we must touch all of.
    S - O(n), where n is the number of nodes in the tree that will needed to be added to a list
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
    public IList<int> PreorderTraversal(TreeNode root) {
        List<int> preorderList = new List<int>();
        PreorderTraversalHelper(root, preorderList);
        return preorderList;
    }
    
    private void PreorderTraversalHelper(TreeNode root, List<int> list){
        if(root == null) return;
        list.Add(root.val);
        PreorderTraversalHelper(root.left, list);
        PreorderTraversalHelper(root.right, list);
    }
}
