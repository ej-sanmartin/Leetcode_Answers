/*
    You are keeping score for a baseball game with strange rules. The game consists of 
    several rounds, where the scores of past rounds may affect future rounds' scores.

    At the beginning of the game, you start with an empty record. You are given a list of 
    strings ops, where ops[i] is the ith operation you must apply to the record and is one 
    of the following:

    An integer x - Record a new score of x.
    "+" - Record a new score that is the sum of the previous two scores. It is guaranteed 
          there will always be two previous scores.
    "D" - Record a new score that is double the previous score. It is guaranteed there will 
          always be a previous score.
    "C" - Invalidate the previous score, removing it from the record. It is guaranteed 
          there will always be a previous score.

    Return the sum of all the scores on the record.

    T - O(n), where n is the length of the ops array. We must do one pass
    S - O(n), where n is the space needed to create stack. At worst, stack can hold all
              values in ops array if all values are just numeric
*/
public class Solution {
    public int CalPoints(string[] ops) {
        Stack<int> stack = new Stack<int>();
        int previousOne, previousTwo, sum, doubled, num, score;
        
        foreach(string s in ops){
            if(int.TryParse(s, out num)) stack.Push(Convert.ToInt32(s));
            else if(s == "+"){
                previousOne = stack.Pop();
                previousTwo = stack.Pop();
                sum = previousOne + previousTwo;
                stack.Push(previousTwo);
                stack.Push(previousOne);
                stack.Push(sum);
            } else if(s == "D"){
                doubled = stack.Peek() * 2;
                stack.Push(doubled);
            } else if(s == "C") stack.Pop();
        }
        
        score = 0;
        while(stack.Count != 0){
            score += stack.Pop();
        }
        
        return score;
    }
}
