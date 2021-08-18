/*
    Given the root of a binary tree, return an array of the largest value in 
    each row of the tree (0-indexed).

    T - O(n), where n is the number of nodes in the tree. We must traverse
              through them all
    S - O(n), at worst case the queue will hold n/2 tree nodes if given a
              full perfect tree
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
    public IList<int> LargestValues(TreeNode root) {
        List<int> output = new List<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        
        if(root != null){
            queue.Enqueue(root);
        }
        
        while(queue.Count != 0){
            int levelSize = queue.Count;
            int maxNumber = Int32.MinValue;
            
            for(int i = 0; i < levelSize; i++){
                TreeNode current = queue.Dequeue();
                maxNumber = Math.Max(maxNumber, current.val);
                if(current.left != null){
                    queue.Enqueue(current.left);   
                }
                
                if(current.right != null){
                    queue.Enqueue(current.right);
                }
            }
            
            output.Add(maxNumber);
        }
        
        return output;
    }
}
