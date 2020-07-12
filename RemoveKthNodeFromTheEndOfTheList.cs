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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode answer = new ListNode(0);
        answer.next = head;
        ListNode current = answer;
        ListNode nPointer = head;
        
        for(int i = 0; i < n; i++){
            nPointer = nPointer.next;
        }
        
        if(nPointer == null){
			current.next = current.next.next;
            return answer.next;
			
		}
        
        while(nPointer != null){
			current = current.next;
			nPointer = nPointer.next;
		}
        
		current.next = current.next.next;
        
        return answer.next;
    }
}
