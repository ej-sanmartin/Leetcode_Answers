/*
    Given the root of a binary tree, imagine yourself standing on the right 
    side of it, return the values of the nodes you can see ordered from top to 
    bottom.

    T - O(n), where n is the number of nodes in Binary Tree
    S - O(n), queue can have as much as n / 2 nodes in it by the time
              we reach the last level in a complete / perfect binary tree
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
    public IList<int> RightSideView(TreeNode root) {
        List<int> rightView = new List<int>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        if (root != null) {
            q.Enqueue(root);
        }
        while (q.Count != 0) {
            int levelSize = q.Count;
            for (int i = 0; i < levelSize; i++) {
                TreeNode current = q.Dequeue();
                if (i + 1 == levelSize) {
                    rightView.Add(current.val);
                }
                
                if (current.left != null) {
                    q.Enqueue(current.left);
                }
                
                if (current.right != null) {
                    q.Enqueue(current.right);
                }
            }
        }
        return rightView;
    }
}
