/*
    Given the root of an n-ary tree, return the postorder traversal of its nodes' 
    values.

    Nary-Tree input serialization is represented in their level order traversal. Each 
    group of children is separated by the null value (See examples)


    T - O(n), where n is the number of nodes in the tree, since we have to touch all nodes
    S - O(n), recursive stack could hold entire tree if tree is super skewed
*/
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
/*
    Recursive solution
*/
public class Solution {
    public IList<int> Postorder(Node root) {
        List<int> postorderList = new List<int>();
        postorderTraverse(root, postorderList);
        return postorderList;
    }
    
    private void postorderTraverse(Node root, List<int> list){
        if(root != null) return;
        
        foreach(Node child in root.children){
            postorderTraverse(child, list);
        }
            
        list.Add(root.val);
    }
}

/*
    Iterative Solution
*/
public class Solution {
    public IList<int> Postorder(Node root){
        LinkedList<int> postorderList = new LinkedList<int>();
        Stack<Node> stack = new Stack<Node>();
        Node current;
        
        if(root == null) return new List<int>(postorderList);
        
        stack.Push(root);
        
        while(stack.Count != 0){
            current = stack.Pop();
            postorderList.AddFirst(current.val);
            foreach(Node child in current.children){
                stack.Push(child);
            }
        }
        
        return new List<int>(postorderList);
    }
}
