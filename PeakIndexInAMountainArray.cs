/*
    Let's call an array arr a mountain if the following properties hold:

    arr.length >= 3
    There exists some i with 0 < i < arr.length - 1 such that:
        arr[0] < arr[1] < ... arr[i-1] < arr[i]
        arr[i] > arr[i+1] > ... > arr[arr.length - 1]

    Given an integer array arr that is guaranteed to be a mountain, return any i such 
    that arr[0] < arr[1] < ... arr[i - 1] < arr[i] > arr[i + 1] > ... > arr[arr.length - 
    1].

    T - O(n),       at worst must traverse through the entire length of the arr mountain.
                    Since a peak is guaranteed, do not need i to be at last index
    T - O(logn),    using binary search, we are cutting out search in half each loop until
                    we find our peak
    S - O(1),       no additonal space was created/ used for both implementations
*/
public class Solution {
    // linear solution
    public int PeakIndexInMountainArray(int[] arr) {
        for(int i = 1; i < arr.Length - 1; i++){
            if(arr[i] > arr[i-1] && arr[i] > arr[i + 1]) return i;
        }
        
        return -1;
    }
    
    // binary search solution
    public int PeakIndexInMountainArray(int[] arr){
        int low, mid, high;
        low = 0;
        high = arr.Length - 1;
        while(low < high){
            mid = (low + high) / 2;
            if(arr[mid] > arr[mid - 1] && arr[mid] > arr[mid + 1]) return mid;
            else if(arr[mid] < arr[mid - 1]) high = mid;
            else if(arr[mid] < arr[mid + 1]) low = mid;
        }
        
        return -1;
    }
