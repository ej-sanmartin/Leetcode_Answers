/**
 * Definition for a binary tree node.
 /*
  Return a list of lists of the value of nodes in a Binary Tree in Level Order
  
  T - O(n), where n is every node in the tree given
  S - O(n), where n is the number of elements in the queue. Theoritically, can be as large as half of
            the nodes in a tree.
 */
 
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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var output = new List<IList<int>>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        TreeNode current;
        int levelSize;
        if(root != null) queue.Enqueue(root);
        
        while(queue.Count != 0){
            List<int> level = new List<int>();
            levelSize = queue.Count;
            while(levelSize != 0){
                current = queue.Dequeue();
                level.Add(current.val);
                if(current.left != null) queue.Enqueue(current.left);
                if(current.right != null) queue.Enqueue(current.right);
                levelSize--;
            }
            output.Add(level);
        }
        
        return output;
    }
}
