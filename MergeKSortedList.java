/*
    You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
    Merge all the linked-lists into one sorted linked-list and return it.
    
    T - O(Nlogk), we are going through n nodes in the final linked list and at each loop we do logk operation
                  of ordering our pq
    S - counting output O(n), not counting output O(k), where n is the size of the new list created
        with all nodes from the array of linked list. O(k) since out priority queue which orders our 
        nodes will only hold up to k space which is the number of listnodes in the input array
*/
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {
    public ListNode mergeKLists(ListNode[] lists) {
        if(lists == null || lists.length == 0) return null;
        PriorityQueue<ListNode> pq = new PriorityQueue<>(lists.length, (a, b) -> a.val - b.val);
        
        ListNode dummy = new ListNode(0);
        ListNode tail = dummy;
        
        for(ListNode node : lists){
            if(node != null) pq.add(node);
        }
        
        while(!pq.isEmpty()){
            tail.next = pq.poll();
            tail = tail.next;
            if(tail.next != null){
                pq.add(tail.next);
            }
        }
        
        return dummy.next;
    }
}
