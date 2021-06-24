/*
  Given a stream of integers and a window size, calculate the moving average of all integers in the sliding window.

  Implement the MovingAverage class:

  MovingAverage(int size) Initializes the object with the size of the window size.
  double next(int val) Returns the moving average of the last size values of the stream.
  
  Was an excuse to implement a Double Ended Queue (Deque), did not realize it was an optimal solution, honestly thought I overkilled it

  T - O(1), as Deque has constant time complexity for enqueue and dequeue as well as constant time access to Head and Tail nodes
  S - O(n), where n is the size of window specified
*/
public class MovingAverage {
    private class LinkedListNode {
        private class Node {
            public int data;
            public Node next;
                
            public Node(int data){
                this.data = data;
                this.next = null;
            }
        }
        
        private Node _head;
        private Node _tail;
        private int _count;
        private int _capacity;
        
        public LinkedListNode(int size){
            this._count = 0;
            this._capacity = size;
            this._head = null;
            this._tail = null;
        }
        
        public bool IsEmpty(){
            return this._count == 0;
        }
        
        public int Enqueue(int data){
            int discardedValue = 0;
            if(this._capacity == this._count) discardedValue = this.Dequeue();
            Node newNode = new Node(data);
            if(this._tail != null) this._tail.next = newNode;
            this._tail = newNode;
            if(IsEmpty()) this._head = this._tail;
            this._count++;
            return discardedValue;
        }
        
        public int Dequeue(){
            if(IsEmpty()) return 0;
            int data = this._head.data;
            this._head = this._head.next;
            this._count--;
            if(IsEmpty()) this._tail = null;
            return data;
        }
    }
    
    private LinkedListNode _queue;
    private double _sum;
    private int _currentSize;
    private int _maxSize;

    public MovingAverage(int size) {
        this._queue = new LinkedListNode(size);
        this._sum = 0.0;
        this._currentSize = 0;
        this._maxSize = size;
    }
    
    public double Next(int val) {
        int potentialDiscardedValue = this._queue.Enqueue(val);
        if(this._currentSize != this._maxSize) this._currentSize++;
        this._sum += val - potentialDiscardedValue;
        return this._currentSize == 0 ? -1.0 : this._sum / this._currentSize;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */
