/*
  You own a Goal Parser that can interpret a string command. The command consists
  of an alphabet of "G", "()" and/or "(al)" in some order. The Goal Parser will
  interpret "G" as the string "G", "()" as the string "o", and "(al)" as the
  string "al". The interpreted strings are then concatenated in the original order.

  Given the string command, return the Goal Parser's interpretation of command.

  T - O(n), since we have to loop through the lend of the command string
  S - O(n), because we have to build a new string that is equal to the amount of different codes/ alphabets combinations in the command
*/
public class Solution {
    public string Interpret(string command) {
        StringBuilder sb = new StringBuilder();
        
        for(int i = 0; i < command.Length; i++){
            if(command[i] == 'G'){
                sb.Append("G");
            } else if(command[i] == '(' && command[i + 1] == ')'){
                sb.Append("o");
                i++;
            } else if(command[i] == '(' && command[i + 1] == 'a'){
                sb.Append("al");
                i += 3;
            }
        }
        
        return sb.ToString();
    }
}
