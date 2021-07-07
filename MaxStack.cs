/*
    Design a max stack data structure that supports the stack 
    operations and supports finding the stack's maximum element.

    Implement the MaxStack class:

    MaxStack() Initializes the stack object.
    void push(int x) Pushes element x onto the stack.
    int pop() Removes the element on top of the stack and returns it.
    int top() Gets the element on the top of the stack without removing it.
    int peekMax() Retrieves the maximum element in the stack without removing it.
    int popMax() Retrieves the maximum element in the stack and 
                 removes it. If there is more than one maximum element, only remove the top-most one.
*/
public class MaxStack {

    Stack<int> main;
    Stack<int> maxStack;
    
    public MaxStack(){
        main = new Stack<int>();
        maxStack = new Stack<int>();
    }
    
    public void Push(int x){
        main.Push(x);
        if(maxStack.Count == 0){
            maxStack.Push(x);
        } else if(x > maxStack.Peek()){
            maxStack.Push(x);
        } else {
            int stillMax = maxStack.Peek();
            maxStack.Push(stillMax);
        }
    }
    
    public int Pop(){
        maxStack.Pop();
        return main.Pop();
    }
    
    public int Top(){
        return main.Peek();
    }
    
    public int PeekMax(){
        return maxStack.Peek();
    }
    
    public int PopMax(){
        int max = PeekMax();
        Stack<int> buffer = new Stack<int>();
        while(Top() != max){
            buffer.Push(Pop());
        }
        
        Pop();
        
        while(buffer.Count != 0){
            Push(buffer.Pop());
        }
        
        return max;
        
    }
}

/**
 * Your MaxStack object will be instantiated and called as such:
 * MaxStack obj = new MaxStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.PeekMax();
 * int param_5 = obj.PopMax();
 */
