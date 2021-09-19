/*
    Given an integer rowIndex, return the rowIndexth (0-indexed) row of the Pascal's triangle.

    In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
*/
public class Solution {
    // recursive
    // T - O(k^2), S - O(k), space for latest and previous row
    public IList<int> GetRow(int rowIndex){
        List<int> row = new List<int>();
        row.Add(1);
        return PascalsTriangle(row, 1, rowIndex);
    }
    
    private List<int> PascalsTriangle(List<int> prev, int level, int targetLevel){
        if(level > targetLevel) return prev;
        List<int> currentLevel = new List<int>();
        currentLevel.Add(1);
        for(int i = 0; i < prev.Count; i++){
            int itemOne = prev[i];
            int itemTwo = (i + 1 >= prev.Count) ? 0 : prev[i + 1];
            currentLevel.Add(itemOne + itemTwo);
        }
        return PascalsTriangle(currentLevel, level + 1, targetLevel);
    }
    
    // using math
    // T - O(k), being input.  S = O(k), input space
    public IList<int> GetRow(int rowIndex) {
        List<int> row = new List<int>();
        row.Add(1);
        
        for(int i = 1; i <= rowIndex; i++){
            row.Add((int)((row[row.Count - 1] * (long)(rowIndex - i + 1)) / i));
        }
        
        return row;
    }
}
