/*
 Given a linked list, return the node where the cycle begins. If there is no cycle, return null.
 
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
    public ListNode DetectCycle(ListNode head) {
        ListNode slow = head;
        ListNode fast = head;
        
        // loop until both pointers meet
        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
            if(slow == fast){ break; } // placed here since placing this at start of while loop with break on 1st iteration, since they both point to head at start
        }
        
        // if fast satisfies these conditions, then there is no cycles
        if(fast == null || fast.next == null){ return null; }
        
        // set slow to head
        slow = head;
        
        // slowly walk both pointers to meet back at the start of the cycle
        while(slow != fast){
            slow = slow.next;
            fast = fast.next;
        }
        
        return slow;
    }
}
