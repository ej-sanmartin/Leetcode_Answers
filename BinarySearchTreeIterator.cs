/*
    Implement the BSTIterator class that represents an iterator over the in-order 
    traversal of a binary search tree (BST):


    BSTIterator(TreeNode root) Initializes an object of the BSTIterator class. The 
    root of the BST is given as part of the constructor. The pointer should be 
    initialized to a non-existent number smaller than any element in the BST.

    boolean hasNext() Returns true if there exists a number in the traversal to the 
    right of the pointer, otherwise returns false.

    int next() Moves the pointer to the right, then returns the number at the pointer.
    
    
    Notice that by initializing the pointer to a non-existent smallest number, the 
    first call to next() will return the smallest element in the BST.

    You may assume that next() calls will always be valid. That is, there will be at 
    least a next number in the in-order traversal when next() is called.

    S - O(n), stack will hold up to n number of nodes that root has
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
public class BSTIterator {
    Stack<TreeNode> stack;
    public BSTIterator(TreeNode root) {
        stack = new Stack<TreeNode>();
        PopulateStack(root);
    }
    
    // T - O(n), bounded by PopulateStack function
    public int Next() {
        TreeNode current = stack.Pop();
        int data = current.val;
        PopulateStack(current.right); 
        return data;
    }
    
    // T - O(1)
    public bool HasNext() {
        return stack.Count != 0;
    }
    
    // T - O(n), n being number of nodes in root's left side
    private void PopulateStack(TreeNode root){
        while(root != null){
            stack.Push(root);
            root = root.left;
        }
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
