/*
    We have n chips, where the position of the ith chip is position[i].

    We need to move all the chips to the same position. In one step, we can change the position of the ith 
    chip from position[i] to:

    position[i] + 2 or position[i] - 2 with cost = 0.
    position[i] + 1 or position[i] - 1 with cost = 1.
    
    Return the minimum cost needed to move all the chips to the same position.

    T - O(n), as we much traverse through every chip in position array to count even and odd elements
    S - O(1), as we do not create additional space that is dependent on the size of the input
*/
public class Solution {
    public int MinCostToMoveChips(int[] position) {
        int evenCount, oddCount;
        evenCount = oddCount = 0;
        
        foreach(int chip in position){
            if(chip % 2 == 0) evenCount++;
            else oddCount++;
        }
        
        return Math.Min(evenCount, oddCount);
    }
}
