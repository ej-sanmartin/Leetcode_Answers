/**
  Given a binary tree, return the sum of values of nodes with even-valued grandparent.  
  A grandparent of a node is the parent of its parent, if it exists.)

  If there are no nodes with an even-valued grandparent, return 0.

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
    public int SumEvenGrandparent(TreeNode root) {
        int answer = 0;  // store answer here
        
        // current, if root node at top of tree, is needed. But initially parent and grandparent can be null
        void findSum(TreeNode current, TreeNode parent, TreeNode grandparent){
            // recursive check, if node doesn't exist, exits
            if(current == null){
                return;
            }
            
            // there must be a grandparent node passed and it must be even for answer int to be updated
            if(grandparent != null && grandparent.val % 2 == 0){
                answer += current.val;
            }
            
            // checks left and right side of binary tree
            findSum(current.left, current, parent);
            findSum(current.right, current, parent);
  
        }
        
        findSum(root, null, null);
        
        return answer;
    }
}
