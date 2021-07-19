/*
    Given a binary tree

    struct Node {
        int val;
        Node *left;
        Node *right;
        Node *next;
    }
    
    Populate each next pointer to point to its next right node. If there is 
    no next right node, the next pointer should be set to NULL.

    Initially, all next pointers are set to NULL.


    T - O(n), as all nodes must be processed and have their next values set
    S - O(n). space used for the queue
*/

/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        Queue<Node> queue = new Queue<Node>();
        int levelSize;
        Node current;
        if(root != null) queue.Enqueue(root);
        
        while(queue.Count != 0){
            levelSize = queue.Count;
            while(levelSize > 0){
                current = queue.Dequeue();
                levelSize--;
                if(levelSize == 0) current.next = null;
                else current.next = queue.Peek();
                if(current.left != null) queue.Enqueue(current.left);
                if(current.right != null) queue.Enqueue(current.right);
            }
        }
        
        return root;
    }
}
