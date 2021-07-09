/*
    Given the head of a linked list and two integers m and n. Traverse the linked 
    list and remove some nodes in the following way:

    Start with the head as the current node.
    Keep the first m nodes starting with the current node.
    Remove the next n nodes
    Keep repeating steps 2 and 3 until you reach the end of the list.
    Return the head of the modified list after removing the mentioned nodes.

    Follow up question: How can you solve this problem by modifying the list in-
    place?

    T - O(n), where n is the length of the Linked List, must traverse
              through all elements
    S - O(1), removal was done in place, created constant space with
              pointers and counters
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
    public ListNode DeleteNodes(ListNode head, int m, int n) {
        ListNode current = head;
        ListNode sentinel = new ListNode(0);
        sentinel.next = head;
        
        int mCount = 0;
        int nCount = 0;
        
        while(current != null){
            if(mCount < m){
                mCount++;
                current = current.next;
                sentinel = sentinel.next;
                if(mCount == m) nCount = 0;
            } else if(nCount < n){
                nCount++;
                sentinel.next = current.next;
                current = sentinel.next;
                if(nCount == n) mCount = 0;
            }
        }
        
        return head;
    }
}
