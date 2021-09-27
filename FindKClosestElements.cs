/*
    Given a sorted integer array arr, two integers k and x, return the k closest 
    integers to x in the array. The result should also be sorted in ascending order.

    An integer a is closer to x than an integer b if:

    |a - x| < |b - x|, or
    |a - x| == |b - x| and a < b

    T - O(log(n - k) + k), we search through arr's length - k space logarithmically
                           and created output in k time
    S - O(1), unless we count space to create output, constant time. Counting output,
              space complexity would be k
*/
public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        List<int> output = new List<int>();
        if(arr.Length == 0 || arr == null) return output;
        int low = 0;
        int high = arr.Length - k;
        
        while(low < high){
            int middle = low + ((high - low) / 2);
            int current = arr[middle];
            if(x - current > arr[middle + k] - x){
                low = middle + 1;
            } else {
                high = middle;
            }
        }
        
        while(k-- != 0){
            output.Add(arr[low++]);
        }
        return output;
    }
}
