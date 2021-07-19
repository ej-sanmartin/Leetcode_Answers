/*
    T - O(n), as we must traverse every element of the given postorder list to place nodes in their
              correct position
    S - O(h), where h is the height of the recursive call stack
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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        int inorderIndex = inorder.Length - 1;
        int postorderIndex = postorder.Length - 1;
        return BuildTreeHelper(ref inorderIndex, ref postorderIndex, null, inorder, postorder);
    }
    
    private TreeNode BuildTreeHelper(ref int inorderIndex, ref int postorderIndex, int? rootValue, int[] inorder, int[] postorder){
        if(rootValue.HasValue && inorder[inorderIndex] == rootValue){
            inorderIndex--;
            return null;
        }
        
        if(postorderIndex < 0) return null;
        
        TreeNode node = new TreeNode(postorder[postorderIndex--]);
        
        node.right = BuildTreeHelper(ref inorderIndex, ref postorderIndex, node.val, inorder, postorder);
        node.left = BuildTreeHelper(ref inorderIndex, ref postorderIndex, rootValue, inorder, postorder);
            
        return node;
    }
}
