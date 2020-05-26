/**
 Given a binary tree, return the sum of values of its deepest leaves.

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
    public int DeepestLeavesSum(TreeNode root) {
        int sum = 0; // answer
        Dictionary<int, List<int>> deepLeaf = new Dictionary<int, List<int>>(); // dict of kvp, int and list
        
        // goes through tree, finding all leaves
        void findDeepNodes(TreeNode node, int layer){
            if(node == null){
                return;
            }
            
            // if no children, this is a leaf
            if(node.left == null && node.right == null){
                if(deepLeaf.ContainsKey(layer)){ // if layer was recorded to dict, add node val to it
                    deepLeaf[layer].Add(node.val);
                } else { // else create new key value pair with layer as key and a new list init. with node val
                    deepLeaf.Add(layer, new List<int> {node.val});
                }
            }
            
            // if node has children, keep recursively searching
            if(node.left != null){
                findDeepNodes(node.left, layer + 1);
            } 
            
            if(node.right != null){
                findDeepNodes(node.right, layer + 1);
            }
        }
        
        // runs above function to populate dictionary
        findDeepNodes(root, 0);
        
        // look through keys (aka depths) in dictionary, returning the largest one
        int depthLevel = deepLeaf.Keys.Max();
        List<int> deepestLeaf = new List<int>(); // create list to contain items from the dict with the highest depth key
        for(int i = 0; i < deepLeaf[depthLevel].Count; i++){
            deepestLeaf.Add(deepLeaf[depthLevel][i]);
        }
        
        // find sum of all items on list
        sum = deepestLeaf.Sum();
        return sum;
    }
}
