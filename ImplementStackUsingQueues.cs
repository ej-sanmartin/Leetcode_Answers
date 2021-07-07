/*
    Implement a last in first out (LIFO) stack using only two queues. The 
    implemented stack should support all the functions of a normal queue 
    (push, top, pop, and empty).

    Implement the MyStack class:

    void push(int x) Pushes element x to the top of the stack.
    int pop() Removes the element on the top of the stack and returns it.
    int top() Returns the element on the top of the stack.
    boolean empty() Returns true if the stack is empty, false otherwise.

    Notes:

    You must use only standard operations of a queue, which means only push to 
    back, peek/pop from front, size, and is empty operations are valid.
    Depending on your language, the queue may not be supported natively. You 
    may simulate a queue using a list or deque (double-ended queue), as long 
    as you use only a queue's standard operations.

    Push() - O(1)
    Pop() - O(n)
    Top() - O(n)
    Empty() - O(1)
    
    private method:
    UpdateQueue() - O(n)
*/
public class MyStack {

    Queue<int> primaryQueue;
    Queue<int> secondaryQueue;
    private bool topIsInPrimary;
    
    /** Initialize your data structure here. */
    public MyStack() {
        primaryQueue = new Queue<int>();
        secondaryQueue = new Queue<int>();
        topIsInPrimary = true;
    }
    
    /** Push element x onto stack. */
    public void Push(int x) {
        if(topIsInPrimary) primaryQueue.Enqueue(x);
        else secondaryQueue.Enqueue(x);
    }
    
    /** Removes the element on top of the stack and returns that element. */
    public int Pop() {
        UpdateQueues();
        if(topIsInPrimary){
            topIsInPrimary = false;
            return primaryQueue.Dequeue();
        } else {
            topIsInPrimary = true;
            return secondaryQueue.Dequeue();
        }
    }
    
    /** Get the top element. */
    public int Top() {
        UpdateQueues();
        if(topIsInPrimary) return primaryQueue.Peek();
        else return secondaryQueue.Peek();
    }
    
    private void UpdateQueues(){
        if(topIsInPrimary && primaryQueue.Count > 1){
            while(primaryQueue.Count > 1){
                secondaryQueue.Enqueue(primaryQueue.Dequeue());
            }
        } else if(!topIsInPrimary && secondaryQueue.Count > 1){
            while(secondaryQueue.Count > 1){
                primaryQueue.Enqueue(secondaryQueue.Dequeue());
            }
        }
        return;
    }
    
    /** Returns whether the stack is empty. */
    public bool Empty() {
        return (primaryQueue.Count == 0) && (secondaryQueue.Count == 0);
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */
