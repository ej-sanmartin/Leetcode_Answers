/**
 Given the root of a binary tree and an integer targetSum, return all root-to-leaf 
 paths where the sum of the node values in the path equals targetSum. Each path should 
 be returned as a list of the node values, not node references.

 A root-to-leaf path is a path starting from the root and ending at any leaf node. A 
 leaf is a node with no children.

 T - O(n^2), we go through every node once in treenode, and when we copy our current list to
             a new list which gets added to our output list, that itself also takes n time
 S - O(n), where space is dependent on current list which at worst case can hold all nodes

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
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        List<IList<int>> output = new List<IList<int>>();
        List<int> current = new List<int>();
        PathSumRecursive(root, targetSum, current, output);
        return output;
    }
    
    public void PathSumRecursive(TreeNode root, int sum, List<int> current, List<IList<int>> list){
        if(root == null) return;
        current.Add(root.val);
        if(root.left == null && root.right == null && root.val == sum){
            list.Add(new List<int>(current));
        }
        PathSumRecursive(root.left, sum - root.val, current, list);
        PathSumRecursive(root.right, sum - root.val, current, list);
        current.RemoveAt(current.Count - 1);
    }
}
