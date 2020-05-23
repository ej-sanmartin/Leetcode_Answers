/*
  Given a non-negative integer num, return the number of steps to reduce it to zero.
  If the current number is even, you have to divide it by 2, otherwise, you have to subtract 1 from it.
*/

public class Solution {
    public int NumberOfSteps (int num) {
        int steps = 0;
        while(num > 0) {
            switch(num % 2){
                case 0:
                   steps++;
                    num = num / 2;
                   break;
                case 1:
                    steps++;
                    num--;
                    break;
            }
        }   
        return steps;
    }
}
