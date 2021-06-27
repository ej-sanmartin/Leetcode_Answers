/*
    Given an integer n, return true if it is a power of three. Otherwise, return 
    false.

    An integer n is a power of three, if there exists an integer x such that n == 
    3x.

    T - O(log3n), since we are dividing input by 3 with every iteration, does
                  removing the amount of work we have to do by a factor of 3
    S - O(1), since we are not creating any additional space to solve this algorithm
*/
public class Solution {
    public bool IsPowerOfThree(int n) {
        if(n < 1) return false;
        
        while(n != 1){
            if(n % 3 != 0) return false;
            n /= 3;
        }
        
        return true;
    }
}
