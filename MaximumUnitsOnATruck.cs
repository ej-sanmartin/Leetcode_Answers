/*
    You are assigned to put some amount of boxes onto one truck. You are given a 2D 
    array boxTypes, where boxTypes[i] = [numberOfBoxesi, numberOfUnitsPerBoxi]:

    numberOfBoxesi is the number of boxes of type i.
    numberOfUnitsPerBoxi is the number of units in each box of the type i.

    You are also given an integer truckSize, which is the maximum number of boxes that 
    can be put on the truck. You can choose any boxes to put on the truck as long as the 
    number of boxes does not exceed truckSize.

    Return the maximum total number of units that can be put on the truck.
    
    T - O(nlogn), using LINQ's sorting by group runs a stable quicksort algorithm on boxTypes
    S - O(logn), Quicksort uses up logn recursive call, stack space
*/
public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        int count, size, i;
        count = size = 0;
        int[][] sortedBoxes = (boxTypes.OrderBy(x => x[1])).ToArray<int[]>();
        
        for(i = boxTypes.Length - 1; i >= 0; i--){
            if(size + sortedBoxes[i][0] < truckSize){
                count += sortedBoxes[i][1] * sortedBoxes[i][0];
                size += sortedBoxes[i][0];
            } else {
                count += sortedBoxes[i][1] * (truckSize - size);
                return count;
            }
        }
        
        return count;
    }
}
