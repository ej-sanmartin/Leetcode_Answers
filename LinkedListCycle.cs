/**
  Given a linked list, determine if it has a cycle in it.

  Definition for singly-linked list.
   public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int x) {
         val = x;
         next = null;
     }
  }
  
 */
 
public class Solution {
    public bool HasCycle(ListNode head) {
        if(head == null) { return false; }
        if(head.next == null) { return false; }
        
        ListNode slow = head;
        ListNode fast = head.next;
        
        while(true){
            if(fast == null || fast.next == null){ return false; }
            if(fast == slow) { return true; }
            slow = slow.next;
            fast = fast.next.next;
        }
    }
}
