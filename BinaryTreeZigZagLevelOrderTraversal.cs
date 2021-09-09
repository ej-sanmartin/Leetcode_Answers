/**
 Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. 
 (i.e., from left to right, then right to left for the next level and alternate between).

 T - O(n), as we go through every node in tree once
 S 0 O(n), out output and queue will hold at most all of our tree nodes or half of it
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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        List<IList<int>> output = new List<IList<int>>();
        Queue<TreeNode> q = new Queue<TreeNode>();
        bool leftToRight = true;
        if(root != null){
            q.Enqueue(root);
        }
        
        while(q.Count != 0){
            LinkedList<int> level = new LinkedList<int>();
            int levelSize = q.Count;
            for(int i = 0; i < levelSize; i++){
                TreeNode current = q.Dequeue();
                if(leftToRight){
                    level.AddLast(current.val);
                } else {
                    level.AddFirst(current.val);
                }
                if(current.left != null){
                    q.Enqueue(current.left);
                }
                if(current.right != null){
                    q.Enqueue(current.right);
                }
            }
            leftToRight = !leftToRight;
            output.Add(level.ToList());
        }
        
        return output;
    }
}
