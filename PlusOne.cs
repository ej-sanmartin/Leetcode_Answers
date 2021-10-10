/*
    Given a non-empty array of decimal digits representing a non-negative integer, 
    increment one to the integer.

    The digits are stored such that the most significant digit is at the head of the 
    list, and each element in the array contains a single digit.

    You may assume the integer does not contain any leading zero, except the number 
    0 itself.

    T - O(n), at worst case we traverse through all of the elements in array
    S - O(n), at worst case (ex nums = [9, 9, 9]), we create a new array to factor
              in the carried number. This new array is the size of the old array
              plus one
*/
public class Solution {
    public int[] PlusOne(int[] digits) {
        for(int i = digits.Length - 1; i >= 0; i--){
            if(digits[i] < 9){
                digits[i]++;
                return digits;
            }
            
            digits[i] = 0;
        }
        
        int[] answer = new int[digits.Length + 1];
        answer[0] = 1;
        return answer;
    }
}

// More verbose
public class Solution {
    public int[] PlusOne(int[] digits) {
        if (digits.Length == 0 || digits == null) {
            return new int[]{1};
        }
        
        int n = digits.Length;
        int carry = -1;
        
        for (int i = digits.Length - 1; i >= 0; i--) {
            if (carry == -1 || carry == 1) {
                int temp = digits[i] + 1;
                carry = temp / 10;
                digits[i] = temp % 10;
            } else {
                break;
            }
        }
        
        if (carry == 1) {
            int[] output = new int[n + 1];
            output[0] = 1;
            return output;
        }
        
        return digits;
    }
}
