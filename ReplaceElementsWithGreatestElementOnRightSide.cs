/*
    Given an array arr, replace every element in that array
    with the greatest element among the elements to its right,
    and replace the last element with -1.

    After doing so, return the array.

    T - O(n), n being the size of the input
    S - O(1), we are making in place change to array
*/
public class Solution {
    public int[] ReplaceElements(int[] arr) {
        int max = -1;
        
        for (int i = arr.Length - 1; i >= 0; i--) {
            int current = arr[i];
            arr[i] = max;
            max = Math.Max(max, current);
        }
        
        return arr;
    }
}
