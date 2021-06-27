/*
    Given the head of a singly linked list, return true if it is a palindrome.

    T - O(n), where n is the length of the linked list
    S - O(1), no extra space is needed that is effected by the size of the input
              Reversing the second half of the linked list is also not going to
              take up extra space since the reversing of the second half of the 
              linked list is in place
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
    public bool IsPalindrome(ListNode head) {
        int size = 0;
        ListNode current = head;
        while(current != null){
            size++;
            current = current.next;
        }
        
        int middle = size / 2;
        current = head;
        
        while(middle != 0){
            current = current.next;
            middle--;
        }
        
        ListNode prev = null;
        ListNode next = null;
        
        while(current != null){
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        
        current = prev;
        ListNode start = head;
        
        while(current != null && start != null){
            if(start.val != current.val) return false;
            current = current.next;
            start = start.next;
        }
        
        return true;
    }
}
