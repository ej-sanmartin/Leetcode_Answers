/*
    Given a non-empty, singly linked list with head node head, return a middle node of 
    linked list.

    If there are two middle nodes, return the second middle node.

    T - O(n), since we are only traversing through n/2 elements of linked list. We drop 
              constants, so we are at O(n)
    S - O(1), we are only creating ListNodes to keep track of position at linked list
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
    public ListNode MiddleNode(ListNode head) {
        ListNode slow = head;
        ListNode fast = head;
        
        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }
        
        return slow;
    }
}
