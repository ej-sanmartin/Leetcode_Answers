/**
  Given head which is a reference node to a singly-linked list.
  The value of each node in the linked list is either 0 or 1.
  The linked list holds the binary representation of a number.

  Return the decimal value of the number in the linked list.

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
    public int GetDecimalValue(ListNode head) {
        int answer = 0;
        int headLength = 0;
        ListNode headClone = head;
        
        // gets length of head linked list
        while(headClone != null){
            headLength++;
            headClone = headClone.next;
        }
        
        // increments sum
        for(int length = headLength; length > 0; length--){
            answer += head.val * (int)Math.Pow(2, length - 1); // 
            head = head.next; // moves to the next node in the list
        }
        
        return answer;
    }
}
