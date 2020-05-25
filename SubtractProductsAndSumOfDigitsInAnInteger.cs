/*
  Given an integer number n, return the difference between the product of its digits and the sum of its digits.
*/

public class Solution {
    public int SubtractProductAndSum(int n) {
        // turns int to string and then into an array of char. Array of char then mutated to array of int
        char[] nChar = n.ToString().ToCharArray();
        int[] nIntArray = Array.ConvertAll(nChar, c => (int)Char.GetNumericValue(c));
        
        // initialize variables that will produce final answer
        int product = 0;
        int sum = 0;
        
        // loops through nIntArray to create product of said array
        for(int i = 0; i < nIntArray.Length; i++){
            if(i == 0){ // makes sure first item of array is set as the initial value of product
                product = nIntArray[0];
                continue;
            }
            product *= nIntArray[i]; 
        }
        
        // loops through nIntArray to create sum of said array
        for(int i = 0; i < nIntArray.Length; i++){
            sum += nIntArray[i];
        }
        
        return product - sum;
    }
}
