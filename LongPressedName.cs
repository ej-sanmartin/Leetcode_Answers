/*
    Your friend is typing his name into a keyboard. Sometimes, when typing a character c, 
    the key might get long pressed, and the character will be typed 1 or more times.

    You examine the typed characters of the keyboard. Return True if it is possible that it 
    was your friends name, with some characters (possibly none) being long pressed.
    
    T - O(n), one pass through input string name
    S - O(1), no additional space dependent on input given
*/
public class Solution {
    public bool IsLongPressedName(string name, string typed) {
        int firstPointer = 0;
        for(int i = 0; i < typed.Length; i++){
            if(firstPointer < name.Length && name[firstPointer] == typed[i]){
                firstPointer++;
            } else if(i == 0 || typed[i] != typed[i - 1]){
                return false;
            }
        }
        return firstPointer == name.Length;
    }
}
