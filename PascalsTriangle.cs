/*
  Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.
  In Pascal's triangle, each number is the sum of the two numbers directly above it.
*/

public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> answer = new List<IList<int>>();
        
        // if numRows is zero, stop the function here
        if(numRows == 0){
            return answer;
        }
        
        // on the top of the triangle, add 1
        answer.Add(new List<int>{1});
        
        // loop as many rows as inputed. Make sure to start i at 1 to keep rows consistent
        for(int i = 1; i < numRows; i++){
            IList<int> row = new List<int>(); // create a List for this iteration, we'll be building it during this loop
            IList<int> previousRow = answer[i - 1]; // create a List referencing the previous row
            
            row.Add(1); // start row with 1 since outer parts of row are 1
            
            // loop for as long as the row size is (this is what i represents), j will be looping through previouslist
            // and adding up values that are directly above the current index of the row list
            for(int j = 1; j < i; j++) {
                row.Add(previousRow[j - 1] + previousRow[j]);
            }
            
            row.Add(1); // end row with 1 since outer parts of row are 1 
            answer.Add(row); // add generated row to answer
        }
        
        return answer;
    }
}
