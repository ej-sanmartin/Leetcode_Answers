/**
    Given a linked list, swap every two adjacent nodes and return its head. You 
    must solve the problem without modifying the values in the list's nodes 
    (i.e., only nodes themselves may be changed.)
    
    T - O(n), as we do one pass through the entire LL to swap every pair
    S - O(1), as no additional space dependent on input size is created
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
    public ListNode SwapPairs(ListNode head) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode runner = dummy;
        
        while(runner.next != null && runner.next.next != null){
            ListNode first = runner.next;
            ListNode second = runner.next.next;
            
            runner.next = second;
            first.next = second.next;
            second.next = first;
            
            runner = runner.next.next;
        }
        
        return dummy.next;
    }
}
