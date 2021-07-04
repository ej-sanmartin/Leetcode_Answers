/*
    Given the root of a binary tree, return the postorder traversal of its nodes' values.
    
    T - O(n), where n is the number of nodes in the tree. We must traverse through them all
    S - O(n), where n is the size of the list storing the nodes of the tree in postorder
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
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> postorderList = new List<int>();
        PostorderTraversalHelper(root, postorderList);
        return postorderList;
    }
    
    private void PostorderTraversalHelper(TreeNode root, List<int> list){
        if(root == null) return;
        PostorderTraversalHelper(root.left, list);
        PostorderTraversalHelper(root.right, list);
        list.Add(root.val);
    }
}
