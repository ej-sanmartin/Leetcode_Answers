/*
    Implement the myAtoi(string s) function, which converts a string to a 32-bit signed 
    integer (similar to C/C++'s atoi function).

    The algorithm for myAtoi(string s) is as follows:
    Read in and ignore any leading whitespace.

    Check if the next character (if not already at the end of the string) is '-' or '+'. 
    
    Read this character in if it is either. This determines if the final result is 
    negative or positive respectively. Assume the result is positive if neither is 
    present.

    Read in next the characters until the next non-digit charcter or the end of the 
    input is reached. The rest of the string is ignored.

    Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits 
    were read, then the integer is 0. Change the sign as necessary (from step 2).

    If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then clamp 
    the integer so that it remains in the range. Specifically, integers less than -231 
    should be clamped to -231, and integers greater than 231 - 1 should be clamped to 
    231 - 1.


    Return the integer as the final result.

    Note:
    Only the space character ' ' is considered a whitespace character.

    Do not ignore any characters other than the leading whitespace or the rest of the 
    string after the digits.


    T - O(n), n being the input string size where at worst case we go through entirely
    S - O(1), no additional space created besides ints
*/
public class Solution {
    public int MyAtoi(string s) {
        if(s == null || s.Length == 0){
            return 0;
        }
        
        int sign = 1;
        int result = 0;
        int i = 0;
        
        while(i < s.Length && s[i] == ' '){
            i++;
        }
        
        if(i >= s.Length){
            return 0;
        }
        
        if(s[i] == '-' || s[i] == '+'){
            sign = 1 - 2 * (s[i++] == '-' ? 1 : 0);
        }

        while(i < s.Length && s[i] >= '0' && s[i] <= '9'){
            if(IsNearInfinity(result, s[i] - '0')){
                if(sign == 1){
                    return Int32.MaxValue;
                } else {
                    return Int32.MinValue;
                }
            }
            result = result * 10 + (s[i++] - '0');
        }
        
        return result * sign;
    }
    
    public bool IsNearInfinity(int total, int num){
        if(total > Int32.MaxValue / 10 || (total == Int32.MaxValue / 10 && num > 7)){
            return true;
        }
        return false;
    }
}
