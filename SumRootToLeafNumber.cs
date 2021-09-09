/**
 You are given the root of a binary tree containing digits from 0 to 9 only.

 Each root-to-leaf path in the tree represents a number.

 For example, the root-to-leaf path 1 -> 2 -> 3 represents the number 123.
 Return the total sum of all root-to-leaf numbers. Test cases are generated so that the answer will 
 fit in a 32-bit integer.

 A leaf node is a node with no children.
 
 T - O(n), as we go through every node n in the given tree
 S - o(h), the height of the tree dictates the recursive stack space size

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
    public int SumNumbers(TreeNode root) {
        List<int> numbers = new List<int>();
        GenerateNumbers(root, 0, 0, numbers);
        int sum = 0;
        foreach(int num in numbers){
            sum += num;
        }
        return sum;
    }
    
    public void GenerateNumbers(TreeNode root, int sum, int depth, List<int> list){
        if(root == null) return;
        int current = sum * 10 + root.val;
        if(root.left == null && root.right == null){
            list.Add(current);
            return;
        }
        GenerateNumbers(root.left, current, depth + 1, list);
        GenerateNumbers(root.right, current, depth + 1, list);
    }
}
