/*
    On an infinite plane, a robot initially stands at (0, 0) and faces north. The robot can receive one of three 
    instructions:

    "G": go straight 1 unit;
    "L": turn 90 degrees to the left;
    "R": turn 90 degrees to the right.

    The robot performs the instructions given in order, and repeats them forever.

    Return true if and only if there exists a circle in the plane such that the robot never leaves the circle.

    T - O(n), as we are traversing through every command in the string
    S - O(1), as we are not creaitng any additonal space that depends on the input size
*/
public class Solution {
    public bool IsRobotBounded(string instructions) {
        int robotDegrees = 90;
        int[] robotCoordinates = new int[2]{ 0, 0 };
        
        foreach(char c in instructions){
            if(c == 'G'){
                robotCoordinates = MoveRobot(robotCoordinates, robotDegrees);
            } else if(c == 'L'){
                robotDegrees = (robotDegrees + 90) % 360;
            } else if(c == 'R'){
                robotDegrees = (robotDegrees - 90) % 360;
            }
        }
        
        return (robotCoordinates[0] == 0 && robotCoordinates[1] == 0) || (robotDegrees != 90 && robotDegrees != -270);
    }
    
    private int[] MoveRobot(int[] coordinates, int degrees){
        switch(degrees){
            case 0:
                coordinates[0]++;
                return coordinates;
            case 90:
                coordinates[1]++;
                return coordinates;
            case 180:
                coordinates[0]--;
                return coordinates;
            case 270:
                coordinates[1]--;
                return coordinates;
            case -90:
                coordinates[1]--;
                return coordinates;
            case -180:
                coordinates[0]--;
                return coordinates;
            case -270:
                coordinates[1]++;
                return coordinates;
        }
        return coordinates;
    }
}
