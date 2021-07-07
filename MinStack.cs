public class MinStack {
    Stack<int> main;
    Stack<int> minStack;

    /** initialize your data structure here. */
    public MinStack() {
        main = new Stack<int>();
        minStack = new Stack<int>();
    }
    
    public void Push(int val) {
        main.Push(val);
        if(minStack.Count == 0){
            minStack.Push(val);
        } else if(val < minStack.Peek()){
            minStack.Push(val);
        } else {
            int stillMinValue = minStack.Peek();
            minStack.Push(stillMinValue);
        }
    }
    
    public void Pop() {
        minStack.Pop();
        main.Pop();
    }
    
    public int Top() {
        return main.Peek();
    }
    
    public int GetMin() {
        return minStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
