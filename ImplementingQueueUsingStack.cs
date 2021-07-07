public class MyQueue {
    
    Stack<int> entranceStack;
    Stack<int> exitStack;

    /** Initialize your data structure here. */
    public MyQueue() {
        entranceStack = new Stack<int>();
        exitStack = new Stack<int>();
    }
    
    /** Push element x to the back of queue. */
    public void Push(int x) {
        if(exitStack.Count != 0){
            while(exitStack.Count != 0){
                entranceStack.Push(exitStack.Pop());
            }
        }
        
        entranceStack.Push(x);
    }
    
    /** Removes the element from in front of queue and returns that element. */
    public int Pop() {
        if(entranceStack.Count == 1){
            return entranceStack.Pop();
        }
        
        while(entranceStack.Count != 0){
            exitStack.Push(entranceStack.Pop());
        }
        
        return exitStack.Pop();
    }
    
    /** Get the front element. */
    public int Peek() {
        if(exitStack.Count != 0){
            return exitStack.Peek();
        }
        
        while(entranceStack.Count != 0){
            exitStack.Push(entranceStack.Pop());
        }
        
        return exitStack.Peek();
    }
    
    /** Returns whether the queue is empty. */
    public bool Empty() {
        return entranceStack.Count == 0 && exitStack.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
