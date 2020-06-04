/**
 Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

 For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of
 the two subtrees of every node never differ by more than 1 

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
    public TreeNode SortedArrayToBST(int[] nums) {
        return BalancedBSTHelper(nums, 0, nums.Length -1);
    }
    
    private TreeNode BalancedBSTHelper(int[] nums, int start, int end){
        if(start > end){
            return null;
        }
        
        if(start == end){
            return new TreeNode(nums[start]);
        }
        
        if(start == end - 1){
            TreeNode root = new TreeNode(nums[start]);
            TreeNode right = new TreeNode(nums[end]);
            root.right = right;
            return root;
        }
        
        int middle = ((end - start)>>1) + start;
        TreeNode left = BalancedBSTHelper(nums, start, middle -1);
        TreeNode m_right = BalancedBSTHelper(nums, middle +1, end);
        TreeNode m_root = new TreeNode(nums[middle]);
        m_root.left = left;
        m_root.right = m_right;
        
        return m_root;
    }
}
