/*
    Given an array of integers arr, return true if and only if it is a valid mountain array.

    Recall that arr is a mountain array if and only if:


    arr.length >= 3
    There exists some i with 0 < i < arr.length - 1 such that:
        arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
        arr[i] > arr[i + 1] > ... > arr[arr.length - 1]

    T - O(n), we must go through all elements in array once
    S - O(1), we are only creating a single variable to simulate
              a person walking through this "mountain" and making
              sure they can make it to the end of the array mountain
*/
public class Solution {
    public bool ValidMountainArray(int[] arr) {
        if (arr.Length == 0 || arr == null) {
            return false;
        }
        
        int i = 0;
        
        while (i + 1 < arr.Length && arr[i] < arr[i + 1]) {
            i++;
        }
        
        if (i == 0 || i == arr.Length - 1) {
            return false;
        }
        
        while(i + 1 < arr.Length && arr[i] > arr[i + 1]) {
            i++;
        }
        
        return i == arr.Length - 1;
    }
}
