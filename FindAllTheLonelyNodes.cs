/*
    In a binary tree, a lonely node is a node that is the only child of its parent node. The root of the 
    tree is not lonely because it does not have a parent node.
    
    Given the root of a binary tree, return an array containing the values of all lonely nodes in the 
    tree. Return the list in any order.

    T - O(n), as we must traverse through all nodes to find which nodes are lonely
    S - O(h), space is dependent on call stack, which at worst case, would be h or all node if tree
              is skewed
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
    public IList<int> GetLonelyNodes(TreeNode root) {
        List<int> lonelyNodes = new List<int>();
        
        if(root.left != null && root.right != null){
            GetLonelyNodesHelper(root.left, true, lonelyNodes);
            GetLonelyNodesHelper(root.right, true, lonelyNodes);
        } else {
            GetLonelyNodesHelper(root.left, false, lonelyNodes);
            GetLonelyNodesHelper(root.right, false, lonelyNodes);
        }
        
        return lonelyNodes;
    }
    
    private void GetLonelyNodesHelper(TreeNode root, bool childIsLonely, List<int> lonelyNodes){
        if(root == null) return;
        if(!childIsLonely) lonelyNodes.Add(root.val);
        if(root.left != null && root.right != null) childIsLonely = true;
        else childIsLonely = false;
        if(root.left != null) GetLonelyNodesHelper(root.left, childIsLonely, lonelyNodes);
        if(root.right != null) GetLonelyNodesHelper(root.right, childIsLonely, lonelyNodes);
    }
}
