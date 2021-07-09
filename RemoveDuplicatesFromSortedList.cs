/*
    Given the head of a sorted linked list, delete all duplicates such that each 
    element appears only once. Return the linked list sorted as well.

    T - O(n), where n is length of the LL since we
              must traverse through all values to
              check for duplicates
    S - O(1), we are only creating pointer variables
              nothing else that is dependent on
              input size
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
    public ListNode DeleteDuplicates(ListNode head){
        if(head == null || head.next == null) return head;
        
        ListNode current = head.next;
        ListNode sentinel = head;
        
        while(current != null){
            if(sentinel.val == current.val) sentinel.next = current.next;
            else sentinel = current;
            
            current = current.next;
        }
        
        return head;
    }
}
