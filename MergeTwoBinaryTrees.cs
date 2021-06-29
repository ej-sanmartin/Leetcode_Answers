/*
    You are given two binary trees root1 and root2.

    Imagine that when you put one of them to cover the other, some nodes of the two trees are 
    overlapped while the others are not. You need to merge the two trees into a new binary tree. 
    The merge rule is that if two nodes overlap, then sum node values up as the new value of the    
    merged node. Otherwise, the NOT null node will be used as the node of the new tree.

    Return the merged tree.

    Note: The merging process must start from the root nodes of both trees.

    T - O(n), where n is the amount of nodes common and not shared nodes from both trees
    S - O(n), stack space is dependent on tree height. If skewed, at worst case, O(n). If
              tree is balanced, then O(logn) space
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

/*
    In place solution, where no new tree is created
*/
public class Solution {
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2){
        if(root1 == null) return root2;
        if(root2 == null) return root1;
        root1.val += root2.val;
        root1.left = MergeTrees(root1.left, root2.left);
        root1.right = MergeTrees(root1.right, root2.right);
        return root1;
    }
}

/*
    Solution which creates a new tree
*/
public class Solution {
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
        return MergeTreesHelper(null, root1, root2);
    }
    
    private TreeNode MergeTreesHelper(TreeNode newTree, TreeNode root1, TreeNode root2){
        if(root1 == null && root2 == null){
            return newTree;
        } else if(root1 != null && root2 != null){
            newTree = new TreeNode(root1.val + root2.val);
            newTree.left = MergeTreesHelper(newTree.left, root1.left, root2.left);
            newTree.right = MergeTreesHelper(newTree.right, root1.right, root2.right);
        } else if(root1 != null || root2 != null){
            if(root1 != null){
                newTree = new TreeNode(root1.val);
                newTree.left = MergeTreesHelper(newTree.left, root1.left, null);
                newTree.right = MergeTreesHelper(newTree.right, root1.right, null);
            } else if(root2 != null) {
                newTree = new TreeNode(root2.val);
                newTree.left = MergeTreesHelper(newTree.left, null, root2.left);
                newTree.right = MergeTreesHelper(newTree.right, null, root2.right);
            }
        }
        
        return newTree;
    }
}
