/*
  Consider all the leaves of a binary tree, from left to right order, the values of those leaves form a leaf value sequence.
  For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8).
  Two binary trees are considered leaf-similar if their leaf value sequence is the same.
  Return true if and only if the two given trees with head nodes root1 and root2 are leaf-similar.
  
  T - O(n + m), where n and m are the two different trees we have to traverse through fully to populate their corresponding
                lists of leaf value sequences.
  S - O(n + m), where n and m are the space needed to traverse the two trees and store their leaf values
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
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        Stack<int> leafValueSequenceOne = new Stack<int>();
        Stack<int> leafValueSequenceTwo = new Stack<int>();
        
        FindLeafValueSequence(root1, leafValueSequenceOne);
        FindLeafValueSequence(root2, leafValueSequenceTwo);
        
        if(leafValueSequenceOne.Count != leafValueSequenceTwo.Count) return false;
        
        while((leafValueSequenceOne.Count != 0) && (leafValueSequenceTwo.Count != 0)){
            if(leafValueSequenceOne.Peek() != leafValueSequenceTwo.Peek()) return false;
            leafValueSequenceOne.Pop();
            leafValueSequenceTwo.Pop();
        }
        
        return true;
    }
    
    private void FindLeafValueSequence(TreeNode root, Stack<int> stack){
        if(root == null) return;
        if(root.left == null && root.right == null){
            stack.Push(root.val);
            return;
        }
        if(root.left != null) FindLeafValueSequence(root.left, stack);
        if(root.right != null) FindLeafValueSequence(root.right, stack);
    }
}
