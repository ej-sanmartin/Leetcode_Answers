/*
    Given the root of a binary search tree (BST) with duplicates, return all the 
    mode(s) (i.e., the most frequently occurred element) in it.

    If the tree has more than one mode, return them in any order.

    Assume a BST is defined as follows:

    The left subtree of a node contains only nodes with keys less than or equal to 
    the node's key.
    The right subtree of a node contains only nodes with keys greater than or equal 
    to the node's key.
    Both the left and right subtrees must also be binary search trees.

    T - O(n), as we must traverse through all nodes in tree to check for modes
    S - O(1), besides recursive stack space, we are only using int variables to
              store state
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
    int? _previous = null;
    int _count = 1;
    int _max = 0;
    
    public int[] FindMode(TreeNode root) {
        List<int> modes = new List<int>();
        inOrderTraverse(root, modes);
        return modes.ToArray();
    }
    
    private void inOrderTraverse(TreeNode root, List<int> modes){
        if(root == null) return;
        inOrderTraverse(root.left, modes);
        
        if(_previous.HasValue){
            if(_previous == root.val){
                _count++;
            } else {
                _count = 1;
            }
        }
        
        if(_count > _max){
            _max = _count;
            modes.Clear();
            modes.Add(root.val);
        } else if(_count == _max){
            modes.Add(root.val);
        }
        
        _previous = root.val;
        
        inOrderTraverse(root.right, modes);
    }
}
