/*
    Given an array of meeting time intervals intervals where intervals[i] = 
    [starti, endi], return the minimum number of conference rooms required.

    T - O(Nlogn), sorting the input has a large overhead of nlogn
    S - O(N),     in worst case, PQ holds intervals.length on a busy day
*/
class Solution {
    public int minMeetingRooms(int[][] intervals) {
        Arrays.sort(intervals, (a, b) -> a[0] - b[0]);
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> a[1] - b[1]);
        for(int[] interval : intervals){
            if(!pq.isEmpty() && pq.peek()[1] <= interval[0]){
                pq.poll();
            }
            pq.add(interval);
        }
        
        return pq.size();
    }
}
