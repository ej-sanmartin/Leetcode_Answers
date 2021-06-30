/*
    There is a robot starting at position (0, 0), the origin, on a 2D plane. Given a 
    sequence of its moves, judge if this robot ends up at (0, 0) after it completes its 
    moves.

    The move sequence is represented by a string, and the character moves[i] represents 
    its ith move. Valid moves are R (right), L (left), U (up), and D (down). If the 
    robot returns to the origin after it finishes all of its moves, return true.   
    Otherwise, return false.

    Note: The way that the robot is "facing" is irrelevant. "R" will always make the 
    robot move to the right once, "L" will always make it move left, etc. Also, assume 
    that the magnitude of the robot's movement is the same for each move.

    T - O(n), as we must traverse through all the move commands in the moves string
    S - O(1), we are only ever creating variables to keep track of robot's position
*/
public class Solution {
    public bool JudgeCircle(string moves){
        int x, y;
        x = y = 0;
        foreach(char move in moves){
            if(move == 'U') y++;
            else if(move == 'D') y--;
            else if(move == 'L') x--;
            else if(move == 'R') x++;
        }
        
        return x == 0 && y == 0;
    }
}
