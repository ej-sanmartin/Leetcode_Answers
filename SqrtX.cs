/*
    Given a non-negative integer x, compute and return the square root of x.

    Since the return type is an integer, the decimal digits are truncated, 
    and only the integer part of the result is returned.

    Note: You are not allowed to use any built-in exponent function or 
    operator, such as pow(x, 0.5) or x ** 0.5.

    T - O(logn), n being the input x
    S - O(1), no additional space dependent on input size used
*/
public class Solution {
    public int MySqrt(int x) {
        if(x < 2) return x;
        int left = 2;
        int right = x /2;
        
        while(left <= right){
            int pivot = left + ((right - left) / 2);
            long num = (long) pivot * pivot;
            if(num > x){
                right = pivot - 1;
            } else if(num < x){
                left = pivot + 1;
            } else {
                return pivot;
            }
        }
        
        return right;
    }
}
