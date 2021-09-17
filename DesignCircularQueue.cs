/*
    Design your implementation of the circular queue. The circular queue is a linear 
    data structure in which the operations are performed based on FIFO (First In First 
    Out) principle and the last position is connected back to the first position to    
    make a circle. It is also called "Ring Buffer".

    One of the benefits of the circular queue is that we can make use of the spaces in 
    front of the queue. In a normal queue, once the queue becomes full, we cannot 
    insert the next element even if there is a space in front of the queue. But using 
    the circular queue, we can use the space to store new values.

    Implementation the MyCircularQueue class:


    MyCircularQueue(k) Initializes the object with the size of the queue to be k.

    int Front() Gets the front item from the queue. If the queue is empty, return -1.

    int Rear() Gets the last item from the queue. If the queue is empty, return -1.

    boolean enQueue(int value) Inserts an element into the circular queue. Return true 
        if the operation is successful.

    boolean deQueue() Deletes an element from the circular queue. Return true if the 
        operation is successful.

    boolean isEmpty() Checks whether the circular queue is empty or not.

    boolean isFull() Checks whether the circular queue is full or not.

    You must solve the problem without using the built-in queue data structure in your 
    programming language. 
*/
public class MyCircularQueue {
    private int[] queue;
    private int head;
    private int count;
    private int capacity;

    public MyCircularQueue(int k) {
        this.capacity = k;
        this.queue = new int[k];
        this.head = 0;
        this.count = 0;
    }
    
    public bool EnQueue(int value) {
        if(this.count == this.capacity) return false;
        this.queue[(this.head + this.count++) % this.capacity] = value;
        return true;
    }
    
    public bool DeQueue() {
        if(this.count == 0) return false;
        this.head = (this.head + 1) % this.capacity;
        this.count--;
        return true;
    }
    
    public int Front() {
        if(this.count == 0) return -1;
        return this.queue[this.head];
    }
    
    public int Rear() {
        if(this.count == 0) return -1;
        int tailIndex = (this.head + this.count - 1) % this.capacity;
        return this.queue[tailIndex];
    }
    
    public bool IsEmpty() {
        return this.count == 0;
    }
    
    public bool IsFull() {
        return this.count == this.capacity;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */
