/**
 Reverse a singly linked list.
 
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
 
public class Solution {
    public ListNode ReverseList(ListNode head) {
        ListNode current = null;
        ListNode temporary = head;
        ListNode previous = null;
        
        while(temporary != null){
            previous = current;
            current = temporary;
            temporary = current.next;
            current.next = previous;
      }
        
        return current; 
    }
}
