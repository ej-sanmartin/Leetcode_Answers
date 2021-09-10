/*
    Given a characters array tasks, representing the tasks a CPU needs to do, where 
    each letter represents a different task. Tasks could be done in any order. Each 
    task is done in one unit of time. For each unit of time, the CPU could complete 
    either one task or just be idle.

    However, there is a non-negative integer n that represents the cooldown period 
    between two same tasks (the same letter in the array), that is that there must be 
    at least n units of time between any two same tasks.

    Return the least number of units of times that the CPU will take to finish all 
    the given tasks.

    T - O(nlogn), for 26 characters in the alphabet, we store and maintain them in pq 
                  in logn time
    S - O(n), where we store the number of tasks n into two different data structures
*/
class Solution {
    public int leastInterval(char[] tasks, int n) {
        if(n == 0) return tasks.length;
        
        HashMap<Character, Integer> table = new HashMap<>();
        for(char c : tasks){
            table.put(c, table.getOrDefault(c, 0) + 1);
        }
        
        PriorityQueue<Integer> pq = new PriorityQueue<>(Collections.reverseOrder());
        pq.addAll(table.values());
        
        int difference = pq.poll() - 1;
        int totalIdles = difference * n;
        
        while(!pq.isEmpty()){
            totalIdles -= Math.min(difference, pq.poll());
        }
        
        return totalIdles > 0 ? totalIdles + tasks.length : tasks.length;
    }
}
