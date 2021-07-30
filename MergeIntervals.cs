/*
    Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, 
    and return an array of the non-overlapping intervals that cover all the intervals in the input.

    T - O(nlogn), overhead from sorting the intervals
    S - O(logn), overhead from sorting the intervals
*/
public class Solution {
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (a, b) => { return a[0] - b[0]; });
        LinkedList<int[]> mergedIntervals = new LinkedList<int[]>();
        
        foreach(int[] interval in intervals){
            if(mergedIntervals.Count == 0 || mergedIntervals.Last.Value[1] < interval[0]){
                mergedIntervals.AddLast(interval);
            } else {
                mergedIntervals.Last.Value[1] = Math.Max(mergedIntervals.Last.Value[1], interval[1]);
            }
        }
        
        return mergedIntervals.ToArray();
    }
}
