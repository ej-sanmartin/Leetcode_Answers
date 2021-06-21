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


/* Below is second attempt */
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
/*
    INPUT = [2, 4, 3], [5, 6, 4]
    First thought, traverse each LL,
    store each value per node into a string
    which we prepend to the beginning of said string
    so that we have two strings that represent a number
    "342" and "465". Now we convert these two strings to
    integers and add them up. Now convert back to strings and create a
    new linked list from the sum of the two LL as a string.
    Thus, creating 7 -> 0 -> 8.
    if both LL are the same size, T - O(n + m), where n is the size of
    two input strings we would have to traverse to find their interger value
    equivalent and m being the size of the new LL we would have to make
    that would represent the sum in a reverse order.
    If all LL are different sizes, potentially T - O(a + b + c);
    S - O(n) as we would be creating a lot of strings and creating a new LL
    that would be the size of the new LL.
    
    A better solution would be to go through both LL at the same time,
    and update the value of the first LL to be the sum of
    LL1 @ first Node + LL2 @ first Node and so on.
    I have to keep in mind that each LL represents a single digit
    so if I get a sum that is more than 10, I should carry the remainder over
    If I have a remainder by the last element then simply create a new element.
    Should key going as long as both LL are traversed, if one is already fully
    traversed, do not try to access its null Node
    
*/

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        int sum = 0;
        int remainder = 0;
        ListNode LL1 = l1;
        ListNode LL2 = l2;
        ListNode answer = new ListNode(0);
        ListNode current = answer;
        
        while(LL1 != null || LL2 != null){
            sum = 0;
            if(LL1 != null) sum += LL1.val;
            if(LL2 != null) sum += LL2.val;
            
            sum += remainder;
            remainder = sum / 10;
            
            current.next = new ListNode(sum % 10);
            current = current.next;
            
            if(LL1 != null) LL1 = LL1.next;
            if(LL2 != null) LL2 = LL2.next;
        }
        
        if(remainder > 0){
            current.next = new ListNode(remainder);
        }
        
        return answer.next;
    }
}
