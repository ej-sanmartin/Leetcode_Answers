/*  2021 UPDATED ANSWER  */
/*
    T - O(n), where n is the number of nodes in the trees. We must process all of them
    S - O(h), where h is the size of the recursive call stack. Depends on if tree is 
              balanced or not
*/
public class Solution {
    public bool IsSymmetric(TreeNode root) {
        return IsSymmetricHelper(root.left, root.right);
    }
    
    private bool IsSymmetricHelper(TreeNode left, TreeNode right){
        if(left == null && right == null) return true;
        if(left == null || right == null) return false;
        bool leftMirror = IsSymmetricHelper(left.left, right.right);
        bool rightMirror = IsSymmetricHelper(left.right, right.left);
        return (left.val == right.val) && leftMirror && rightMirror;
    }
}

/*
  Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
  
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
    public bool IsSymmetric(TreeNode root) {
        if (root == null)  { return true; }
        return IsSymmetricHelper(root.left, root.right);
    }

    public bool IsSymmetricHelper(TreeNode left,  TreeNode right){
        if(left == null && right == null) { return true; }
        if(left == null || right == null) { return false; }
        if(left.val == right.val) {
            return IsSymmetricHelper(left.left, right.right) && IsSymmetricHelper(left.right, right.left);
        } else { return false; }
    }
}
