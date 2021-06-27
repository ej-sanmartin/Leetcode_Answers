/*
    Given an integer num, return a string of its base 7 representation.
    
    T - O(log7n)        as we are dividing the input by 7 with every iteration thus 
                        we are cutting the work by 7 every loop
    S - O(1) or O(n)    space depends on what we are considering. No auxillary space
                        is created besides the bool variable. However, if we count
                        the output string we are creating then space would devolve
                        to O(n) to the length of the string
*/
public class Solution {
    public string ConvertToBase7(int num) {
        if(num == 0) return "0";
        
        string s = "";
        bool isNegative = false;
        
        if(num < 0) isNegative = true;

        while(Math.Abs(num) > 0){
            s += Math.Abs(num) % 7;
            num /= 7;
        }
        
        if(isNegative){
            s += "-";
        }
        
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
