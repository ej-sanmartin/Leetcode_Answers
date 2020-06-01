/**
  Given the root node of a binary search tree (BST) and a value to be inserted into the tree,
  insert the value into the BST. Return the root node of the BST after the insertion. It is
  guaranteed that the new value does not exist in the original BST.

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
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if(root == null){
            return new TreeNode(val);
        } 
        
        if(root.val > val){
            root.left = InsertIntoBST(root.left, val);
        } else {
            root.right = InsertIntoBST(root.right, val);
        }

        return root;
    }
}
