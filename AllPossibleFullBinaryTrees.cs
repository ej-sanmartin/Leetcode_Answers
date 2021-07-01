/*
    Given an integer n, return a list of all possible full binary trees with n nodes. Each 
    node of each tree in the answer must have Node.val == 0.

    Each element of the answer is the root node of one possible tree. You may return the 
    final list of trees in any order.

    A full binary tree is a binary tree where each node has exactly 0 or 2 children.

    T - O(2^n), we are creating two branches of depth n in the foreach loops, which calculates
                and returns a list of FBT at the passed i and j numbers
    S - O(2^n), for the amount of space created via recursive stack calls
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
    Dictionary<int, List<TreeNode>> memo = new Dictionary<int, List<TreeNode>>();
    
    public IList<TreeNode> AllPossibleFBT(int n) {
        if(!memo.ContainsKey(n)){
            int i, j;
            List<TreeNode> answer = new List<TreeNode>();
            if(n == 1){
                answer.Add(new TreeNode(0));
            } else if(n % 2 == 1){
                for(i = 0; i < n; i++){
                    j = n - 1 - i;
                    foreach(TreeNode left in AllPossibleFBT(i)){
                        foreach(TreeNode right in AllPossibleFBT(j)){
                            TreeNode current = new TreeNode(0);
                            current.left = left;
                            current.right = right;
                            answer.Add(current);
                        }
                    }
                }
            }
            
            memo.Add(n, answer);
        }
        
        return memo[n];
    }
}
