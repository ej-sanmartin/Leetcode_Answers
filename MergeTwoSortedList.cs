/**
 Merge two sorted linked lists and return it as a new sorted list.
 The new list should be made by splicing together the nodes of the first two lists.
 
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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        ListNode answer = new ListNode(0);  
        ListNode tail = answer; 
        
        while(true){  
            if(l1 == null){  
                tail.next = l2;  
                break;  
            }  
            
            if(l2 == null){  
                tail.next = l1;  
                break;  
            }  
  
            if(l1.val <= l2.val){  
                tail.next = l1;  
                l1 = l1.next;  
            } else {  
                tail.next = l2;  
                l2 = l2.next;  
            }  
  
            tail = tail.next;  
        }
        
        return answer.next; 
    }
}
