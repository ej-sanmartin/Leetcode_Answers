/*
  On a plane there are n points with integer coordinates points[i] = [xi, yi]. Your task is to find the
  minimum time in seconds to visit all points.

  You can move according to the next rules:

  In one second always you can either move vertically, horizontally by one unit or diagonally (it means
  to move one unit vertically and one unit horizontally in one second).
  
  You have to visit the points in the same order as they appear in the array.
*/

public class Solution {
    public int MinTimeToVisitAllPoints(int[][] points) {
        int answer = 0;
        
        // diagonal is fastest to travel so do as much as possible; diagonal travel is just traveling up and down, thus abs function
        for(int i = 0; i < points.Length - 1; i++){
            answer += Math.Max(Math.Abs(points[i][0] - points[i + 1][0]), Math.Abs(points[i][1] - points[i + 1][1]));
        }
        
        return answer;
    }
}
