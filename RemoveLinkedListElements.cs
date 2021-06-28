/*
    Given the head of a linked list and an integer val, remove all the nodes of the 
    linked list that has Node.val == val, and return the new head.

    T - O(n), as we must go through entire length n of Linked List to remove all elements
    S - O(1), as we are not creating any additional space that is dependent on the size
              of the input
*/

/**
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
    public ListNode RemoveElements(ListNode head, int val) {
        ListNode sentinel = new ListNode(0);
       sentinel.next = head;
        
        ListNode previous = sentinel;
        ListNode current = head;
        
        while(current != null){
            if(current.val == val) previous.next = current.next;
            else previous = current;
            current = current.next;
        }
        
        return sentinel.next;
    }
}
