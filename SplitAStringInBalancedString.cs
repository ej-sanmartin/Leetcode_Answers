/*
  Balanced strings are those who have equal quantity of 'L' and 'R' characters.

  Given a balanced string s split it in the maximum amount of balanced strings.

  Return the maximum amount of splitted balanced strings.
*/

public class Solution {
    public int BalancedStringSplit(string s) {
        int balanceCheck = 0;
        int answer = 0;
        
        for(int i = 0; i < s.Length; i++){
            if(s[i].Equals('R')){
                balanceCheck += 1;
            } else if(s[i].Equals('L')){
                balanceCheck -= 1;
            }
            
            if(balanceCheck == 0){
                answer++;
            }
        }
        
        return answer;
    }
}
