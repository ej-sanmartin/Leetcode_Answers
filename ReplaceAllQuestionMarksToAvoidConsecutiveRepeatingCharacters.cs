/*
    Given a string s containing only lower case English letters and the '?' character, convert all the '?' characters 
    into lower case letters such that the final string does not contain any consecutive repeating characters. You 
    cannot modify the non '?' characters.

    It is guaranteed that there are no consecutive repeating characters in the given string except for '?'.

    Return the final string after all the conversions (possibly zero) have been made. If there is more than one 
    solution, return any of them. It can be shown that an answer is always possible with the given constraints.

    T - O(n), where n is the length of the s string passed into the method. Inner for loop is doing 3 constant loops ever
    s - O(n), for when we are creating a new modified string with stringbuilder
*/
public class Solution {
    public string ModifyString(string s) {
        StringBuilder sb = new StringBuilder(s);
        
        for(int i = 0; i < sb.Length; i++){
            if(sb[i] == '?'){
                for(char c = 'a'; c <= 'c'; c++){
                    if(i - 1 >= 0 && sb[i - 1] == c) continue;
                    if(i + 1 < sb.Length && sb[i + 1] == c) continue;
                    sb[i] = c;
                    break;
                }
            }
        }
        
        return sb.ToString();
    }
}
