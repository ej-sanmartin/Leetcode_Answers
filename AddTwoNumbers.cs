/*
 You are given two non-empty linked lists representing two non-negative integers. The digits
 are stored in reverse order and each of their nodes contain a single digit. Add the two
 numbers and return it as a linked list.

 You may assume the two numbers do not contain any leading zero, except the number 0 itself.
  
  Definition for singly-linked list.
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }
*/

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode l1Current = l1;
        ListNode l2Current = l2;
        
        ListNode answer = new ListNode(0); // create answer linked list
        ListNode answerBuilder = answer; // create this listnode to build answer with while loop traversal
        int sum = 0;
        
        while(l1Current != null || l2Current != null){
            sum /= 10;
            
            if(l1Current != null){
                sum += l1Current.val;
                l1Current = l1Current.next;
            }
            
            if(l2Current != null){
                sum += l2Current.val;
                l2Current = l2Current.next;
            }
            
            answerBuilder.next = new ListNode(sum % 10);
            answerBuilder = answerBuilder.next;
        }
        
        if (sum / 10 == 1) { answerBuilder.next = new ListNode(1); }

        return answer.next; // answer.next because first ListNode was the 0 you started with to create LinkedList
    }
}
