/*
  Given a fixed length array arr of integers, duplicate each occurrence of zero, shifting the remaining elements to the right.

  Note that elements beyond the length of the original array are not written.

  Do the above modifications to the input array in place, do not return anything from your function.
  
  T - O(n^2), at worst case, where every item in the array is 0, then we must do n number of shifts for every item in the array
              Keep in mind that a shift operation, specified by the inner for loop, is a linear operation as we must shift all elements
              up from the i index until the end of the array
  S - O(1), no additional space needed or created for in place array function
*/
public class Solution {
    public void DuplicateZeros(int[] arr) {
        for(int i = 0; i < arr.Length; i++){
            if(arr[i] == 0){
                for(int j = arr.Length - 1; j > i + 1; j--){
                    arr[j] = arr[j - 1];
                }
                if(i + 1 < arr.Length) arr[i + 1] = 0;
                i++;
            }
        }
    }
}
