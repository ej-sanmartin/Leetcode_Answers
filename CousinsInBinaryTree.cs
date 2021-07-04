/*
    In a binary tree, the root node is at depth 0, and children of each depth k node are at depth k+1.
    Two nodes of a binary tree are cousins if they have the same depth, but have different parents.
    We are given the root of a binary tree with unique values, and the values x and y of two different 
    nodes in the tree.
    Return true if and only if the nodes corresponding to the values x and y are cousins.

    T - O(n), where we must traverse through every node in the tree potentially in a BFS manner
    S - O(n), where the queue at worst can hold up to half of the nodes in a tree with we are 
              traversing the last level of a complete binary tree
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
    class NodeWithMemory {
        public TreeNode node;
        public int parent;
        public NodeWithMemory(TreeNode node, int parent){
            this.node = node;
            this.parent = parent;
        }
    }
    
    public bool IsCousins(TreeNode root, int x, int y) {
        if(root == null) return false;
		
		List<NodeWithMemory> matches = new List<NodeWithMemory>();
		Queue<NodeWithMemory> queue = new Queue<NodeWithMemory>();
        queue.Enqueue(new NodeWithMemory(root, -1));
		
		int levelSize;
        NodeWithMemory current;
		
        while(queue.Count != 0){
            levelSize = queue.Count;
			
            while(levelSize != 0){
                current = queue.Dequeue();
                if(current.node.val == x || current.node.val == y) matches.Add(current);
                if(current.node.left != null) queue.Enqueue(new NodeWithMemory(current.node.left, current.node.val));
                if(current.node.right != null) queue.Enqueue(new NodeWithMemory(current.node.right, current.node.val));
                levelSize--;
            }
			
            if(matches.Count == 1) return false;
            if(matches.Count == 2){
                if(matches[0].parent == matches[1].parent) return false;
                return true;
            }
        }
        
        return true;
    }
}
