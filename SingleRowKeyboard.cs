/*
  There is a special keyboard with all keys in a single row.

  Given a string keyboard of length 26 indicating the layout of the keyboard (indexed from 0 to 25).
  Initially, your finger is at index 0. To type a character, you have to move your finger to the
  index of the desired character. The time taken to move your finger from index i to index j is |i - j|.

  You want to type a string word. Write a function to calculate how much time it takes to type it with one finger.

  T - O(n), as we must loop through length of word to find the time it takes to get from one character to another starting from the 0 index of keyboard
  S - O(1), although we are making a dictionary, this dictionary will always be of size 26 since the keyboard will always be of size 26
*/
public class Solution {
    public int CalculateTime(string keyboard, string word) {
        Dictionary<char, int> keyboardMapping = new Dictionary<char, int>();
        
        for(int i = 0; i < keyboard.Length; i++){
            keyboardMapping.Add(keyboard[i], i);
        }
        
        int count, start, end;
        count = start = 0;
        
        foreach(char c in word){
            end = keyboardMapping[c];
            count += Math.Abs(start - end);
            start = end;
        }
        
        return count;
    }
}
