/*
  Given a binary tree, return the inorder traversal of its nodes' values.
  
  Definition for a binary tree node.
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }
 */
 
public class Solution {
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> answer = new List<int>();
        traversalHelper(root, answer); 
        return answer;
    }
    
    private void traversalHelper(TreeNode node, List<int> result) {
        if(node != null) {
            traversalHelper(node.left, result);
            result.Add(node.val);
            traversalHelper(node.right, result);
        }
    }
}
