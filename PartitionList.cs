/**
 Given the head of a linked list and a value x, partition it such that all nodes less 
 than x come before nodes greater than or equal to x.

 You should preserve the original relative order of the nodes in each of the two 
 partitions.

 T - O(n), n being the size of the input linked list. We go through all elements once
 S - O(1), we create constant space that does not depend on input size
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
    public ListNode Partition(ListNode head, int x) {
        ListNode lessThanHead = new ListNode(0);
        ListNode lessThanRunner = lessThanHead;
        ListNode moreThanHead = new ListNode(0);
        ListNode moreThanRunner = moreThanHead;
        
        while(head != null){
            if(head.val < x){
                lessThanRunner.next = head;
                lessThanRunner = lessThanRunner.next;
            } else {
                moreThanRunner.next = head;
                moreThanRunner = moreThanRunner.next;
            }
            
            head = head.next;
        }
        
        moreThanRunner.next = null;
        lessThanRunner.next = moreThanHead.next;
        return lessThanHead.next;
    }
}
