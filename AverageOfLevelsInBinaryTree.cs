/*
    
    Given the root of a binary tree, return the average value of the nodes on each 
    level in the form of an array. Answers within 10-5 of the actual answer will be 
    accepted.

    T - O(n), where n is the amount of nodes in the tree. We have to traverse them all
              in level order in order to get each level's averages
    S - O(n), where n is the number of nodes in a level that will be placed in a queue
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
    public IList<double> AverageOfLevels(TreeNode root) {
        List<double> averageOfLevels = new List<double>();
        int levelSize, i;
        double sum;
        TreeNode temp;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while(queue.Count != 0){
            levelSize = queue.Count;
            sum = 0;
            for(i = 0; i < levelSize; i++){
                temp = queue.Dequeue();
                sum += (double)temp.val;
                if(temp.left != null) queue.Enqueue(temp.left);
                if(temp.right != null) queue.Enqueue(temp.right);
            }
            averageOfLevels.Add(sum /levelSize);
        }
        
        return averageOfLevels;
    }
}
