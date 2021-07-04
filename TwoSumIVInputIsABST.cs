/*
    Given the root of a Binary Search Tree and a target number k, return true if there exist two 
    elements in the BST such that their sum is equal to the given target.

    T - O(n), worst case we must traverse through every node to find the target sum
    S - O(n), either using a hashset or a list populated by traversing through the BST
              in order, worst case both of these data structures are filled with the
              every node in the tree
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
    // create list from BST inorder and find target by doing one pass on that list
    public bool FindTarget(TreeNode root, int k) {
        List<int> inorderList = new List<int>();
        InorderTraversal(root, inorderList);
        int left = 0;
        int right = inorderList.Count -  1;
        int sum;
        
        while(left < right){
            sum = inorderList[left] + inorderList[right];
            if(sum == k) return true;
            else if(sum < k) left++;
            else right--;
        }
        
        return false;
    }
    
    private void InorderTraversal(TreeNode root, List<int> list){
        if(root == null) return;
        InorderTraversal(root.left, list);
        list.Add(root.val);
        InorderTraversal(root.right, list);
    }
    
    
    // use hashset to remember past traversed nodes and find if it contains the number that is 
    // equal to k - root.val
    public bool FindTarget(TreeNode root, int k) {
        HashSet<int> hashset = new HashSet<int>();
        return FindTargetHelper(root, k, hashset);
    }
    
    private bool FindTargetHelper(TreeNode root, int k, HashSet<int> hashset){
        if(root == null) return false;
        if(hashset.Contains(k - root.val)) return true;
        hashset.Add(root.val);
        return FindTargetHelper(root.left, k, hashset) || FindTargetHelper(root.right, k, hashset);
    }
}
