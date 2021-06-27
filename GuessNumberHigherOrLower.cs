/*
    We are playing the Guess Game. The game is as follows:

    I pick a number from 1 to n. You have to guess which number I picked.

    Every time you guess wrong, I will tell you whether the number I picked is 
    higher or lower than your guess.

    You call a pre-defined API int guess(int num), which returns 3 possible results:

    -1: The number I picked is lower than your guess (i.e. pick < num).
    1: The number I picked is higher than your guess (i.e. pick > num).
    0: The number I picked is equal to your guess (i.e. pick == num).
    
    Return the number that I picked
    

    It's a binary search implementation
    
    
    T - O(logn), as we are splitting the search down by half every attempt
    S - O(1), no extra space is created that is dependent on input size
*/

/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is lower than the guess number
 *			      1 if num is higher than the guess number
 *               otherwise return 0
 * int guess(int num);
 */
public class Solution : GuessGame {
    public int GuessNumber(int n) {
        int low = 1;
        int high = n;
        int middle, result;
        while(low <= high){
            middle = low + (high - low) / 2;
            result = guess(middle);
            if(result == 0) return middle;
            else if(result == -1) high = middle - 1;
            else low = middle + 1;
        }
        return -1;
    }
}
