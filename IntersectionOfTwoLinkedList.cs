/*
    Given the heads of two singly linked-lists headA and headB, return the node at 
    which the two lists intersect. If the two linked lists have no intersection at 
    all, return null.

    For example, the following two linked lists begin to intersect at node c1:

    It is guaranteed that there are no cycles anywhere in the entire linked 
    structure.

    Note that the linked lists must retain their original structure after the 
    function returns.
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    /*
        T - O(n + m), must traverse through both linked list, worst case
        T - O(n), where n is the first linked lsit stored in a hashset
    */
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        HashSet<ListNode> hashset = new HashSet<ListNode>();
        ListNode current = headA;
        while(current != null){
            hashset.Add(current);
            current = current.next;
        }
        current = headB;
        while(current != null){
            if(hashset.Contains(current)) return current;
            current = current.next;
        }
        
        return null;
    }
    
    /*
        T - O(n + m), traverse through both linked list until they line up and
                      return an intersection node or null
        S - O(1), no additional space created besides two pointers
    */
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        ListNode firstPointer = headA;
        ListNode secondPointer = headB;
        
        while(firstPointer != secondPointer){
            firstPointer = firstPointer == null ? headB : firstPointer.next;
            secondPointer = secondPointer == null ? headA : secondPointer.next;
        }
        
        return firstPointer;
    }
}
