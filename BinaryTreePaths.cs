/**
 * Given the root of a binary tree, return all root-to-leaf paths in any order.
 *
 * A leaf is a node with no children.
 *
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
 * T - O(n) where n is the number of nodes in the tree. We have to traverse through all
 * S - O(h) where h is the height of the tree which, in the worst case, is the height of
 *          a super unbalanced tree. The call recursive call stack would be of size h
 */
public class Solution {
    public IList<string> BinaryTreePaths(TreeNode root) {
        List<string> paths = new List<string>();
        BinaryTreePathsHelper(root, "", paths);
        return paths;
    }
    
    private void BinaryTreePathsHelper(TreeNode root, string path, List<string> paths){
        path += root.val.ToString();
        if(root.left == null && root.right == null){
            paths.Add(path);
        } else {
            path += "->";
            if(root.left != null) BinaryTreePathsHelper(root.left, path, paths);
            if(root.right != null) BinaryTreePathsHelper(root.right, path, paths);
        }
    }
}
