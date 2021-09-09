/**
 Given the root of a binary tree, return the most frequent subtree sum. If there is a tie, return 
 all the values with the highest frequency in any order.

 The subtree sum of a node is defined as the sum of all the node values formed by the subtree rooted 
 at that node (including the node itself).


 T - O(n + m), n as we go through every node once in tree to calcualte sub tree sums to store in 
               dicitonary and m as we loop through dictionary to find and retrieve most frequent 
               sums
 S - O(m), we create a lot of space in this solution, from the dictionary which is size of number of 
           nodes as each node is its own subtree with at worst case their own unique sum. Also 
           recursive call stack plays a part in increasing space complexity, where it depends on if 
           the tree is balanced
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
    public int[] FindFrequentTreeSum(TreeNode root) {
        Dictionary<int, int> table = new Dictionary<int, int>();
        FindSubtreeSums(root, table);
        int frequentCount = 0;
        foreach(KeyValuePair<int, int> sum in table){
            frequentCount = Math.Max(sum.Value, frequentCount);
        }
        List<int> output = new List<int>();
        foreach(KeyValuePair<int, int> sum in table){
            if(sum.Value == frequentCount){
                output.Add(sum.Key);
            }
        }
        return output.ToArray();
    }
    
    public int FindSubtreeSums(TreeNode root, Dictionary<int, int> table){
        if(root == null) return 0;
        int sum = root.val + FindSubtreeSums(root.left, table) + FindSubtreeSums(root.right, table);
        if(!table.ContainsKey(sum)){
            table.Add(sum, 0);
        }
        table[sum]++;
        return sum;
    }
}
