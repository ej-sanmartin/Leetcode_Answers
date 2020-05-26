/**
  Given two binary trees original and cloned and given a
  reference to a node target in the original tree.

  The cloned tree is a copy of the original tree.

  Return a reference to the same node in the cloned tree.

 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    TreeNode answer;
    
    // does check for making sure the currently passed node isn't null
    public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target) {
        if(cloned == null || target == null){
            return null;
        }
        
        search(cloned, target);
        return answer;
    }
    
    // searches for match between clone and target node
    public void search(TreeNode clone, TreeNode target){
        if(clone == null){ // clone is empty, so stop
            return;
        }
        
        if(answer != null){ // answer is found, so stop
            return;
        }
        
        if(clone.val == target.val){ // answer is found if clone and target match in value
            answer = clone;
            return;
        }
        
        // recursively checks both sides for answer
        search(clone.left,target);
        search(clone.right,target);
    }
}
