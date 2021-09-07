/**
 Given the head of a linked list, remove the nth node from the end of the list and return its head.
 T - O(n), as runner is always going to do one full pass through the entire list
 S - O(1), as we do not create any additional space that is dependent on the input
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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        
        ListNode runner = dummy;
        ListNode walker = dummy;
        
        for(int i = 1; i <= n + 1; i++){
            runner = runner.next;
        }
        
        while(runner != null){
            runner = runner.next;
            walker = walker.next;
        }
        
        walker.next = walker.next.next;
        return dummy.next;
    }
}
